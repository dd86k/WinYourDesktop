using System;
using System.Drawing;
using System.Windows.Forms;
using WinYourDesktopLibrary;

//TODO: Sizable form (v0.7)
//TODO: Edit mode (v0.6)
//TODO: Dark theme (v0.7)

// Tip: In VS, you can fold every scope with CTRL+M+O.

namespace WinYourDesktop
{
    internal partial class FormMain : Form
    {
        #region Constructors
        internal FormMain()
        {
            InitializeComponent();
            PostInitialize();
        }
        
        internal FormMain(string pDesktopFilePath)
        {
            InitializeComponent();
            PostInitialize();

            MakeCurrentFile(pDesktopFilePath, true);
        }
        #endregion

        #region Main MenuStrip (ssMain)
        #region App
        // Restart
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        // Quit
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region View mode
        // Home view
        private void tsmiHome_Click(object sender, EventArgs e)
        {
            if (!tsmiHome.Checked)
            {
                ToggleMode(ViewingMode.Home);
            }
        }

        // Editor view
        private void tsmiEditor_Click(object sender, EventArgs e)
        {
            if (!tsmiEditor.Checked)
            {
                ToggleMode(ViewingMode.Editor);
            }
        }

        // Debugger view
        private void tsmiDebugger_Click(object sender, EventArgs e)
        {
            if (!tsmiDebugger.Checked)
            {
                ToggleMode(ViewingMode.Debugger);
            }
        }

        // Settings view
        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            if (!tsmiSettings.Checked)
            {
                ToggleMode(ViewingMode.Settings);
            }
        }
        #endregion

        #region Tools
        private void tsmiCreationWizard_Click(object sender, EventArgs e)
        {

        }

