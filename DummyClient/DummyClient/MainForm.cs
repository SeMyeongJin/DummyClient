using System;
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

        bool isNetworkThreadRunning = false;
        bool isProcessRunning = false;

        System.Threading.Thread networkReadThread = null;
        System.Threading.Thread networkSendThread = null;

        Queue<byte[]> sendPacketQueue = new Queue<byte[]>();

        System.Windows.Forms.Timer timer;



        public MainForm()
        {
            InitializeComponent();
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

            DisconnectBtn.Enabled = false;

            TextLog.Write("Program Starts", LOG_LEVEL.INFO);
        }

        private void CloseMainForm(object sender, FormClosingEventArgs e)
        {
            isNetworkThreadRunning = false;
            isProcessRunning = false;

            dummyClient.Close();
        }

        private void OnConnectBtn(object sender, EventArgs e)
        {
            string address = TextBoxIP.Text;

            int port = Convert.ToInt32(TextBoxPort.Text);

            if (dummyClient.Connect(address, port))
            {
                LabelConnected.Text = string.Format("{0}. 서버에 접속 중", DateTime.Now);
                ConnectBtn.Enabled = false;
                DisconnectBtn.Enabled = true;
            }
            else
            {
                LabelConnected.Text = string.Format("{0}. 서버에 접속 실패", DateTime.Now);
            }
        }

        private void OnDisconnectBtn(object sender, EventArgs e)
        {
            SetDisconnected();
            dummyClient.Close();
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
