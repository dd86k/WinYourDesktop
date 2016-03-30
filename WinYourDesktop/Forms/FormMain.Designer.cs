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
            this.tsmiEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebugger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreationWizard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNotifications = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.sslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelEditor = new System.Windows.Forms.Panel();
            this.panelDebugger = new System.Windows.Forms.Panel();
            this.btnRunCopy = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRunWithDebugger = new System.Windows.Forms.Button();
            this.lblRunCurrentFile = new System.Windows.Forms.Label();
            this.txtRunOutput = new System.Windows.Forms.TextBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.lblSettingsLanguage = new System.Windows.Forms.Label();
            this.cboSettingsLanguage = new System.Windows.Forms.ComboBox();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.ImageListNotification = new System.Windows.Forms.ImageList(this.components);
            this.chkSettingsDarkTheme = new System.Windows.Forms.CheckBox();
            this.chkSettingsEnableVistualStyles = new System.Windows.Forms.CheckBox();
            this.msMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDebugger.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmApplication,
            this.tsmView,
            this.tsmTools,
            this.tsmiSupport,
            this.tsmNotifications});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(786, 25);
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
            this.tsmiEditor,
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
            // tsmiEditor
            // 
            this.tsmiEditor.Name = "tsmiEditor";
            this.tsmiEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.tsmiEditor.Size = new System.Drawing.Size(159, 22);
            this.tsmiEditor.Text = "Edit";
            this.tsmiEditor.Click += new System.EventHandler(this.tsmiEditor_Click);
            // 
            // tsmiDebugger
            // 
            this.tsmiDebugger.Name = "tsmiDebugger";
            this.tsmiDebugger.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
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
            // tsmTools
            // 
            this.tsmTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreationWizard});
            this.tsmTools.Name = "tsmTools";
            this.tsmTools.Size = new System.Drawing.Size(51, 21);
            this.tsmTools.Text = "Tools";
            // 
            // tsmiCreationWizard
            // 
            this.tsmiCreationWizard.Enabled = false;
            this.tsmiCreationWizard.Name = "tsmiCreationWizard";
            this.tsmiCreationWizard.Size = new System.Drawing.Size(170, 22);
            this.tsmiCreationWizard.Text = "Creation Wizard";
            this.tsmiCreationWizard.Click += new System.EventHandler(this.tsmiCreationWizard_Click);
            this.tsmiCreationWizard.MouseEnter += new System.EventHandler(this.tsmiCreationWizard_MouseEnter);
            this.tsmiCreationWizard.MouseLeave += new System.EventHandler(this.tsmiCreationWizard_MouseLeave);
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
            this.tsmiHelp.Size = new System.Drawing.Size(152, 22);
            this.tsmiHelp.Text = "Help";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(152, 22);
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
            this.ssMain.Location = new System.Drawing.Point(0, 581);
            this.ssMain.Name = "ssMain";
            this.ssMain.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ssMain.Size = new System.Drawing.Size(786, 22);
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
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(132, 112);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 100);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnEdit.MouseEnter += new System.EventHandler(this.btnEdit_MouseEnter);
            this.btnEdit.MouseLeave += new System.EventHandler(this.btnEdit_MouseLeave);
            // 
            // btnDebug
            // 
            this.btnDebug.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDebug.BackgroundImage")));
            this.btnDebug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDebug.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebug.Location = new System.Drawing.Point(4, 112);
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
            // btnCreate
            // 
            this.btnCreate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreate.BackgroundImage")));
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(132, 4);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(120, 100);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.btnCreate.MouseEnter += new System.EventHandler(this.btnCreate_MouseEnter);
            this.btnCreate.MouseLeave += new System.EventHandler(this.btnCreate_MouseLeave);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnRun);
            this.panelMain.Controls.Add(this.btnCreate);
            this.panelMain.Controls.Add(this.btnEdit);
            this.panelMain.Controls.Add(this.btnDebug);
            this.panelMain.Location = new System.Drawing.Point(10, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(256, 216);
            this.panelMain.TabIndex = 6;
            // 
            // panelEditor
            // 
            this.panelEditor.Location = new System.Drawing.Point(443, 37);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(244, 240);
            this.panelEditor.TabIndex = 7;
            this.panelEditor.Visible = false;
            // 
            // panelDebugger
            // 
            this.panelDebugger.AllowDrop = true;
            this.panelDebugger.Controls.Add(this.btnRunCopy);
            this.panelDebugger.Controls.Add(this.btnOpen);
            this.panelDebugger.Controls.Add(this.btnRunWithDebugger);
            this.panelDebugger.Controls.Add(this.lblRunCurrentFile);
            this.panelDebugger.Controls.Add(this.txtRunOutput);
            this.panelDebugger.Location = new System.Drawing.Point(10, 323);
            this.panelDebugger.Name = "panelDebugger";
            this.panelDebugger.Size = new System.Drawing.Size(391, 246);
            this.panelDebugger.TabIndex = 8;
            this.panelDebugger.Visible = false;
            this.panelDebugger.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDebugger_DragDrop);
            this.panelDebugger.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelDebugger_DragEnter);
            // 
            // btnRunCopy
            // 
            this.btnRunCopy.Location = new System.Drawing.Point(132, 24);
            this.btnRunCopy.Margin = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.btnRunCopy.Name = "btnRunCopy";
            this.btnRunCopy.Size = new System.Drawing.Size(127, 29);
            this.btnRunCopy.TabIndex = 6;
            this.btnRunCopy.Text = "Copy";
            this.btnRunCopy.UseVisualStyleBackColor = true;
            this.btnRunCopy.Click += new System.EventHandler(this.btnRunCopyOutput_Click);
            this.btnRunCopy.MouseEnter += new System.EventHandler(this.btnRunCopy_MouseEnter);
            this.btnRunCopy.MouseLeave += new System.EventHandler(this.btnRunCopy_MouseLeave);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3, 24);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(127, 29);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnOpen.MouseEnter += new System.EventHandler(this.btnOpen_MouseEnter);
            this.btnOpen.MouseLeave += new System.EventHandler(this.btnOpen_MouseLeave);
            // 
            // btnRunWithDebugger
            // 
            this.btnRunWithDebugger.Enabled = false;
            this.btnRunWithDebugger.Location = new System.Drawing.Point(262, 24);
            this.btnRunWithDebugger.Margin = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.btnRunWithDebugger.Name = "btnRunWithDebugger";
            this.btnRunWithDebugger.Size = new System.Drawing.Size(127, 29);
            this.btnRunWithDebugger.TabIndex = 7;
            this.btnRunWithDebugger.Text = "Run";
            this.btnRunWithDebugger.UseVisualStyleBackColor = true;
            this.btnRunWithDebugger.Click += new System.EventHandler(this.btnRunWithDebugger_Click);
            this.btnRunWithDebugger.MouseEnter += new System.EventHandler(this.btnRunWithDebugger_MouseEnter);
            this.btnRunWithDebugger.MouseLeave += new System.EventHandler(this.btnRunWithDebugger_MouseLeave);
            // 
            // lblRunCurrentFile
            // 
            this.lblRunCurrentFile.AutoSize = true;
            this.lblRunCurrentFile.Location = new System.Drawing.Point(4, 5);
            this.lblRunCurrentFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblRunCurrentFile.Name = "lblRunCurrentFile";
            this.lblRunCurrentFile.Size = new System.Drawing.Size(0, 17);
            this.lblRunCurrentFile.TabIndex = 1;
            // 
            // txtRunOutput
            // 
            this.txtRunOutput.BackColor = System.Drawing.Color.Black;
            this.txtRunOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRunOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtRunOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRunOutput.ForeColor = System.Drawing.Color.White;
            this.txtRunOutput.Location = new System.Drawing.Point(0, 59);
            this.txtRunOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRunOutput.Multiline = true;
            this.txtRunOutput.Name = "txtRunOutput";
            this.txtRunOutput.ReadOnly = true;
            this.txtRunOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRunOutput.Size = new System.Drawing.Size(391, 187);
            this.txtRunOutput.TabIndex = 8;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.chkSettingsEnableVistualStyles);
            this.panelSettings.Controls.Add(this.chkSettingsDarkTheme);
            this.panelSettings.Controls.Add(this.btnSettingsSave);
            this.panelSettings.Controls.Add(this.lblSettingsLanguage);
            this.panelSettings.Controls.Add(this.cboSettingsLanguage);
            this.panelSettings.Location = new System.Drawing.Point(423, 292);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(300, 277);
            this.panelSettings.TabIndex = 9;
            this.panelSettings.Visible = false;
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Location = new System.Drawing.Point(4, 243);
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
            this.lblSettingsLanguage.Location = new System.Drawing.Point(3, 3);
            this.lblSettingsLanguage.Margin = new System.Windows.Forms.Padding(3);
            this.lblSettingsLanguage.Name = "lblSettingsLanguage";
            this.lblSettingsLanguage.Size = new System.Drawing.Size(65, 17);
            this.lblSettingsLanguage.TabIndex = 1;
            this.lblSettingsLanguage.Text = "Language";
            // 
            // cboSettingsLanguage
            // 
            this.cboSettingsLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSettingsLanguage.FormattingEnabled = true;
            this.cboSettingsLanguage.Items.AddRange(new object[] {
            "English (English)",
            "English (Pirate)",
            "Français (French)"});
            this.cboSettingsLanguage.Location = new System.Drawing.Point(5, 26);
            this.cboSettingsLanguage.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cboSettingsLanguage.Name = "cboSettingsLanguage";
            this.cboSettingsLanguage.Size = new System.Drawing.Size(290, 25);
            this.cboSettingsLanguage.TabIndex = 0;
            // 
            // ofdMain
            // 
            this.ofdMain.Filter = "Desktop files|*.desktop|All file|*.*";
            // 
            // ImageListNotification
            // 
            this.ImageListNotification.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListNotification.ImageStream")));
            this.ImageListNotification.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListNotification.Images.SetKeyName(0, "NotificationLow.png");
            this.ImageListNotification.Images.SetKeyName(1, "NotificationHigh.png");
            this.ImageListNotification.Images.SetKeyName(2, "NotificationCrucial.png");
            // 
            // chkSettingsDarkTheme
            // 
            this.chkSettingsDarkTheme.AutoSize = true;
            this.chkSettingsDarkTheme.Location = new System.Drawing.Point(5, 57);
            this.chkSettingsDarkTheme.Name = "chkSettingsDarkTheme";
            this.chkSettingsDarkTheme.Size = new System.Drawing.Size(94, 21);
            this.chkSettingsDarkTheme.TabIndex = 3;
            this.chkSettingsDarkTheme.Text = "Dark theme";
            this.chkSettingsDarkTheme.UseVisualStyleBackColor = true;
            // 
            // chkSettingsEnableVistualStyles
            // 
            this.chkSettingsEnableVistualStyles.AutoSize = true;
            this.chkSettingsEnableVistualStyles.Checked = true;
            this.chkSettingsEnableVistualStyles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsEnableVistualStyles.Location = new System.Drawing.Point(5, 84);
            this.chkSettingsEnableVistualStyles.Name = "chkSettingsEnableVistualStyles";
            this.chkSettingsEnableVistualStyles.Size = new System.Drawing.Size(138, 21);
            this.chkSettingsEnableVistualStyles.TabIndex = 4;
            this.chkSettingsEnableVistualStyles.Text = "Enable visual styles";
            this.chkSettingsEnableVistualStyles.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 603);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelDebugger);
            this.Controls.Add(this.panelEditor);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ToolStripMenuItem tsmiSupport;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestart;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem tsmNotifications;
        private System.Windows.Forms.ToolStripMenuItem tsmTools;
        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.Panel panelDebugger;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.ToolStripMenuItem tsmiHome;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditor;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebugger;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripStatusLabel sslblStatus;
        private System.Windows.Forms.Label lblSettingsLanguage;
        private System.Windows.Forms.ComboBox cboSettingsLanguage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRunWithDebugger;
        private System.Windows.Forms.Label lblRunCurrentFile;
        private System.Windows.Forms.TextBox txtRunOutput;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.Button btnRunCopy;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreationWizard;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList ImageListNotification;
        private System.Windows.Forms.CheckBox chkSettingsEnableVistualStyles;
        private System.Windows.Forms.CheckBox chkSettingsDarkTheme;
    }
}
