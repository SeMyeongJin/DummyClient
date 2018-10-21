using System;
using System.Net.Sockets;
using System.Net;

namespace DummyClient
{
    public class TcpClient
    {
        public Socket socket = null;

        public string errorMsg;
        public byte[] recvBuffer = new byte[256];


        public bool IsConnected() { return (socket != null && socket.Connected) ? true : false; }

        public bool Connect(string ip, int portNum)
        {
            try
            {
                IPAddress serverIP = IPAddress.Parse(ip);
                int serverPort = portNum;
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(serverIP, serverPort));

                if (socket == null || socket.Connected == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                errorMsg = e.Message;
                return false;
            }
        }

        public void SendData(byte[] sendData)
        {
            try
            {
                if (IsConnected() == true)
                {
                    socket.Send(sendData, 0, sendData.Length, SocketFlags.None);
                }
                if (IsConnected() == false)
                {
                    errorMsg = "서버에 접속해주시기 바랍니다.";
                }
            }
            catch (SocketException se)
            {
                errorMsg = se.Message;
            }
        }

        public void Receive()
        {
            try
            { 
                int recv = socket.Receive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None);

                if (recv == 0)
                    return;
            }
            catch (SocketException se)
            {
                errorMsg = se.Message;
            }
        }

        public void Close()
        {
            if (IsConnected() == true)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
    }
}
