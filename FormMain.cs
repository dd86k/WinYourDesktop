using System.Windows.Forms;

namespace WinYourDesktop
{
    internal partial class FormMain : Form
    {
        internal FormMain() : this(string.Empty)
        {
            // Call FormMain(string.Empty)
        }

        internal FormMain(string pDesktopFilePath)
        {
            InitializeComponent();

            if (pDesktopFilePath != string.Empty)
            {

            }
        }
    }
}
