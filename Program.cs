using System;
using System.Windows.Forms;

namespace WinYourDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            // No file or switches
            /*if (args.Length == 0)
            {
                ShowForm();
            }*/

            //string filepath = string.Empty;
            string filepath = "lol.desktop";

            // CLI arguments
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-S":
                    case "--showui":
                        ShowForm();
                        return 0;
                    case "-C":
                    case "--createdummy":
                    case "--touch":

                        break;
                    default:
                        filepath = arg;
                        break;

                }
            }

            if (filepath != string.Empty)
            {
                try
                {
                    Interpreter.Run(filepath);
                }
                catch (Exception ex)
                {
                    string nl = Environment.NewLine;
                    MessageBox.Show("There was an error interpreting the desktop file." + nl + nl +
                        $"Exception: {ex.GetType()} ({ex.HResult.ToString("x8")})" + nl +
                        $"Message: {ex.Message}",
                        "Oops!",
                        MessageBoxButtons.OK);
                }
            }

            return 0;
        }

        static void ShowForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}