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
            this.creationWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.sslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelEditor = new System.Windows.Forms.Panel();
            this.panelDebugger = new System.Windows.Forms.Panel();
            this.btnRunClear = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRunWithDebugger = new System.Windows.Forms.Button();
            this.lblRunCurrentFile = new System.Windows.Forms.Label();
            this.txtRunOutput = new System.Windows.Forms.TextBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.chkSettingsShowDebug = new System.Windows.Forms.CheckBox();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.lblSettingsLanguage = new System.Windows.Forms.Label();
            this.cboSettingsLanguage = new System.Windows.Forms.ComboBox();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
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
            this.toolStripMenuItem1});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(857, 25);
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
            this.tsmiHome.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmiHome.Size = new System.Drawing.Size(143, 22);
            this.tsmiHome.Text = "Home";
            this.tsmiHome.Click += new System.EventHandler(this.tsmiHome_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmiEditor
            // 
            this.tsmiEditor.Name = "tsmiEditor";
            this.tsmiEditor.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tsmiEditor.Size = new System.Drawing.Size(143, 22);
            this.tsmiEditor.Text = "Edit";
            this.tsmiEditor.Click += new System.EventHandler(this.tsmiEditor_Click);
            // 
            // tsmiDebugger
            // 
            this.tsmiDebugger.Name = "tsmiDebugger";
            this.tsmiDebugger.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.tsmiDebugger.Size = new System.Drawing.Size(143, 22);
            this.tsmiDebugger.Text = "Debug";
            this.tsmiDebugger.Click += new System.EventHandler(this.tsmiDebugger_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tsmiSettings.Size = new System.Drawing.Size(143, 22);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmTools
            // 
            this.tsmTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creationWizardToolStripMenuItem});
            this.tsmTools.Name = "tsmTools";
            this.tsmTools.Size = new System.Drawing.Size(51, 21);
            this.tsmTools.Text = "Tools";
            // 
            // creationWizardToolStripMenuItem
            // 
            this.creationWizardToolStripMenuItem.Name = "creationWizardToolStripMenuItem";
            this.creationWizardToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.creationWizardToolStripMenuItem.Text = "Creation Wizard";
            // 
            // tsmiSupport
            // 
            this.tsmiSupport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiSupport.Name = "tsmiSupport";
            this.tsmiSupport.Size = new System.Drawing.Size(26, 21);
            this.tsmiSupport.Text = "?";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(111, 22);
            this.tsmiAbout.Text = "About";
            this.tsmiAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 21);
            this.toolStripMenuItem1.Text = "0";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // ssMain
            // 
            this.ssMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslblStatus});
            this.ssMain.Location = new System.Drawing.Point(0, 564);
            this.ssMain.Name = "ssMain";
            this.ssMain.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.ssMain.Size = new System.Drawing.Size(857, 22);
            this.ssMain.SizingGrip = false;
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "statusStrip1";
            // 
            // sslblStatus
            // 
            this.sslblStatus.Name = "sslblStatus";
            this.sslblStatus.Size = new System.Drawing.Size(42, 17);
            this.sslblStatus.Text = "Hello!";
            // 
            // btnRun
            // 
            this.btnRun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRun.BackgroundImage")));
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(8, 8);
            this.btnRun.Margin = new System.Windows.Forms.Padding(8);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(128, 96);
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
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(152, 120);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(128, 96);
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
            this.btnDebug.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebug.Location = new System.Drawing.Point(8, 120);
            this.btnDebug.Margin = new System.Windows.Forms.Padding(8);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(128, 96);
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
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(152, 8);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(8);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(128, 96);
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
            this.panelMain.Location = new System.Drawing.Point(12, 30);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(292, 225);
            this.panelMain.TabIndex = 6;
            // 
            // panelEditor
            // 
            this.panelEditor.Location = new System.Drawing.Point(506, 44);
            this.panelEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(279, 282);
            this.panelEditor.TabIndex = 7;
            this.panelEditor.Visible = false;
            // 
            // panelDebugger
            // 
            this.panelDebugger.Controls.Add(this.btnRunClear);
            this.panelDebugger.Controls.Add(this.btnOpen);
            this.panelDebugger.Controls.Add(this.btnRunWithDebugger);
            this.panelDebugger.Controls.Add(this.lblRunCurrentFile);
            this.panelDebugger.Controls.Add(this.txtRunOutput);
            this.panelDebugger.Location = new System.Drawing.Point(12, 263);
            this.panelDebugger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelDebugger.Name = "panelDebugger";
            this.panelDebugger.Size = new System.Drawing.Size(447, 289);
            this.panelDebugger.TabIndex = 8;
            this.panelDebugger.Visible = false;
            // 
            // btnRunClear
            // 
            this.btnRunClear.Location = new System.Drawing.Point(151, 28);
            this.btnRunClear.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnRunClear.Name = "btnRunClear";
            this.btnRunClear.Size = new System.Drawing.Size(145, 35);
            this.btnRunClear.TabIndex = 5;
            this.btnRunClear.Text = "Clear";
            this.btnRunClear.UseVisualStyleBackColor = true;
            this.btnRunClear.Click += new System.EventHandler(this.btnRunClearOutput_Click);
            this.btnRunClear.MouseEnter += new System.EventHandler(this.btnRunClear_MouseEnter);
            this.btnRunClear.MouseLeave += new System.EventHandler(this.btnRunClear_MouseLeave);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3, 28);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(145, 35);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnOpen.MouseEnter += new System.EventHandler(this.btnOpen_MouseEnter);
            this.btnOpen.MouseLeave += new System.EventHandler(this.btnOpen_MouseLeave);
            // 
            // btnRunWithDebugger
            // 
            this.btnRunWithDebugger.Enabled = false;
            this.btnRunWithDebugger.Location = new System.Drawing.Point(299, 28);
            this.btnRunWithDebugger.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnRunWithDebugger.Name = "btnRunWithDebugger";
            this.btnRunWithDebugger.Size = new System.Drawing.Size(145, 35);
            this.btnRunWithDebugger.TabIndex = 3;
            this.btnRunWithDebugger.Text = "Run";
            this.btnRunWithDebugger.UseVisualStyleBackColor = true;
            this.btnRunWithDebugger.Click += new System.EventHandler(this.btnRunWithDebugger_Click);
            this.btnRunWithDebugger.MouseEnter += new System.EventHandler(this.btnRunWithDebugger_MouseEnter);
            this.btnRunWithDebugger.MouseLeave += new System.EventHandler(this.btnRunWithDebugger_MouseLeave);
            // 
            // lblRunCurrentFile
            // 
            this.lblRunCurrentFile.AutoSize = true;
            this.lblRunCurrentFile.Location = new System.Drawing.Point(5, 5);
            this.lblRunCurrentFile.Margin = new System.Windows.Forms.Padding(5);
            this.lblRunCurrentFile.Name = "lblRunCurrentFile";
            this.lblRunCurrentFile.Size = new System.Drawing.Size(0, 20);
            this.lblRunCurrentFile.TabIndex = 1;
            // 
            // txtRunOutput
            // 
            this.txtRunOutput.BackColor = System.Drawing.Color.Black;
            this.txtRunOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtRunOutput.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRunOutput.ForeColor = System.Drawing.Color.White;
            this.txtRunOutput.Location = new System.Drawing.Point(0, 69);
            this.txtRunOutput.Multiline = true;
            this.txtRunOutput.Name = "txtRunOutput";
            this.txtRunOutput.ReadOnly = true;
            this.txtRunOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRunOutput.Size = new System.Drawing.Size(447, 220);
            this.txtRunOutput.TabIndex = 0;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.chkSettingsShowDebug);
            this.panelSettings.Controls.Add(this.btnSettingsSave);
            this.panelSettings.Controls.Add(this.lblSettingsLanguage);
            this.panelSettings.Controls.Add(this.cboSettingsLanguage);
            this.panelSettings.Location = new System.Drawing.Point(521, 334);
            this.panelSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(264, 200);
            this.panelSettings.TabIndex = 9;
            this.panelSettings.Visible = false;
            // 
            // chkSettingsShowDebug
            // 
            this.chkSettingsShowDebug.AutoSize = true;
            this.chkSettingsShowDebug.Location = new System.Drawing.Point(7, 66);
            this.chkSettingsShowDebug.Name = "chkSettingsShowDebug";
            this.chkSettingsShowDebug.Size = new System.Drawing.Size(193, 24);
            this.chkSettingsShowDebug.TabIndex = 3;
            this.chkSettingsShowDebug.Text = "Show debug information";
            this.chkSettingsShowDebug.UseVisualStyleBackColor = true;
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Location = new System.Drawing.Point(3, 158);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(98, 39);
            this.btnSettingsSave.TabIndex = 2;
            this.btnSettingsSave.Text = "Save";
            this.btnSettingsSave.UseVisualStyleBackColor = true;
            // 
            // lblSettingsLanguage
            // 
            this.lblSettingsLanguage.AutoSize = true;
            this.lblSettingsLanguage.Location = new System.Drawing.Point(3, 4);
            this.lblSettingsLanguage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSettingsLanguage.Name = "lblSettingsLanguage";
            this.lblSettingsLanguage.Size = new System.Drawing.Size(74, 20);
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
            this.cboSettingsLanguage.Location = new System.Drawing.Point(6, 31);
            this.cboSettingsLanguage.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cboSettingsLanguage.Name = "cboSettingsLanguage";
            this.cboSettingsLanguage.Size = new System.Drawing.Size(252, 28);
            this.cboSettingsLanguage.TabIndex = 0;
            this.cboSettingsLanguage.SelectedValueChanged += new System.EventHandler(this.cboSettingsLanguage_SelectedValueChanged);
            // 
            // ofdMain
            // 
            this.ofdMain.Filter = "Desktop files|*.desktop|All file|*.*";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 586);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelDebugger);
            this.Controls.Add(this.panelEditor);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
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
        private System.Windows.Forms.Button btnRunClear;
        private System.Windows.Forms.CheckBox chkSettingsShowDebug;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.ToolStripMenuItem creationWizardToolStripMenuItem;
    }
}
