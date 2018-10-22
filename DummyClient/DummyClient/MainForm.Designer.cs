namespace DummyClient
{
    partial class MainForm
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.TextBoxIP = new System.Windows.Forms.TextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.TextBoxPort = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.TextBoxUser = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.LabelConnected = new System.Windows.Forms.Label();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.LabelTestText = new System.Windows.Forms.Label();
            this.LabelInterval = new System.Windows.Forms.Label();
            this.TextBoxInterval = new System.Windows.Forms.TextBox();
            this.LabelRange = new System.Windows.Forms.Label();
            this.TextBoxMin = new System.Windows.Forms.TextBox();
            this.LabelRange2 = new System.Windows.Forms.Label();
            this.TextBoxMax = new System.Windows.Forms.TextBox();
            this.TestConnectBtn = new System.Windows.Forms.Button();
            this.TextBoxSend = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.ListBoxLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            //
            // GroupBox1
            //
            this.GroupBox1.Controls.Add(this.IPLabel);
            this.GroupBox1.Controls.Add(this.TextBoxIP);
            this.GroupBox1.Controls.Add(this.PortLabel);
            this.GroupBox1.Controls.Add(this.TextBoxPort);
            this.GroupBox1.Controls.Add(this.UserLabel);
            this.GroupBox1.Controls.Add(this.TextBoxUser);
            this.GroupBox1.Location = new System.Drawing.Point(14, 15);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox1.Size = new System.Drawing.Size(566, 65);
            this.GroupBox1.TabIndex = 27;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "더미 클라이언트 설정";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(7, 30);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(70, 25);
            this.IPLabel.TabIndex = 10;
            this.IPLabel.Text = "IP Address:";
            // 
            // textBoxIP
            // 
            this.TextBoxIP.Location = new System.Drawing.Point(90, 25);
            this.TextBoxIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxIP.MaxLength = 15;
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Size = new System.Drawing.Size(100, 25);
            this.TextBoxIP.TabIndex = 11;
            this.TextBoxIP.Text = "127.0.0.1";
            this.TextBoxIP.WordWrap = false;
            this.TextBoxIP.TextChanged += new System.EventHandler(this.TextBoxIP_TextChanged);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(205, 30);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(90, 25);
            this.PortLabel.TabIndex = 17;
            this.PortLabel.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.TextBoxPort.Location = new System.Drawing.Point(240, 25);
            this.TextBoxPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxPort.MaxLength = 5;
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(50, 25);
            this.TextBoxPort.TabIndex = 18;
            this.TextBoxPort.Text = "0";
            this.TextBoxPort.WordWrap = false;
            this.TextBoxPort.TextChanged += new System.EventHandler(this.TextBoxPort_TextChanged);
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(310, 30);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(70, 25);
            this.UserLabel.TabIndex = 53;
            this.UserLabel.Text = "Client Num:";
            // 
            // textBoxUser
            // 
            this.TextBoxUser.Location = new System.Drawing.Point(395, 25);
            this.TextBoxUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxUser.MaxLength = 15;
            this.TextBoxUser.Name = "TextBoxUser";
            this.TextBoxUser.Size = new System.Drawing.Size(50, 25);
            this.TextBoxUser.TabIndex = 54;
            this.TextBoxUser.Text = "1000";
            this.TextBoxUser.WordWrap = false;
            this.TextBoxUser.TextChanged += new System.EventHandler(this.TextBoxUser_TextChanged);
            //
            // ConnectBtn
            //
            this.ConnectBtn.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ConnectBtn.Location = new System.Drawing.Point(481, 35);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(93, 38);
            this.ConnectBtn.TabIndex = 28;
            this.ConnectBtn.Text = "접속 요청";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.OnConnectBtn);
            // 
            // LabelConnected
            // 
            this.LabelConnected.AutoSize = true;
            this.LabelConnected.Location = new System.Drawing.Point(10, 103);
            this.LabelConnected.Name = "LabelConnected";
            this.LabelConnected.Size = new System.Drawing.Size(241, 38);
            this.LabelConnected.TabIndex = 40;
            this.LabelConnected.Text = "접속 클라이언트 수 : ";
            //
            // DisconnectBtn
            //
            this.DisconnectBtn.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DisconnectBtn.Location = new System.Drawing.Point(481, 95);
            this.DisconnectBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(98, 38);
            this.DisconnectBtn.TabIndex = 29;
            this.DisconnectBtn.Text = "접속 해제";
            this.DisconnectBtn.UseVisualStyleBackColor = true;
            this.DisconnectBtn.Click += new System.EventHandler(this.OnDisconnectBtn);
            //
            // GroupBox2
            //
            this.GroupBox2.Location = new System.Drawing.Point(14, 141);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox2.Size = new System.Drawing.Size(571, 115);
            this.GroupBox2.TabIndex = 49;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Connection Test";
            // 
            // LabelTestText
            // 
            this.LabelTestText.AutoSize = true;
            this.LabelTestText.Location = new System.Drawing.Point(22, 175);
            this.LabelTestText.Name = "LabelTestText";
            this.LabelTestText.Size = new System.Drawing.Size(280, 38);
            this.LabelTestText.TabIndex = 46;
            this.LabelTestText.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelTestText.Text = "Interval(ms)마다 범위 내 클라이언트의 접속과 해제를 반복합니다.";
            // 
            // LabelInterval
            // 
            this.LabelInterval.AutoSize = true;
            this.LabelInterval.Location = new System.Drawing.Point(22, 219);
            this.LabelInterval.Name = "LabelInterval";
            this.LabelInterval.Size = new System.Drawing.Size(90, 38);
            this.LabelInterval.TabIndex = 51;
            this.LabelInterval.Text = "Interval:";
            // 
            // textBoxInterval
            // 
            this.TextBoxInterval.Location = new System.Drawing.Point(87, 211);
            this.TextBoxInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxInterval.MaxLength = 5;
            this.TextBoxInterval.Name = "TextBoxInterval";
            this.TextBoxInterval.Size = new System.Drawing.Size(40, 25);
            this.TextBoxInterval.TabIndex = 52;
            this.TextBoxInterval.Text = "10";
            this.TextBoxInterval.WordWrap = false;
            this.TextBoxInterval.TextChanged += new System.EventHandler(this.TextBoxInterval_TextChanged);
            // 
            // LabelRange
            // 
            this.LabelRange.AutoSize = true;
            this.LabelRange.Location = new System.Drawing.Point(150, 219);
            this.LabelRange.Name = "LabelRange";
            this.LabelRange.Size = new System.Drawing.Size(90, 38);
            this.LabelRange.TabIndex = 55;
            this.LabelRange.Text = "클라이언트 수 범위:";
            // 
            // textBoxMin
            // 
            this.TextBoxMin.Location = new System.Drawing.Point(290, 211);
            this.TextBoxMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxMin.MaxLength = 5;
            this.TextBoxMin.Name = "TextBoxInterval";
            this.TextBoxMin.Size = new System.Drawing.Size(40, 25);
            this.TextBoxMin.TabIndex = 56;
            this.TextBoxMin.Text = "500";
            this.TextBoxMin.WordWrap = false;
            this.TextBoxMin.TextChanged += new System.EventHandler(this.TextBoxMin_TextChanged);
            // 
            // textBoxMax
            // 
            this.TextBoxMax.Location = new System.Drawing.Point(380, 211);
            this.TextBoxMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxMax.MaxLength = 5;
            this.TextBoxMax.Name = "TextBoxInterval";
            this.TextBoxMax.Size = new System.Drawing.Size(40, 25);
            this.TextBoxMax.TabIndex = 57;
            this.TextBoxMax.Text = "800";
            this.TextBoxMax.WordWrap = false;
            this.TextBoxMax.TextChanged += new System.EventHandler(this.TextBoxMax_TextChanged);
            // 
            // LabelRange2
            // 
            this.LabelRange2.AutoSize = true;
            this.LabelRange2.Location = new System.Drawing.Point(350, 219);
            this.LabelRange2.Name = "LabelRange2";
            this.LabelRange2.Size = new System.Drawing.Size(90, 38);
            this.LabelRange2.TabIndex = 58;
            this.LabelRange2.Text = "~";
            //
            // TestConnectBtn
            //
            this.TestConnectBtn.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TestConnectBtn.Location = new System.Drawing.Point(481, 205);
            this.TestConnectBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TestConnectBtn.Name = "TestConnectBtn";
            this.TestConnectBtn.Size = new System.Drawing.Size(98, 38);
            this.TestConnectBtn.TabIndex = 47;
            this.TestConnectBtn.Text = "접속 테스트";
            this.TestConnectBtn.UseVisualStyleBackColor = true;
            this.TestConnectBtn.Click += new System.EventHandler(this.OnTestConnectBtn);
            // 
            // TextBoxSend
            // 
            this.TextBoxSend.Location = new System.Drawing.Point(14, 270);
            this.TextBoxSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxSend.MaxLength = 32;
            this.TextBoxSend.Name = "TextBoxSend";
            this.TextBoxSend.Size = new System.Drawing.Size(460, 38);
            this.TextBoxSend.TabIndex = 38;
            this.TextBoxSend.Text = "";
            this.TextBoxSend.WordWrap = false;
            // 
            // SendBtn
            // 
            this.SendBtn.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SendBtn.Location = new System.Drawing.Point(481, 265);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(98, 38);
            this.SendBtn.TabIndex = 39;
            this.SendBtn.Text = "Send Msg";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.OnSendBtn);
            // 
            // ListBoxLog
            // 
            this.ListBoxLog.FormattingEnabled = true;
            this.ListBoxLog.HorizontalScrollbar = true;
            this.ListBoxLog.ItemHeight = 15;
            this.ListBoxLog.Location = new System.Drawing.Point(14, 310);
            this.ListBoxLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListBoxLog.Name = "listBoxLog";
            this.ListBoxLog.Size = new System.Drawing.Size(564, 240);
            this.ListBoxLog.TabIndex = 41;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 560);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.LabelConnected);
            this.Controls.Add(this.LabelTestText);
            this.Controls.Add(this.LabelInterval);
            this.Controls.Add(this.TextBoxInterval);
            this.Controls.Add(this.LabelRange);
            this.Controls.Add(this.TextBoxMin);
            this.Controls.Add(this.TextBoxMax);
            this.Controls.Add(this.LabelRange2);
            this.Controls.Add(this.TestConnectBtn);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.TextBoxSend);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ListBoxLog);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "더미 클라이언트";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseMainForm);
            this.Load += new System.EventHandler(this.LoadMainForm);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.TextBox TextBoxIP;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox TextBoxPort;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.TextBox TextBoxUser;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label LabelConnected;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Label LabelTestText;
        private System.Windows.Forms.Label LabelInterval;
        private System.Windows.Forms.TextBox TextBoxInterval;
        private System.Windows.Forms.Label LabelRange;
        private System.Windows.Forms.Label LabelRange2;
        private System.Windows.Forms.TextBox TextBoxMin;
        private System.Windows.Forms.TextBox TextBoxMax;
        private System.Windows.Forms.Button TestConnectBtn;
        private System.Windows.Forms.TextBox TextBoxSend;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.ListBox ListBoxLog;
    }
}

