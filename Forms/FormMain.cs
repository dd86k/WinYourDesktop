using System.Windows.Forms;
using System.Drawing;

/*
    FormMain.cs
    FormMain
    Constructors, events (delegates).
*/

// TODO:View: Execute -> OpenFileDialog
// TODO:View: Create -> SaveFileDialog -> Edit

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
                tsmiHome.Checked = true;
                tsmiEditor.Checked = false;
                tsmiDebugger.Checked = false;
                tsmiSettings.Checked = false;
                ToggleMode(ViewingMode.Home);
            }
        }

        // Editor view
        private void tsmiEditor_Click(object sender, System.EventArgs e)
        {
            if (!tsmiEditor.Checked)
            {
                tsmiHome.Checked = false;
                tsmiEditor.Checked = true;
                tsmiDebugger.Checked = false;
                tsmiSettings.Checked = false;
                ToggleMode(ViewingMode.Editor);
            }
        }

        // Debugger view
        private void tsmiDebugger_Click(object sender, System.EventArgs e)
        {
            if (!tsmiDebugger.Checked)
            {
                tsmiHome.Checked = false;
                tsmiEditor.Checked = false;
                tsmiDebugger.Checked = true;
                tsmiSettings.Checked = false;
                ToggleMode(ViewingMode.Debugger);
            }
        }

        // Settings view
        private void tsmiSettings_Click(object sender, System.EventArgs e)
        {
            if (!tsmiSettings.Checked)
            {
                tsmiHome.Checked = false;
                tsmiEditor.Checked = false;
                tsmiDebugger.Checked = false;
                tsmiSettings.Checked = true;
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
            sslblStatus.Text = RM.GetString("sslblStatusbtnRun");
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
            sslblStatus.Text = RM.GetString("sslblStatusbtnCreate");
        }

        private void btnCreate_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = string.Empty;
        }

        // Debug
        private void btnDebug_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDebug_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("sslblStatusbtnDebug");
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
            sslblStatus.Text = RM.GetString("sslblStatusbtnEdit");
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
                switch (pLevel)
                {
                    case ErrorLevel.Debug:
                        txtRunOutput.Text += $"[ DBUG ] {pInput}{nl}";
                        break;
                    case ErrorLevel.Info:
                        txtRunOutput.Text += $"[ INFO ] {pInput}{nl}";
                        break;
                    case ErrorLevel.Warning:
                        txtRunOutput.Text += $"[ WARN ] {pInput}{nl}";
                        break;
                    case ErrorLevel.Error:
                        txtRunOutput.Text += $"[ ERR! ] {pInput}{nl}";
                        break;
                    case ErrorLevel.Fatal:
                        txtRunOutput.Text += $"[FATAL!] {pInput}{nl}";
                        break;
                }
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

        // Clear output
        private void btnRunClearOutput_Click(object sender, System.EventArgs e)
        {
            txtRunOutput.Clear();
        }

        // Run file
        private void btnRunWithDebugger_Click(object sender, System.EventArgs e)
        {
            Interpreter.Run(CurrentFile.Path);
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
