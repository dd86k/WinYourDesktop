using System;
using System.Windows.Forms;

namespace WinYourDesktop
{
    static class Program
    {
        static string ProjectVersion
        {
            get
            {
                return $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            // No file or switches
            if (args.Length == 0)
            {
                ShowForm();
                return 0;
            }

            string filepath = string.Empty;

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
                        CreateDummy();
                        return 0;

                    case "-D":
                    case "--debug":

                        break;

                    case "--version":
                        ShowVersion();
                        return 0;

                    case "--help":
                    case "/?":
                        ShowHelp();
                        return 0;

                    default:
                        filepath = arg;
                        break;

                }
            }

            //TODO: --showui + path => Edit file

            if (filepath != string.Empty)
            {
                string nl = Environment.NewLine;
                try
                {
                    Interpreter.Run(filepath);
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show($"The file could not be found. {nl + nl}" +
                        $"Exception: {ex.GetType()} {nl}" +
                        $"Message: {ex.Message}",
                        $"Oops! - {ex.GetType()}",
                        MessageBoxButtons.OK);
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    MessageBox.Show($"The directory could not be found. {nl + nl}" +
                        $"Exception: {ex.GetType()} {nl}" +
                        $"Message: {ex.Message}",
                        $"Oops! - {ex.GetType()}",
                        MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"There was an error interpreting the desktop file. {nl + nl}" +
                        $"Exception: {ex.GetType()} {nl}" +
                        $"Message: {ex.Message}",
                        $"Oops! - {ex.GetType()}",
                        MessageBoxButtons.OK);
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
                tw.WriteLine("#Exec=cmd");
                tw.Close();
            }
        }

        static void ShowForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        static void ShowHelp()
        {
            Console.WriteLine(" Usage:");
            Console.WriteLine("  WinYourDesktop [options]");
            Console.WriteLine("  --showui, -S        Show the user interface.");
            Console.WriteLine("  --createdummy, -C   Create a dummy desktop file.");
            Console.WriteLine("  --debug, -D         Show debugging information in a console.");
            Console.WriteLine();
            Console.WriteLine("  --help, /?   Shows this screen");
            Console.WriteLine("  --version    Shows version");
        }

        static void ShowVersion()
        {
            Console.WriteLine("WinYourDesktop - ");
            Console.WriteLine("Copyright (c) 2015 DD~!/guitarxhero");
            Console.WriteLine("License: MIT License <http://opensource.org/licenses/MIT>");
            Console.WriteLine("Project page: <https://github.com/guitarxhero/WinYourDesktop>");
            Console.WriteLine();
            Console.WriteLine(" -- Credits --");
            Console.WriteLine("DD~! (guitarxhero) - Original author");
        }
    }
}