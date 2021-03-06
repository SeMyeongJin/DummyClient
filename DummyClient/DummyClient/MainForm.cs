﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Marshaling
using System.Runtime.InteropServices;


namespace DummyClient
{
    public partial class MainForm : Form
    {
        TcpClient dummyClient = new TcpClient();
        TcpClient[] dummys = new TcpClient[1000];

        bool isNetworkThreadRunning = false;
        bool isProcessRunning = false;
        bool isTestRunning = false;
        bool isMsgTestRunning = false;

        System.Threading.Thread networkReadThread = null;
        System.Threading.Thread networkSendThread = null;


        Queue<byte[]> sendPacketQueue = new Queue<byte[]>();

        System.Windows.Forms.Timer timer;
        System.Windows.Forms.Timer TestTimer;
        System.Windows.Forms.Timer TestTimer2;

        int count = 0;
        int UserNum = 0;
        int randMax = 0;
        int Min = 0;
        int Max = 0;
        int Avg = 0;
        int MsgCount = 0;


        public MainForm()
        {
            InitializeComponent();

            for (int i = 0; i < 1000; i++)
            {
                dummys[i] = new TcpClient();
            }
        }

        private void LoadMainForm(object sender, EventArgs e)
        {
            isNetworkThreadRunning = true;
            networkReadThread = new System.Threading.Thread(this.NetworkReadProcess);
            networkReadThread.Start();
            networkSendThread = new System.Threading.Thread(this.NetworkSendProcess);
            networkSendThread.Start();

            isProcessRunning = true;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(BackGroundProcess);
            timer.Interval = 100;
            timer.Start();

            TestConnectBtn.Enabled = false;
            DisconnectBtn.Enabled = false;
            TestMsgBtn.Enabled = false;

            LabelConnected.Text = string.Format("접속 클라이언트 수 : {0}", count);

            TextLog.Write("Program Starts", LOG_LEVEL.INFO);
        }

        private void CloseMainForm(object sender, FormClosingEventArgs e)
        {
            isNetworkThreadRunning = false;
            isProcessRunning = false;
            isTestRunning = false;
            isMsgTestRunning = false;

            dummyClient.Close();

            for (int i = 0; i < 1000; i++)
            {
                dummys[i].Close();
            }
        }

        private void OnConnectBtn(object sender, EventArgs e)
        {
            string address = TextBoxIP.Text;

            int port = Convert.ToInt32(TextBoxPort.Text);

            UserNum = Convert.ToInt32(TextBoxUser.Text);

            for (int i = 0; i < UserNum; i++)
            {
                dummys[i].Connect(address, port);
            }

            if (dummyClient.Connect(address, port))
            {
                ConnectBtn.Enabled = false;
                TestConnectBtn.Enabled = true;
                DisconnectBtn.Enabled = true;
                TestMsgBtn.Enabled = true;
                count = Convert.ToInt32(TextBoxUser.Text);
            }
            else
            {
                return;
            }
            TestConnectBtn.ForeColor = Color.Black;
            TestMsgBtn.ForeColor = Color.Black;
            LabelConnected.Text = string.Format("접속 클라이언트 수 : {0}", count);
        }

        private void OnTestConnectBtn(object sender, EventArgs e)
        {
            if (TestConnectBtn.ForeColor == Color.Black)
            {
                isTestRunning = true;
                TestConnectBtn.ForeColor = Color.Blue;
                TestTimer = new System.Windows.Forms.Timer();
                TestTimer.Tick += new EventHandler(Test);
                TestTimer.Interval = Convert.ToInt32(TextBoxInterval.Text);
                TestTimer.Start();
                return;
            }
            if (TestConnectBtn.ForeColor == Color.Blue)
            {
                isTestRunning = false;
                TestConnectBtn.ForeColor = Color.Black;
                return;
            }
        }

        private void OnTestMsgBtn(object sender, EventArgs e)
        {
            if (TestMsgBtn.ForeColor == Color.Black)
            {
                isMsgTestRunning = true;
                TestMsgBtn.ForeColor = Color.Blue;
                TestTimer2 = new System.Windows.Forms.Timer();
                TestTimer2.Tick += new EventHandler(MsgTest);
                TestTimer2.Interval = Convert.ToInt32(TextBoxInterval2.Text);
                TestTimer2.Start();
                return;
            }
            if (TestMsgBtn.ForeColor == Color.Blue)
            {
                isMsgTestRunning = false;
                TestMsgBtn.ForeColor = Color.Black;
                return;
            }
        }

        private void OnDisconnectBtn(object sender, EventArgs e)
        {
            SetDisconnected();
            dummyClient.Close();

            UserNum = Convert.ToInt32(TextBoxUser.Text);

            for (int i = 0; i < UserNum; i++)
            {
                dummys[i].Close();
            }
            count = 0;
            isTestRunning = false;
            isMsgTestRunning = false;
        }

        private void OnSendBtn(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxSend.Text))
            {
                MessageBox.Show("보낼 텍스트를 입력하세요");
                return;
            }
            
            List<byte> dataSource = new List<byte>();
            dataSource.AddRange(Encoding.UTF8.GetBytes(TextBoxSend.Text));
            
