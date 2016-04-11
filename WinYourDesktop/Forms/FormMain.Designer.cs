namespace WinYourDesktop
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHome = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDebugger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNotifications = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.sslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.panelDebugger = new System.Windows.Forms.Panel();
            this.btnDebuggerRun = new System.Windows.Forms.Button();
            this.lblDebuggerFile = new System.Windows.Forms.Label();
            this.txtDebuggerOutput = new System.Windows.Forms.TextBox();
            this.msDebugger = new System.Windows.Forms.MenuStrip();
            this.tsmDebuggerFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebuggerOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebuggerRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDebugger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebuggerClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebuggerCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.lblSettingsRequireRestart = new System.Windows.Forms.Label();
            this.chkSettingsAutoDetectLanguage = new System.Windows.Forms.CheckBox();
            this.chkSettingsEnableVisualStyles = new System.Windows.Forms.CheckBox();
            this.chkSettingsDarkTheme = new System.Windows.Forms.CheckBox();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.lblSettingsLanguage = new System.Windows.Forms.Label();
            this.cboSettingsLanguage = new System.Windows.Forms.ComboBox();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.ImageListNotification = new System.Windows.Forms.ImageList(this.components);
            this.msMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDebugger.SuspendLayout();
            this.msDebugger.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmApplication,
            this.tsmView,
            this.tsmiSupport,
            this.tsmNotifications});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(826, 25);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmApplication
            // 
            this.tsmApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRestart,
            this.tsmiQuit});
            this.tsmApplication.Name = "tsmApplication";
            this.tsmApplication.Size = new System.Drawing.Size(44, 21);
            this.tsmApplication.Text = "App";
            // 
            // tsmiRestart
            // 
            this.tsmiRestart.Name = "tsmiRestart";
            this.tsmiRestart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiRestart.Size = new System.Drawing.Size(162, 22);
            this.tsmiRestart.Text = "Restart";
            this.tsmiRestart.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiQuit.Size = new System.Drawing.Size(162, 22);
            this.tsmiQuit.Text = "Quit";
            this.tsmiQuit.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // tsmView
            // 
            this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHome,
            this.toolStripSeparator3,
            this.tsmiDebugger,
            this.toolStripSeparator2,
            this.tsmiSettings});
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(55, 21);
            this.tsmView.Text = "Mode";
            // 
            // tsmiHome
            // 
            this.tsmiHome.Checked = true;
            this.tsmiHome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiHome.Name = "tsmiHome";
            this.tsmiHome.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.tsmiHome.Size = new System.Drawing.Size(159, 22);
            this.tsmiHome.Text = "Home";
            this.tsmiHome.Click += new System.EventHandler(this.tsmiHome_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // tsmiDebugger
            // 
            this.tsmiDebugger.Name = "tsmiDebugger";
            this.tsmiDebugger.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.tsmiDebugger.Size = new System.Drawing.Size(159, 22);
            this.tsmiDebugger.Text = "Debug";
            this.tsmiDebugger.Click += new System.EventHandler(this.tsmiDebugger_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tsmiSettings.Size = new System.Drawing.Size(159, 22);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiSupport
            // 
            this.tsmiSupport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelp,
            this.toolStripSeparator1,
            this.tsmiAbout});
            this.tsmiSupport.Name = "tsmiSupport";
            this.tsmiSupport.Size = new System.Drawing.Size(26, 21);
            this.tsmiSupport.Text = "?";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Enabled = false;
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tsmiHelp.Size = new System.Drawing.Size(124, 22);
            this.tsmiHelp.Text = "Help";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(124, 22);
            this.tsmiAbout.Text = "About";
            this.tsmiAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tsmNotifications
            // 
            this.tsmNotifications.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmNotifications.Image = ((System.Drawing.Image)(resources.GetObject("tsmNotifications.Image")));
            this.tsmNotifications.Name = "tsmNotifications";
            this.tsmNotifications.Size = new System.Drawing.Size(43, 21);
            this.tsmNotifications.Text = "0";
            this.tsmNotifications.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // ssMain
            // 
            this.ssMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslblStatus});
            this.ssMain.Location = new System.Drawing.Point(0, 514);
            this.ssMain.Name = "ssMain";
            this.ssMain.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ssMain.Size = new System.Drawing.Size(826, 22);
            this.ssMain.SizingGrip = false;
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "statusStrip1";
            // 
            // sslblStatus
            // 
            this.sslblStatus.Name = "sslblStatus";
            this.sslblStatus.Size = new System.Drawing.Size(69, 17);
            this.sslblStatus.Text = "sslblStatus";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRun.BackgroundImage")));
            this.btnRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(4, 4);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(120, 100);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            this.btnRun.MouseEnter += new System.EventHandler(this.btnRun_MouseEnter);
            this.btnRun.MouseLeave += new System.EventHandler(this.btnRun_MouseLeave);
            // 
            // btnDebug
            // 
            this.btnDebug.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDebug.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDebug.BackgroundImage")));
            this.btnDebug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDebug.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebug.Location = new System.Drawing.Point(132, 4);
            this.btnDebug.Margin = new System.Windows.Forms.Padding(4);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(120, 100);
            this.btnDebug.TabIndex = 3;
            this.btnDebug.Text = "Debug";
            this.btnDebug.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            this.btnDebug.MouseEnter += new System.EventHandler(this.btnDebug_MouseEnter);
            this.btnDebug.MouseLeave += new System.EventHandler(this.btnDebug_MouseLeave);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Controls.Add(this.btnRun);
            this.panelMain.Controls.Add(this.btnDebug);
            this.panelMain.Location = new System.Drawing.Point(20, 27);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(256, 109);
            this.panelMain.TabIndex = 6;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // panelDebugger
            // 
            this.panelDebugger.AllowDrop = true;
            this.panelDebugger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDebugger.Controls.Add(this.btnDebuggerRun);
            this.panelDebugger.Controls.Add(this.lblDebuggerFile);
            this.panelDebugger.Controls.Add(this.txtDebuggerOutput);
            this.panelDebugger.Controls.Add(this.msDebugger);
            this.panelDebugger.Location = new System.Drawing.Point(13, 142);
            this.panelDebugger.Name = "panelDebugger";
            this.panelDebugger.Size = new System.Drawing.Size(436, 348);
            this.panelDebugger.TabIndex = 8;
            this.panelDebugger.Visible = false;
            this.panelDebugger.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDebugger_DragDrop);
            this.panelDebugger.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDebugger_DragEnter);
            // 
            // btnDebuggerRun
            // 
            this.btnDebuggerRun.Enabled = false;
            this.btnDebuggerRun.Location = new System.Drawing.Point(376, 27);
            this.btnDebuggerRun.Name = "btnDebuggerRun";
            this.btnDebuggerRun.Size = new System.Drawing.Size(57, 31);
            this.btnDebuggerRun.TabIndex = 10;
            this.btnDebuggerRun.Text = "▶";
            this.btnDebuggerRun.UseVisualStyleBackColor = true;
            this.btnDebuggerRun.Click += new System.EventHandler(this.btnDebuggerRun_Click);
            this.btnDebuggerRun.MouseEnter += new System.EventHandler(this.btnDebuggerRun_MouseEnter);
            this.btnDebuggerRun.MouseLeave += new System.EventHandler(this.btnDebuggerRun_MouseLeave);
            // 
            // lblDebuggerFile
            // 
            this.lblDebuggerFile.AutoSize = true;
            this.lblDebuggerFile.Location = new System.Drawing.Point(4, 33);
            this.lblDebuggerFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblDebuggerFile.Name = "lblDebuggerFile";
            this.lblDebuggerFile.Size = new System.Drawing.Size(96, 17);
            this.lblDebuggerFile.TabIndex = 1;
            this.lblDebuggerFile.Text = "No opened file";
            // 
            // txtDebuggerOutput
            // 
            this.txtDebuggerOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebuggerOutput.BackColor = System.Drawing.Color.Black;
            this.txtDebuggerOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDebuggerOutput.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebuggerOutput.ForeColor = System.Drawing.Color.White;
            this.txtDebuggerOutput.Location = new System.Drawing.Point(0, 63);
            this.txtDebuggerOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDebuggerOutput.Multiline = true;
            this.txtDebuggerOutput.Name = "txtDebuggerOutput";
            this.txtDebuggerOutput.ReadOnly = true;
            this.txtDebuggerOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebuggerOutput.Size = new System.Drawing.Size(436, 285);
            this.txtDebuggerOutput.TabIndex = 8;
            // 
            // msDebugger
            // 
            this.msDebugger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDebuggerFile,
            this.tsmDebugger});
            this.msDebugger.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.msDebugger.Location = new System.Drawing.Point(0, 0);
            this.msDebugger.Name = "msDebugger";
            this.msDebugger.Size = new System.Drawing.Size(436, 24);
            this.msDebugger.TabIndex = 9;
            this.msDebugger.Text = "menuStrip1";
            // 
            // tsmDebuggerFile
            // 
            this.tsmDebuggerFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDebuggerOpen,
            this.toolStripSeparator5,
            this.tsmiDebuggerRun});
            this.tsmDebuggerFile.Name = "tsmDebuggerFile";
            this.tsmDebuggerFile.Size = new System.Drawing.Size(37, 20);
            this.tsmDebuggerFile.Text = "File";
            // 
            // tsmiDebuggerOpen
            // 
            this.tsmiDebuggerOpen.Name = "tsmiDebuggerOpen";
            this.tsmiDebuggerOpen.Size = new System.Drawing.Size(152, 22);
            this.tsmiDebuggerOpen.Text = "Open";
            this.tsmiDebuggerOpen.Click += new System.EventHandler(this.tsmiDebuggerOpen_Click);
            this.tsmiDebuggerOpen.MouseEnter += new System.EventHandler(this.tsmiDebuggerOpen_MouseEnter);
            this.tsmiDebuggerOpen.MouseLeave += new System.EventHandler(this.tsmiDebuggerOpen_MouseLeave);
            // 
            // tsmiDebuggerRun
            // 
            this.tsmiDebuggerRun.Enabled = false;
            this.tsmiDebuggerRun.Name = "tsmiDebuggerRun";
            this.tsmiDebuggerRun.Size = new System.Drawing.Size(152, 22);
            this.tsmiDebuggerRun.Text = "Run";
            this.tsmiDebuggerRun.Click += new System.EventHandler(this.tsmiDebuggerRun_Click);
            this.tsmiDebuggerRun.MouseEnter += new System.EventHandler(this.tsmiDebuggerRun_MouseEnter);
            this.tsmiDebuggerRun.MouseLeave += new System.EventHandler(this.tsmiDebuggerRun_MouseLeave);
            // 
            // tsmDebugger
            // 
            this.tsmDebugger.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDebuggerClear,
            this.tsmiDebuggerCopyToClipboard});
            this.tsmDebugger.Name = "tsmDebugger";
            this.tsmDebugger.Size = new System.Drawing.Size(71, 20);
            this.tsmDebugger.Text = "Debugger";
            // 
            // tsmiDebuggerClear
            // 
            this.tsmiDebuggerClear.Name = "tsmiDebuggerClear";
            this.tsmiDebuggerClear.Size = new System.Drawing.Size(208, 22);
            this.tsmiDebuggerClear.Text = "Clear";
            this.tsmiDebuggerClear.Click += new System.EventHandler(this.tsmiDebuggerClear_Click);
            this.tsmiDebuggerClear.MouseEnter += new System.EventHandler(this.tsmiDebuggerClear_MouseEnter);
            this.tsmiDebuggerClear.MouseLeave += new System.EventHandler(this.tsmiDebuggerClear_MouseLeave);
            // 
            // tsmiDebuggerCopyToClipboard
            // 
            this.tsmiDebuggerCopyToClipboard.Name = "tsmiDebuggerCopyToClipboard";
            this.tsmiDebuggerCopyToClipboard.Size = new System.Drawing.Size(208, 22);
            this.tsmiDebuggerCopyToClipboard.Text = "Copy output to clipboard";
            this.tsmiDebuggerCopyToClipboard.Click += new System.EventHandler(this.tsmiDebuggerCopyToClipboard_Click);
            this.tsmiDebuggerCopyToClipboard.MouseEnter += new System.EventHandler(this.tsmiDebuggerCopyToClipboard_MouseEnter);
            this.tsmiDebuggerCopyToClipboard.MouseLeave += new System.EventHandler(this.tsmiDebuggerCopyToClipboard_MouseLeave);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.Controls.Add(this.lblSettingsRequireRestart);
            this.panelSettings.Controls.Add(this.chkSettingsAutoDetectLanguage);
            this.panelSettings.Controls.Add(this.chkSettingsEnableVisualStyles);
            this.panelSettings.Controls.Add(this.chkSettingsDarkTheme);
            this.panelSettings.Controls.Add(this.btnSettingsSave);
            this.panelSettings.Controls.Add(this.lblSettingsLanguage);
            this.panelSettings.Controls.Add(this.cboSettingsLanguage);
            this.panelSettings.Location = new System.Drawing.Point(455, 29);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(359, 360);
            this.panelSettings.TabIndex = 9;
            this.panelSettings.Visible = false;
            // 
            // lblSettingsRequireRestart
            // 
            this.lblSettingsRequireRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSettingsRequireRestart.AutoSize = true;
            this.lblSettingsRequireRestart.Location = new System.Drawing.Point(3, 303);
            this.lblSettingsRequireRestart.Name = "lblSettingsRequireRestart";
            this.lblSettingsRequireRestart.Size = new System.Drawing.Size(196, 17);
            this.lblSettingsRequireRestart.TabIndex = 6;
            this.lblSettingsRequireRestart.Text = "* Requires an application restart";
            // 
            // chkSettingsAutoDetectLanguage
            // 
            this.chkSettingsAutoDetectLanguage.AutoSize = true;
            this.chkSettingsAutoDetectLanguage.Checked = true;
            this.chkSettingsAutoDetectLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsAutoDetectLanguage.Enabled = false;
            this.chkSettingsAutoDetectLanguage.Location = new System.Drawing.Point(6, 104);
            this.chkSettingsAutoDetectLanguage.Name = "chkSettingsAutoDetectLanguage";
            this.chkSettingsAutoDetectLanguage.Size = new System.Drawing.Size(202, 21);
            this.chkSettingsAutoDetectLanguage.TabIndex = 5;
            this.chkSettingsAutoDetectLanguage.Text = "Automatically detect language";
            this.chkSettingsAutoDetectLanguage.UseVisualStyleBackColor = true;
            // 
            // chkSettingsEnableVisualStyles
            // 
            this.chkSettingsEnableVisualStyles.AutoSize = true;
            this.chkSettingsEnableVisualStyles.Checked = true;
            this.chkSettingsEnableVisualStyles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsEnableVisualStyles.Enabled = false;
            this.chkSettingsEnableVisualStyles.Location = new System.Drawing.Point(6, 82);
            this.chkSettingsEnableVisualStyles.Name = "chkSettingsEnableVisualStyles";
            this.chkSettingsEnableVisualStyles.Size = new System.Drawing.Size(143, 21);
            this.chkSettingsEnableVisualStyles.TabIndex = 4;
            this.chkSettingsEnableVisualStyles.Text = "Enable visual styles*";
            this.chkSettingsEnableVisualStyles.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDarkTheme
            // 
            this.chkSettingsDarkTheme.AutoSize = true;
            this.chkSettingsDarkTheme.Enabled = false;
            this.chkSettingsDarkTheme.Location = new System.Drawing.Point(6, 60);
            this.chkSettingsDarkTheme.Name = "chkSettingsDarkTheme";
            this.chkSettingsDarkTheme.Size = new System.Drawing.Size(94, 21);
            this.chkSettingsDarkTheme.TabIndex = 3;
            this.chkSettingsDarkTheme.Text = "Dark theme";
            this.chkSettingsDarkTheme.UseVisualStyleBackColor = true;
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsSave.Location = new System.Drawing.Point(255, 326);
            this.btnSettingsSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(100, 30);
            this.btnSettingsSave.TabIndex = 2;
            this.btnSettingsSave.Text = "Save";
            this.btnSettingsSave.UseVisualStyleBackColor = true;
            this.btnSettingsSave.Click += new System.EventHandler(this.btnSettingsSave_Click);
            // 
            // lblSettingsLanguage
            // 
            this.lblSettingsLanguage.AutoSize = true;
            this.lblSettingsLanguage.Location = new System.Drawing.Point(3, 6);
            this.lblSettingsLanguage.Margin = new System.Windows.Forms.Padding(3);
            this.lblSettingsLanguage.Name = "lblSettingsLanguage";
            this.lblSettingsLanguage.Size = new System.Drawing.Size(65, 17);
            this.lblSettingsLanguage.TabIndex = 1;
            this.lblSettingsLanguage.Text = "Language";
            // 
            // cboSettingsLanguage
            // 
            this.cboSettingsLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSettingsLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSettingsLanguage.FormattingEnabled = true;
            this.cboSettingsLanguage.Items.AddRange(new object[] {
            "English (English)",
            "Français (French)"});
            this.cboSettingsLanguage.Location = new System.Drawing.Point(8, 29);
            this.cboSettingsLanguage.Margin = new System.Windows.Forms.Padding(8);
            this.cboSettingsLanguage.Name = "cboSettingsLanguage";
            this.cboSettingsLanguage.Size = new System.Drawing.Size(343, 25);
            this.cboSettingsLanguage.TabIndex = 0;
            // 
            // ofdMain
            // 
            this.ofdMain.Filter = "Desktop entry files|*.desktop|All files|*.*";
            this.ofdMain.RestoreDirectory = true;
            // 
            // ImageListNotification
            // 
            this.ImageListNotification.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListNotification.ImageStream")));
            this.ImageListNotification.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListNotification.Images.SetKeyName(0, "NotificationLow.png");
            this.ImageListNotification.Images.SetKeyName(1, "NotificationHigh.png");
            this.ImageListNotification.Images.SetKeyName(2, "NotificationCrucial.png");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 536);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelDebugger);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinYourDesktop";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelDebugger.ResumeLayout(false);
            this.panelDebugger.PerformLayout();
            this.msDebugger.ResumeLayout(false);
            this.msDebugger.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmApplication;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.ToolStripMenuItem tsmiSupport;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestart;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem tsmNotifications;
        private System.Windows.Forms.Panel panelDebugger;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.ToolStripMenuItem tsmiHome;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebugger;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripStatusLabel sslblStatus;
        private System.Windows.Forms.Label lblSettingsLanguage;
        private System.Windows.Forms.ComboBox cboSettingsLanguage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label lblDebuggerFile;
        private System.Windows.Forms.TextBox txtDebuggerOutput;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList ImageListNotification;
        private System.Windows.Forms.CheckBox chkSettingsEnableVisualStyles;
        private System.Windows.Forms.CheckBox chkSettingsDarkTheme;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.MenuStrip msDebugger;
        private System.Windows.Forms.ToolStripMenuItem tsmDebuggerFile;
        private System.Windows.Forms.Button btnDebuggerRun;
        private System.Windows.Forms.ToolStripMenuItem tsmDebugger;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebuggerClear;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebuggerCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebuggerOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebuggerRun;
        private System.Windows.Forms.CheckBox chkSettingsAutoDetectLanguage;
        private System.Windows.Forms.Label lblSettingsRequireRestart;
    }
}
