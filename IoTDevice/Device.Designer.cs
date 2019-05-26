namespace IoTDevice
{
    partial class Device
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
            this.tabPager = new System.Windows.Forms.TabControl();
            this.devicePage = new System.Windows.Forms.TabPage();
            this.btnToRegister = new System.Windows.Forms.Button();
            this.rtxtDeviceOutput = new System.Windows.Forms.RichTextBox();
            this.cboxDevices = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.registerPage = new System.Windows.Forms.TabPage();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.tboxDeviceName = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnDoneRegister = new System.Windows.Forms.Button();
            this.tabPager.SuspendLayout();
            this.devicePage.SuspendLayout();
            this.registerPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPager
            // 
            this.tabPager.Controls.Add(this.devicePage);
            this.tabPager.Controls.Add(this.registerPage);
            this.tabPager.Location = new System.Drawing.Point(12, 12);
            this.tabPager.Name = "tabPager";
            this.tabPager.SelectedIndex = 0;
            this.tabPager.Size = new System.Drawing.Size(308, 468);
            this.tabPager.TabIndex = 4;
            // 
            // devicePage
            // 
            this.devicePage.Controls.Add(this.btnToRegister);
            this.devicePage.Controls.Add(this.rtxtDeviceOutput);
            this.devicePage.Controls.Add(this.cboxDevices);
            this.devicePage.Controls.Add(this.btnStop);
            this.devicePage.Controls.Add(this.btnStart);
            this.devicePage.Location = new System.Drawing.Point(4, 22);
            this.devicePage.Name = "devicePage";
            this.devicePage.Padding = new System.Windows.Forms.Padding(3);
            this.devicePage.Size = new System.Drawing.Size(300, 442);
            this.devicePage.TabIndex = 0;
            this.devicePage.Text = "Device";
            this.devicePage.UseVisualStyleBackColor = true;
            // 
            // btnToRegister
            // 
            this.btnToRegister.Location = new System.Drawing.Point(110, 414);
            this.btnToRegister.Name = "btnToRegister";
            this.btnToRegister.Size = new System.Drawing.Size(75, 23);
            this.btnToRegister.TabIndex = 5;
            this.btnToRegister.Text = "Add Device";
            this.btnToRegister.UseVisualStyleBackColor = true;
            this.btnToRegister.Click += new System.EventHandler(this.BtnToRegister_Click);
            // 
            // rtxtDeviceOutput
            // 
            this.rtxtDeviceOutput.Location = new System.Drawing.Point(6, 64);
            this.rtxtDeviceOutput.Name = "rtxtDeviceOutput";
            this.rtxtDeviceOutput.ReadOnly = true;
            this.rtxtDeviceOutput.Size = new System.Drawing.Size(280, 344);
            this.rtxtDeviceOutput.TabIndex = 7;
            this.rtxtDeviceOutput.Text = "";
            // 
            // cboxDevices
            // 
            this.cboxDevices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboxDevices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxDevices.Items.AddRange(new object[] {
            "IoT Device 01"});
            this.cboxDevices.Location = new System.Drawing.Point(6, 8);
            this.cboxDevices.Name = "cboxDevices";
            this.cboxDevices.Size = new System.Drawing.Size(280, 21);
            this.cboxDevices.TabIndex = 4;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(211, 35);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop Device";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 35);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start Device";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // registerPage
            // 
            this.registerPage.Controls.Add(this.btnDoneRegister);
            this.registerPage.Controls.Add(this.lblDeviceName);
            this.registerPage.Controls.Add(this.tboxDeviceName);
            this.registerPage.Controls.Add(this.btnRegister);
            this.registerPage.Location = new System.Drawing.Point(4, 22);
            this.registerPage.Name = "registerPage";
            this.registerPage.Padding = new System.Windows.Forms.Padding(3);
            this.registerPage.Size = new System.Drawing.Size(300, 442);
            this.registerPage.TabIndex = 1;
            this.registerPage.Text = "Register Device";
            this.registerPage.UseVisualStyleBackColor = true;
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(6, 14);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(72, 13);
            this.lblDeviceName.TabIndex = 2;
            this.lblDeviceName.Text = "Device Name";
            // 
            // tboxDeviceName
            // 
            this.tboxDeviceName.Location = new System.Drawing.Point(9, 30);
            this.tboxDeviceName.Name = "tboxDeviceName";
            this.tboxDeviceName.Size = new System.Drawing.Size(285, 20);
            this.tboxDeviceName.TabIndex = 1;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(9, 56);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnDoneRegister
            // 
            this.btnDoneRegister.Location = new System.Drawing.Point(9, 413);
            this.btnDoneRegister.Name = "btnDoneRegister";
            this.btnDoneRegister.Size = new System.Drawing.Size(75, 23);
            this.btnDoneRegister.TabIndex = 3;
            this.btnDoneRegister.Text = "Done";
            this.btnDoneRegister.UseVisualStyleBackColor = true;
            this.btnDoneRegister.Click += new System.EventHandler(this.BtnDoneRegister_Click);
            // 
            // Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 488);
            this.Controls.Add(this.tabPager);
            this.Name = "Device";
            this.Text = "Device";
            this.tabPager.ResumeLayout(false);
            this.devicePage.ResumeLayout(false);
            this.registerPage.ResumeLayout(false);
            this.registerPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPager;
        private System.Windows.Forms.TabPage devicePage;
        private System.Windows.Forms.RichTextBox rtxtDeviceOutput;
        private System.Windows.Forms.ComboBox cboxDevices;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabPage registerPage;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.TextBox tboxDeviceName;
        private System.Windows.Forms.Button btnToRegister;
        private System.Windows.Forms.Button btnDoneRegister;
    }
}

