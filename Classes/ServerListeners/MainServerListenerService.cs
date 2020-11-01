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
    class MainServerListenerService
    {
        public static MainServerListenerService instance;
        private PKShoutService _pkShoutService;
        private MainFrm _mainFrm;

        private Button _btnStart;
        private Button _btnDisconnect;

        private const int BUFFER_SIZE = 4096;
        private readonly byte[] buffer = new byte[BUFFER_SIZE];
        private List<TcpClient> _msClientList;

        private bool isActive = false;

        public CancellationTokenSource cancelToken;


        public MainServerListenerService(MainFrm _main, PKShoutService _PKshoutService, Button btnStart, Button btnDisconnect)
        {
            instance = this;
            _mainFrm = _main;
            _pkShoutService = _PKshoutService;
            _btnStart = (btnStart != null ? btnStart : null);
            _btnDisconnect = (btnDisconnect != null ? btnDisconnect : null);

        }
        private TcpListener _msListenter;
        public TcpListener MsListenter
        {
            get

            {
                return _msListenter;
            }

        }

        private void btnControl(bool isActive)
        {
            if (_btnStart != null && _btnDisconnect != null)
                Globals.btnControl(isActive, _btnStart, _btnDisconnect);
        }


        public async void InitAsync()
        {
            _msClientList = new List<TcpClient>();

            try
            {
                cancelToken = new CancellationTokenSource();
                await Task.Run(() => ListenMS(cancelToken.Token), cancelToken.Token);
            }
            catch (OperationCanceledException)
            {
                cancelToken.Dispose();
                Globals.mainFrm.AddLog2List($"Log Service :  Message log Server Stopped.");
                btnControl(false);
            }


        }


        private async Task ListenMS(CancellationToken token)
        {
            try
            {
                IPAddress address = IPAddress.Parse(Globals.settings.MS_LISTENER_IP);
                _msListenter = new TcpListener(address, Globals.settings.MS_LISTENER_PORT);
                _msListenter.Start();
                isActive = true;
                _mainFrm.AddLog2List("Log Service : Message Log Server is now live.");

                btnControl(true);

                //token.ThrowIfCancellationRequested();
                while (isActive)
                {

                    TcpClient msClient = _msListenter.AcceptTcpClient();
                    token.ThrowIfCancellationRequested();

                    _msClientList.Add(msClient);
                    Globals.mainFrm.AddLog2List("Log Service : Main Server connected now.");
                    await HandleClient(msClient, _mainFrm, token);

                }
                Debug.WriteLine("Line Exited");

            }
            //catch (OperationCanceledException)
            //{
            //    _msListenter.Stop();
            //    _mainFrm.AddLog2List("Log Service :  Message Server Stopped.");
            //    isActive = false;
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
                        _mainFrm.AddLog2List("Log Service : Message Server error while starting.");
                        isActive = false;
                        btnControl(false);
                    }
                }

            }


        }

        private static async Task HandleClient(TcpClient client, MainFrm mainFrm, CancellationToken token)
        {
            try
            {
                int BUFFER_SIZE = 4096;

                TcpClient tcpClient = client;
                byte[] buffer = new byte[BUFFER_SIZE];
                String data = null;
                using NetworkStream ns = tcpClient.GetStream();
                string message = null;
                int bytesReceivedMessage = 0;

                while (true)
                {
                    token.ThrowIfCancellationRequested();
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
                    message = Encoding.Default.GetString(buffer);
                    Debug.WriteLine("Received: {0}", message);
                    LogIdentificationService.Log(message);
                    message = null;
                    bytesReceivedMessage = 0;
                    token.ThrowIfCancellationRequested();
                }

                mainFrm.AddLog2List("Log Service : Main Server Client disconnected.");
                tcpClient.Close();
            }
            catch (Exception)
            {
                client.Close();
                throw;
            }

        }


        public void Disconnect()
        {
            try
            {
                foreach (TcpClient client in _msClientList)
                {
                    client.GetStream().Close();
                    client.Close();
                }
                isActive = false;
                cancelToken.Cancel();
                btnControl(false);
                _msListenter.Stop();
                //_mainFrm.AddLog2List("Log Service :  Message Server Stopped.");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
