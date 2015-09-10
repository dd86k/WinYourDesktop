using System.Windows.Forms;

namespace WinYourDesktop
{
    internal partial class FormMain : Form
    {
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

        #region Menubar
        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new FormAbout().ShowDialog();
        }

        private void restartToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Restart();
        }

        private void quitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Main buttons

        #endregion
    }
}
