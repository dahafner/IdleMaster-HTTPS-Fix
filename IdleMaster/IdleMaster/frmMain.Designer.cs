using System.ComponentModel;
using System.Windows.Forms;

namespace IdleMaster
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.LblCookieStatus = new System.Windows.Forms.Label();
            this.TmrCheckCookieData = new System.Windows.Forms.Timer(this.components);
            this.LblSteamStatus = new System.Windows.Forms.Label();
            this.TmrCheckSteam = new System.Windows.Forms.Timer(this.components);
            this.LnkResetCookies = new System.Windows.Forms.LinkLabel();
            this.LnkSignIn = new System.Windows.Forms.LinkLabel();
            this.LblDrops = new System.Windows.Forms.Label();
            this.LblIdle = new System.Windows.Forms.Label();
            this.LblCurrentStatus = new System.Windows.Forms.Label();
            this.LblCurrentRemaining = new System.Windows.Forms.Label();
            this.LblGameName = new System.Windows.Forms.LinkLabel();
            this.MnuTop = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileBlacklist = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuGamePause = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuGameResume = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuGameSkip = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuGameSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MnuGameBlacklist = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelpStats = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelpChangelog = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelpOfficial = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuHelpSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.TmrReadyToGo = new System.Windows.Forms.Timer(this.components);
            this.TmrCardDropCheck = new System.Windows.Forms.Timer(this.components);
            this.StrFooter = new System.Windows.Forms.StatusStrip();
            this.PgrIdle = new System.Windows.Forms.ToolStripProgressBar();
            this.LblNextCheck = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.PbxReadingPage = new System.Windows.Forms.PictureBox();
            this.BtnSkip = new System.Windows.Forms.Button();
            this.PbxIdleStatus = new System.Windows.Forms.PictureBox();
            this.PbxCookieStatus = new System.Windows.Forms.PictureBox();
            this.PbxSteamStatus = new System.Windows.Forms.PictureBox();
            this.PbxApp = new System.Windows.Forms.PictureBox();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnResume = new System.Windows.Forms.Button();
            this.TmrStartNext = new System.Windows.Forms.Timer(this.components);
            this.TmrBadgeReload = new System.Windows.Forms.Timer(this.components);
            this.LblSignedOnAs = new System.Windows.Forms.Label();
            this.GamesState = new System.Windows.Forms.ListView();
            this.GameName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LblHoursPlayed = new System.Windows.Forms.Label();
            this.TmrStatistics = new System.Windows.Forms.Timer(this.components);
            this.MnuTop.SuspendLayout();
            this.StrFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxReadingPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxIdleStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCookieStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSteamStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxApp)).BeginInit();
            this.SuspendLayout();
            // 
            // LblCookieStatus
            // 
            this.LblCookieStatus.AutoSize = true;
            this.LblCookieStatus.Location = new System.Drawing.Point(31, 59);
            this.LblCookieStatus.Name = "LblCookieStatus";
            this.LblCookieStatus.Size = new System.Drawing.Size(186, 13);
            this.LblCookieStatus.TabIndex = 0;
            this.LblCookieStatus.Text = "Idle Master is not connected to Steam";
            // 
            // TmrCheckCookieData
            // 
            this.TmrCheckCookieData.Enabled = true;
            this.TmrCheckCookieData.Tick += new System.EventHandler(this.TmrCheckCookieData_Tick);
            // 
            // LblSteamStatus
            // 
            this.LblSteamStatus.AutoSize = true;
            this.LblSteamStatus.Location = new System.Drawing.Point(30, 37);
            this.LblSteamStatus.Name = "LblSteamStatus";
            this.LblSteamStatus.Size = new System.Drawing.Size(103, 13);
            this.LblSteamStatus.TabIndex = 3;
            this.LblSteamStatus.Text = "Steam is not running";
            // 
            // TmrCheckSteam
            // 
            this.TmrCheckSteam.Enabled = true;
            this.TmrCheckSteam.Interval = 500;
            this.TmrCheckSteam.Tick += new System.EventHandler(this.TmrCheckSteam_Tick);
            // 
            // LnkResetCookies
            // 
            this.LnkResetCookies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LnkResetCookies.AutoSize = true;
            this.LnkResetCookies.Location = new System.Drawing.Point(198, 59);
            this.LnkResetCookies.Name = "LnkResetCookies";
            this.LnkResetCookies.Size = new System.Drawing.Size(52, 13);
            this.LnkResetCookies.TabIndex = 4;
            this.LnkResetCookies.TabStop = true;
            this.LnkResetCookies.Text = "(Sign out)";
            this.LnkResetCookies.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkResetCookies_LinkClicked);
            // 
            // LnkSignIn
            // 
            this.LnkSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LnkSignIn.AutoSize = true;
            this.LnkSignIn.Location = new System.Drawing.Point(208, 59);
            this.LnkSignIn.Name = "LnkSignIn";
            this.LnkSignIn.Size = new System.Drawing.Size(45, 13);
            this.LnkSignIn.TabIndex = 5;
            this.LnkSignIn.TabStop = true;
            this.LnkSignIn.Text = "(Sign in)";
            this.LnkSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSignIn_LinkClicked);
            // 
            // LblDrops
            // 
            this.LblDrops.AutoSize = true;
            this.LblDrops.Location = new System.Drawing.Point(31, 92);
            this.LblDrops.Name = "LblDrops";
            this.LblDrops.Size = new System.Drawing.Size(105, 13);
            this.LblDrops.TabIndex = 9;
            this.LblDrops.Text = "card drops remaining";
            this.LblDrops.Visible = false;
            // 
            // LblIdle
            // 
            this.LblIdle.AutoSize = true;
            this.LblIdle.Location = new System.Drawing.Point(31, 108);
            this.LblIdle.Name = "LblIdle";
            this.LblIdle.Size = new System.Drawing.Size(86, 13);
            this.LblIdle.TabIndex = 10;
            this.LblIdle.Text = "games left to idle";
            this.LblIdle.Visible = false;
            // 
            // LblCurrentStatus
            // 
            this.LblCurrentStatus.Location = new System.Drawing.Point(15, 135);
            this.LblCurrentStatus.Name = "LblCurrentStatus";
            this.LblCurrentStatus.Size = new System.Drawing.Size(88, 13);
            this.LblCurrentStatus.TabIndex = 11;
            this.LblCurrentStatus.Text = "Currently in-game";
            // 
            // LblCurrentRemaining
            // 
            this.LblCurrentRemaining.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCurrentRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrentRemaining.ForeColor = System.Drawing.Color.Blue;
            this.LblCurrentRemaining.Location = new System.Drawing.Point(15, 292);
            this.LblCurrentRemaining.Name = "LblCurrentRemaining";
            this.LblCurrentRemaining.Size = new System.Drawing.Size(279, 20);
            this.LblCurrentRemaining.TabIndex = 12;
            this.LblCurrentRemaining.Text = "3 card drops remaining";
            this.LblCurrentRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblCurrentRemaining.Click += new System.EventHandler(this.LblCurrentRemaining_Click);
            // 
            // LblGameName
            // 
            this.LblGameName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblGameName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblGameName.Location = new System.Drawing.Point(98, 135);
            this.LblGameName.Name = "LblGameName";
            this.LblGameName.Size = new System.Drawing.Size(159, 15);
            this.LblGameName.TabIndex = 16;
            this.LblGameName.TabStop = true;
            this.LblGameName.Text = "Game Name";
            this.LblGameName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblGameName_LinkClicked);
            // 
            // MnuTop
            // 
            this.MnuTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MnuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MnuGame,
            this.MnuHelp});
            this.MnuTop.Location = new System.Drawing.Point(0, 0);
            this.MnuTop.Name = "MnuTop";
            this.MnuTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MnuTop.Size = new System.Drawing.Size(308, 24);
            this.MnuTop.TabIndex = 19;
            this.MnuTop.Text = "menuStrip1";
            // 
            // MnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFileSettings,
            this.MnuFileBlacklist,
            this.MnuFileSeparator,
            this.MnuFileExit});
            this.MnuFile.Name = "MnuFile";
            this.MnuFile.Size = new System.Drawing.Size(37, 20);
            this.MnuFile.Text = "&File";
            // 
            // MnuFileSettings
            // 
            this.MnuFileSettings.Image = global::IdleMaster.Properties.Resources.imgSettings;
            this.MnuFileSettings.Name = "MnuFileSettings";
            this.MnuFileSettings.Size = new System.Drawing.Size(117, 22);
            this.MnuFileSettings.Text = "&Settings";
            this.MnuFileSettings.Click += new System.EventHandler(this.MnuFileSettings_Click);
            // 
            // MnuFileBlacklist
            // 
            this.MnuFileBlacklist.Image = global::IdleMaster.Properties.Resources.imgBlacklist;
            this.MnuFileBlacklist.Name = "MnuFileBlacklist";
            this.MnuFileBlacklist.Size = new System.Drawing.Size(117, 22);
            this.MnuFileBlacklist.Text = "&Blacklist";
            this.MnuFileBlacklist.Click += new System.EventHandler(this.MnuFileBlacklist_Click);
            // 
            // MnuFileSeparator
            // 
            this.MnuFileSeparator.Name = "MnuFileSeparator";
            this.MnuFileSeparator.Size = new System.Drawing.Size(114, 6);
            // 
            // MnuFileExit
            // 
            this.MnuFileExit.Image = global::IdleMaster.Properties.Resources.imgExit;
            this.MnuFileExit.Name = "MnuFileExit";
            this.MnuFileExit.Size = new System.Drawing.Size(117, 22);
            this.MnuFileExit.Text = "E&xit";
            this.MnuFileExit.Click += new System.EventHandler(this.MnuFileExit_Click);
            // 
            // MnuGame
            // 
            this.MnuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuGamePause,
            this.MnuGameResume,
            this.MnuGameSkip,
            this.MnuGameSeparator,
            this.MnuGameBlacklist});
            this.MnuGame.Name = "MnuGame";
            this.MnuGame.Size = new System.Drawing.Size(50, 20);
            this.MnuGame.Text = "&Game";
            // 
            // MnuGamePause
            // 
            this.MnuGamePause.Image = ((System.Drawing.Image)(resources.GetObject("MnuGamePause.Image")));
            this.MnuGamePause.Name = "MnuGamePause";
            this.MnuGamePause.Size = new System.Drawing.Size(194, 22);
            this.MnuGamePause.Text = "&Pause Idling";
            this.MnuGamePause.Click += new System.EventHandler(this.MnuGamePause_Click);
            // 
            // MnuGameResume
            // 
            this.MnuGameResume.Enabled = false;
            this.MnuGameResume.Image = ((System.Drawing.Image)(resources.GetObject("MnuGameResume.Image")));
            this.MnuGameResume.Name = "MnuGameResume";
            this.MnuGameResume.Size = new System.Drawing.Size(194, 22);
            this.MnuGameResume.Text = "Resume Idling";
            this.MnuGameResume.Click += new System.EventHandler(this.MnuGameResume_Click);
            // 
            // MnuGameSkip
            // 
            this.MnuGameSkip.Image = ((System.Drawing.Image)(resources.GetObject("MnuGameSkip.Image")));
            this.MnuGameSkip.Name = "MnuGameSkip";
            this.MnuGameSkip.Size = new System.Drawing.Size(194, 22);
            this.MnuGameSkip.Text = "&Skip Current Game";
            this.MnuGameSkip.Click += new System.EventHandler(this.MnuGameSkip_Click);
            // 
            // MnuGameSeparator
            // 
            this.MnuGameSeparator.Name = "MnuGameSeparator";
            this.MnuGameSeparator.Size = new System.Drawing.Size(191, 6);
            // 
            // MnuGameBlacklist
            // 
            this.MnuGameBlacklist.Image = global::IdleMaster.Properties.Resources.imgBlacklist;
            this.MnuGameBlacklist.Name = "MnuGameBlacklist";
            this.MnuGameBlacklist.Size = new System.Drawing.Size(194, 22);
            this.MnuGameBlacklist.Text = "&Blacklist Current Game";
            this.MnuGameBlacklist.Click += new System.EventHandler(this.MnuGameBlacklist_Click);
            // 
            // MnuHelp
            // 
            this.MnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuHelpStats,
            this.MnuHelpChangelog,
            this.MnuHelpOfficial,
            this.MnuHelpSeparator,
            this.MnuHelpAbout});
            this.MnuHelp.Name = "MnuHelp";
            this.MnuHelp.Size = new System.Drawing.Size(44, 20);
            this.MnuHelp.Text = "&Help";
            // 
            // MnuHelpStats
            // 
            this.MnuHelpStats.Image = global::IdleMaster.Properties.Resources.imgStatistics;
            this.MnuHelpStats.Name = "MnuHelpStats";
            this.MnuHelpStats.Size = new System.Drawing.Size(184, 26);
            this.MnuHelpStats.Text = "&Statistics";
            this.MnuHelpStats.Click += new System.EventHandler(this.MnuHelpStatistics_Click);
            // 
            // MnuHelpChangelog
            // 
            this.MnuHelpChangelog.Image = global::IdleMaster.Properties.Resources.imgDocument;
            this.MnuHelpChangelog.Name = "MnuHelpChangelog";
            this.MnuHelpChangelog.Size = new System.Drawing.Size(184, 26);
            this.MnuHelpChangelog.Text = "&Release Notes";
            this.MnuHelpChangelog.Click += new System.EventHandler(this.MnuHelpChangelog_Click);
            // 
            // MnuHelpOfficial
            // 
            this.MnuHelpOfficial.Image = global::IdleMaster.Properties.Resources.imgGlobe;
            this.MnuHelpOfficial.Name = "MnuHelpOfficial";
            this.MnuHelpOfficial.Size = new System.Drawing.Size(184, 26);
            this.MnuHelpOfficial.Text = "&Official Group";
            this.MnuHelpOfficial.Click += new System.EventHandler(this.MnuHelpOfficial_Click);
            // 
            // MnuHelpSeparator
            // 
            this.MnuHelpSeparator.Name = "MnuHelpSeparator";
            this.MnuHelpSeparator.Size = new System.Drawing.Size(181, 6);
            // 
            // MnuHelpAbout
            // 
            this.MnuHelpAbout.Image = global::IdleMaster.Properties.Resources.imgInfo;
            this.MnuHelpAbout.Name = "MnuHelpAbout";
            this.MnuHelpAbout.Size = new System.Drawing.Size(184, 26);
            this.MnuHelpAbout.Text = "&About";
            this.MnuHelpAbout.Click += new System.EventHandler(this.MnuHelpAbout_Click);
            // 
            // TmrReadyToGo
            // 
            this.TmrReadyToGo.Enabled = true;
            this.TmrReadyToGo.Tick += new System.EventHandler(this.TmrReadyToGo_Tick);
            // 
            // TmrCardDropCheck
            // 
            this.TmrCardDropCheck.Interval = 1000;
            this.TmrCardDropCheck.Tick += new System.EventHandler(this.TmrCardDropCheck_Tick);
            // 
            // StrFooter
            // 
            this.StrFooter.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StrFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PgrIdle,
            this.LblNextCheck,
            this.LblTimer});
            this.StrFooter.Location = new System.Drawing.Point(0, 314);
            this.StrFooter.Name = "StrFooter";
            this.StrFooter.ShowItemToolTips = true;
            this.StrFooter.Size = new System.Drawing.Size(308, 22);
            this.StrFooter.SizingGrip = false;
            this.StrFooter.TabIndex = 20;
            this.StrFooter.Text = "statusStrip1";
            this.StrFooter.Visible = false;
            // 
            // PgrIdle
            // 
            this.PgrIdle.Name = "PgrIdle";
            this.PgrIdle.Size = new System.Drawing.Size(130, 16);
            // 
            // LblNextCheck
            // 
            this.LblNextCheck.AutoSize = false;
            this.LblNextCheck.Name = "LblNextCheck";
            this.LblNextCheck.Size = new System.Drawing.Size(115, 17);
            this.LblNextCheck.Text = "Next check";
            this.LblNextCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTimer
            // 
            this.LblTimer.Name = "LblTimer";
            this.LblTimer.Size = new System.Drawing.Size(34, 17);
            this.LblTimer.Text = "15:00";
            // 
            // PbxReadingPage
            // 
            this.PbxReadingPage.Image = global::IdleMaster.Properties.Resources.imgSpin;
            this.PbxReadingPage.Location = new System.Drawing.Point(15, 90);
            this.PbxReadingPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PbxReadingPage.Name = "PbxReadingPage";
            this.PbxReadingPage.Size = new System.Drawing.Size(15, 15);
            this.PbxReadingPage.TabIndex = 26;
            this.PbxReadingPage.TabStop = false;
            this.PbxReadingPage.Visible = false;
            // 
            // BtnSkip
            // 
            this.BtnSkip.Image = global::IdleMaster.Properties.Resources.imgSkipSmall;
            this.BtnSkip.Location = new System.Drawing.Point(274, 135);
            this.BtnSkip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSkip.Name = "BtnSkip";
            this.BtnSkip.Size = new System.Drawing.Size(15, 15);
            this.BtnSkip.TabIndex = 23;
            this.BtnSkip.UseVisualStyleBackColor = true;
            this.BtnSkip.Click += new System.EventHandler(this.BtnSkip_Click);
            // 
            // PbxIdleStatus
            // 
            this.PbxIdleStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxIdleStatus.Location = new System.Drawing.Point(290, 315);
            this.PbxIdleStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PbxIdleStatus.Name = "PbxIdleStatus";
            this.PbxIdleStatus.Size = new System.Drawing.Size(15, 15);
            this.PbxIdleStatus.TabIndex = 15;
            this.PbxIdleStatus.TabStop = false;
            // 
            // PbxCookieStatus
            // 
            this.PbxCookieStatus.Location = new System.Drawing.Point(15, 57);
            this.PbxCookieStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PbxCookieStatus.Name = "PbxCookieStatus";
            this.PbxCookieStatus.Size = new System.Drawing.Size(15, 15);
            this.PbxCookieStatus.TabIndex = 8;
            this.PbxCookieStatus.TabStop = false;
            // 
            // PbxSteamStatus
            // 
            this.PbxSteamStatus.Location = new System.Drawing.Point(15, 34);
            this.PbxSteamStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PbxSteamStatus.Name = "PbxSteamStatus";
            this.PbxSteamStatus.Size = new System.Drawing.Size(15, 15);
            this.PbxSteamStatus.TabIndex = 7;
            this.PbxSteamStatus.TabStop = false;
            // 
            // PbxApp
            // 
            this.PbxApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxApp.Location = new System.Drawing.Point(15, 154);
            this.PbxApp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PbxApp.Name = "PbxApp";
            this.PbxApp.Size = new System.Drawing.Size(274, 138);
            this.PbxApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxApp.TabIndex = 6;
            this.PbxApp.TabStop = false;
            this.PbxApp.Visible = false;
            // 
            // BtnPause
            // 
            this.BtnPause.Image = global::IdleMaster.Properties.Resources.imgPauseSmall;
            this.BtnPause.Location = new System.Drawing.Point(259, 135);
            this.BtnPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(15, 15);
            this.BtnPause.TabIndex = 22;
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnResume
            // 
            this.BtnResume.Image = global::IdleMaster.Properties.Resources.imgPlaySmall;
            this.BtnResume.Location = new System.Drawing.Point(259, 135);
            this.BtnResume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnResume.Name = "BtnResume";
            this.BtnResume.Size = new System.Drawing.Size(15, 15);
            this.BtnResume.TabIndex = 24;
            this.BtnResume.UseVisualStyleBackColor = true;
            this.BtnResume.Visible = false;
            this.BtnResume.Click += new System.EventHandler(this.BtnResume_Click);
            // 
            // TmrStartNext
            // 
            this.TmrStartNext.Tick += new System.EventHandler(this.TmrStartNext_Tick);
            // 
            // TmrBadgeReload
            // 
            this.TmrBadgeReload.Interval = 1000;
            this.TmrBadgeReload.Tick += new System.EventHandler(this.TmrBadgeReload_Tick);
            // 
            // LblSignedOnAs
            // 
            this.LblSignedOnAs.AutoSize = true;
            this.LblSignedOnAs.Location = new System.Drawing.Point(30, 72);
            this.LblSignedOnAs.Name = "LblSignedOnAs";
            this.LblSignedOnAs.Size = new System.Drawing.Size(65, 13);
            this.LblSignedOnAs.TabIndex = 27;
            this.LblSignedOnAs.Text = "Signed in as";
            this.LblSignedOnAs.Visible = false;
            // 
            // GamesState
            // 
            this.GamesState.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GameName,
            this.Hours});
            this.GamesState.HideSelection = false;
            this.GamesState.Location = new System.Drawing.Point(15, 154);
            this.GamesState.Margin = new System.Windows.Forms.Padding(2);
            this.GamesState.Name = "GamesState";
            this.GamesState.Size = new System.Drawing.Size(275, 139);
            this.GamesState.TabIndex = 28;
            this.GamesState.UseCompatibleStateImageBehavior = false;
            this.GamesState.View = System.Windows.Forms.View.Details;
            this.GamesState.Visible = false;
            // 
            // GameName
            // 
            this.GameName.Tag = "";
            this.GameName.Text = "Name";
            this.GameName.Width = 200;
            // 
            // Hours
            // 
            this.Hours.Text = "Hours";
            this.Hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Hours.Width = 45;
            // 
            // LblHoursPlayed
            // 
            this.LblHoursPlayed.AutoSize = true;
            this.LblHoursPlayed.Location = new System.Drawing.Point(15, 295);
            this.LblHoursPlayed.Name = "LblHoursPlayed";
            this.LblHoursPlayed.Size = new System.Drawing.Size(0, 13);
            this.LblHoursPlayed.TabIndex = 29;
            this.LblHoursPlayed.Visible = false;
            // 
            // TmrStatistics
            // 
            this.TmrStatistics.Interval = 60000;
            this.TmrStatistics.Tick += new System.EventHandler(this.TmrStatistics_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(308, 336);
            this.Controls.Add(this.LblHoursPlayed);
            this.Controls.Add(this.GamesState);
            this.Controls.Add(this.LblSignedOnAs);
            this.Controls.Add(this.PbxReadingPage);
            this.Controls.Add(this.BtnSkip);
            this.Controls.Add(this.PbxIdleStatus);
            this.Controls.Add(this.LblCurrentRemaining);
            this.Controls.Add(this.LblCurrentStatus);
            this.Controls.Add(this.LblIdle);
            this.Controls.Add(this.LblDrops);
            this.Controls.Add(this.PbxCookieStatus);
            this.Controls.Add(this.PbxSteamStatus);
            this.Controls.Add(this.LnkSignIn);
            this.Controls.Add(this.LnkResetCookies);
            this.Controls.Add(this.LblSteamStatus);
            this.Controls.Add(this.LblCookieStatus);
            this.Controls.Add(this.MnuTop);
            this.Controls.Add(this.StrFooter);
            this.Controls.Add(this.BtnPause);
            this.Controls.Add(this.BtnResume);
            this.Controls.Add(this.LblGameName);
            this.Controls.Add(this.PbxApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MnuTop;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Idle Master HTTPS Fix";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClose);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MnuTop.ResumeLayout(false);
            this.MnuTop.PerformLayout();
            this.StrFooter.ResumeLayout(false);
            this.StrFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxReadingPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxIdleStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxCookieStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxSteamStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblCookieStatus;
        private Timer TmrCheckCookieData;
        private Label LblSteamStatus;
        private Timer TmrCheckSteam;
        private LinkLabel LnkResetCookies;
        private LinkLabel LnkSignIn;
        private PictureBox PbxApp;
        private PictureBox PbxSteamStatus;
        private PictureBox PbxCookieStatus;
        private Label LblDrops;
        private Label LblIdle;
        private Label LblCurrentStatus;
        private Label LblCurrentRemaining;
        private PictureBox PbxIdleStatus;
        private LinkLabel LblGameName;
        private MenuStrip MnuTop;
        private ToolStripMenuItem MnuFile;
        private ToolStripMenuItem MnuFileSettings;
        private ToolStripSeparator MnuFileSeparator;
        private ToolStripMenuItem MnuFileExit;
        private ToolStripMenuItem MnuHelp;
        private ToolStripMenuItem MnuHelpAbout;
        private Timer TmrReadyToGo;
        private Timer TmrCardDropCheck;
        private StatusStrip StrFooter;
        private ToolStripProgressBar PgrIdle;
        private ToolStripStatusLabel LblTimer;
        private ToolStripStatusLabel LblNextCheck;
        private Button BtnPause;
        private Button BtnSkip;
        private Button BtnResume;
        private ToolStripMenuItem MnuGame;
        private ToolStripMenuItem MnuGamePause;
        private ToolStripMenuItem MnuGameResume;
        private ToolStripMenuItem MnuGameSkip;
        private PictureBox PbxReadingPage;
        private ToolStripMenuItem MnuFileBlacklist;
        private ToolStripSeparator MnuGameSeparator;
        private ToolStripMenuItem MnuGameBlacklist;
        private Timer TmrStartNext;
        private ToolStripMenuItem MnuHelpChangelog;
        private ToolStripMenuItem MnuHelpOfficial;
        private ToolStripSeparator MnuHelpSeparator;
        private Timer TmrBadgeReload;
        private Label LblSignedOnAs;
    private ListView GamesState;
    private ColumnHeader GameName;
    private ColumnHeader Hours;
    private Label LblHoursPlayed;
        private Timer TmrStatistics;
        private ToolStripMenuItem MnuHelpStats;
    }
}

