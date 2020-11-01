using BackendManager.Classes;
using BackendManager.Classes.ServerListeners;
using BackendManager.Model;
using BackendManager.Utli;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackendManager
{
    public partial class MainFrm : Form
    {
        private Socket Server;
        int backlog = -1;
        MainServerListenerService _msListen;
        PKShoutService _pkService;
        LoginLogManager _LoginManager;
        TCP_MainServer _tcp_MainServer;
        ZoneServerListenerService _zoneServerListenerService;
        AnnouncementService _as;

        private int AS_MSG_CURRENT_INDEX = 0;

        private string OLDMSG;

        private readonly List<Socket> clientSockets = new List<Socket>();
        private const int BUFFER_SIZE = 2048;
        private int PORT;
        private readonly byte[] buffer = new byte[BUFFER_SIZE];

        public static MainFrm Instance = null;

        public static APP_SETTINGS Settings;

        public MainFrm()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Instance = this;
            LoadSetting();
            //PORT = ServerInfo.Default.Backend_MS_PORT;
            //PORT = 7789;

            checkHWID();
            Initilize();
            StartServices();
            //StartMS_ServerListen();
            //lstOnlinePlayer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void Initilize()
        {
            Globals.mainFrm = this;
            _pkService = new PKShoutService(btn_PVPService_Start, btn_PVPService_Stop);
            _msListen = new MainServerListenerService(this, _pkService, btnMSLogServerStart, btnMSLogServerClose);
            Globals.LoginLogService = _LoginManager = new LoginLogManager(btnLoginlogServiceStart, btnLoginlogServiceClose);
            _zoneServerListenerService = new ZoneServerListenerService(btnZSGameLogServiceStart, btnZSGameLogServiceClose);
            _tcp_MainServer = new TCP_MainServer(this, btnMSClientStart, btnMSClientClose);
            _as = new AnnouncementService(as_Send_Timer, AS_Msg_List, btn_AS_Service_Start, btn_AS_Service_Close);


            LoadMaps();

        }

        private void LoadSetting()
        {
            // read file into a string and deserialize JSON to a type
            Settings = JsonConvert.DeserializeObject<APP_SETTINGS>(File.ReadAllText(@"settings.json"));
            Globals.settings = Settings;

        }



        private void LoadMaps()
        {
            string h = File.ReadAllText(@"Data\maps.json");

            Dictionary<string, string> mapList = JsonConvert.DeserializeObject<Dictionary<string, string>>(h);
            //Assign map list to the Global varible
            Globals.MAPS = mapList;
        }

        private void StartServices()
        {
            //Listen for Main Server 
            _msListen.InitAsync();
            //Listen for Zone Server
            _zoneServerListenerService.InitAsync();


            _LoginManager.StartService();
            _tcp_MainServer.InitAsync();
            _pkService.StartService();
        }



        private void BeginAccpetCallBack(IAsyncResult ar)
        {
            Socket acServerSocket = null;
            try
            {
                acServerSocket = Server.EndAccept(ar);
                if (acServerSocket == null)
                    return;
                clientSockets.Add(acServerSocket);
                acServerSocket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, acServerSocket);
                LogServer("Client Connected! Waiting for request");
                Server.BeginAccept(BeginAccpetCallBack, null);

            }
            catch (ObjectDisposedException)
            {
                LogServer("Error Found at BeginAccpetCallBack");
            }




        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            int received = 0;

            try
            {
                received = client.EndReceive(ar);
            }
            catch (SocketException)
            {

                LogServer("Client forcefully disconnected");
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                client.Close();
                clientSockets.Remove(client);
                btnStartListen.Enabled = true;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string response = Encoding.ASCII.GetString(recBuf);
            LoginLogManager.instance.ReadLoginLog(response);
            LogServer("Received : " + response);
            client.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, client);

        }

        //Start MainServerClient Button TCP_MainServer

        public void btnStartMSClient(bool isActive)
        {
            if (btnMSLogServerStart.InvokeRequired)
            {
                btnMSLogServerStart.Invoke((MethodInvoker)delegate
                {
                    btnMSLogServerStart.Enabled = isActive;
                });
            }
            else
            {
                btnMSLogServerStart.Enabled = isActive;
            }
        }

        //Start button for Announcement Service
        public void btnStartAnnouncementService(bool isActive)
        {
            if (btn_AS_Service_Start.InvokeRequired)
            {
                btn_AS_Service_Start.Invoke((MethodInvoker)delegate
                {
                    btn_AS_Service_Start.Enabled = isActive;
                });
            }
            else
            {
                btn_AS_Service_Start.Enabled = isActive;
            }
        }


        //Start button for Main Server Listen
        public void btnStartEnableDisable(Button btn, bool isActive)
        {
            if (btn.InvokeRequired)
            {
                btn.Invoke((MethodInvoker)delegate
                {
                    btn.Enabled = isActive;
                });
            }
            else
            {
                btn.Enabled = isActive;
            }
        }


        public void LogServer(string logtext)
        {
            this.BeginInvoke((Action)delegate
            {
                lstServerLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lstServerLog.Items.Add(logtext);
            });
        }

        public void UpdatePlayerOnlineList(ListViewItem record, int TotalOnlinePlayer, bool LoginRecord)
        {

            this.BeginInvoke((Action)delegate
            {
                if (LoginRecord)
                {
                    lstOnlinePlayer.Items.Add(record);
                }
                else
                {
                    lstOnlinePlayer.Items.Remove(record);
                }
                lblPlayerOnlineCount.Text = TotalOnlinePlayer.ToString();
            });



        }





        private bool isConnected(Socket client)
        {
            return client.Connected;
        }

        private void Process(Socket client)
        {

            Console.WriteLine("Incoming connection from " + client.RemoteEndPoint);

            const int maxMessageSize = 1024;
            byte[] response;
            int received;

            while (true)
            {

                // Send message to the client:
                Console.Write("Server: ");
                client.Send(Encoding.ASCII.GetBytes(Console.ReadLine()));
                Console.WriteLine();

                // Receive message from the server:
                response = new byte[maxMessageSize];
                received = client.Receive(response);
                if (received == 0)
                {
                    Console.WriteLine("Client closed connection!");
                    return;
                }

                List<byte> respBytesList = new List<byte>(response);
                respBytesList.RemoveRange(received, maxMessageSize - received); // truncate zero end
                Console.WriteLine("Client (" + client.RemoteEndPoint + "+: " + Encoding.ASCII.GetString(respBytesList.ToArray()));
            }
        }

        public void AS_LIST_ADD(string message)
        {
            try
            {
                message = message.Trim();
                if (AS_Msg_List.InvokeRequired)
                {
                    AS_Msg_List.Invoke((MethodInvoker)delegate
                    {
                        AS_Msg_List.Items.Add(message);
                    }
                    );
                }
                else
                {
                    AS_Msg_List.Items.Add(message);
                }
                // AS_Msg_List.Items.Add(message);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AS_LIST_CLEAR()
        {
            try
            {

                if (AS_Msg_List.InvokeRequired)
                {
                    AS_Msg_List.Invoke((MethodInvoker)delegate
                    {
                        AS_Msg_List.Items.Clear();
                    }
                    );
                }
                else
                {
                    AS_Msg_List.Items.Clear();
                }
                // AS_Msg_List.Items.Add(message);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnLoginlogServiceStart_Click(object sender, EventArgs e)
        {
            _LoginManager.StartService();
        }

        private void btnMSLogServerStart_Click(object sender, EventArgs e)
        {
            _msListen.InitAsync();
        }



        private void btnDisconnectMSLogServer_Click(object sender, EventArgs e)
        {
            _LoginManager.StopService();

        }

        private void lblServerListen_Click(object sender, EventArgs e)
        {

        }

        private void checkHWID()
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorId"].ToString();
                break;
            }

            LogServer(id);
        }

        private void btnClearLoginLog_Click(object sender, EventArgs e)
        {
            lstServerLog.Clear();
        }



        private void lstServerLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstServerLog.SelectedItems.Count > 0)
            {
                txtLogView.AppendText(lstServerLog.SelectedItems[0].Text + Environment.NewLine);
            }
        }


        private void tabCtrlManager_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }





        private void btnSetInterval_Click(object sender, EventArgs e)
        {
            //convert the to milisec
            int timeInMs = int.Parse(txtASinterval.Text) * 1000;
            as_Send_Timer.Interval = timeInMs;
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            // _as.SendMsg();
        }

        private async void btn_reload_asMessages_ClickAsync(object sender, EventArgs e)
        {
            AS_Msg_List.Items.Clear();
            await Task.Run(() => _as.LoadMessages());
        }

        public ListBox GetListBox()
        {

            return AS_Msg_List;

        }

        private void as_Send_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                _as.NextAnnouncemnet();
                //btnStartAnnouncementService(false);
                //await Task.Run(() => _as.SendAnnoucemnetAsync(AS_Msg_List.Items[AS_MSG_CURRENT_INDEX].ToString()));
                //AS_MSG_CURRENT_INDEX++;
                //if (AS_MSG_CURRENT_INDEX > AS_Msg_List.Items.Count - 1)
                //{
                //    AS_MSG_CURRENT_INDEX = 0;
                //}
            }
            catch (Exception)
            {
                //btnStartAnnouncementService(true);
                AddLog2List($"Error : Issue sending Announcememnt");
                throw;
            }
        }

        private void btn_Start_AS_Service_Click(object sender, EventArgs e)
        {
            _as.StartService();
        }

        private void btn_StopAnnouncementService_Click(object sender, EventArgs e)
        {
            _as.StopService();
        }

        private async void btnAddAsMessage_Click(object sender, EventArgs e)
        {
            await Task.Run(() => _as.AddMessageAsync(txt_MsgData.Text, true));

        }

        private async void btnDeleteASMessage_Click(object sender, EventArgs e)
        {
            string msg = AS_Msg_List.Items[AS_Msg_List.SelectedIndex].ToString();
            await Task.Run(() => _as.DeleteMessageAsync(msg));

        }

        private async void btnUpdateAsMSG_Click(object sender, EventArgs e)
        {
            try
            {
                if (AS_Msg_List.SelectedIndex == -1)
                {
                    await Task.Run(() => AddLog2List("Select the message to be Updated"));
                }
                string oldMsg = AS_Msg_List.Items[AS_Msg_List.SelectedIndex].ToString();
                string newMsg = txt_MsgData.Text;
                await Task.Run(() => _as.UpdateMessageAsync(oldMsg, newMsg));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AddLog2List(string msg)
        {
            if (lst_ALL_LOG.InvokeRequired)
            {
                lst_ALL_LOG.Invoke((MethodInvoker)delegate
                {
                    lst_ALL_LOG.Items.Add(msg);
                });
            }
            else
            {
                lst_ALL_LOG.Items.Add(msg);
            }

        }

        private void btnZSGameLogServiceStart_Click(object sender, EventArgs e)
        {
            _zoneServerListenerService.InitAsync();
        }

        private void btnZSGameLogServiceClose_Click(object sender, EventArgs e)
        {
            _zoneServerListenerService.Disconnect();
        }

        private void btnMSClientStart_Click(object sender, EventArgs e)
        {
            _tcp_MainServer.InitAsync();
        }

        private void btnMSClientClose_Click(object sender, EventArgs e)
        {
            _tcp_MainServer.Disconnect();
        }

        private void btn_PVPService_Stop_Click(object sender, EventArgs e)
        {
            _pkService.StopService();
        }

        private void btn_PVPService_Start_Click(object sender, EventArgs e)
        {
            _pkService.StartService();
        }

        private void AS_Msg_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AS_Msg_List.SelectedIndex != -1)
            {
                string oldMsg = AS_Msg_List.Items[AS_Msg_List.SelectedIndex].ToString();
                txt_MsgData.Text = oldMsg;
            }
        }


        public void UpdatePVP_SHOUT_LIST(string msg)
        {
            if (lstbox_PVP_Shout.InvokeRequired)
            {
                lstbox_PVP_Shout.Invoke((MethodInvoker)delegate
               {
                   lstbox_PVP_Shout.Items.Add(msg);
               });
            }
            else
            {
                lstbox_PVP_Shout.Items.Add(msg);
            }
        }


        public void UpdatePVP_LOG_LIST(string msg)
        {
            if (lstbox_PVPLOG.InvokeRequired)
            {
                lstbox_PVPLOG.Invoke((MethodInvoker)delegate
                {
                    lstbox_PVPLOG.Items.Add(msg);
                });
            }
            else
            {
                lstbox_PVPLOG.Items.Add(msg);
            }
        }
    }
}
