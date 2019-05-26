using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IoTDevice;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Azure.Devices;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureIoTAnalyzer
{
    public partial class AnalyzeDevice : Form
    {
        private delegate void SafeCallDelegate(string text);
        private static readonly string s_eventHubsCompatibleEndpoint = "Endpoint=sb://ihsuprodbyres028dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=jbil7wIH6u/FX8LXgCuSdsZqVWsDM8jpd3szxFi8C8I=;EntityPath=iothub-ehub-forensics-1638385-9adfc3e047";
        private static readonly string s_eventHubsCompatiblePath = "iothub-ehub-forensics-1638385-9adfc3e047";
        private static readonly string s_iotHubSasKey = "jbil7wIH6u/FX8LXgCuSdsZqVWsDM8jpd3szxFi8C8I=";
        private static readonly string s_iotHubSasKeyName = "iothubowner";
        private static EventHubClient s_eventHubClient;
        static string _iotConnectionString = "HostName=Forensics.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=jbil7wIH6u/FX8LXgCuSdsZqVWsDM8jpd3szxFi8C8I=";
        private static RegistryManager _registryManager;
        private ReportData report;
        
        private class ReportData
        {
            public DateTime FromDateTime { get; set; }
            public DateTime ToDateTime { get; set; }
            public String deviceName { get; set; }
            public String deviceKey { get; set; }
            public String twin { get; set; }
            public List<String> messageList;

            public ReportData()
            {
                messageList = new List<string>();
            }
        }

        public AnalyzeDevice()
        {
            InitializeComponent();
            report = new ReportData();
        }

        private void BtnLoadDevices_Click(object sender, EventArgs e)
        {
            if (opfDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cboxDevices.Items.Clear();
                    if (!File.Exists(opfDialog.FileName))
                    {
                        return;
                    }
                    try
                    {
                        using (var sr = new StreamReader(opfDialog.FileName))
                        {
                            while (sr.Peek() >= 0)
                            {
                                var line = sr.ReadLine();
                                var readDevice = new DeviceObject()
                                {
                                    DeviceName = line.Split(':')[0],
                                    DeviceKey = line.Split(':')[1]
                                };
                                cboxDevices.Items.Add(readDevice);
                                report.deviceKey = readDevice.DeviceKey;
                                report.deviceName = readDevice.DeviceName;
                            }

                            cboxDevices.Enabled = true;
                            btnGetData.Enabled = true;
                        }
                    }
                    catch (IOException exception)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(exception.Message);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void BtnGetData_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = dateFrom.Value;
            DateTime endDateTime = dateTo.Value;
            report.FromDateTime = startDateTime;
            report.ToDateTime = endDateTime;
            var dev = (DeviceObject) cboxDevices.SelectedItem;
            Task.Run(async() => await KickOffListener(startDateTime, endDateTime, dev));
        }

        private async Task KickOffListener(DateTime @from, DateTime To, DeviceObject device)
        {
            var connectionString = new EventHubsConnectionStringBuilder("Endpoint=sb://ihsuprodbyres028dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=jbil7wIH6u/FX8LXgCuSdsZqVWsDM8jpd3szxFi8C8I=;EntityPath=iothub-ehub-forensics-1638385-9adfc3e047");  //(new Uri(s_eventHubsCompatibleEndpoint), s_eventHubsCompatiblePath, s_iotHubSasKeyName, s_iotHubSasKey);
            s_eventHubClient = EventHubClient.CreateFromConnectionString(connectionString.ToString());
            var runtimeInfo = await s_eventHubClient.GetRuntimeInformationAsync();
            var d2cPartitions = runtimeInfo.PartitionIds;
            _registryManager = RegistryManager.CreateFromConnectionString(_iotConnectionString);
            var twin = await _registryManager.GetTwinAsync(device.DeviceName);
            report.twin = twin.ToJson();
            SafelyWriteTo(twin.ToJson());

            CancellationTokenSource cts = new CancellationTokenSource();

            //cts.Cancel();

            var tasks = new List<Task>();
            foreach (string partition in d2cPartitions)
            {
                tasks.Add(ReceiveMessagesFromDeviceAsync(partition, cts.Token, from, To));
            }
            Task.WaitAll(tasks.ToArray());
        }

        private void SafelyWriteTo(string text)
        {
            if (rtbAnalysis.InvokeRequired)
            {
                var d = new SafeCallDelegate(SafelyWriteTo);
                Invoke(d, new object[] { text });
            }
            else
            {
                rtbAnalysis.Text += JToken.Parse(text).ToString(Formatting.Indented) + Environment.NewLine + Environment.NewLine;
                rtbAnalysis.SelectionStart = rtbAnalysis.TextLength;
                rtbAnalysis.ScrollToCaret();
            }
        }

        private async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct, DateTime fromDateTime, DateTime toDateTime)
        {
            var eventHubReceiver = s_eventHubClient.CreateReceiver("$Default", partition, EventPosition.FromEnqueuedTime(fromDateTime));
            bool fetchUntil = true;
            while (fetchUntil)
            {
                if (ct.IsCancellationRequested) break;
                var events = await eventHubReceiver.ReceiveAsync(100);
                if (events == null) continue;

                foreach (EventData eventData in events)
                {
                    if (eventData.SystemProperties.EnqueuedTimeUtc.CompareTo(toDateTime) > 0)
                    {
                        fetchUntil = false;
                    }
                    else
                    {
                        string data = Encoding.UTF8.GetString(eventData.Body.Array);

                        report.messageList.Add(data);
                        SafelyWriteTo(data);
                    }
                }
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            using(System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())   
            {  
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);  
  
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Path.Combine(Directory.GetCurrentDirectory(), @"report.pdf"), FileMode.Create));  
                document.Open();  
  
                Paragraph twinChunk = new Paragraph("The device twin for " + report.deviceName);
                twinChunk.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f, BaseColor.BLACK);
                document.Add(twinChunk);  
  
                Paragraph twinPara = new Paragraph(JToken.Parse(report.twin).ToString(Formatting.Indented) + Environment.NewLine + Environment.NewLine);
                twinPara.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
                document.Add(twinPara);
                Paragraph twinParaHash = new Paragraph("Hash of device twin: " + ComputeSha256Hash(report.twin) + Environment.NewLine + Environment.NewLine);
                twinParaHash.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
                document.Add(twinParaHash);

                Console.WriteLine(report.twin);

                Paragraph chunk = new Paragraph("The messages for " + report.deviceName + " between " + report.FromDateTime + " and " + report.ToDateTime);  
                chunk.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f, BaseColor.BLACK);
                document.Add(chunk);  

                foreach (var message in report.messageList)
                {
                    Paragraph para = new Paragraph(JToken.Parse(message).ToString(Formatting.Indented) + Environment.NewLine + Environment.NewLine);
                    para.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
                    document.Add(para);

                    Paragraph paraHash = new Paragraph("Message hash: " + ComputeSha256Hash(message) + Environment.NewLine + Environment.NewLine);
                    paraHash.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
                    document.Add(paraHash);
                }
  
                document.Close();
            }  
        }

        private string ComputeSha256Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }
    }
}
