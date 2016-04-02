using System;
using WinYourDesktopLibrary;
using static System.Console;
using static System.Diagnostics.Process;
using static System.Reflection.Assembly;

/// <summary>
/// Console solution.
/// </summary>
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
                    GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Get the current filename without extension of the executable.
        /// </summary>
        static string FilenameWithoutExtension
        {
            get
            {
                return
                    System.IO.Path.GetFileNameWithoutExtension(
                        GetCurrentProcess().MainModule.FileName
                    );
            }
        }

        static string filepath;
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return 0;
            }

            bool verboise = false;

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

                    case "/v":
                    case "/verbose":
                    case "-V":
                    case "--verbose":
                        verboise = true;
                        break;

                    default:
                        filepath = args[i];
                        break;
                }
            }

            try
            {
                // Interpreter already checks if the file exists
                ErrorCode r = Interpreter.Run(filepath, verboise);

                if (r != ErrorCode.Success)
                    WriteLine($"ERROR: {r} - {r.GetErrorMessage()} ({r.Hex()})");

                return r.S();
            }
            catch (Exception ex)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("[ ERROR ]");
                ResetColor();
                WriteLine($"Exception: {ex.GetType()} - 0x{ex.HResult:X8}");
                WriteLine($"  Message: {ex.Message}");
                return ex.HResult;
            }
        }
        
        static void ShowHelp()
        {
            //         1       10        20        30        40        50        60        70        80
            //         |--------|---------|---------|---------|---------|---------|---------|---------|
            WriteLine(" Usage:");
            WriteLine($"  {FilenameWithoutExtension} [options] <file>");
            WriteLine();
            WriteLine("  /v, -V    Verbose.");
            WriteLine();
            WriteLine("  /?        Shows this screen and exits.");
            WriteLine("  /version  Shows version and exits.");
        }

        static void ShowVersion()
        {
            //         1       10        20        30        40        50        60        70        80
            //         |--------|---------|---------|---------|---------|---------|---------|---------|
            WriteLine();
            WriteLine($"{FilenameWithoutExtension} - {ProjectVersion}");
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
