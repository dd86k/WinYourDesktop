﻿using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinYourDesktopLibrary;

namespace WinYourDesktop
{
    partial class FormMain
    {
        #region Properties
        FileInfo CurrentFile;
        ResourceManager RM;
        #endregion

        #region Post initialize
        /// <summary>
        /// Prepares the application.
        /// </summary>
        /// <remarks>
        /// This is not in the Designer code because VS will 
        /// rewrite anything that was previously written there.
        /// So, this is untouched by VS.
        /// </remarks>
        void PostInitialize()
        {
            SuspendLayout();
            //Application.Run(new SystemTrayApp());

            panelDebugger.Dock =
                panelSettings.Dock =
                panelMain.Dock =
                    DockStyle.Fill;

            ToggleMode(ViewingMode.Home);

            Console.SetOut(new ConReader(txtDebuggerOutput));

            ChangeCulture();

            ResumeLayout(true);
        }
        #endregion

        #region Culture
        /// <summary>
        /// Change to the system's current culture.
        /// </summary>
        void ChangeCulture()
        {
            ChangeCulture(Thread.CurrentThread.CurrentCulture);
        }

        /// <summary>
        /// Change the current culture (locale) with a
        /// <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="language"></param>
        void ChangeCulture(CultureInfo language)
        {
            ChangeCulture(language.Name);
        }

        /// <summary>
        /// Change the current culture (locale) with a string name.
        /// </summary>
        /// <param name="language">Culture name.</param>
        void ChangeCulture(string language)
        {
#if DEBUG && EN
            pLanguage = "en";
#endif
            if (language == null) return;

            SettingsHandler.Language = language;

            switch (language)
            {
                case "fr-FR":
                case "fr-CA":
                    RM = new ResourceManager("WinYourDesktop.Culture.fr-FR",
                             typeof(FormMain).Assembly);
                    break;

                // Default: English (fallback)
                default:
                    RM = new ResourceManager("WinYourDesktop.Culture.en-US",
                             typeof(FormMain).Assembly);
                    break;
            }

            // === msMain
            // == App
            tsmApplication.Text = RM.GetString("tsmApplication");
            tsmiAssignDesktopFiles.Text = RM.GetString("tsmiAssignDesktopFiles");
            tsmiRestart.Text = RM.GetString("tsmiRestart");
            tsmiQuit.Text = RM.GetString("tsmiQuit");
            // == Mode
            tsmView.Text = RM.GetString("tsmView");
            tsmiHome.Text = RM.GetString("tsmiHome");
            tsmiDebugger.Text = RM.GetString("tsmiDebugger");
            tsmiSettings.Text = RM.GetString("tsmiSettings");
            // == ?
            tsmiHelp.Text = RM.GetString("tsmiHelp");
            tsmiAbout.Text = RM.GetString("tsmiAbout");

            // ==== panelMain
            btnRun.Text = RM.GetString("btnRun");
            btnDebug.Text = RM.GetString("btnDebug");

            // ==== panelDebugger
            lblDebuggerFile.Text = RM.GetString("MiscNoFile");
            // === msDebugger
            tsmDebuggerFile.Text = RM.GetString("tsmDebuggerFile");
            tsmiDebuggerOpen.Text = RM.GetString("tsmiDebuggerOpen");
            tsmiDebuggerRun.Text = RM.GetString("tsmiDebuggerRun");
            tsmDebugger.Text = RM.GetString("tsmDebugger");
            tsmiDebuggerClear.Text = RM.GetString("tsmiDebuggerClear");
            tsmiDebuggerCopyToClipboard.Text = RM.GetString("tsmiDebuggerCopyToClipboard");

            // ==== panelSettings
            lblSettingsLanguage.Text = RM.GetString("lblSettingsLanguage");
            cboSettingsLanguage.Text = RM.GetString("cboSettingsLanguage");
            btnSettingsSave.Text = RM.GetString("btnSettingsSave");

            // ==== ssMain
            sslblStatus.Text = RM.GetString("MiscWelcome");
        }
        #endregion

        #region Viewing modes
        /// <summary>
        /// Viewing modes.
        /// </summary>
        enum ViewingMode : byte
        {
            Home, Debugger, Settings
        }

        void ToggleMode(ViewingMode viewmode)
        {
            SuspendLayout();

            switch (viewmode)
            {
                case ViewingMode.Home:
                    tsmiHome.Checked =
                        panelMain.Visible = true;
                    tsmiDebugger.Checked =
                        tsmiSettings.Checked =
                        panelDebugger.Visible =
                        panelSettings.Visible = false;

                    AdjustClientSize(panelMain);
                    break;

                case ViewingMode.Debugger:
                    tsmiDebugger.Checked =
                        panelDebugger.Visible = true;
                    tsmiHome.Checked =
                        tsmiSettings.Checked =
                        panelMain.Visible =
                        panelSettings.Visible = false;

                    AdjustClientSize(panelDebugger);
                    break;

                case ViewingMode.Settings:
                    tsmiSettings.Checked =
                        panelSettings.Visible = true;
                    tsmiHome.Checked =
                        tsmiDebugger.Checked =
                        panelMain.Visible =
                        panelDebugger.Visible = false;

                    AdjustClientSize(panelSettings);
                    break;
            }

            ResumeLayout(true);
        }

        /// <summary>
        /// Adjusts the size of the client.
        /// </summary>
        /// <param name="panel">Panel</param>
        void AdjustClientSize(Panel panel)
        {
            AdjustClientSize(panel.Width, panel.Height);
        }

        /// <summary>
        /// Adjusts the size of the client.
        /// </summary>
        /// <param name="height">Panel's height.</param>
        void AdjustClientSize(int width, int height)
        {
            ClientSize = new Size(width,
                msMain.Height + height + ssMain.Height
            );
        }
        #endregion

        #region File
        void PromptToMakeCurrentFile()
        {
            if (ofdMain.ShowDialog() == DialogResult.OK)
                MakeCurrentFile(ofdMain.FileName);
        }

        void MakeCurrentFile(string path)
        {
            MakeCurrentFile(new FileInfo(path));
        }

        void MakeCurrentFile(FileInfo file)
        {
            CurrentFile = file;

            lblDebuggerFile.Text = CurrentFile.Name;

            // Debugger
            btnDebuggerRun.Enabled =
                tsmiDebuggerRun.Enabled =
                true;
        }

        void RunFile()
        {
            txtDebuggerOutput.Clear();
            ErrorCode r = Interpreter.Run(CurrentFile.FullName, true);

            if (r != ErrorCode.Success)
            {
                txtDebuggerOutput.AppendText($"Return code: {r} ({r.Hex()})\n");
                txtDebuggerOutput.AppendText($"Message: {r.GetErrorMessage()}");
            }
        }
        #endregion
    }

    #region ConReader
    /// <summary>
    /// Console Reader
    /// </summary>
    public class ConReader : TextWriter
    {
        TextBox t;

        public ConReader(TextBox output)
        {
            t = output;
        }

        public override void Write(char c)
        {
            Append(c.ToString());
        }

        public override void Write(string c)
        {
            Append(c);
        }

        delegate void AppendCallback(string text);

        void Append(string s)
        {
            if (t.InvokeRequired)
                t.Invoke(new AppendCallback(Append), s);
            else
                t.AppendText(s);
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
    #endregion
}