using System;
using System.Windows.Forms;

// Windows console error codes:
//http://www.symantec.com/connect/articles/windows-system-error-codes-exit-codes-description

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

        static internal bool Debugging
        {
            get;
            private set;
        }

        /// <summary>
        /// Non-disposed instance of <see cref="FormMain"/>
        /// for debugging (desktop files) purposes.
        /// </summary>
        static internal FormMain form = new FormMain();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <remarks>
        /// Also know as <c>.ctor</c> in MSIL.
        /// </remarks>
        [STAThread]
        static int Main(string[] args)
        {
            // No arguments
            if (args.Length == 0)
            {
                ShowForm();
                return 0;
            }

            string filepath = string.Empty;
            bool showform = false;

            // CLI arguments
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-S":
                    case "--showui":
                    case "/S":
                    case "/showui":
                        showform = true;
                        return 0;

                    case "-C":
                    case "--createdummy":
                    case "/C":
                    case "/createdummy":
                        CreateDummy();
                        return 0;

                    case "-D":
                    case "--debug":
                    case "/D":
                    case "/debug":
                        Debugging = true;
                        break;

                    case "--version":
                    case "/version":
                        ShowVersion();
                        return 0;

                    case "--help":
                    case "/?":
                    case "/help":
                        ShowHelp();
                        return 0;

                    default:
                        filepath = arg;
                        break;

                }
            }

            //TODO: Show UI depending on arguments
            // --showui => Main
            // --showui + path => Editor mode (Edit)
            if (showform)
            {
                ShowForm();
                return 0;
            }

            string nl = Environment.NewLine;

            if (filepath != string.Empty)
            {
                try
                {
                    Interpreter.Run(filepath);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show($"A Win32 error happened.{nl + nl}" +
                           $"Exception: {ex.GetType() + nl}" +
                           $"Message: {ex.Message}",
                           $"Oops! - {ProjectName} - {ProjectVersion}",
                           MessageBoxButtons.OK);

                    return 2;
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show($"The file could not be found.{nl + nl}" +
                        $"Exception: {ex.GetType() + nl}" +
                        $"Message: {ex.Message}",
                        $"Oops! - {ProjectName} - {ProjectVersion}",
                        MessageBoxButtons.OK);

                    return 2;
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    MessageBox.Show($"The directory could not be found.{nl + nl}" +
                        $"Exception: {ex.GetType() + nl}" +
                        $"Message: {ex.Message}",
                        $"Oops! - {ProjectName} - {ProjectVersion}",
                        MessageBoxButtons.OK);

                    return 3;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"There was an error interpreting the desktop file.{nl}{nl}" +
                        $"Exception: {ex.GetType() + nl}" +
                        $"Message: {ex.Message}",
                        $"Oops! - {ProjectName} - {ProjectVersion}",
                        MessageBoxButtons.OK);

                    return 1;
                }
            }

            return 0;
        }

        static void CreateDummy()
        {
            string nl = Environment.NewLine;
            using (System.IO.TextWriter tw = new System.IO.StreamWriter("Dummy.desktop"))
            {
                tw.WriteLine("[Desktop Entry]");
                tw.WriteLine("#This is a simple generated dummy desktop file.");
                tw.WriteLine("Type=Application");
                tw.WriteLine("Name=Dummy Desktop File");
                tw.WriteLine("Exec=echo hi & pause");
                tw.WriteLine("Terminal=true");
                tw.Close();
            }
        }

        static void ShowForm()
        {
            Application.EnableVisualStyles();
            Application.Run(form);
        }

        static void ShowHelp()
        {
                             //1       10        20        30        40        50        60        70        80
                             //|--------|---------|---------|---------|---------|---------|---------|---------|
            Console.WriteLine(" Usage:");
            Console.WriteLine("  WinYourDesktop [options]");
            Console.WriteLine("  /showui, /S        Show the user interface.");
            Console.WriteLine("  /createdummy, /C   Create a dummy desktop file.");
            Console.WriteLine("  /debug, /D         Show debugging information in a console.");
            Console.WriteLine();
            Console.WriteLine("  /help, /?   Shows this screen and exits.");
            Console.WriteLine("  /version    Shows version and exits.");
        }

        static void ShowVersion()
        {
            Console.WriteLine($"{ProjectName} - {ProjectVersion}");
            Console.WriteLine("Copyright (c) 2015 DD~!/guitarxhero");
            Console.WriteLine("License: MIT License <http://opensource.org/licenses/MIT>");
            Console.WriteLine("Project page: <https://github.com/guitarxhero/WinYourDesktop>");
            Console.WriteLine();
            Console.WriteLine(" -- Credits --");
            Console.WriteLine("DD~! (guitarxhero) - Original author");
        }
    }
}