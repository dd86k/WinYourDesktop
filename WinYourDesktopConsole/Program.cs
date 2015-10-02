using System;

// Windows console error codes:
//http://www.symantec.com/connect/articles/windows-system-error-codes-exit-codes-description

namespace WinYourDesktopConsole
{
    class Program
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



            return 0;
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
            Console.WriteLine($"WinYourDesktopConsole - {ProjectVersion}");
            Console.WriteLine("Copyright (c) 2015 DD~!/guitarxhero");
            Console.WriteLine("License: MIT License <http://opensource.org/licenses/MIT>");
            Console.WriteLine("Project page: <https://github.com/guitarxhero/WinYourDesktop>");
            Console.WriteLine();
            Console.WriteLine(" -- Credits --");
            Console.WriteLine("DD~! (guitarxhero) - Original author");
        }
    }
}
