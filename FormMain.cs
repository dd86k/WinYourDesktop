using System.Windows.Forms;
using System.Drawing;

namespace WinYourDesktop
{
    internal partial class FormMain : Form
    {
        #region Constructors
        internal FormMain() : this(null)
        {
            // Call FormMain(string) with this(null)
        }

        string file = null;
        internal FormMain(string pDesktopFilePath)
        {
            InitializeComponent();

            if (pDesktopFilePath != null)
            {
                file = pDesktopFilePath;
            }
        }
        #endregion

        #region Modes
        /// <summary>
        /// Viewing modes.
        /// </summary>
        enum ViewingMode
        {
            /// <summary>
            /// Default viewing mode.
            /// Also like ImgBurn's Ez-Picker Mode.
            /// </summary>
            Default,
            /// <summary>
            /// Editing
            /// </summary>
            Editing,
            Debugging
        }

        ViewingMode CurrentViewingMode = ViewingMode.Default;

        void ToggleMode(ViewingMode pNewViewingMode)
        {
            //TODO: Mode toggle
            // ...Just do the other panels.

            this.SuspendLayout();

            switch (CurrentViewingMode)
            {
                case ViewingMode.Default:
                    MainPanel.Visible = false;
                    break;
                case ViewingMode.Editing:

                    break;
                case ViewingMode.Debugging:

                    break;
            }

            switch (pNewViewingMode)
            {
                case ViewingMode.Default:
                    MainPanel.Visible = true;
                    break;
                case ViewingMode.Editing:
                    break;
                case ViewingMode.Debugging:
                    break;
            }

            this.ResumeLayout(false);
        }
        #endregion

        #region Menubar
        // Editor mode
        private void showEditorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

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

        // Create
        private void btnCreate_Click(object sender, System.EventArgs e)
        {

        }

        // Debug
        private void btnDebug_Click(object sender, System.EventArgs e)
        {

        }

        // Edit
        private void btnEdit_Click(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
