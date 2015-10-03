using System;
using static System.Console;

// Windows console error codes:
//http://www.symantec.com/connect/articles/windows-system-error-codes-exit-codes-description

namespace WinYourDesktopConsole
{
    class Program
    {
        /// <summary>
        /// Get the current version of the console oriented solution.
        /// </summary>
        static string ProjectVersion
        {
            get
            {
                return
                    System.Reflection.Assembly
                    .GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Returns the current name of the file.
        /// </summary>
        static string CurrentFilename
        {
            get
            {
                return
                    System.IO.Path.GetFileNameWithoutExtension(
                        System.Diagnostics.Process
                        .GetCurrentProcess().MainModule.FileName
                    );
            }
        }
        
        static string filepath;
        static int Main(string[] args)
        {
            foreach (string arg in args)
            {
                switch (arg)
                {
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

            try
            {
                WinYourDesktop.Interpreter.Run(filepath);
            }
            catch (Exception ex)
            {
                WriteLine($"The following error occured: {ex.GetType()}");
                return 1;
            }

            return 0;
        }
        
        static void ShowHelp()
        {
            //         1       10        20        30        40        50        60        70        80
            //         |--------|---------|---------|---------|---------|---------|---------|---------|
            WriteLine(" Usage:");
            WriteLine($"  {CurrentFilename} [options]");
            /*
            WriteLine("  /showui, /S        Show the user interface.");
            WriteLine("  /createdummy, /C   Create a dummy desktop file.");
            WriteLine("  /debug, /D         Show debugging information in a console.");
            */
            WriteLine();
            WriteLine("  /help, /?   Shows this screen and exits.");
            WriteLine("  /version    Shows version and exits.");
        }

        static void ShowVersion()
        {
            WriteLine($"{CurrentFilename} - {ProjectVersion}");
            WriteLine("Copyright (c) 2015 DD~!/guitarxhero");
            WriteLine("License: MIT License <http://opensource.org/licenses/MIT>");
            WriteLine("Project page: <https://github.com/guitarxhero/WinYourDesktop>");
            WriteLine();
            WriteLine(" -- Credits --");
            WriteLine("DD~! (guitarxhero) - Original author");
        }
    }
}
