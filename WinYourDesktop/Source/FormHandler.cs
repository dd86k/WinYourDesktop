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
        /// <summary>
        /// Relocate the panels, resize <see cref="FormMain"/>,
        /// and prepare language.
        /// </summary>
        /// <remarks>
        /// This is not in the Designer code because VS will 
        /// rewrite anything that was previously written there.
        /// So, this is untouched by VS.
        /// </remarks>
        void PostInitialize()
        {
            SuspendLayout();

            panelDebugger.Location =
            panelEditor.Location =
            panelSettings.Location =
            panelMain.Location = new Point(0, msMain.Size.Height);

            AdjustClientSize(panelMain);

            Console.SetOut(new ConStreamWriter(txtRunOutput));

            ChangeCulture();

            ResumeLayout();
        }

        #region Language
        ResourceManager RM;

        void ChangeCulture()
        {
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            ChangeCulture(ci);
        }

        void ChangeCulture(CultureInfo pLanguage)
        {
            ChangeCulture(pLanguage.Name);
        }

        void ChangeCulture(string pLanguage)
        {
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

                case "en":
                case "en-US":
                case "en-UK":
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
            btnRunClear.Text = RM.GetString("btnRunClear");
            btnRunWithDebugger.Text = RM.GetString("btnRun");

            // === panelSettings
            lblSettingsLanguage.Text = RM.GetString("lblSettingsLanguage");

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
            Home,
            Editor,
            Debugger,
            Settings
        }

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
            ClientSize = new Size(pPanel.Size.Width,
                msMain.Size.Height +
                pPanel.Size.Height +
                ssMain.Size.Height
            );
        }

        /// <summary>
        /// Adjusts the size of the client.
        /// </summary>
        /// <param name="pPanelHeight">Panel's height.</param>
        void AdjustClientSize(int pPanelWidth, int pPanelHeight)
        {
            ClientSize = new Size(pPanelWidth,
                msMain.Size.Height +
                pPanelHeight +
                ssMain.Size.Height
            );
            Refresh();
        }
    }

    /// <summary>
    /// Console Reader
    /// </summary>
    public class ConStreamWriter : TextWriter
    {
        TextBox t = null;

        public ConStreamWriter(TextBox output)
        {
            t = output;
        }

        public override void Write(char value)
        {
            t.AppendText($"{value}");
        }

        public override void Write(string value)
        {
            t.AppendText(value);
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
