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

//TODO: Pick random welcoming text at startup

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
            this.SuspendLayout();

            this.panelDebugger.Location =
            this.panelEditor.Location =
            this.panelSettings.Location =
            this.panelMain.Location =
                new Point
                {
                    X = 0,
                    Y = this.msMain.Size.Height
                };

            this.ClientSize = new Size
            {
                Width = this.panelMain.Size.Width,
                Height =
                    this.msMain.Size.Height +
                    this.panelMain.Size.Height +
                    this.ssMain.Size.Height
            };

            ChangeCulture();

            this.ResumeLayout();
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
            // For now, we're using a switch, but if this project
            // gets really big, now we could use string interpolation.
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

            // == Menu bar ==
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
            tsmiHelp.Text = RM.GetString("tsmiHelp");
            tsmiAbout.Text = RM.GetString("tsmiAbout");

            // == Main panel ==
            // Home buttons
            btnRun.Text = RM.GetString("btnRun");
            btnCreate.Text = RM.GetString("btnCreate");
            btnEdit.Text = RM.GetString("btnEdit");
            btnDebug.Text = RM.GetString("btnDebug");

            // == Misc ==
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
            Debuger,
            Settings
        }

        void ToggleMode(ViewingMode pNewViewingMode)
        {
            this.SuspendLayout();

            switch (pNewViewingMode)
            {
                case ViewingMode.Home:
                    panelMain.Visible = true;
                    panelEditor.Visible = false;
                    panelDebugger.Visible = false;
                    panelSettings.Visible = false;
                    this.ClientSize = new Size
                    {
                        Width = this.panelMain.Size.Width,
                        Height =
                            this.msMain.Size.Height +
                            this.panelMain.Size.Height +
                            this.ssMain.Size.Height
                    };
                    break;

                case ViewingMode.Editor:
                    panelMain.Visible = false;
                    panelEditor.Visible = true;
                    panelDebugger.Visible = false;
                    panelSettings.Visible = false;
                    this.ClientSize = new Size
                    {
                        Width = this.panelMain.Size.Width,
                        Height =
                            this.msMain.Size.Height +
                            this.panelEditor.Size.Height +
                            this.ssMain.Size.Height
                    };
                    break;

                case ViewingMode.Debuger:
                    panelMain.Visible = false;
                    panelEditor.Visible = false;
                    panelDebugger.Visible = true;
                    panelSettings.Visible = false;
                    this.ClientSize = new Size
                    {
                        Width = this.panelMain.Size.Width,
                        Height =
                            this.msMain.Size.Height +
                            this.panelDebugger.Size.Height +
                            this.ssMain.Size.Height
                    };
                    break;

                case ViewingMode.Settings:
                    panelMain.Visible = false;
                    panelEditor.Visible = false;
                    panelDebugger.Visible = false;
                    panelSettings.Visible = true;
                    this.ClientSize = new Size
                    {
                        Width = this.panelMain.Size.Width,
                        Height =
                            this.msMain.Size.Height +
                            this.panelSettings.Size.Height +
                            this.ssMain.Size.Height
                    };
                    break;
            }

            this.ResumeLayout(true);
        }
        #endregion
    }
}
