using BackendManager.Utli;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackendManager.Classes
{
    public class TCP_MainServer
    {
        public static TCP_MainServer instance = null;
        MainFrm mainFrm;
        Button _btnStart;
        Button _btnDisconnect;

        //Main Server Ip , This is the server ip on which the Main Server is Hosted 
        IPAddress mainServerIP;
        //Main Server PORT
        int mainServerPORT;

        string MS_ASK_Server_ID = "01 A0 00 00 02"; //ID 2


        private TcpClient _client_ms;
        private byte[] buffer;

        public bool isActive = false;
        public CancellationTokenSource cancelToken;

        public TCP_MainServer(MainFrm _mainFrm, Button btnStart, Button btnDisconnect)
        {
            instance = this;
            Globals.MainServerClient = instance;
            mainFrm = _mainFrm;
            _btnStart = btnStart;
            _btnDisconnect = btnDisconnect;
        }
        private void btnControl(bool _isActive)
        {
            isActive = _isActive;
            if (_btnStart != null && _btnDisconnect != null)
                Globals.btnControl(_isActive, _btnStart, _btnDisconnect);
        }

        public TcpClient mainServer
        {
            get
            {
                return _client_ms;
            }
        }

        public async void InitAsync()
        {
            try
            {
                cancelToken = new CancellationTokenSource();
                await ConnectMS(cancelToken.Token);
            }
            catch (OperationCanceledException)
            {
                mainFrm.AddLog2List("Service : Message Service is stopped.");
            }
        }


        public async Task ConnectMS(CancellationToken token)
        {
            try
            {
                mainServerIP = IPAddress.Parse(Globals.settings.MS_IP);
                mainServerPORT = Globals.settings.MS_PORT;
                _client_ms = new TcpClient();
                await _client_ms.ConnectAsync(mainServerIP, mainServerPORT);
                if (_client_ms.Connected)
                {
                    Debug.WriteLine("Main Server is now Connected");
                    //mainFrm.btnMSLogServerStart.Enabled = false;
                    SendAskID();
                    //_client_ms.Close();
                    btnControl(true);
                }
                token.ThrowIfCancellationRequested();
            }
            catch (Exception)
            {
                _client_ms.Close();
                btnControl(false);
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                mainFrm.AddLog2List("Error : Issue While Connecting MS Client");
                Debug.WriteLine("Error While Connecting MS Client");
                //throw; 
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_client_ms.Connected)
                {
                    _client_ms.Close();
                    cancelToken.Cancel();
                    Debug.WriteLine("Main Server Connection is now Closed");
                    btnControl(false);
                }
            }
            catch (Exception)
            {
                cancelToken.Cancel();
                btnControl(false);
                mainFrm.AddLog2List("Error While disconnecting MS Client");
                // throw;
            }

        }

        public async Task SendShoutAsync(string msg, string _sender = "JARVIS", string msgTypeID = "0")
        {
            if (_client_ms.Connected)
            {
                string gmname = _sender;
                //if (!_sender.Equals("JARVIS"))
                //{
                //    gmname = _sender;
                //}
                //string gmname = "Virtual-GM";
                // Chr$(1) & Chr$(161) & Chr$(116) & Chr$(0) & Chr$(choice) & Chr$(173) & Chr$(32) & Chr$(0) & Chr$(0) & Chr$(0))
                // 1,161,116,0,choice,173,32,0,0,0 //Yellow Msg
                // 1,161,116,0,245,173,32,0,0,0 //Anounce choice 245 @WSHOUT Greem
                /*Choice :
                 * 0 = Shout
                 * 241 = PVP
                 * 245 = Announcement / GMShout 
                 */
                string packetString = "1,161,116,0," + msgTypeID + ",173,32,0,0,0";
                byte[] FullMessaget2Send;
                byte[] shoutPacket1 = Packet.MakeBytesArrayfromIntString(packetString, ',');
                byte[] gmnametobytes = Packet.GetBytesFrom(gmname);
                int addzero = 42 - gmnametobytes.Length;
                gmnametobytes = Packet.CombineByteArray(gmnametobytes, Packet.GetZeroHexPacket(addzero)); //42

                shoutPacket1 = Packet.CombineByteArray(shoutPacket1, gmnametobytes); //52
                byte[] msgToBytes = Packet.GetBytesFrom(msg);
                int addzero2 = 64 - msg.Length; //9

                msgToBytes = Packet.CombineByteArray(msgToBytes, Packet.GetZeroHexPacket(addzero2)); //64

                FullMessaget2Send = Packet.CombineByteArray(shoutPacket1, msgToBytes); //116

                var test = FullMessaget2Send.Length;
                //byte[] askID = Packet.MakeBytesArrayfromHexString(MS_ASK_Server_ID);
                Packet.WRITE(_client_ms, FullMessaget2Send);
            }
            else
            {
                await ConnectMS(cancelToken.Token);

            }
        }

        public async Task SendAnnoucemnetAsync(string msg, string _gmname = null)
        {

            if (_client_ms.Connected)
            {

                string gmname = (_gmname != null && _gmname != "GM") ? _gmname : "GM";
                // Chr$(1) & Chr$(161) & Chr$(116) & Chr$(0) & Chr$(choice) & Chr$(173) & Chr$(32) & Chr$(0) & Chr$(0) & Chr$(0))
                // 1,161,116,0,choice,173,32,0,0,0 //Yellow Msg
                // 1,161,116,0,245,173,32,0,0,0 //Anounce choice 245 @WSHOUT Greem
                string packetString = "1,161,116,0,245,173,32,0,0,0";
                byte[] FullMessaget2Send;
                byte[] shoutPacket1 = Packet.MakeBytesArrayfromIntString(packetString, ',');
                byte[] gmnametobytes = Packet.GetBytesFrom(gmname);
                int addzero = 42 - gmnametobytes.Length;
                gmnametobytes = Packet.CombineByteArray(gmnametobytes, Packet.GetZeroHexPacket(addzero)); //42

                shoutPacket1 = Packet.CombineByteArray(shoutPacket1, gmnametobytes); //52
                byte[] msgToBytes = Packet.GetBytesFrom(msg);
                int addzero2 = 64 - msg.Length; //9

                msgToBytes = Packet.CombineByteArray(msgToBytes, Packet.GetZeroHexPacket(addzero2)); //64

                FullMessaget2Send = Packet.CombineByteArray(shoutPacket1, msgToBytes); //116

                var test = FullMessaget2Send.Length;
                //byte[] askID = Packet.MakeBytesArrayfromHexString(MS_ASK_Server_ID);
                Packet.WRITE(_client_ms, FullMessaget2Send);
            }
            else
            {
                await ConnectMS(cancelToken.Token);

            }
        }



        public void SendAskID()
        {
            byte[] askID = Packet.MakeBytesArrayfromHexString(MS_ASK_Server_ID);
            Packet.WRITE(_client_ms, askID);
        }


    }
}
