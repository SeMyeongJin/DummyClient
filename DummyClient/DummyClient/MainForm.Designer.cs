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
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.LabelConnected = new System.Windows.Forms.Label();
            this.DisconnectBtn = new System.Windows.Forms.Button();
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
            this.GroupBox1.Location = new System.Drawing.Point(14, 15);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox1.Size = new System.Drawing.Size(461, 65);
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
            this.TextBoxIP.Location = new System.Drawing.Point(100, 25);
            this.TextBoxIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxIP.MaxLength = 15;
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Size = new System.Drawing.Size(100, 25);
            this.TextBoxIP.TabIndex = 11;
            this.TextBoxIP.Text = "127.0.0.1";
            this.TextBoxIP.WordWrap = false;
            this.TextBoxPort.TextChanged += new System.EventHandler(this.TextBoxPort_TextChanged);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(225, 30);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(90, 25);
            this.PortLabel.TabIndex = 17;
            this.PortLabel.Text = "Port Number:";
            // 
            // textBoxPort
            // 
            this.TextBoxPort.Location = new System.Drawing.Point(320, 25);
            this.TextBoxPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxPort.MaxLength = 5;
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(40, 25);
            this.TextBoxPort.TabIndex = 18;
            this.TextBoxPort.Text = "0";
            this.TextBoxPort.WordWrap = false;
            this.TextBoxPort.TextChanged += new System.EventHandler(this.TextBoxPort_TextChanged);
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
            this.LabelConnected.Location = new System.Drawing.Point(210, 103);
            this.LabelConnected.Name = "LabelConnected";
            this.LabelConnected.Size = new System.Drawing.Size(241, 38);
            this.LabelConnected.TabIndex = 40;
            this.LabelConnected.Text = "서버 접속 처리 상태 : ";
            //
            // DisconnectBtn
            //
            this.DisconnectBtn.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DisconnectBtn.Location = new System.Drawing.Point(481, 90);
            this.DisconnectBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(93, 38);
            this.DisconnectBtn.TabIndex = 29;
            this.DisconnectBtn.Text = "접속 해제";
            this.DisconnectBtn.UseVisualStyleBackColor = true;
            this.DisconnectBtn.Click += new System.EventHandler(this.OnDisconnectBtn);
            // 
            // TextBoxSend
            // 
            this.TextBoxSend.Location = new System.Drawing.Point(14, 140);
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
            this.SendBtn.Location = new System.Drawing.Point(481, 135);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(93, 38);
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
            this.ListBoxLog.Location = new System.Drawing.Point(14, 190);
            this.ListBoxLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListBoxLog.Name = "listBoxLog";
            this.ListBoxLog.Size = new System.Drawing.Size(559, 210);
            this.ListBoxLog.TabIndex = 41;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 410);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.LabelConnected);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.TextBoxSend);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ListBoxLog);
            this.Controls.Add(this.GroupBox1);
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
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label LabelConnected;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.TextBox TextBoxSend;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.ListBox ListBoxLog;
    }
}

