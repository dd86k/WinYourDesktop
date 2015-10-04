using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;

/*
    FormHandler.cs
    FormMain
    Methods, properties, enums.
*/

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
            panelMain.Location =
                new Point
                {
                    X = 0,
                    Y = msMain.Size.Height
                };

            ClientSize = new Size
            {
                Width = panelMain.Size.Width,
                Height =
                    msMain.Size.Height +
                    panelMain.Size.Height +
                    ssMain.Size.Height
            };

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

            // ========== Menu bar
            // App
            tsmApplication.Text = RM.GetString("tsmApplication");
            tsmiRestart.Text = RM.GetString("tsmiRestart");
            tsmiQuit.Text = RM.GetString("tsmiQuit");
            // View
            tsmView.Text = RM.GetString("tsmView");
            tsmiHome.Text = RM.GetString("tsmiHome");
            tsmiEditor.Text = RM.GetString("tsmiEditor");
            tsmiDebugger.Text = RM.GetString("tsmiDebugger");
            tsmiSettings.Text = RM.GetString("tsmiSettings");
            // Tools
            tsmTools.Text = RM.GetString("tsmTools");

            // ?
            //tsmiHelp.Text = RM.GetString("tsmiHelp");
            tsmiAbout.Text = RM.GetString("tsmiAbout");

            // ========== Home panel
            btnRun.Text = RM.GetString("btnRun");
            btnCreate.Text = RM.GetString("btnCreate");
            btnEdit.Text = RM.GetString("btnEdit");
            btnDebug.Text = RM.GetString("btnDebug");

            // ========== Run panel
            btnOpen.Text = RM.GetString("btnOpen");
            btnRunClear.Text = RM.GetString("btnRunClear");
            btnRunWithDebugger.Text = RM.GetString("btnRun");

            // ========== Settings panel
            lblSettingsLanguage.Text = RM.GetString("lblSettingsLanguage");

            // ========== Misc.
            sslblStatus.Text = RM.GetString("Welcome");
        }
        #endregion

        #region Viewing modes
        /// <summary>
        /// Viewing modes.
        /// </summary>
        enum ViewingMode
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
                    ClientSize = new Size
                    {
                        Width = panelMain.Size.Width,
                        Height =
                            msMain.Size.Height +
                            panelMain.Size.Height +
                            ssMain.Size.Height
                    };
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
                    ClientSize = new Size
                    {
                        Width = panelEditor.Size.Width,
                        Height =
                            msMain.Size.Height +
                            panelEditor.Size.Height +
                            ssMain.Size.Height
                    };
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
                    ClientSize = new Size
                    {
                        Width = panelDebugger.Size.Width,
                        Height =
                            msMain.Size.Height +
                            panelDebugger.Size.Height +
                            ssMain.Size.Height
                    };
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
                    ClientSize = new Size
                    {
                        Width = panelMain.Size.Width,
                        Height =
                            msMain.Size.Height +
                            panelSettings.Size.Height +
                            ssMain.Size.Height
                    };
                    break;
            }

            ResumeLayout(true);
        }
        #endregion
    }
}
