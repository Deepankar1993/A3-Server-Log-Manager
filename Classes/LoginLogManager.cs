using BackendManager.Utli;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackendManager.Classes
{
    public class LoginLogManager
    {
        MainFrm mainFrm;
        public const string LOGIN_RECORD = "1001";
        public const string LOGIN_ENTRY = "109";
        public const string LOGOUT_ENTRY = "0";
        public int LoginCount = 0;

        public static LoginLogManager instance;

        private Button _btnStart;
        private Button _btnDisconnect;
        public bool isActive = false;

        public LoginLogManager(Button btnStart, Button btnDisconnect)
        {
            instance = this;
            mainFrm = Globals.mainFrm;
            _btnStart = (btnStart != null ? btnStart : null);
            _btnDisconnect = (btnDisconnect != null ? btnDisconnect : null);
        }

        private void btnControl(bool _isActive)
        {
            isActive = _isActive;
            if (_btnStart != null && _btnDisconnect != null)
                Globals.btnControl(_isActive, _btnStart, _btnDisconnect);
        }
        public void StartService()
        {
            btnControl(true);
        }

        public void StopService()
        {
            btnControl(false);
        }

        public async void ReadLoginLog(string mslog)
        {
            if (!isActive)
                return;
            string[] msg = mslog.Split(" ");
            if (msg[0] == LOGIN_RECORD)
                await Task.Run(() => UpdateLogin(msg, mslog));

        }



        private void UpdateLogin(string[] logData, string textlog)
        {
            /*
             * 0 : 1001
             * 1 : 24
             * 2 : user
             * 3 : TestChr
             * 4 : 127.0.0.1
             * 5 : 2020-08-26
             * 6 : 16:25:39
             * 7 : 1
             * 8 : 109
             * 9 : 000
             * 10: 0
             * 11:2020-08-26
             * 12:16:25:43
             */

            if (!isActive)
                return;

            if (mainFrm == null)
                mainFrm = Globals.mainFrm;

            ListView onlineList = mainFrm.lstOnlinePlayer;
            LoginCount = onlineList.Items.Count;

            if (logData[8] == LOGIN_ENTRY)
            {
                LoginCount++;
                ListViewItem pItem = new ListViewItem();

                pItem.Text = logData[3]; // Name 
                pItem.SubItems.Add(logData[2]); // Account
                pItem.SubItems.Add(logData[4]); //IP 
                pItem.SubItems.Add(logData[11]); // Login Date
                pItem.SubItems.Add(logData[12]); // Login Time
                //TODO : Add ping
                pItem.SubItems.Add("0ms"); // ping 
                mainFrm.UpdatePlayerOnlineList(pItem, LoginCount, true);
                mainFrm.LogServer("Player Login : " + textlog);

            }
            //------------LOGOUT EVENT -------------------------
            else if (logData[8] == LOGOUT_ENTRY)
            {

                if (LoginCount > 0)
                    LoginCount--;

                ListViewItem pItem = onlineList.Items.Cast<ListViewItem>()
                .Where(x => (x.SubItems[0].Text == logData[3]))
                .FirstOrDefault();
                mainFrm.LogServer("Player Logout : " + textlog);
                mainFrm.UpdatePlayerOnlineList(pItem, LoginCount, false);
            }
        }
    }
}
