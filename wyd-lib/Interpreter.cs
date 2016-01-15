using System;
using System.IO;
using wyd_lib;

namespace WinYourDesktopLibrary
{

    /// <summary>
    /// Standard used:
    /// http://standards.freedesktop.org/desktop-entry-spec/latest/index.html
    /// Most useful page:
    /// http://standards.freedesktop.org/desktop-entry-spec/latest/ar01s05.html
    /// </summary>
    static public class Interpreter
    {
        #region Properties
        /// <summary>
        /// Get the current version of the library.
        /// </summary>
        static public string ProjectVersion
        {
            get
            {
                return
                    System.Reflection.Assembly
                    .GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        #endregion

        #region Enumerations
        /// <summary>
        /// Desktop Entry header type.
        /// </summary>
        enum DesktopFileType
        {
            /// <summary>
            /// Application type. (UI and CLI apps)
            /// </summary>
            Application,
            /// <summary>
            /// Link type. (URLs)
            /// </summary>
            Link,
            /// <summary>
            /// Directory type. (File Explorer)
            /// </summary>
            Directory,
            /// <summary>
            /// Unknown header type. Default.
            /// </summary>
            Unknown
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Interpret a Desktop file.
        /// </summary>
        /// <param name="pPath">Path of the Desktop file.</param>
        static public int Run(string pPath)
        {
            Console.WriteLine($"Started debugging {Path.GetFileName(pPath)}...");

            if (pPath == null || pPath == string.Empty)
            {
                Console.WriteLine("Error: Specified path is null or empty.");
                return 1;
            }

            if (!File.Exists(pPath))
                Console.WriteLine($"Specified file doesn't exist.{Environment.NewLine}Path: {pPath}");
            else
                Console.WriteLine("File found");

            Console.WriteLine("Reading file...");

            string text = File.ReadAllText(pPath);

            if (text.Length == 0 || !text.Contains("\n"))
            {
                Console.WriteLine("Specified desktop file is empty, or contains no new lines.");
                return 3;
            }

            Console.WriteLine("Splitting file...");

            string[] lines =
                text.Split(new char[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            if (lines[0] != "[Desktop Entry]")
            {
                Console.WriteLine("First line must be [Desktop Entry].");
                return 5;
            }

            string[] line = new string[0];
            DesktopFileType type = DesktopFileType.Unknown;
            string exec = string.Empty;
            string url = string.Empty;
            string path = string.Empty;
            bool terminal = false;
            // Starts at 1 to skip "[Desktop Entry]"
            for (int i = 1; i < lines.Length; i++)
            {
                //TODO: lines[i][0] == '[' // Group header

                if (lines[i][0] != '#') // Avoid comments.
                {
                    if (!lines[i].Contains("="))
                    {
                        Console.WriteLine($"Failed to split key and value at line {i + 1}.");
                        Console.WriteLine("Missing '=' operator?");
                        return 7;
                    }

                    line =
                        lines[i].Split(new char[] { '=' },
                        StringSplitOptions.RemoveEmptyEntries);

                    Console.WriteLine($"Line #{i + 1}: {lines[i]}");

                    switch (line[0])
                    {
                        case "Type":
                            switch (line[1])
                            {
                                case "Application": type = DesktopFileType.Application; break;
                                case "Link": type = DesktopFileType.Link; break;
                                case "Directory": type = DesktopFileType.Directory; break;
                            }
                            Console.WriteLine($"Type is {type}");
                            break;

                        case "Exec":
                        case "TryExec":
                            exec = line[1];
                            break;

                        case "URL":
                            url = line[1];
                            Console.WriteLine($"URL SET AS {url}");
                            break;

                        case "Path":
                            path = line[1];
                            Console.WriteLine($"PATH SET AS {path}");
                            break;
                            
                        case "Terminal":
                            if (line[1].ToLower() == "true")
                                terminal = true;

                            Console.WriteLine($"Terminal mode enabled");
                            break;
                    }
                }
            } // End of for(;;)

            if (type == DesktopFileType.Unknown)
            {
                Console.WriteLine($"Unknown or missing Type value! ({type})");
                return 9;
            }

            switch (type)
            {
                // Launch an application.
                case DesktopFileType.Application:
                    string[] execs = new string[0];

                    // Split application (e.g. ping) with arguments (-t ::1) if possible
                    if (exec.Contains(" ") && !terminal)
                        execs = exec.Split(new char[] { ' ', '\t' }, 2);

                    //TODO: Fix Terminal key usage. ("start cmd")
                    string args = execs.Length > 0 ? execs[1] : string.Empty;
                    Console.WriteLine($"Program: {execs[0]}");
                    Console.WriteLine($"Arguments: {args}");
                    Console.WriteLine("Starting...");
                    try
                    {
                        System.Diagnostics.Process.Start(terminal ? "start cmd" : execs[0], args);
                        Console.WriteLine("Started");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.GetType()} ({ex.HResult:X8})");
                        return ex.HResult;
                    }
                    break;

                // Launch the user's default application that handles URLs.
                case DesktopFileType.Link:
                    Console.WriteLine("Starting...");
                    try
                    {
                        System.Diagnostics.Process.Start(url);
                        Console.WriteLine("Started");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not start with the provided link.");
                        Console.WriteLine($"Error: {ex.GetType()} ({ex.HResult:X8})");
                        return 12;
                    }
                    break;

                // Open File Explorer with a specific path/directory.
                case DesktopFileType.Directory:
                    //FormMain.dbgWrite("Starting...");
                    if (Directory.Exists(path))
                    {
                        System.Diagnostics.Process.Start($"{Utils.ExplorerPath}", $"{path}");
                        Console.WriteLine("Started");
                    }
                    else
                    { 
                        Console.WriteLine($"Error: Directory \"{path}\" could not be found.");
                        return 14;
                    }
                    break;
            } // End of switch()

            return 0;
        }

        /// <summary>
        /// Creates a dummy/example file in the current directory.
        /// </summary>
        static public void CreateDummy()
        {
            using (TextWriter tw = new StreamWriter("Dummy.desktop", false))
            {
                tw.WriteLine("[Desktop Entry]");
                tw.WriteLine("# This is a simple generated dummy desktop file.");
                tw.WriteLine("Type=Application");
                tw.WriteLine("Name=Dummy Desktop File");
                tw.WriteLine("Exec=echo hi & pause");
                tw.WriteLine("Terminal=true");
            }
        }
        #endregion Public Methods
    }
}
