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

            string filepath = string.Empty;
            bool showform = false;

            // CLI arguments
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
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
                        Interpreter.CreateDummy();
                        return 0;
                }
            }

            if (System.IO.File.Exists(args[args.Length - 1]))
            {
                filepath = args[args.Length - 1];
            }

            string nl = Environment.NewLine;

            if (filepath != string.Empty)
            {
                if (showform)
                {
                    ShowForm(filepath);
                    return 0;
                }

                try
                {
                    Interpreter.Run(filepath);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show($"A Win32 error happened.{nl + nl}" +
                        $"Exception: {ex.GetType() + nl}" +
                        $"Message: {ex.Message}",
                        $"{ProjectName} - Oops! ({ProjectVersion})",
                        MessageBoxButtons.OK);

                    return 2;
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show($"The file could not be found.{nl + nl}" +
                        $"Exception: {ex.GetType() + nl}" +
                        $"Message: {ex.Message}",
                        $"{ProjectName} - Oops! ({ProjectVersion})",
                        MessageBoxButtons.OK);

                    return 2;
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    MessageBox.Show($"The directory could not be found.{nl + nl}" +
                        $"Exception: {ex.GetType() + nl}" +
                        $"Message: {ex.Message}",
                        $"{ProjectName} - Oops! ({ProjectVersion})",
                        MessageBoxButtons.OK);

                    return 3;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"There was an error interpreting the desktop file.{nl}{nl}" +
                        $"Exception: {ex.GetType() + nl}" +
                        $"Message: {ex.Message}",
                        $"{ProjectName} - Oops! ({ProjectVersion})",
                        MessageBoxButtons.OK);

                    return 1;
                }
            }

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