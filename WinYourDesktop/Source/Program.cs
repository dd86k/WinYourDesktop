using System;
using System.Windows.Forms;
using static System.Environment;
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

            if (args.Length == 1)
            {

            }

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
            
            if (System.IO.File.Exists(file))
            {
                ErrorCode err = (ErrorCode)Run(file);
                string msg = $"Error: {err}{NewLine}";
                switch (err)
                {
                    case ErrorCode.NullPath:
                        msg += "The specified path is null.";
                        break;
                    case ErrorCode.EmptyPath:
                        msg += "The specified path is empty.";
                        break;
                    case ErrorCode.FileEmpty:
                        msg += "The file is empty.";
                        break;
                    case ErrorCode.FileNoDesktopEntry:
                        msg += "Missing \"[Desktop Entry\".";
                        break;
                    case ErrorCode.FileMissingDelimiter:
                        msg += @"Missing ""="" delimiter.";
                        break;
                    case ErrorCode.FileMissingTypeValue:
                        msg += "Missing Type value.";
                        break;
                    case ErrorCode.FileMissingExecValue:
                        msg += "Missing Exec or TryExec value.";
                        break;
                    case ErrorCode.FileMissingUrlValue:
                        msg += "Missing URL value.";
                        break;
                    case ErrorCode.FileMissingPathValue:
                        msg += "Missing Path value.";
                        break;
                    case ErrorCode.ExecError:
                        msg += "The specified value for Exec or TryExec caused an error.";
                        break;
                    case ErrorCode.LinkError:
                        msg += "The specified value for URL caused an error.";
                        break;
                    case ErrorCode.DirectoryError:
                        msg += "The specified value for Path caused an error.";
                        break;
                    case ErrorCode.DirectoryNotFound:
                        msg += "The directory specified at Path could not be found.";
                        break;
                }

                if ((int)err != 0)
                {
                    Application.EnableVisualStyles();
                    MessageBox.Show($"{msg} (0x{err:X8})",
                        $"WinYourDesktop - {err}",
                        MessageBoxButtons.OK);
                }

                return (int)err;
            }
            else
            {

                return (int)ErrorCode.FileNotFound;
            }
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