            sendPacketQueue.Enqueue(dataSource.ToArray());
        }

        void NetworkReadProcess()
        {
            while (isNetworkThreadRunning)
            {
                if (dummyClient.IsConnected() == false)
                {
                    System.Threading.Thread.Sleep(1);
                    continue;
                }

                dummyClient.Receive();

                PT_DELIVERY_CHAT recvPacket = new PT_DELIVERY_CHAT();

                recvPacket = (PT_DELIVERY_CHAT)Deserialize(dummyClient.recvBuffer, typeof(PT_DELIVERY_CHAT));

                if (dummyClient.recvBuffer.Length > 0)
                {
                    TextLog.Write($"받은 데이터: {recvPacket.Message}", LOG_LEVEL.INFO);
                }
                else
                {
                    TextLog.Write("서버와 접속 종료 !!!", LOG_LEVEL.INFO);
                }
            }
        }

        void NetworkSendProcess()
        {
            while (isNetworkThreadRunning)
            {
                System.Threading.Thread.Sleep(1);

                if (dummyClient.IsConnected() == false)
                {
                    continue;
                }

                lock (((System.Collections.ICollection)sendPacketQueue).SyncRoot)
                {
                    if (sendPacketQueue.Count > 0)
                    {
                        byte[] sendbyte = new byte[256];
                        var packet = sendPacketQueue.Dequeue();
                        String str = Encoding.Default.GetString(packet);

                        PT_DELIVERY_CHAT chatPack = new PT_DELIVERY_CHAT(str, GValue.packetNumber++);

                        sendbyte = Serialize(chatPack);

                        dummyClient.SendData(sendbyte);
                    }
                }
            }
        }

        void BackGroundProcess(object sender, EventArgs e)
        {
            ProcessLog();
        }

        private void ProcessLog()
        {
            // 너무 이 작업만 할 수 없으므로 일정 작업 이상을 하면 일단 패스한다.
            int logWorkCount = 0;

            while (isProcessRunning)
            {
                System.Threading.Thread.Sleep(1);
            
                string msg;
            
                if (TextLog.GetLog(out msg))
                {
                    ++logWorkCount;
            
                    if (ListBoxLog.Items.Count > 512)
                    {
                        ListBoxLog.Items.Clear();
                    }
            
                    ListBoxLog.Items.Add(msg);
                    ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1;
                }
                else
                {
                    break;
                }
            
                if (logWorkCount > 8)
                {
                    break;
                }
            }
        }

        private void Test(object sender, EventArgs e)
        {
            Random rand = new Random();

            Min = Convert.ToInt32(TextBoxMin.Text);
            Max = Convert.ToInt32(TextBoxMax.Text);
            Avg = (Min + Max) / 2;
            randMax = Convert.ToInt32(TextBoxUser.Text) - 1;

            int port = Convert.ToInt32(TextBoxPort.Text);

            while (isTestRunning)
            {
                if ( count >= Avg )
                {
                    if (dummys[rand.Next(0, randMax)].IsConnected())
                    {
                        dummys[rand.Next(0, randMax)].Close();
                        count--;
                    }
                }
                if (count > Min || count < Max)
                {
                    if (dummys[rand.Next(0, randMax)].IsConnected())
                    {
                        dummys[rand.Next(0, randMax)].Close();
                        count--;
                    }
                    if (!dummys[rand.Next(0, randMax)].IsConnected())
                    {
                        dummys[rand.Next(0, randMax)].Connect("127.0.0.1", port);
                        count++;
                    }
                }

                if (count <= Avg )
                {
                    if (!dummys[rand.Next(0, randMax)].IsConnected())
                    {
                        dummys[rand.Next(0, randMax)].Connect("127.0.0.1", port);
                        count++;
                    }
                }
                if (count > 0)
                    break;
            }
            LabelConnected.Text = string.Format("접속 클라이언트 수 : {0}", count);
        }

        private void MsgTest(object sender, EventArgs e)
        {
            MsgCount = Convert.ToInt32(TextBoxCount.Text);

            Random rand = new Random();
            randMax = Convert.ToInt32(TextBoxUser.Text) - 1;
            Byte[] writeBuffer = new byte[256];

            

            while (isMsgTestRunning)
            {
                for(int i = 0; i < MsgCount; i++)
                {
                    if (dummys[rand.Next(0, randMax)].IsConnected())
                    {
                        PT_DELIVERY_CHAT chatPack = new PT_DELIVERY_CHAT("hell", GValue.packetNumber++);

                        writeBuffer = Serialize(chatPack);

                        dummys[rand.Next(0, randMax)].SendData(writeBuffer);
                    }
                }
                if (MsgCount > 0)
                    break;
            }
        }

        public void SetDisconnected()
        {
            if (ConnectBtn.Enabled == false)
            {
                ConnectBtn.Enabled = true;
                DisconnectBtn.Enabled = false;
            }
            
            sendPacketQueue.Clear();
            
            LabelConnected.Text = "서버 연결이 끊어졌습니다.";
        }

        private void TextBoxPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxInterval_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxInterval2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {

        }

        public byte[] Serialize(object data)
        {
            int RawSize = Marshal.SizeOf(data);
            IntPtr buffer = Marshal.AllocHGlobal(RawSize); //메모리 할당(임시공간)

            Marshal.StructureToPtr(data, buffer, false);

            byte[] RawData = new byte[RawSize];

            Marshal.Copy(buffer, RawData, 0, RawSize);
            Marshal.FreeHGlobal(buffer);

            return RawData;
        }

        public object Deserialize(byte[] data, Type dataType)
        {
            int RawSize = Marshal.SizeOf(dataType);
            if (RawSize > data.Length)
            {
                return null;
            }
            IntPtr buffer = Marshal.AllocHGlobal(RawSize);
            Marshal.Copy(data, 0, buffer, RawSize);

            object objData = Marshal.PtrToStructure(buffer, dataType);
            Marshal.FreeHGlobal(buffer);
            return objData;
        }
    }
}