        private void tsmiCreationWizard_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiCreationWizard_MouseEnter");
        }

        private void tsmiCreationWizard_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }
        #endregion

        #region ?
        // Help
        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            FormHelp fHelp = new FormHelp();
            fHelp.Location = new Point
            {
                // FormHelp will show right if only it can fit into the current screen.
                X = Location.X + Size.Width + fHelp.Size.Width >
                        Screen.FromControl(this).WorkingArea.Size.Width ?
                        Location.X - fHelp.Size.Width :
                        Location.X + Size.Width,
                Y = Location.Y
            };
            fHelp.Show();
        }

        // About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout fAbout = new FormAbout();
            fAbout.Location = new Point
            {
                // FormAbout will show right if only it can fit into the current screen.
                X = Location.X + Size.Width + fAbout.Size.Width >
                        Screen.FromControl(this).WorkingArea.Size.Width ?
                        Location.X - fAbout.Size.Width :
                        Location.X + Size.Width,
                Y = Location.Y
            };
            fAbout.Show();
        }
        #endregion
        #endregion

        #region Home view
        // Run
        private void btnRun_Click(object sender, EventArgs e)
        {
            DialogResult r = ofdMain.ShowDialog();

            if (r == DialogResult.OK)
            {
                ErrorCode c = Interpreter.Run(ofdMain.FileName);

                if (c == ErrorCode.Success)
                    Application.Exit();
                else
                    sslblStatus.Text = c.ToString();
            }
        }

        private void btnRun_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnRun_MouseEnter");
        }

        private void btnRun_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Create
        private void btnCreate_Click(object sender, EventArgs e)
        {
            ToggleMode(ViewingMode.Editor);
        }

        private void btnCreate_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnCreate_MouseEnter");
        }

        private void btnCreate_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Debug
        private void btnDebug_Click(object sender, EventArgs e)
        {
            ToggleMode(ViewingMode.Debugger);
        }

        private void btnDebug_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnDebug_MouseEnter");
        }

        private void btnDebug_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ToggleMode(ViewingMode.Editor);
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnEdit_MouseEnter");
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }
        #endregion

        #region Editor view
        // Refresh
        private void btnEditorRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnEditorRefresh_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnEditorRefresh_MouseEnter");
        }

        private void btnEditorRefresh_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Move up
        private void btnEditorMoveUp_Click(object sender, EventArgs e)
        {

        }

        private void btnEditorMoveUp_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnEditorMoveUp_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Move down
        private void btnEditorMoveDown_Click(object sender, EventArgs e)
        {

        }

        private void btnEditorMoveDown_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnEditorMoveDown_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Add
        private void btnEditorAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEditorAdd_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnEditorAdd_MouseEnter");
        }

        private void btnEditorAdd_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Modify
        private void btnEditorModify_Click(object sender, EventArgs e)
        {

        }
        private void btnEditorModify_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnEditorModify_MouseEnter");
        }

        private void btnEditorModify_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Remove
        private void btnEditorRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnEditorRemove_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnEditorRemove_MouseEnter");
        }

        private void btnEditorRemove_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // == msEditor
        // = tsmFile

        // Open
        private void tsmiEditorOpen_Click(object sender, EventArgs e)
        {
            PromptToMakeCurrentFile();
        }

        private void tsmiEditorOpen_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiEditorOpen_MouseEnter");
        }

        private void tsmiEditorOpen_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }
        
        // Save
        private void tsmiEditorSave_Click(object sender, EventArgs e)
        {

        }

        private void tsmiEditorSave_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiEditorSave_MouseEnter");
        }

        private void tsmiEditorSave_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Save as...
        private void tsmiEditorSaveAs_Click(object sender, EventArgs e)
        {

        }

        private void tsmiEditorSaveAs_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiEditorSaveAs_MouseEnter");
        }

        private void tsmiEditorSaveAs_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Debug
        private void tsmiEditorDebug_Click(object sender, EventArgs e)
        {

        }

        private void tsmiEditorDebug_MouseEnter(object sender, EventArgs e)
        {

        }

        private void tsmiEditorDebug_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Run
        private void tsmiEditorRun_Click(object sender, EventArgs e)
        {

        }

        private void tsmiEditorRun_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiEditorRun_MouseEnter");
        }

        private void tsmiEditorRun_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }
        #endregion

        #region Debug view
        // Run
        private void btnDebuggerRun_Click(object sender, EventArgs e)
        {
            txtDebuggerOutput.Clear();
            ErrorCode r = Interpreter.Run(CurrentFile.FullName, true);

            if (r != ErrorCode.Success)
            {
                txtDebuggerOutput.AppendText($"Return code: 0x{r.S():X4} ({r})\n");
                txtDebuggerOutput.AppendText($"Message: {r.GetErrorMessage()}");
            }
            else
                txtDebuggerOutput.AppendText("OK!");
        }

        private void btnDebuggerRun_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnDebuggerRun_MouseEnter");
        }

        private void btnDebuggerRun_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // == msDebugger

        // Open
        private void tsmiDebuggerOpen_Click(object sender, EventArgs e)
        {
            PromptToMakeCurrentFile();
        }

        private void tsmiDebuggerOpen_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiDebuggerOpen_MouseEnter");
        }

        private void tsmiDebuggerOpen_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Edit
        private void tsmiDebuggerEdit_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDebuggerEdit_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiDebuggerEdit_MouseEnter");
        }

        private void tsmiDebuggerEdit_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Run
        private void tsmiDebuggerRun_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDebuggerRun_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiDebuggerRun_MouseEnter");
        }

        private void tsmiDebuggerRun_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Clear
        private void tsmiDebuggerClear_Click(object sender, EventArgs e)
        {
            txtDebuggerOutput.Clear();
        }

        private void tsmiDebuggerClear_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiDebuggerClear_MouseEnter");
        }

        private void tsmiDebuggerClear_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Copy to clipboard
        private void tsmiDebuggerCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDebuggerOutput.Text, TextDataFormat.UnicodeText);
        }

        private void tsmiDebuggerCopyToClipboard_MouseEnter(object sender, EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiDebuggerCopyToClipboard_MouseEnter");
        }

        private void tsmiDebuggerCopyToClipboard_MouseLeave(object sender, EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }
        
        // DragDrop
        private void panelDebugger_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect =
                e.Data.GetDataPresent(DataFormats.FileDrop) ?
                DragDropEffects.Move :
                DragDropEffects.None;
        }

        private void panelDebugger_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] list = (string[])(e.Data.GetData(DataFormats.FileDrop));

                if (list[0].ToLower().Contains(".desktop"))
                    MakeCurrentFile(list[0], false);
            }
        }
        #endregion

        #region Settings view
        private void btnSettingsSave_Click(object sender, EventArgs e)
        {
            string language = cboSettingsLanguage.SelectedItem.ToString();
            language = language.Substring(language.IndexOf('(') + 1);
            switch (language.TrimEnd(')'))
            {
                case "French":
                    ChangeCulture("fr-FR");
                    break;

                case "Pirate":
                    ChangeCulture("en-Pirate");
                    break;

                default:
                    ChangeCulture("en-US");
                    break;
            }

            //TODO: Don't forget to save with the SettingsManager! (v0.8)
        }
        #endregion
    }
}
