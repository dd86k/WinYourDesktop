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
            this.tsmiEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebugger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.panelSettings = new System.Windows.Forms.Panel();
            this.lblSettingsLanguage = new System.Windows.Forms.Label();
            this.cboSettingsLanguage = new System.Windows.Forms.ComboBox();
            this.msMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmApplication,
            this.tsmView,
            this.tsmTools,
            this.tsmiSupport,
            this.toolStripMenuItem1});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msMain.Size = new System.Drawing.Size(712, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmApplication
            // 
            this.tsmApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRestart,
            this.tsmiQuit});
            this.tsmApplication.Name = "tsmApplication";
            this.tsmApplication.Size = new System.Drawing.Size(41, 20);
            this.tsmApplication.Text = "App";
            // 
            // tsmiRestart
            // 
            this.tsmiRestart.Name = "tsmiRestart";
            this.tsmiRestart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiRestart.Size = new System.Drawing.Size(151, 22);
            this.tsmiRestart.Text = "Restart";
            this.tsmiRestart.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiQuit.Size = new System.Drawing.Size(151, 22);
            this.tsmiQuit.Text = "Quit";
            this.tsmiQuit.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // tsmView
            // 
            this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHome,
            this.tsmiEditor,
            this.tsmiDebugger,
            this.tsmiSettings});
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(44, 20);
            this.tsmView.Text = "View";
            // 
            // tsmiHome
            // 
            this.tsmiHome.Checked = true;
            this.tsmiHome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiHome.Name = "tsmiHome";
            this.tsmiHome.Size = new System.Drawing.Size(126, 22);
            this.tsmiHome.Text = "Home";
            this.tsmiHome.Click += new System.EventHandler(this.tsmiHome_Click);
            // 
            // tsmiEditor
            // 
            this.tsmiEditor.Name = "tsmiEditor";
            this.tsmiEditor.Size = new System.Drawing.Size(126, 22);
            this.tsmiEditor.Text = "Editor";
            this.tsmiEditor.Click += new System.EventHandler(this.tsmiEditor_Click);
            // 
            // tsmiDebugger
            // 
            this.tsmiDebugger.Name = "tsmiDebugger";
            this.tsmiDebugger.Size = new System.Drawing.Size(126, 22);
            this.tsmiDebugger.Text = "Debugger";
            this.tsmiDebugger.Click += new System.EventHandler(this.tsmiDebugger_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(126, 22);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmTools
            // 
            this.tsmTools.Name = "tsmTools";
            this.tsmTools.Size = new System.Drawing.Size(47, 20);
            this.tsmTools.Text = "Tools";
            // 
            // tsmiSupport
            // 
            this.tsmiSupport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelp,
            this.toolStripSeparator1,
            this.tsmiAbout});
            this.tsmiSupport.Name = "tsmiSupport";
            this.tsmiSupport.Size = new System.Drawing.Size(24, 20);
            this.tsmiSupport.Text = "?";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tsmiHelp.Size = new System.Drawing.Size(118, 22);
            this.tsmiHelp.Text = "Help";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(118, 22);
            this.tsmiAbout.Text = "About";
            this.tsmiAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
            this.toolStripMenuItem1.Text = "0";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslblStatus});
            this.ssMain.Location = new System.Drawing.Point(0, 570);
            this.ssMain.Name = "ssMain";
            this.ssMain.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ssMain.Size = new System.Drawing.Size(712, 22);
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "statusStrip1";
            // 
            // sslblStatus
            // 
            this.sslblStatus.Name = "sslblStatus";
            this.sslblStatus.Size = new System.Drawing.Size(38, 17);
            this.sslblStatus.Text = "Hello!";
            // 
            // btnRun
            // 
            this.btnRun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRun.BackgroundImage")));
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(2, 2);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(128, 96);
            this.btnRun.TabIndex = 2;
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
            this.btnEdit.Location = new System.Drawing.Point(134, 102);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(128, 96);
            this.btnEdit.TabIndex = 3;
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
            this.btnDebug.Location = new System.Drawing.Point(2, 102);
            this.btnDebug.Margin = new System.Windows.Forms.Padding(2);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(128, 96);
            this.btnDebug.TabIndex = 4;
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
            this.btnCreate.Location = new System.Drawing.Point(134, 2);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(128, 96);
            this.btnCreate.TabIndex = 5;
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
            this.panelMain.Location = new System.Drawing.Point(12, 59);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(264, 200);
            this.panelMain.TabIndex = 6;
            // 
            // panelEditor
            // 
            this.panelEditor.Location = new System.Drawing.Point(308, 36);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(287, 248);
            this.panelEditor.TabIndex = 7;
            this.panelEditor.Visible = false;
            // 
            // panelDebugger
            // 
            this.panelDebugger.Location = new System.Drawing.Point(14, 291);
            this.panelDebugger.Name = "panelDebugger";
            this.panelDebugger.Size = new System.Drawing.Size(248, 246);
            this.panelDebugger.TabIndex = 8;
            this.panelDebugger.Visible = false;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.lblSettingsLanguage);
            this.panelSettings.Controls.Add(this.cboSettingsLanguage);
            this.panelSettings.Location = new System.Drawing.Point(308, 291);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(264, 200);
            this.panelSettings.TabIndex = 9;
            this.panelSettings.Visible = false;
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
            "English (English) - en-US",
            "French (Français) - fr-FR",
            "Pirate - en-Pirate"});
            this.cboSettingsLanguage.Location = new System.Drawing.Point(5, 26);
            this.cboSettingsLanguage.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cboSettingsLanguage.Name = "cboSettingsLanguage";
            this.cboSettingsLanguage.Size = new System.Drawing.Size(254, 25);
            this.cboSettingsLanguage.TabIndex = 0;
            this.cboSettingsLanguage.SelectedValueChanged += new System.EventHandler(this.cboSettingsLanguage_SelectedValueChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 592);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
    }
}
