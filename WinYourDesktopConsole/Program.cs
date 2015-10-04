using System;
using static System.Console;
using WinYourDesktopLibrary;

/*
Windows console error codes:
http://www.symantec.com/connect/articles/windows-system-error-codes-exit-codes-description
*/

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
        /// Get the current filename without extension of the executable.
        /// </summary>
        static string CurrentFilenameWithoutExtension
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

        static ConsoleColor OriginalForegroundColor = ForegroundColor;

        static string filepath;
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return 0;
            }

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
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
                        filepath = args[i];
                        break;

                }
            }

            try
            {
                Interpreter.Run(filepath);
            }
            catch (Exception ex)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("[ ERROR ]");
                ForegroundColor = OriginalForegroundColor;
                WriteLine($"Exception: {ex.GetType()}");
                WriteLine($"  Message: {ex.Message}");
                return 1;
            }

            return 0;
        }
        
        static void ShowHelp()
        {
            //         1       10        20        30        40        50        60        70        80
            //         |--------|---------|---------|---------|---------|---------|---------|---------|
            WriteLine(" Usage:");
            WriteLine($"  {CurrentFilenameWithoutExtension} [options] <file>");
            /*
            WriteLine("  /createdummy, /C   Create a dummy desktop file.");
            WriteLine("  /debug, /D         Show debugging information in console.");
            */
            WriteLine();
            WriteLine("  /help, /?   Shows this screen and exits.");
            WriteLine("  /version    Shows version and exits.");
        }

        static void ShowVersion()
        {
            //         1       10        20        30        40        50        60        70        80
            //         |--------|---------|---------|---------|---------|---------|---------|---------|
            WriteLine();
            WriteLine($"{CurrentFilenameWithoutExtension} - {ProjectVersion}");
            WriteLine($"WinYourDesktopLibrary - {Interpreter.ProjectVersion}");
            WriteLine("Copyright (c) 2015 DD~!/guitarxhero");
            WriteLine("License: MIT License <http://opensource.org/licenses/MIT>");
            WriteLine("Project page: <https://github.com/guitarxhero/WinYourDesktop>");
            WriteLine();
            WriteLine(" -- Credits --");
            WriteLine("DD~! (guitarxhero) - Original author");
        }
    }
}
