using System;
using System.IO;

namespace WinYourDesktop
{

    /// <summary>
    /// Standard used:
    /// http://standards.freedesktop.org/desktop-entry-spec/latest/index.html
    /// Most useful page:
    /// http://standards.freedesktop.org/desktop-entry-spec/latest/ar01s05.html
    /// </summary>
    static public class Interpreter
    {
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

        /// <summary>
        /// Desktop Entry header type.
        /// </summary>
        enum dType
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

        /// <summary>
        /// Interprets a Desktop file.
        /// </summary>
        /// <param name="pPath">Path of the Desktop file.</param>
        static public void Run(string pPath)
        {
            //FormMain.dbgWrite($"Started debugging {Path.GetFileName(pPath)}");

            if (pPath == null || pPath == string.Empty)
            {
                /*
                if (FormMain.DebugEnabled)
                {
                    FormMain.dbgWrite("Specified path is null or empty.", FormMain.ErrorLevel.Error);
                    return;
                }
                else*/
                    throw new NullReferenceException("Specified path is null or empty.");
            }

            if (!File.Exists(pPath))
                throw new FileNotFoundException($"Specified desktop file doesn't exist.{Environment.NewLine}Path: {pPath}");
            /*else
                FormMain.dbgWrite("File found");*/

            //FormMain.dbgWrite("Reading file...");

            string text = File.ReadAllText(pPath);

            if (text.Length == 0 || !text.Contains("\n"))
                /*if (FormMain.DebugEnabled)
                {
                    FormMain.dbgWrite("Specified desktop file is empty.", FormMain.ErrorLevel.Error);
                    return;
                }
                else*/
                    throw new Exception("Specified desktop file is empty.");

            //FormMain.dbgWrite("Splitting file...");

            string[] lines =
                text.Split(new char[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            if (lines[0] != "[Desktop Entry]")
                /*if (FormMain.DebugEnabled)
                {
                    FormMain.dbgWrite("First line must be [Desktop Entry].", FormMain.ErrorLevel.Error);
                    return;
                }
                else*/
                    throw new Exception("First line must be [Desktop Entry].");

            string[] line = new string[0];
            dType Type = dType.Unknown;
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
                        /*if (FormMain.DebugEnabled)
                        {
                            // "i + 1" is due to object oriented programming, indexes starting at 0.
                            FormMain.dbgWrite($"Failed to split key and value at line {i + 1}.", FormMain.ErrorLevel.Error);
                            return;
                        }
                        else*/
                            throw new Exception($"Failed to split key and value at line {i + 1}.{Environment.NewLine}Missing '=' operator?");

                    line = lines[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    //FormMain.dbgWrite($"Line #{i + 1}: {lines[i]}");

                    switch (line[0])
                    {
                        case "Type":
                            switch (line[1])
                            {
                                case "Application": Type = dType.Application; break;
                                case "Link": Type = dType.Link; break;
                                case "Directory": Type = dType.Directory; break;
                            }
                            //FormMain.dbgWrite($"Type is {Type}");
                            break;

                        case "Exec":
                        case "TryExec":
                            exec = line[1];
                            break;

                        case "URL":
                            url = line[1];
                            //FormMain.dbgWrite($"URL is {url}");
                            break;

                        case "Path":
                            path = line[1];
                            //FormMain.dbgWrite($"Path is {path}");
                            break;

                        case "Terminal":
                            if (line[1].ToLower() == "true")
                                terminal = true;

                            //FormMain.dbgWrite($"Terminal mode enabled");
                            break;
                    }
                }
            } // End of for(;;)

            if (Type == dType.Unknown)
                /*if (FormMain.DebugEnabled)
                {
                    FormMain.dbgWrite("Unknown or missing Type value!", FormMain.ErrorLevel.Error);
                    return;
                }
                else*/
                    throw new Exception("Unknown or missing Type value!");

            switch (Type)
            {
                // Launch an application.
                case dType.Application:
                    string[] execs = new string[0];

                    if (exec.Contains(" ") && !terminal)
                        // Split application (e.g. ping) with arguments (-t ::1)
                        execs = exec.Split(new char[] { ' ' }, 2);

                    //TODO: Fix Terminal key usage.

                    if (terminal)
                    {
                        //FormMain.dbgWrite($"Program: start cmd {exec}");
                        //FormMain.dbgWrite("Starting...");
                        try
                        {
                            System.Diagnostics.Process.Start("start cmd", $"{exec}");
                            //FormMain.dbgWrite("Started");
                        }
                        catch (Exception ex)
                        {
                            /*if (FormMain.DebugEnabled)
                            {
                                FormMain.dbgWrite($"{ex.GetType()} - 0x{ex.GetHashCode().ToString("X8")}", FormMain.ErrorLevel.Error);
                                FormMain.dbgWrite("Stopped", FormMain.ErrorLevel.Error);
                            }
                            else // Re-throw exception*/
                                throw;
                        }
                    }
                    else
                    {
                        if (execs.Length > 0)
                        {
                            /*FormMain.dbgWrite($"Program: {execs[0]}");
                            FormMain.dbgWrite($"Arguments: {execs[1]}");
                            FormMain.dbgWrite("Starting...");
                            FormMain.dbgWrite("Started");*/
                            System.Diagnostics.Process.Start(execs[0], execs[1]);
                        }
                        else
                        {
                            /*FormMain.dbgWrite($"Program: {exec}");
                            FormMain.dbgWrite("Starting...");
                            FormMain.dbgWrite("Started");*/
                            System.Diagnostics.Process.Start(exec);
                        }
                    }
                    break;

                // Launch the user's default application that handles URLs.
                case dType.Link:
                    //FormMain.dbgWrite("Starting...");
                    System.Diagnostics.Process.Start(url);
                    //FormMain.dbgWrite("Started");
                    break;

                // Open File Explorer with a specific path/directory.
                case dType.Directory:
                    //FormMain.dbgWrite("Starting...");
                    if (Directory.Exists(path))
                    {
                        string explorerpath =
                            Directory.GetParent(Environment.SystemDirectory).ToString() +
                            Path.DirectorySeparatorChar +
                            "explorer";

                        System.Diagnostics.Process.Start($"{explorerpath}", $"{path}");
                        //FormMain.dbgWrite("Started");
                    }
                    else
                    {
                        /*if (FormMain.DebugEnabled)
                        {
                            FormMain.dbgWrite($"Directory \"{path}\" could not be found.", FormMain.ErrorLevel.Error);
                            FormMain.dbgWrite("Started");
                        }
                        else*/
                            throw new DirectoryNotFoundException($"Directory \"{path}\" could not be found.");
                    }
                    break;
            } // End of switch()
        }
    }
}
