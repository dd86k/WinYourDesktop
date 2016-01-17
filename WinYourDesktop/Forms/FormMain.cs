using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinYourDesktopLibrary;

//TODO:View: Execute -> OpenFileDialog -> Interpreter
//TODO:View: Create -> SaveFileDialog -> Edit mode

// Tip: In VS, you can fold all #regions with CTRL+M+O.

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

            if (File.Exists(pDesktopFilePath))
            {
                CurrentFile = new FileInfo(pDesktopFilePath);
            }
        }
        #endregion

        #region Main MenuStrip (ssMain)
        #region App
        // Restart
        private void restartToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Restart();
        }

        // Quit
        private void quitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region View mode
        // Home view
        private void tsmiHome_Click(object sender, System.EventArgs e)
        {
            if (!tsmiHome.Checked)
            {
                ToggleMode(ViewingMode.Home);
            }
        }

        // Editor view
        private void tsmiEditor_Click(object sender, System.EventArgs e)
        {
            if (!tsmiEditor.Checked)
            {
                ToggleMode(ViewingMode.Editor);
            }
        }

        // Debugger view
        private void tsmiDebugger_Click(object sender, System.EventArgs e)
        {
            if (!tsmiDebugger.Checked)
            {
                ToggleMode(ViewingMode.Debugger);
            }
        }

        // Settings view
        private void tsmiSettings_Click(object sender, System.EventArgs e)
        {
            if (!tsmiSettings.Checked)
            {
                ToggleMode(ViewingMode.Settings);
            }
        }
        #endregion

        #region Tools
        private void tsmiCreationWizard_Click(object sender, System.EventArgs e)
        {

        }

        private void tsmiCreationWizard_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("tsmiCreationWizard_MouseEnter");
        }

        private void tsmiCreationWizard_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }
        #endregion

        #region ?
        // Help
        private void tsmiHelp_Click(object sender, System.EventArgs e)
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
        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
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
        private void btnRun_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRun_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnRun_MouseEnter");
        }

        private void btnRun_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Create
        private void btnCreate_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCreate_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnCreate_MouseEnter");
        }

        private void btnCreate_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Debug
        private void btnDebug_Click(object sender, System.EventArgs e)
        {
            ToggleMode(ViewingMode.Debugger);
        }

        private void btnDebug_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnDebug_MouseEnter");
        }

        private void btnDebug_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Edit
        private void btnEdit_Click(object sender, System.EventArgs e)
        {

        }

        private void btnEdit_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnEdit_MouseEnter");
        }

        private void btnEdit_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }
        #endregion

        #region Edit view

        #endregion

        #region Debug view
        // Open file
        private void btnOpen_Click(object sender, System.EventArgs e)
        {
            ofdMain.FileName = string.Empty;
            ofdMain.ShowDialog();
            if (ofdMain.FileName != string.Empty)
            {
                SetCurrentFile(ofdMain.FileName);
            }
        }

        private void btnOpen_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnOpen_MouseEnter");
        }

        private void btnOpen_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Copy output
        private void btnRunCopyOutput_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(txtRunOutput.Text, TextDataFormat.UnicodeText);
        }

        private void btnRunCopy_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnRunCopy_MouseEnter");
        }

        private void btnRunCopy_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Run file
        private void btnRunWithDebugger_Click(object sender, System.EventArgs e)
        {
            txtRunOutput.Clear();
            int r = Interpreter.Run(CurrentFile.FullName);
            txtRunOutput.AppendText($"Return code: 0x{r:X8} ({r})");
        }

        private void btnRunWithDebugger_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnRunWithDebugger_MouseEnter");
        }

        private void btnRunWithDebugger_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // DragDrop
        private void panelDebugger_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void panelDebugger_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] list = (string[])(e.Data.GetData(DataFormats.FileDrop));

                if (list[0].ToLower().Contains(".desktop"))
                    SetCurrentFile(list[0]);
            }
        }
        #endregion

        #region Settings view
        private void btnSettingsSave_Click(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
