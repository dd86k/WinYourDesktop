using System.Windows.Forms;
using System.Drawing;

/*
    FormMain.cs
    FormMain
    Constructors, events (delegates).
*/

// TODO:View: Execute -> OpenFileDialog
// TODO:View: Create -> SaveFileDialog -> Edit
// TODO: Drag&Drop:
// *.desktop -> Run
// *.* -> Add entry (edit)

namespace WinYourDesktop
{
    internal partial class FormMain : Form
    {
        #region Properties
        struct CurrentFile
        {
            /// <summary>
            /// Only get the name of the file out of the path.
            /// </summary>
            internal static string FileName
            {
                get
                {
                    return
                        Path != null ?
                        System.IO.Path.GetFileName(Path) : null;
                }
            }
            /// <summary>
            /// The full path of the file.
            /// </summary>
            internal static string Path
            {
                get; set;
            }
        }

        readonly string nl = System.Environment.NewLine;
        #endregion

        #region Constructors
        internal FormMain() : this(null)
        {
            // Call FormMain(string) with this(null)
        }

        string file = null;
        internal FormMain(string pDesktopFilePath)
        {
            InitializeComponent();
            PostInitialize();

            if (pDesktopFilePath != null)
            {
                file = pDesktopFilePath;
            }
        }
        #endregion

        #region Menubar
        // ImgBurn's EzPicker-styled view
        // Do I have to say sorry for this?
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

        // Help
        /*
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
        */

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

        #region Main buttons
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

        #region Debug
        static internal bool DebugEnabled
        {
            get; private set;
        }

        internal enum ErrorLevel
        {
            Debug,
            Info,
            Warning,
            Error,
            Fatal
        }

        static internal void dbgWrite(string pInput)
        {
            Program.form.Write(pInput, ErrorLevel.Info);
        }

        static internal void dbgWrite(string pInput, ErrorLevel pLevel)
        {
            Program.form.Write(pInput, pLevel);
        }

        void Write(string pInput, ErrorLevel pLevel)
        {
            if (DebugEnabled)
            {
                txtRunOutput.AppendText($"[{pLevel}] {pInput}{nl}");
            }
        }

        // Open file
        private void btnOpen_Click(object sender, System.EventArgs e)
        {
            ofdMain.FileName = string.Empty;
            ofdMain.ShowDialog();
            if (ofdMain.FileName != string.Empty)
            {
                CurrentFile.Path = ofdMain.FileName;
                lblRunCurrentFile.Text = CurrentFile.FileName;
                btnRunWithDebugger.Enabled = true;
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

        // Clear output
        private void btnRunClearOutput_Click(object sender, System.EventArgs e)
        {
            txtRunOutput.Clear();
        }

        private void btnRunClear_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnRunClear_MouseEnter");
        }

        private void btnRunClear_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Run file
        private void btnRunWithDebugger_Click(object sender, System.EventArgs e)
        {
            Interpreter.Run(CurrentFile.Path);
        }

        private void btnRunWithDebugger_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("btnRunWithDebugger_MouseEnter");
        }

        private void btnRunWithDebugger_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }
        #endregion

        #region Settings
        private void cboSettingsLanguage_SelectedValueChanged(object sender, System.EventArgs e)
        {
            string culture = string.Empty;
            try
            {
                // I felt like doing a crazy one liner.
                culture =
                    cboSettingsLanguage.Items[cboSettingsLanguage.SelectedIndex]
                    .ToString()
                    .Split(new string[] { " - " }, System.StringSplitOptions.None)[1];
            }
            catch
            { }

            if (culture != string.Empty)
                ChangeCulture(culture);
        }
        #endregion
    }
}
