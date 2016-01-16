using System;
using System.Windows.Forms;
using WinYourDesktopLibrary;

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

            //TODO: CLI (UI)
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "/dummy":
                        Interpreter.CreateDummy();
                        return 0;
                }
            }

            string file = args[args.Length - 1];

            if (System.IO.File.Exists(file))
                return Interpreter.Run(file);

            return 0;
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