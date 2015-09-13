using System.Windows.Forms;

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

        #region Methods
        void ToggleMode()
        {

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
            new FormAbout().ShowDialog();
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
