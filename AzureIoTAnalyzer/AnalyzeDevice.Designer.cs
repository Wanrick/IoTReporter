namespace AzureIoTAnalyzer
{
    partial class AnalyzeDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadDevices = new System.Windows.Forms.Button();
            this.cboxDevices = new System.Windows.Forms.ComboBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbAnalysis = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.btnGetData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.opfDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadDevices
            // 
            this.btnLoadDevices.Location = new System.Drawing.Point(13, 34);
            this.btnLoadDevices.Name = "btnLoadDevices";
            this.btnLoadDevices.Size = new System.Drawing.Size(88, 23);
            this.btnLoadDevices.TabIndex = 0;
            this.btnLoadDevices.Text = "Load Devices";
            this.btnLoadDevices.UseVisualStyleBackColor = true;
            this.btnLoadDevices.Click += new System.EventHandler(this.BtnLoadDevices_Click);
            // 
            // cboxDevices
            // 
            this.cboxDevices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboxDevices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDevices.Enabled = false;
            this.cboxDevices.Items.AddRange(new object[] {
            "IoT Device 01"});
            this.cboxDevices.Location = new System.Drawing.Point(107, 36);
            this.cboxDevices.Name = "cboxDevices";
            this.cboxDevices.Size = new System.Drawing.Size(280, 21);
            this.cboxDevices.TabIndex = 5;
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(94, 113);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 20);
            this.dateFrom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select device to analyze";
            // 
            // rtbAnalysis
            // 
            this.rtbAnalysis.Location = new System.Drawing.Point(3, 1);
            this.rtbAnalysis.Name = "rtbAnalysis";
            this.rtbAnalysis.Size = new System.Drawing.Size(500, 212);
            this.rtbAnalysis.TabIndex = 8;
            this.rtbAnalysis.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select time range to analyze";
            // 
            // From
            // 
            this.From.AutoSize = true;
            this.From.Location = new System.Drawing.Point(13, 119);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(30, 13);
            this.From.TabIndex = 10;
            this.From.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "To";
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(94, 139);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 20);
            this.dateTo.TabIndex = 11;
            // 
            // btnGetData
            // 
            this.btnGetData.Enabled = false;
            this.btnGetData.Location = new System.Drawing.Point(299, 179);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 13;
            this.btnGetData.Text = "Analyze";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLoadDevices);
            this.panel1.Controls.Add(this.btnGetData);
            this.panel1.Controls.Add(this.cboxDevices);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.From);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 216);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.rtbAnalysis);
            this.panel2.Location = new System.Drawing.Point(408, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 216);
            this.panel2.TabIndex = 15;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(509, 179);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // opfDialog
            // 
            this.opfDialog.FileName = "OpenDevice";
            // 
            // AnalyzeDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 240);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AnalyzeDevice";
            this.Text = "AnalyzeDevice";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDevices;
        private System.Windows.Forms.ComboBox cboxDevices;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbAnalysis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label From;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.OpenFileDialog opfDialog;
    }
}