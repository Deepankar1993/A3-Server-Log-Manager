using BackendManager.Utli;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackendManager.Classes
{
    class PKShoutService
    {

        public const string GAMELOG_RECORD = "8001";
        public const string PK_LOG = "803";
        public const string PK_DIED_LOG = "804";
        public const string PK_SHOUT_ALERT_MSGTYPE = "241";

        public static PKShoutService instance;

        private Button _btnStart;
        private Button _btnDisconnect;

        public bool isActive = false;


        public PKShoutService(Button btnStart, Button btnDisconnect)
        {
            instance = this;
            Globals.PKShoutService = instance;
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

        public async void ReadLoginLog(string zslog)
        {
            string[] msg = zslog.Split(" ");
            //if (msg[0] != PK_LOG)
            //    //return;
            if (msg[0] == GAMELOG_RECORD && msg[2] == PK_LOG)
                await Task.Run(() => UpdatePKAsync(msg, zslog));

        }

        private async void UpdatePKAsync(string[] pklog, string mslog)
        {
            /* Wisper 
             * 8001 0
             * 23 1
             * 803 2
             * Testchar 3
             * testid 4
             * 117.229.5.135 5
             * 26_37_62 6
             * Kill:char2 7 
             * 10:49:28 AM 8
             * 
             */

            string _killerName = pklog[3];
            string _killerID = pklog[4];
            string _killerIP = pklog[5];
            string _pkLocation = pklog[6];


            string[] location = _pkLocation.Split('_');
            string mapCode = location[0];
            string mapX = location[1];
            string mapY = location[2];

            string _mapName = (Globals.MAPS.ContainsKey(mapCode) ? Globals.MAPS[mapCode] : "Map");

            string[] killdata = pklog[7].Split(':');
            string _killedName = killdata[1].ToString();
            _killedName = _killedName.Replace("\0", "");
            _killedName = _killedName.Replace("\r", "");
            //string _killTime = pklog[8];

            string _makekillLocationData = _mapName + "(" + mapX + "," + mapY + ")";
            string _buildpkShout = _killerName + " killed " + _killedName + " at " + _makekillLocationData;
            string _alertSender = "[PVP Alert]";
            Globals.mainFrm.UpdatePVP_SHOUT_LIST($"Shout : " + _buildpkShout);
            Globals.mainFrm.UpdatePVP_LOG_LIST($"Shout Log : " + _buildpkShout);
            await Globals.MainServerClient.SendShoutAsync(_buildpkShout, _alertSender, PK_SHOUT_ALERT_MSGTYPE);

        }
    }
}
