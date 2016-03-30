using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinYourDesktop
{
    partial class FormMain
    {
        #region Properties
        FileInfo CurrentFile;
        NotificationHandler NotificationHandler;
        ResourceManager RM;
        readonly string nl = Environment.NewLine;
        #endregion
        
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

            panelDebugger.Location =
                panelEditor.Location =
                panelSettings.Location =
                panelMain.Location =
                new Point(0, msMain.Height);

            AdjustClientSize(panelMain);

            Console.SetOut(new ConReader(txtRunOutput));

            NotificationHandler = new NotificationHandler(tsmNotifications, ImageListNotification);

            ChangeCulture();

            ResumeLayout();
        }

        #region Language
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
        /// <param name="pLanguage"></param>
        void ChangeCulture(CultureInfo pLanguage)
        {
            ChangeCulture(pLanguage.Name);
        }

        /// <summary>
        /// Change the current culture (locale) with a string name.
        /// </summary>
        /// <param name="pLanguage">Culture name.</param>
        void ChangeCulture(string pLanguage)
        {
#if DEBUG && EN
            pLanguage = "en";
#endif

            switch (pLanguage)
            {
                case "en-Pirate":
                    RM = new ResourceManager("WinYourDesktop.Culture.en-Pirate",
                             typeof(FormMain).Assembly);
                    break;

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
            tsmiRestart.Text = RM.GetString("tsmiRestart");
            tsmiQuit.Text = RM.GetString("tsmiQuit");
            // == View
            tsmView.Text = RM.GetString("tsmView");
            tsmiHome.Text = RM.GetString("tsmiHome");
            tsmiEditor.Text = RM.GetString("tsmiEditor");
            tsmiDebugger.Text = RM.GetString("tsmiDebugger");
            tsmiSettings.Text = RM.GetString("tsmiSettings");
            // == Tools
            tsmTools.Text = RM.GetString("tsmTools");
            tsmiCreationWizard.Text = RM.GetString("tsmiCreationWizard");
            // == ?
            tsmiHelp.Text = RM.GetString("tsmiHelp");
            tsmiAbout.Text = RM.GetString("tsmiAbout");

            // === panelMain
            btnRun.Text = RM.GetString("btnRun");
            btnCreate.Text = RM.GetString("btnCreate");
            btnEdit.Text = RM.GetString("btnEdit");
            btnDebug.Text = RM.GetString("btnDebug");

            // === panelDebugger
            btnOpen.Text = RM.GetString("btnOpen");
            btnRunCopy.Text = RM.GetString("btnRunCopy");
            btnRunWithDebugger.Text = RM.GetString("btnRun");

            // === panelSettings
            lblSettingsLanguage.Text = RM.GetString("lblSettingsLanguage");
            cboSettingsLanguage.Text = RM.GetString("cboSettingsLanguage");
            btnSettingsSave.Text = RM.GetString("btnSettingsSave");

            // === ssMain
            sslblStatus.Text = RM.GetString("Welcome");
        }
#endregion

#region Viewing modes
        /// <summary>
        /// Viewing modes.
        /// </summary>
        enum ViewingMode : byte
        {
            Home, Editor, Debugger, Settings
        }

        ViewingMode CurrentView = ViewingMode.Home;

        void ToggleMode(ViewingMode pNewViewingMode)
        {
            SuspendLayout();

            switch (pNewViewingMode)
            {
                case ViewingMode.Home:
                    tsmiHome.Checked =
                        panelMain.Visible = true;
                    tsmiEditor.Checked =
                        tsmiDebugger.Checked =
                        tsmiSettings.Checked =
                        panelEditor.Visible =
                        panelDebugger.Visible =
                        panelSettings.Visible = false;
                    AdjustClientSize(panelMain);
                    CurrentView = ViewingMode.Home;
                    break;

                case ViewingMode.Editor:
                    tsmiEditor.Checked =
                        panelEditor.Visible = true;
                    tsmiHome.Checked =
                        tsmiDebugger.Checked =
                        tsmiSettings.Checked =
                        panelMain.Visible =
                        panelDebugger.Visible =
                        panelSettings.Visible = false;
                    AdjustClientSize(panelEditor);
                    CurrentView = ViewingMode.Editor;
                    break;

                case ViewingMode.Debugger:
                    tsmiDebugger.Checked =
                        panelDebugger.Visible = true;
                    tsmiHome.Checked =
                        tsmiEditor.Checked =
                        tsmiSettings.Checked =
                        panelMain.Visible =
                        panelEditor.Visible =
                        panelSettings.Visible = false;
                    AdjustClientSize(panelDebugger);
                    CurrentView = ViewingMode.Debugger;
                    break;

                case ViewingMode.Settings:
                    tsmiSettings.Checked =
                        panelSettings.Visible = true;
                    tsmiHome.Checked =
                        tsmiEditor.Checked =
                        tsmiDebugger.Checked =
                        panelMain.Visible =
                        panelEditor.Visible =
                        panelDebugger.Visible = false;
                    AdjustClientSize(panelSettings);
                    CurrentView = ViewingMode.Settings;
                    break;
            }

            ResumeLayout(true);
        }
#endregion

        /// <summary>
        /// Adjusts the size of the client.
        /// </summary>
        /// <param name="pPanel">Panel</param>
        void AdjustClientSize(Panel pPanel)
        {
            ClientSize = new Size(pPanel.Width,
                msMain.Height +
                pPanel.Height +
                ssMain.Height
            );
        }

        /// <summary>
        /// Adjusts the size of the client.
        /// </summary>
        /// <param name="pPanelHeight">Panel's height.</param>
        void AdjustClientSize(int pPanelWidth, int pPanelHeight)
        {
            ClientSize = new Size(pPanelWidth,
                msMain.Height +
                pPanelHeight +
                ssMain.Height
            );
        }

        /// <summary>
        /// Sets current file.
        /// </summary>
        /// <param name="pPath">File path.</param>
        void SetCurrentFile(string pPath)
        {
            if (File.Exists(pPath))
            {
                switch (CurrentView)
                {
                    case ViewingMode.Home:
                        break;
                    case ViewingMode.Editor:
                        break;
                    case ViewingMode.Debugger:
                        lblRunCurrentFile.Text = Path.GetFileName(pPath);
                        btnRunWithDebugger.Enabled = true;
                        break;
                    case ViewingMode.Settings:
                        break;
                }
            }
        }
    }

    #region Console wrapper UI implementation
    /// <summary>
    /// Console Reader
    /// </summary>
    public class ConReader : TextWriter
    {
        TextBox t = null;

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
