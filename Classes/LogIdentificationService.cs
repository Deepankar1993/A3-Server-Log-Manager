using BackendManager.Utli;
using System.Threading.Tasks;

namespace BackendManager.Classes
{
    class LogIdentificationService
    {

        public LogIdentificationService instance;
        #region Varibles
        MainFrm mainFrm;

        #endregion

        #region Entry Types
        public const string LOGIN_RECORD = "1001";

        #endregion



        public enum LOG_TYPE
        {
            LOGIN_RECORD = 1001,
            GAME_LOG = 8001,

        }

        public enum GAMELOG_TYPE
        {
            PK_LOG = 803,
            GOT_PK_LOG = 804,

        }




        /// <summary>
        /// Proccess every new log message and 
        /// Send it appropiate Log service
        /// </summary>
        /// <param name="log"></param>
        public static async void Log(string log)
        {
            try
            {
                int intLogType;
                string[] logSplit = log.Split(" ");
                if (logSplit[0] != null)
                {
                    intLogType = int.Parse(logSplit[0]);
                    await Distribute(intLogType, logSplit, log);

                }
            }
            catch (System.Exception)
            {

                Globals.mainFrm.AddLog2List("Error Reading logs");
            }


        }

        private static async Task Distribute(int logtype, string[] logSplit, string log)
        {
            switch (logtype)
            {
                case (int)LOG_TYPE.LOGIN_RECORD:
                    if (Globals.LoginLogService != null)
                    {
                        await Task.Run(() => Globals.LoginLogService.ReadLoginLog(log));
                    }
                    break;
                case (int)LOG_TYPE.GAME_LOG:
                    if (Globals.LoginLogService != null)
                    {

                        await Task.Run(() => Distribute_LOG_8001(logtype, logSplit, log));
                    }
                    break;
                default:
                    break;
            }
        }

        private static void Distribute_LOG_8001(int logtype, string[] logSplit, string log)
        {
            if (logtype == (int)LOG_TYPE.GAME_LOG)
            {
                if (logSplit[2] != null)
                {
                    int _gameLogType = int.Parse(logSplit[2]);
                    switch (_gameLogType)
                    {
                        case (int)GAMELOG_TYPE.PK_LOG:
                            Globals.PKShoutService.ReadLoginLog(log);
                            break;
                        default:
                            break;
                    }
                }

            }
        }
    }
}
