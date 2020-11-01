using BackendManager.Classes;
using BackendManager.Model;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BackendManager.Utli
{

    static class Globals
    {
        // global int
        public static APP_SETTINGS settings;
        public static MainFrm mainFrm;
        public static TCP_MainServer MainServerClient;
        public static LoginLogManager LoginLogService;
        public static PKShoutService PKShoutService;


        //Lists
        public static Dictionary<string, string> MAPS;



        public static void btnControl(bool isActive, Button _btnStart, Button _btnDisconnect)
        {
            if (isActive)
            {
                mainFrm.btnStartEnableDisable(_btnStart, false);
                mainFrm.btnStartEnableDisable(_btnDisconnect, true);
            }
            else
            {
                mainFrm.btnStartEnableDisable(_btnStart, true);
                mainFrm.btnStartEnableDisable(_btnDisconnect, false);
            }
        }

    }

}
