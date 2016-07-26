using System;
using System.Drawing;
using System.Windows.Forms;
using WinYourDesktopLibrary;
using Microsoft.Win32;
using System.Security.Principal;

// Tip: In VS, you can fold every scope with CTRL+M+O.

namespace WinYourDesktop
{
    internal partial class FormMain : Form
    {
        #region Constructors
        internal FormMain(string path = null)
        {
            InitializeComponent();
            PostInitialize();

            if (SettingsHandler.SettingFileExists)
            {
                SettingsHandler.Load();

                ChangeCulture(SettingsHandler.Language);
            }

            if (path != null)
                MakeCurrentFile(path);

            tsmiAssignDesktopFiles.Enabled = IsAdministrator;
        }
        #endregion

        #region ssMain events
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
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                sslblStatus.Text = "...";

                ErrorCode c = Interpreter.Run(ofdMain.FileName);

                if (c != ErrorCode.Success)
                    sslblStatus.Text = "❌ - " + c.Hex();
                else
                    sslblStatus.Text = "✔️";
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
        #endregion

        #region Debug view
        // Run
        private void btnDebuggerRun_Click(object sender, EventArgs e)
        {
            RunFile();
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

        // Run
        private void tsmiDebuggerRun_Click(object sender, EventArgs e)
        {
            RunFile();
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
                DragDropEffects.Link :
                DragDropEffects.None;
        }

        private void panelDebugger_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string file = ((string[])(e.Data.GetData(DataFormats.FileDrop)))[0];

                if (file.ToLower().EndsWith(".desktop"))
                    MakeCurrentFile(file);
                else
                    MessageBox.Show("!",
                        RM.GetString("Misc_ErrNotDesktopFile"),
                        MessageBoxButtons.OK);
            }
        }
        #endregion

        #region Settings view
        private void cboSettingsLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = cboSettingsLanguage.SelectedItem.ToString();

            // Sorry about this horrible section.
            switch (language.Substring(language.IndexOf('(') + 1).TrimEnd(')'))
            {
                case "French":
                    ChangeCulture("fr-FR");
                    break;

                default:
                    ChangeCulture("en-US");
                    break;
            }
        }

        private void btnSettingsSave_Click(object sender, EventArgs e)
        {
            SettingsHandler.Save();
        }
        #endregion

        private void tsmiAssignDesktopFiles_Click(object sender, EventArgs e)
        { //"C:\PATH\WinYourDesktop.exe" "%1"

            if (MessageBox.Show(RM.GetString("DialogAssignFile"),
                    RM.GetString("DialogAssignFileTitle"),
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string file = System.IO.Path.GetFileNameWithoutExtension(
                        System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
                    );

                    //TODO: Properly make default
                    // https://msdn.microsoft.com/en-us/library/windows/desktop/cc144154(v=vs.85).aspx
                    Registry.SetValue(
                        @"HKEY_CLASSES_ROOT\desktop_auto_file\shell\open\command",
                        "", // Default value name
                        $@"""{file}"" ""%1""", // "C:\e.exe" "%1"
                        RegistryValueKind.String);
                    
                    MessageBox.Show(RM.GetString("DialogAssignFileSuccess"),
                        "OK!",
                        MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        ex.ToString(),
                        MessageBoxButtons.OK);
                }
            }
        }

        // http://stackoverflow.com/a/11660205
        public static bool IsAdministrator =>
            new WindowsPrincipal(WindowsIdentity.GetCurrent())
                .IsInRole(WindowsBuiltInRole.Administrator);
    }
}
