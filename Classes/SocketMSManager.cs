using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BackendManager.Classes
{
    public class SocketMSManager
    {
        public static SocketMSManager instance = null;
        MainFrm main;

        private Socket socket_MS;
        private byte[] buffer;


        public SocketMSManager(MainFrm frm)
        {
            instance = this;
            main = MainFrm.Instance;
        }

        public Socket ms_socket
        {
            get
            {
                return socket_MS;
            }
            set
            {
                if (socket_MS != null && !socket_MS.Connected)
                {
                    ConnectMS();
                }
            }
        }

        public void ConnectMS()
        {
            try
            {
                IPAddress msIP = IPAddress.Parse(ServerInfo.Default.MainServer_IP);
                IPEndPoint IP_endPoint = new IPEndPoint(msIP, ServerInfo.Default.MainServer_PORT);
                socket_MS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // socket_MS.Connect(MS_connect);
                socket_MS.BeginConnect(IP_endPoint, OnConnectConnect, null);
                MainFrm.Instance.MSLogList("Trying to Connect Main Server ");
            }
            catch (SocketException sock_ex)
            {
                MainFrm.Instance.MSLogList("Socket MS: Failed to Connect to Main Server " + ServerInfo.Default.MainServer_IP +
                    ":" + ServerInfo.Default.MainServer_PORT);
            }



        }

        private void OnConnectConnect(IAsyncResult ar)
        {
            //On Connection to the Main Server 
            try
            {
                socket_MS.EndConnect(ar);
                buffer = new byte[socket_MS.ReceiveBufferSize];
                socket_MS.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnDataReceive, null);
                MainFrm.Instance.MSLogList("Connected to Main Server. Waiting for Logs ");

            }
            catch (SocketException ex)
            {
                MainFrm.Instance.LogServer(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                MainFrm.Instance.LogServer(ex.Message);
            }
        }

        private void OnDataReceive(IAsyncResult ar)
        {
            try
            {
                int received = socket_MS.EndReceive(ar);
                if (received == 0)
                {
                    return;
                }

                string message = Encoding.ASCII.GetString(buffer);

                MainFrm.Instance.MSLogList(message);

                /*                Invoke((Action)delegate
                                {
                                    Text = "Main Server In: " + message;
                                });*/

            }
            catch (SocketException ex)
            {
                MainFrm.Instance.LogServer(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                MainFrm.Instance.LogServer(ex.Message);
            }
        }

        private void CreateLogEntry()
        {

        }



    }
}
