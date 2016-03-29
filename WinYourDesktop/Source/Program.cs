using System;
using System.Windows.Forms;
using WinYourDesktopLibrary;
using static WinYourDesktopLibrary.Interpreter;

namespace WinYourDesktop
{
    static class Program
    {
        static string ProjectVersion
        {
            get
            {
                return
                    System.Reflection.Assembly
                    .GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        static string ProjectName
        {
            get
            {
                return
                    System.Reflection.Assembly
                    .GetExecutingAssembly().GetName().Name;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            // No arguments
            if (args.Length == 0)
            {
                ShowForm();
                return 0;
            }

            string file = args[args.Length - 1];

            //TODO: CLI (UI)
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "/dummy":
                        CreateDummy();
                        return 0;
                }
            }
            
            ErrorCode err = Run(file);

            if (err != ErrorCode.Success)
            {
                Application.EnableVisualStyles();

                MessageBox.Show($"{err.GetErrorMessage()} ({err})",
                    $"WinYourDesktop - 0x{err.S():X8}",
                    MessageBoxButtons.OK);
            }

            return err.S();
        }

        static void ShowForm()
        {
            Application.EnableVisualStyles();
            Application.Run(new FormMain());
        }

        static void ShowForm(string pPath)
        {
            Application.EnableVisualStyles();
            Application.Run(new FormMain(pPath));
        }
    }
}