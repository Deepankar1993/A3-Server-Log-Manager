namespace BackendManager
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.lblServerListen = new System.Windows.Forms.Label();
            this.btnLoginlogServiceStart = new System.Windows.Forms.Button();
            this.lstServerLog = new System.Windows.Forms.ListView();
            this.colLogList = new System.Windows.Forms.ColumnHeader();
            this.txtLogView = new System.Windows.Forms.RichTextBox();
            this.btnLoginlogServiceClose = new System.Windows.Forms.Button();
            this.lstOnlinePlayer = new System.Windows.Forms.ListView();
            this.pName = new System.Windows.Forms.ColumnHeader();
            this.pAccount = new System.Windows.Forms.ColumnHeader();
            this.pIP = new System.Windows.Forms.ColumnHeader();
            this.pLoginDate = new System.Windows.Forms.ColumnHeader();
            this.pLoginTime = new System.Windows.Forms.ColumnHeader();
            this.pPing = new System.Windows.Forms.ColumnHeader();
            this.tabCtrlOnlineLog = new System.Windows.Forms.TabControl();
            this.tabOnlinePlayerPage = new System.Windows.Forms.TabPage();
            this.tabOnlinePlayerLogPage = new System.Windows.Forms.TabPage();
            this.btnClearLoginLog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabASManager = new System.Windows.Forms.TabControl();
            this.tabOnlinePlayerManagerPage = new System.Windows.Forms.TabPage();
            this.tab_AS_Manager = new System.Windows.Forms.TabPage();
            this.btnUpdateAsMSG = new System.Windows.Forms.Button();
            this.btnDeleteASMessage = new System.Windows.Forms.Button();
            this.btnAddAsMessage = new System.Windows.Forms.Button();
            this.txt_MsgData = new System.Windows.Forms.TextBox();
            this.btn_AS_Service_Close = new System.Windows.Forms.Button();
            this.btn_AS_Service_Start = new System.Windows.Forms.Button();
            this.btn_reload_asMessages = new System.Windows.Forms.Button();
            this.btnSetInterval = new System.Windows.Forms.Button();
            this.lvlInterval = new System.Windows.Forms.Label();
            this.txtASinterval = new System.Windows.Forms.TextBox();
            this.AS_Msg_List = new System.Windows.Forms.ListBox();
            this.tabPVP = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPVPAlerts = new System.Windows.Forms.TabPage();
            this.lstbox_PVP_Shout = new System.Windows.Forms.ListBox();
            this.tabPVPLogs = new System.Windows.Forms.TabPage();
            this.lstbox_PVPLOG = new System.Windows.Forms.ListBox();
            this.btnMSLogServerClose = new System.Windows.Forms.Button();
            this.btnMSLogServerStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlayerOnlineCount = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.as_Send_Timer = new System.Windows.Forms.Timer(this.components);
            this.lst_ALL_LOG = new System.Windows.Forms.ListBox();
            this.btnZSGameLogServiceStart = new System.Windows.Forms.Button();
            this.btnZSGameLogServiceClose = new System.Windows.Forms.Button();
            this.btnMSClientStart = new System.Windows.Forms.Button();
            this.btnMSClientClose = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.btn_PVPService_Stop = new System.Windows.Forms.Button();
            this.btn_PVPService_Start = new System.Windows.Forms.Button();
            this.tabCtrlOnlineLog.SuspendLayout();
            this.tabOnlinePlayerPage.SuspendLayout();
            this.tabOnlinePlayerLogPage.SuspendLayout();
            this.tabASManager.SuspendLayout();
            this.tabOnlinePlayerManagerPage.SuspendLayout();
            this.tab_AS_Manager.SuspendLayout();
            this.tabPVP.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPVPAlerts.SuspendLayout();
            this.tabPVPLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServerListen
            // 
            resources.ApplyResources(this.lblServerListen, "lblServerListen");
            this.lblServerListen.Name = "lblServerListen";
            this.lblServerListen.Click += new System.EventHandler(this.lblServerListen_Click);
            // 
            // btnLoginlogServiceStart
            // 
            resources.ApplyResources(this.btnLoginlogServiceStart, "btnLoginlogServiceStart");
            this.btnLoginlogServiceStart.Name = "btnLoginlogServiceStart";
            this.btnLoginlogServiceStart.UseVisualStyleBackColor = true;
            this.btnLoginlogServiceStart.Click += new System.EventHandler(this.btnLoginlogServiceStart_Click);
            // 
            // lstServerLog
            // 
            resources.ApplyResources(this.lstServerLog, "lstServerLog");
            this.lstServerLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLogList});
            this.lstServerLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstServerLog.HideSelection = false;
            this.lstServerLog.Name = "lstServerLog";
            this.lstServerLog.UseCompatibleStateImageBehavior = false;
            this.lstServerLog.View = System.Windows.Forms.View.Details;
            this.lstServerLog.SelectedIndexChanged += new System.EventHandler(this.lstServerLog_SelectedIndexChanged);
            // 
            // colLogList
            // 
            resources.ApplyResources(this.colLogList, "colLogList");
            // 
            // txtLogView
            // 
            resources.ApplyResources(this.txtLogView, "txtLogView");
            this.txtLogView.Name = "txtLogView";
            // 
            // btnLoginlogServiceClose
            // 
            resources.ApplyResources(this.btnLoginlogServiceClose, "btnLoginlogServiceClose");
            this.btnLoginlogServiceClose.Name = "btnLoginlogServiceClose";
            this.btnLoginlogServiceClose.UseVisualStyleBackColor = true;
            this.btnLoginlogServiceClose.Click += new System.EventHandler(this.btnDisconnectMSLogServer_Click);
            // 
            // lstOnlinePlayer
            // 
            resources.ApplyResources(this.lstOnlinePlayer, "lstOnlinePlayer");
            this.lstOnlinePlayer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pName,
            this.pAccount,
            this.pIP,
            this.pLoginDate,
            this.pLoginTime,
            this.pPing});
            this.lstOnlinePlayer.HideSelection = false;
            this.lstOnlinePlayer.Name = "lstOnlinePlayer";
            this.lstOnlinePlayer.UseCompatibleStateImageBehavior = false;
            this.lstOnlinePlayer.View = System.Windows.Forms.View.Details;
            // 
            // pName
            // 
            resources.ApplyResources(this.pName, "pName");
            // 
            // pAccount
            // 
            resources.ApplyResources(this.pAccount, "pAccount");
            // 
            // pIP
            // 
            resources.ApplyResources(this.pIP, "pIP");
            // 
            // pLoginDate
            // 
            resources.ApplyResources(this.pLoginDate, "pLoginDate");
            // 
            // pLoginTime
            // 
            resources.ApplyResources(this.pLoginTime, "pLoginTime");
            // 
            // pPing
            // 
            resources.ApplyResources(this.pPing, "pPing");
            // 
            // tabCtrlOnlineLog
            // 
            resources.ApplyResources(this.tabCtrlOnlineLog, "tabCtrlOnlineLog");
            this.tabCtrlOnlineLog.Controls.Add(this.tabOnlinePlayerPage);
            this.tabCtrlOnlineLog.Controls.Add(this.tabOnlinePlayerLogPage);
            this.tabCtrlOnlineLog.Multiline = true;
            this.tabCtrlOnlineLog.Name = "tabCtrlOnlineLog";
            this.tabCtrlOnlineLog.SelectedIndex = 0;
            // 
            // tabOnlinePlayerPage
            // 
            resources.ApplyResources(this.tabOnlinePlayerPage, "tabOnlinePlayerPage");
            this.tabOnlinePlayerPage.Controls.Add(this.lstOnlinePlayer);
            this.tabOnlinePlayerPage.Name = "tabOnlinePlayerPage";
            this.tabOnlinePlayerPage.UseVisualStyleBackColor = true;
            // 
            // tabOnlinePlayerLogPage
            // 
            resources.ApplyResources(this.tabOnlinePlayerLogPage, "tabOnlinePlayerLogPage");
            this.tabOnlinePlayerLogPage.Controls.Add(this.btnClearLoginLog);
            this.tabOnlinePlayerLogPage.Controls.Add(this.txtLogView);
            this.tabOnlinePlayerLogPage.Controls.Add(this.lstServerLog);
            this.tabOnlinePlayerLogPage.Name = "tabOnlinePlayerLogPage";
            this.tabOnlinePlayerLogPage.UseVisualStyleBackColor = true;
            // 
            // btnClearLoginLog
            // 
            resources.ApplyResources(this.btnClearLoginLog, "btnClearLoginLog");
            this.btnClearLoginLog.Name = "btnClearLoginLog";
            this.btnClearLoginLog.UseVisualStyleBackColor = true;
            this.btnClearLoginLog.Click += new System.EventHandler(this.btnClearLoginLog_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabASManager
            // 
            resources.ApplyResources(this.tabASManager, "tabASManager");
            this.tabASManager.Controls.Add(this.tabOnlinePlayerManagerPage);
            this.tabASManager.Controls.Add(this.tab_AS_Manager);
            this.tabASManager.Controls.Add(this.tabPVP);
            this.tabASManager.Name = "tabASManager";
            this.tabASManager.SelectedIndex = 2;
            this.tabASManager.SelectedIndexChanged += new System.EventHandler(this.tabCtrlManager_SelectedIndexChanged_1);
            // 
            // tabOnlinePlayerManagerPage
            // 
            resources.ApplyResources(this.tabOnlinePlayerManagerPage, "tabOnlinePlayerManagerPage");
            this.tabOnlinePlayerManagerPage.Controls.Add(this.label2);
            this.tabOnlinePlayerManagerPage.Controls.Add(this.tabCtrlOnlineLog);
            this.tabOnlinePlayerManagerPage.Controls.Add(this.lblServerListen);
            this.tabOnlinePlayerManagerPage.Controls.Add(this.btnLoginlogServiceStart);
            this.tabOnlinePlayerManagerPage.Controls.Add(this.btnLoginlogServiceClose);
            this.tabOnlinePlayerManagerPage.Name = "tabOnlinePlayerManagerPage";
            this.tabOnlinePlayerManagerPage.UseVisualStyleBackColor = true;
            // 
            // tab_AS_Manager
            // 
            resources.ApplyResources(this.tab_AS_Manager, "tab_AS_Manager");
            this.tab_AS_Manager.Controls.Add(this.btnUpdateAsMSG);
            this.tab_AS_Manager.Controls.Add(this.btnDeleteASMessage);
            this.tab_AS_Manager.Controls.Add(this.btnAddAsMessage);
            this.tab_AS_Manager.Controls.Add(this.txt_MsgData);
            this.tab_AS_Manager.Controls.Add(this.btn_AS_Service_Close);
            this.tab_AS_Manager.Controls.Add(this.btn_AS_Service_Start);
            this.tab_AS_Manager.Controls.Add(this.btn_reload_asMessages);
            this.tab_AS_Manager.Controls.Add(this.btnSetInterval);
            this.tab_AS_Manager.Controls.Add(this.lvlInterval);
            this.tab_AS_Manager.Controls.Add(this.txtASinterval);
            this.tab_AS_Manager.Controls.Add(this.AS_Msg_List);
            this.tab_AS_Manager.Name = "tab_AS_Manager";
            this.tab_AS_Manager.UseVisualStyleBackColor = true;
            // 
            // btnUpdateAsMSG
            // 
            resources.ApplyResources(this.btnUpdateAsMSG, "btnUpdateAsMSG");
            this.btnUpdateAsMSG.Name = "btnUpdateAsMSG";
            this.btnUpdateAsMSG.UseVisualStyleBackColor = true;
            this.btnUpdateAsMSG.Click += new System.EventHandler(this.btnUpdateAsMSG_Click);
            // 
            // btnDeleteASMessage
            // 
            resources.ApplyResources(this.btnDeleteASMessage, "btnDeleteASMessage");
            this.btnDeleteASMessage.Name = "btnDeleteASMessage";
            this.btnDeleteASMessage.UseVisualStyleBackColor = true;
            this.btnDeleteASMessage.Click += new System.EventHandler(this.btnDeleteASMessage_Click);
            // 
            // btnAddAsMessage
            // 
            resources.ApplyResources(this.btnAddAsMessage, "btnAddAsMessage");
            this.btnAddAsMessage.Name = "btnAddAsMessage";
            this.btnAddAsMessage.UseVisualStyleBackColor = true;
            this.btnAddAsMessage.Click += new System.EventHandler(this.btnAddAsMessage_Click);
            // 
            // txt_MsgData
            // 
            resources.ApplyResources(this.txt_MsgData, "txt_MsgData");
            this.txt_MsgData.Name = "txt_MsgData";
            // 
            // btn_AS_Service_Close
            // 
            resources.ApplyResources(this.btn_AS_Service_Close, "btn_AS_Service_Close");
            this.btn_AS_Service_Close.Name = "btn_AS_Service_Close";
            this.btn_AS_Service_Close.UseVisualStyleBackColor = true;
            this.btn_AS_Service_Close.Click += new System.EventHandler(this.btn_StopAnnouncementService_Click);
            // 
            // btn_AS_Service_Start
            // 
            resources.ApplyResources(this.btn_AS_Service_Start, "btn_AS_Service_Start");
            this.btn_AS_Service_Start.Name = "btn_AS_Service_Start";
            this.btn_AS_Service_Start.UseVisualStyleBackColor = true;
            this.btn_AS_Service_Start.Click += new System.EventHandler(this.btn_Start_AS_Service_Click);
            // 
            // btn_reload_asMessages
            // 
            resources.ApplyResources(this.btn_reload_asMessages, "btn_reload_asMessages");
            this.btn_reload_asMessages.Name = "btn_reload_asMessages";
            this.btn_reload_asMessages.UseVisualStyleBackColor = true;
            this.btn_reload_asMessages.Click += new System.EventHandler(this.btn_reload_asMessages_ClickAsync);
            // 
            // btnSetInterval
            // 
            resources.ApplyResources(this.btnSetInterval, "btnSetInterval");
            this.btnSetInterval.Name = "btnSetInterval";
            this.btnSetInterval.UseVisualStyleBackColor = true;
            this.btnSetInterval.Click += new System.EventHandler(this.btnSetInterval_Click);
            // 
            // lvlInterval
            // 
            resources.ApplyResources(this.lvlInterval, "lvlInterval");
            this.lvlInterval.Name = "lvlInterval";
            // 
            // txtASinterval
            // 
            resources.ApplyResources(this.txtASinterval, "txtASinterval");
            this.txtASinterval.Name = "txtASinterval";
            // 
            // AS_Msg_List
            // 
            resources.ApplyResources(this.AS_Msg_List, "AS_Msg_List");
            this.AS_Msg_List.FormattingEnabled = true;
            this.AS_Msg_List.Name = "AS_Msg_List";
            this.AS_Msg_List.SelectedIndexChanged += new System.EventHandler(this.AS_Msg_List_SelectedIndexChanged);
            // 
            // tabPVP
            // 
            resources.ApplyResources(this.tabPVP, "tabPVP");
            this.tabPVP.Controls.Add(this.tabControl2);
            this.tabPVP.Name = "tabPVP";
            // 
            // tabControl2
            // 
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Controls.Add(this.tabPVPAlerts);
            this.tabControl2.Controls.Add(this.tabPVPLogs);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            // 
            // tabPVPAlerts
            // 
            resources.ApplyResources(this.tabPVPAlerts, "tabPVPAlerts");
            this.tabPVPAlerts.Controls.Add(this.lstbox_PVP_Shout);
            this.tabPVPAlerts.Name = "tabPVPAlerts";
            this.tabPVPAlerts.UseVisualStyleBackColor = true;
            // 
            // lstbox_PVP_Shout
            // 
            resources.ApplyResources(this.lstbox_PVP_Shout, "lstbox_PVP_Shout");
            this.lstbox_PVP_Shout.FormattingEnabled = true;
            this.lstbox_PVP_Shout.Name = "lstbox_PVP_Shout";
            // 
            // tabPVPLogs
            // 
            resources.ApplyResources(this.tabPVPLogs, "tabPVPLogs");
            this.tabPVPLogs.Controls.Add(this.lstbox_PVPLOG);
            this.tabPVPLogs.Name = "tabPVPLogs";
            this.tabPVPLogs.UseVisualStyleBackColor = true;
            // 
            // lstbox_PVPLOG
            // 
            resources.ApplyResources(this.lstbox_PVPLOG, "lstbox_PVPLOG");
            this.lstbox_PVPLOG.FormattingEnabled = true;
            this.lstbox_PVPLOG.Name = "lstbox_PVPLOG";
            // 
            // btnMSLogServerClose
            // 
            resources.ApplyResources(this.btnMSLogServerClose, "btnMSLogServerClose");
            this.btnMSLogServerClose.Name = "btnMSLogServerClose";
            this.btnMSLogServerClose.UseVisualStyleBackColor = true;
            this.btnMSLogServerClose.Click += new System.EventHandler(this.btnDisconnectMSLogServer_Click);
            // 
            // btnMSLogServerStart
            // 
            resources.ApplyResources(this.btnMSLogServerStart, "btnMSLogServerStart");
            this.btnMSLogServerStart.Name = "btnMSLogServerStart";
            this.btnMSLogServerStart.UseVisualStyleBackColor = true;
            this.btnMSLogServerStart.Click += new System.EventHandler(this.btnMSLogServerStart_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblPlayerOnlineCount
            // 
            resources.ApplyResources(this.lblPlayerOnlineCount, "lblPlayerOnlineCount");
            this.lblPlayerOnlineCount.Name = "lblPlayerOnlineCount";
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.HideSelection = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            // 
            // listView2
            // 
            resources.ApplyResources(this.listView2, "listView2");
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView2.HideSelection = false;
            this.listView2.Name = "listView2";
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            resources.ApplyResources(this.columnHeader7, "columnHeader7");
            // 
            // columnHeader8
            // 
            resources.ApplyResources(this.columnHeader8, "columnHeader8");
            // 
            // as_Send_Timer
            // 
            this.as_Send_Timer.Interval = 60000;
            this.as_Send_Timer.Tick += new System.EventHandler(this.as_Send_Timer_Tick);
            // 
            // lst_ALL_LOG
            // 
            resources.ApplyResources(this.lst_ALL_LOG, "lst_ALL_LOG");
            this.lst_ALL_LOG.FormattingEnabled = true;
            this.lst_ALL_LOG.Name = "lst_ALL_LOG";
            // 
            // btnZSGameLogServiceStart
            // 
            resources.ApplyResources(this.btnZSGameLogServiceStart, "btnZSGameLogServiceStart");
            this.btnZSGameLogServiceStart.Name = "btnZSGameLogServiceStart";
            this.btnZSGameLogServiceStart.UseVisualStyleBackColor = true;
            this.btnZSGameLogServiceStart.Click += new System.EventHandler(this.btnZSGameLogServiceStart_Click);
            // 
            // btnZSGameLogServiceClose
            // 
            resources.ApplyResources(this.btnZSGameLogServiceClose, "btnZSGameLogServiceClose");
            this.btnZSGameLogServiceClose.Name = "btnZSGameLogServiceClose";
            this.btnZSGameLogServiceClose.UseVisualStyleBackColor = true;
            this.btnZSGameLogServiceClose.Click += new System.EventHandler(this.btnZSGameLogServiceClose_Click);
            // 
            // btnMSClientStart
            // 
            resources.ApplyResources(this.btnMSClientStart, "btnMSClientStart");
            this.btnMSClientStart.Name = "btnMSClientStart";
            this.btnMSClientStart.UseVisualStyleBackColor = true;
            this.btnMSClientStart.Click += new System.EventHandler(this.btnMSClientStart_Click);
            // 
            // btnMSClientClose
            // 
            resources.ApplyResources(this.btnMSClientClose, "btnMSClientClose");
            this.btnMSClientClose.Name = "btnMSClientClose";
            this.btnMSClientClose.UseVisualStyleBackColor = true;
            this.btnMSClientClose.Click += new System.EventHandler(this.btnMSClientClose_Click);
            // 
            // listView3
            // 
            resources.ApplyResources(this.listView3, "listView3");
            this.listView3.HideSelection = false;
            this.listView3.Name = "listView3";
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            resources.ApplyResources(this.columnHeader10, "columnHeader10");
            // 
            // columnHeader11
            // 
            resources.ApplyResources(this.columnHeader11, "columnHeader11");
            // 
            // columnHeader12
            // 
            resources.ApplyResources(this.columnHeader12, "columnHeader12");
            // 
            // columnHeader13
            // 
            resources.ApplyResources(this.columnHeader13, "columnHeader13");
            // 
            // columnHeader14
            // 
            resources.ApplyResources(this.columnHeader14, "columnHeader14");
            // 
            // columnHeader15
            // 
            resources.ApplyResources(this.columnHeader15, "columnHeader15");
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            resources.ApplyResources(this.richTextBox2, "richTextBox2");
            this.richTextBox2.Name = "richTextBox2";
            // 
            // listView4
            // 
            resources.ApplyResources(this.listView4, "listView4");
            this.listView4.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView4.HideSelection = false;
            this.listView4.Name = "listView4";
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader16
            // 
            resources.ApplyResources(this.columnHeader16, "columnHeader16");
            // 
            // btn_PVPService_Stop
            // 
            resources.ApplyResources(this.btn_PVPService_Stop, "btn_PVPService_Stop");
            this.btn_PVPService_Stop.Name = "btn_PVPService_Stop";
            this.btn_PVPService_Stop.UseVisualStyleBackColor = true;
            this.btn_PVPService_Stop.Click += new System.EventHandler(this.btn_PVPService_Stop_Click);
            // 
            // btn_PVPService_Start
            // 
            resources.ApplyResources(this.btn_PVPService_Start, "btn_PVPService_Start");
            this.btn_PVPService_Start.Name = "btn_PVPService_Start";
            this.btn_PVPService_Start.UseVisualStyleBackColor = true;
            this.btn_PVPService_Start.Click += new System.EventHandler(this.btn_PVPService_Start_Click);
            // 
            // MainFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_PVPService_Start);
            this.Controls.Add(this.btn_PVPService_Stop);
            this.Controls.Add(this.btnMSClientClose);
            this.Controls.Add(this.btnMSClientStart);
            this.Controls.Add(this.btnZSGameLogServiceClose);
            this.Controls.Add(this.btnZSGameLogServiceStart);
            this.Controls.Add(this.lst_ALL_LOG);
            this.Controls.Add(this.lblPlayerOnlineCount);
            this.Controls.Add(this.btnMSLogServerClose);
            this.Controls.Add(this.btnMSLogServerStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabASManager);
            this.Name = "MainFrm";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.tabCtrlOnlineLog.ResumeLayout(false);
            this.tabOnlinePlayerPage.ResumeLayout(false);
            this.tabOnlinePlayerLogPage.ResumeLayout(false);
            this.tabASManager.ResumeLayout(false);
            this.tabOnlinePlayerManagerPage.ResumeLayout(false);
            this.tabOnlinePlayerManagerPage.PerformLayout();
            this.tab_AS_Manager.ResumeLayout(false);
            this.tab_AS_Manager.PerformLayout();
            this.tabPVP.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPVPAlerts.ResumeLayout(false);
            this.tabPVPLogs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerListen;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.ListView lstServerLog;
        private System.Windows.Forms.ColumnHeader colLogList;
        private System.Windows.Forms.RichTextBox txtLogView;
        private System.Windows.Forms.Button btnDisconnectListen;
        private System.Windows.Forms.TabControl tabCtrlOnlineLog;
        private System.Windows.Forms.TabPage tabOnlinePlayerPage;
        private System.Windows.Forms.TabPage tabOnlinePlayerLogPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabASManager;
        private System.Windows.Forms.TabPage tabOnlinePlayerManagerPage;
        private System.Windows.Forms.Button btnClearLoginLog;
        private System.Windows.Forms.ColumnHeader pName;
        private System.Windows.Forms.ColumnHeader pAccount;
        private System.Windows.Forms.ColumnHeader pIP;
        private System.Windows.Forms.ColumnHeader pLoginTime;
        private System.Windows.Forms.ColumnHeader pPing;
        private System.Windows.Forms.ColumnHeader pLoginDate;
        public System.Windows.Forms.ListView lstOnlinePlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlayerOnlineCount;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnMSLogServerClose;
        public System.Windows.Forms.Button btnMSLogServerStart;
        private System.Windows.Forms.Timer as_Send_Timer;
        public System.Windows.Forms.TabPage tab_AS_Manager;
        private System.Windows.Forms.ListBox AS_Msg_List;
        private System.Windows.Forms.Label lvlInterval;
        private System.Windows.Forms.TextBox txtASinterval;
        private System.Windows.Forms.Button btnSetInterval;
        private System.Windows.Forms.Button btn_reload_asMessages;
        private System.Windows.Forms.Button btn_AS_Service_Start;
        private System.Windows.Forms.Button btn_AS_Service_Close;
        private System.Windows.Forms.Button btnAddAsMessage;
        private System.Windows.Forms.TextBox txt_MsgData;
        private System.Windows.Forms.Button btnDeleteASMessage;
        private System.Windows.Forms.Button btnUpdateAsMSG;
        private System.Windows.Forms.ListBox lst_ALL_LOG;
        private System.Windows.Forms.Button btnLoginlogServiceStart;
        private System.Windows.Forms.Button btnLoginlogServiceClose;
        private System.Windows.Forms.Button btnZSGameLogServiceStart;
        private System.Windows.Forms.Button btnZSGameLogServiceClose;
        private System.Windows.Forms.Button btnMSClientStart;
        private System.Windows.Forms.Button btnMSClientClose;
        private System.Windows.Forms.TabPage tabPVP;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPVPAlerts;
        private System.Windows.Forms.TabPage tabPVPLogs;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Button btn_PVPService_Stop;
        private System.Windows.Forms.Button btn_PVPService_Start;
        private System.Windows.Forms.ListBox lstbox_PVP_Shout;
        private System.Windows.Forms.ListBox lstbox_PVPLOG;
    }
}
