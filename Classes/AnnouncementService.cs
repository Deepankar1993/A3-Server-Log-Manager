using BackendManager.Utli;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackendManager.Classes
{
    public class AnnouncementService
    {
        public static AnnouncementService instance;

        MainFrm _mainFrm;
        TCP_MainServer _mainServer;
        Timer _AsMsgTimer;
        private bool isActive = false;
        string DB_FILE_NAME = @"Data\database.sqlite";


        private Button _btnStart;
        private Button _btnDisconnect;

        // We use these three SQLite objects:

        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;


        ListBox _accouncemnetListBox;

        private int AS_MSG_CURRENT_INDEX = 0;

        public AnnouncementService(Timer timer, ListBox listBox, Button btnStart, Button btnDisconnect)
        {
            _mainFrm = Globals.mainFrm;
            _mainServer = Globals.MainServerClient;
            _accouncemnetListBox = listBox;
            _btnStart = btnStart;
            _btnDisconnect = btnDisconnect;
            _AsMsgTimer = timer;
            ConnectDB();
            LoadMessages();
        }

        private void ConnectDB()
        {
            try
            {
                if (File.Exists(DB_FILE_NAME))
                {
                    sqlite_conn = new SQLiteConnection("URI=file:" + DB_FILE_NAME + " ");
                }
                if (sqlite_conn != null && sqlite_conn.State == System.Data.ConnectionState.Closed)
                {
                    sqlite_conn.Open();
                }
            }
            catch (System.Exception)
            {
                //sqlite_conn.Close();
                throw;
            }

        }

        public async void LoadMessages(bool clearAll = false)
        {
            try
            {
                if (clearAll)
                {
                    _mainFrm.AS_LIST_CLEAR();
                }
                if (sqlite_conn.State != System.Data.ConnectionState.Open)
                {
                    ConnectDB();
                }
                sqlite_cmd = new SQLiteCommand("SELECT * FROM asmessage", sqlite_conn);
                //sqlite_datareader = sqlite_cmd.ExecuteReader();
                // DbDataReader datareader = await sqlite_cmd.ExecuteReaderAsync();
                //using (SQLiteDataReader reader = sqlite_cmd.ExecuteReader())
                //{
                using (SQLiteDataReader reader = (SQLiteDataReader)await sqlite_cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        if (reader.GetString(1) != null)
                        {
                            _mainFrm.AS_LIST_ADD(reader.GetString(1));
                            //Debug.WriteLine(sqlite_datareader.GetString(1));
                        }
                        // _mainFrm.AS_LIST_ADD(sqlite_datareader.GetString(0).ToString());
                    }
                }
                sqlite_conn.Close();
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        private void btnControl(bool _isActive)
        {
            isActive = _isActive;
            if (_btnStart != null && _btnDisconnect != null)
                Globals.btnControl(_isActive, _btnStart, _btnDisconnect);
        }

        public void StartService()
        {
            //Check if we are connected to the main server
            //If not the call the tcpClient to connect to main Server
            if (!Globals.MainServerClient.isActive)
                Globals.MainServerClient.InitAsync();
            _AsMsgTimer.Start();
            btnControl(true);
            Globals.mainFrm.AddLog2List($"Service : Announcement Service Started.");
        }
        public void StopService()
        {
            _AsMsgTimer.Stop();
            btnControl(false);
            Globals.mainFrm.AddLog2List($"Service : Announcement Service Stopped.");
        }

        public async void NextAnnouncemnet()
        {
            try
            {
                if (_accouncemnetListBox != null && _accouncemnetListBox.Items.Count > 0)
                {
                    await SendAnnoucemnetAsync(_accouncemnetListBox.Items[AS_MSG_CURRENT_INDEX].ToString());
                    AS_MSG_CURRENT_INDEX++;

                    if (AS_MSG_CURRENT_INDEX > _accouncemnetListBox.Items.Count - 1)
                    {
                        AS_MSG_CURRENT_INDEX = 0;
                    }
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void _getNewListbox()
        {
            _accouncemnetListBox = null;
            _accouncemnetListBox = Globals.mainFrm.GetListBox();
        }

        public async Task SendAnnoucemnetAsync(string msg)
        {
            msg = msg.Trim();
            await TCP_MainServer.instance.SendAnnoucemnetAsync(msg);
        }

        public async void AddMessageAsync(string msg, bool isActive = true, int position = 0)
        {
            try
            {
                if (sqlite_conn.State != System.Data.ConnectionState.Open)
                {
                    ConnectDB();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(sqlite_conn))
                {
                    cmd.CommandText = "INSERT INTO asmessage (message , position, active) VALUES('" + msg + "','" + position + "','" + isActive + "')";
                    await cmd.ExecuteNonQueryAsync();
                    await Task.Run(() => _mainFrm.AS_LIST_CLEAR());
                    await Task.Run(() => LoadMessages());
                }
                sqlite_conn.Close();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async void DeleteMessageAsync(string msg)
        {
            try
            {
                if (sqlite_conn.State != System.Data.ConnectionState.Open)
                {
                    ConnectDB();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(sqlite_conn))
                {
                    cmd.CommandText = "DELETE FROM asmessage WHERE id=(SELECT id FROM asmessage where message='" + msg + "' LIMIT 1)";
                    await cmd.ExecuteNonQueryAsync();
                    await Task.Run(() => _mainFrm.AS_LIST_CLEAR());
                    await Task.Run(() => LoadMessages());
                }
                sqlite_conn.Close();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async void UpdateMessageAsync(string oldmsg, string newMsg)
        {
            try
            {
                if (sqlite_conn.State != System.Data.ConnectionState.Open)
                {
                    ConnectDB();
                }
                using (SQLiteCommand cmd = new SQLiteCommand(sqlite_conn))
                {
                    cmd.CommandText = "UPDATE asmessage SET message='" + newMsg + "' WHERE id=(SELECT id FROM asmessage where message='" + oldmsg + "' LIMIT 1)";
                    await cmd.ExecuteNonQueryAsync();
                    await Task.Run(() => _mainFrm.AS_LIST_CLEAR());
                    await Task.Run(() => LoadMessages());
                }
                sqlite_conn.Close();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }


}
