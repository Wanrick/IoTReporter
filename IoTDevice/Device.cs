using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;
using Message = Microsoft.Azure.Devices.Client.Message;
using TransportType = Microsoft.Azure.Devices.Client.TransportType;

namespace IoTDevice
{
    public partial class Device : Form
    {
        static DeviceClient _deviceClient = null;
        static string _iotHubUri = "Forensics.azure-devices.net";
        static string _iotConnectionString = "HostName=Forensics.azure-devices.net;SharedAccessKeyName=registryReadWrite;SharedAccessKey=/H0Yf4aw7Zg/RB3dTAPFDNBk0Te1F3Jl3TCZnuGBhg4=";
        static RegistryManager _registryManager;
        static bool _running = false;

        string _docPath = "../../data/devices.txt";

        public Device()
        {
            InitializeComponent();
            tabPager.Appearance = TabAppearance.FlatButtons;
            tabPager.ItemSize = new Size(0, 1);
            tabPager.SizeMode = TabSizeMode.Fixed;
            _registryManager = RegistryManager.CreateFromConnectionString(_iotConnectionString);
            ReadDevicesFromFile();
        }

        private void ReadDevicesFromFile()
        {
            cboxDevices.Items.Clear();
            if (!File.Exists(_docPath))
            {
                return;
            }
            try
            {
                using (var sr = new StreamReader(_docPath))
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
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private async void SendDeviceToCloudMessagesAsync(DeviceObject deviceObj)
        {
            double minTemperature = 10;
            double minHumidity = 60;
            var rand = new Random();
            var messageBuilder = new StringBuilder();
            while (_running)
            {
                var currentTemperature = minTemperature + rand.NextDouble() * 10;
                var currentHumidity = minHumidity + rand.NextDouble() * 20;

                var telemetryDataPoint = new
                {
                    messageId = Guid.NewGuid(),
                    deviceId = deviceObj.DeviceName + ":" + deviceObj.DeviceKey,
                    temperature = currentTemperature,
                    humidity = currentHumidity
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));
                message.Properties.Add("temperatureAlert", (currentTemperature > 20) ? "true" : "false");

                await _deviceClient.SendEventAsync(message);
                
                messageBuilder.Append($"{DateTime.Now} > Sending message: {messageString}");
                messageBuilder.AppendLine();

                rtxtDeviceOutput.Text = messageBuilder.ToString();
                rtxtDeviceOutput.ScrollToCaret();
                await Task.Delay(1000);
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _running = false;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (tboxDeviceName.Text.Length > 0)
            {
                AddDeviceAsync(tboxDeviceName.Text);

            }
        }

        private async Task AddDeviceAsync(string deviceId)
        {
            Microsoft.Azure.Devices.Device device = null;
            try
            {
                device = await _registryManager.AddDeviceAsync(new Microsoft.Azure.Devices.Device(deviceId));
                SaveDeviceToFile($"{deviceId}:{device.Authentication.SymmetricKey.PrimaryKey}");
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await _registryManager.GetDeviceAsync(deviceId);
                SaveDeviceToFile($"{deviceId}:{device.Authentication.SymmetricKey.PrimaryKey}");
            }
        }

        private void SaveDeviceToFile(String device)
        {
            using (var outputFile = new StreamWriter(_docPath, true))
            {
                outputFile.WriteLine(device);
            }
        }

        private void BtnToRegister_Click(object sender, EventArgs e)
        {
            tabPager.SelectedIndex = 1;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (cboxDevices.SelectedIndex >= 0)
            {
                var deviceObj = (DeviceObject)cboxDevices.SelectedItem;
                _running = true;
                _deviceClient = DeviceClient.Create(_iotHubUri,
                    new DeviceAuthenticationWithRegistrySymmetricKey(deviceObj.DeviceName, deviceObj.DeviceKey), TransportType.Mqtt);

                SendDeviceToCloudMessagesAsync(deviceObj);
            }
        }

        private void BtnDoneRegister_Click(object sender, EventArgs e)
        {
            tabPager.SelectedIndex = 0;
        }
    }
}