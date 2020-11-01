using BackendManager.Utli;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackendManager.Classes.ServerListeners
{
    class ZoneServerListenerService
    {
        public static ZoneServerListenerService instance;
        private PKShoutService _pkShoutService;
        private MainFrm _mainFrm;

        private Button _btnStart;
        private Button _btnDisconnect;
        private bool isActive = false;

        private const int BUFFER_SIZE = 4096;
        private readonly byte[] buffer = new byte[BUFFER_SIZE];


        private List<TcpClient> _gamelogClientList;

        public CancellationTokenSource cancelToken;

        public ZoneServerListenerService(Button btnStart, Button btnDisconnect)
        {
            instance = this;
            _mainFrm = Globals.mainFrm;
            _pkShoutService = Globals.PKShoutService;
            _btnStart = (btnStart != null ? btnStart : null);
            _btnDisconnect = (btnDisconnect != null ? btnDisconnect : null);
        }

        private TcpListener _gamelogServer;
        public TcpListener GamelogServer
        {
            get

            {
                return _gamelogServer;
            }
        }

        public async void InitAsync()
        {

            try
            {
                cancelToken = new CancellationTokenSource();
                _gamelogClientList = new List<TcpClient>();
                await ListenZSGamelog(cancelToken.Token);
            }
            catch (OperationCanceledException)
            {
                _mainFrm.AddLog2List("Log Service : Gamelog Server is stopped.");
                cancelToken.Dispose();
                btnControl(false);
            }

        }



        private void btnControl(bool _isActive)
        {
            isActive = _isActive;
            if (_btnStart != null && _btnDisconnect != null)
                Globals.btnControl(_isActive, _btnStart, _btnDisconnect);
        }

        private async Task ListenZSGamelog(CancellationToken token)
        {
            try
            {
                IPAddress address = IPAddress.Parse(Globals.settings.ZS_LISTENER_IP);
                _gamelogServer = new TcpListener(address, Globals.settings.ZS_LISTENER_PORT);
                _gamelogServer.Start();
                _mainFrm.AddLog2List("Log Service : Gamelog Server is now live.");
                btnControl(true);
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    TcpClient glClient = await _gamelogServer.AcceptTcpClientAsync();
                    _gamelogClientList.Add(glClient);
                    Globals.mainFrm.AddLog2List("Log Service : Zoneserver is connected now.");
                    await HandleClient(glClient, _mainFrm, token);
                }
            }
            //catch (OperationCanceledException)
            //{
            //    _mainFrm.AddLog2List("Log Service : Gamelog Server is stopped.");

            //    btnControl(false);
            //}
            catch (Exception ex)
            {
                if (ex.InnerException is OperationCanceledException)
                {
                    token.ThrowIfCancellationRequested();
                }
                else
                {
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    else
                    {
                        Debug.WriteLine("Error : " + ex.Message);
                        _mainFrm.AddLog2List("Log Service : Gamelog Server  error while starting.");
                        btnControl(false);
                    }
                }
            }


        }

        private static async Task HandleClient(TcpClient client, MainFrm mainFrm, CancellationToken token)
        {
            int BUFFER_SIZE = 4096;

            TcpClient tcpClient = client;
            byte[] buffer = new byte[BUFFER_SIZE];
            String data = null;
            using NetworkStream ns = tcpClient.GetStream();
            string message = null;
            int bytesReceivedMessage = 0;
            try
            {
                while (true)
                {


                    try
                    {
                        bytesReceivedMessage = await ns.ReadAsync(buffer, 0, buffer.Length);
                    }
                    catch (System.Exception)
                    {

                        break;
                    }
                    if (bytesReceivedMessage == 0)
                    {
                        //the client has disconnected from the server
                        break;
                    }
                    //byte[] recBuf = new byte[bytesReceivedMessage];
                    //Array.Copy(buffer, recBuf, bytesReceivedMessage);
                    message = Encoding.ASCII.GetString(buffer);
                    Debug.WriteLine("Received: {0}", message);
                    LogIdentificationService.Log(message);
                    message = null;
                    bytesReceivedMessage = 0;
                    //token.ThrowIfCancellationRequested();
                }
            }
            catch (Exception)
            {

            }

            Globals.mainFrm.AddLog2List("Log Service : Main Server Client disconnected.");
            tcpClient.Close();
        }

        public void Disconnect()
        {
            try
            {
                foreach (TcpClient client in _gamelogClientList)
                {
                    client.GetStream().Close();
                    client.Close();
                }
                isActive = false;
                _gamelogServer.Stop();
                btnControl(false);
                cancelToken.Cancel();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
