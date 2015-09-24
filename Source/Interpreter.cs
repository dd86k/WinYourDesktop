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
    static class Interpreter
    {
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
        static internal void Run(string pPath)
        {
            FormMain.dbgWrite($"Started debugging {Path.GetFileName(pPath)}");

            if (pPath == null || pPath == string.Empty)
            {
                if (FormMain.DebugEnabled)
                {
                    FormMain.dbgWrite($"");
                    return;
                }
                else
                    throw new NullReferenceException("Specified path is null or empty.");
            }
            
            if (!File.Exists(pPath))
                throw new FileNotFoundException($"Specified desktop file doesn't exist.{Environment.NewLine}Path: {pPath}");

            string text = File.ReadAllText(pPath);

            if (text.Length == 0 || !text.Contains("\n"))
                throw new Exception("Specified desktop file is empty.");

            string[] lines =
                text.Split(new char[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            if (lines[0] != "[Desktop Entry]")
                throw new FormatException("First line must be [Desktop Entry].");

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
                        // "i + 1" is due to object oriented programming, indexes starting at 0.
                        throw new Exception($"Failed to split key and value at line {i + 1}.{Environment.NewLine}Missing '=' operator?");

                    line = lines[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    switch (line[0])
                    {
                        case "Type":
                            switch (line[1])
                            {
                                case "Application": Type = dType.Application; break;
                                case "Link": Type = dType.Link; break;
                                case "Directory": Type = dType.Directory; break;
                            }
                            break;

                        case "Exec":
                        case "TryExec":
                            exec = line[1];
                            break;

                        case "URL":
                            url = line[1];
                            break;

                        case "Path":
                            path = line[1];
                            break;

                        case "Terminal":
                            if (line[1].ToLower() == "true")
                                terminal = true;
                            break;
                    }
                }
            }

            if (Type == dType.Unknown)
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
                        System.Diagnostics.Process.Start("start cmd", $"{exec}");
                    }
                    else
                    {
                        if (execs.Length > 0)
                        {
                            System.Diagnostics.Process.Start(execs[0], execs[1]);
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(exec);
                        }
                    }
                    break;

                // Launch the user's default application that handles URLs.
                case dType.Link:
                    System.Diagnostics.Process.Start(url);
                    break;

                // Open File Explorer with a specific path/directory.
                case dType.Directory:
                    if (Directory.Exists(path))
                    {
                        string explorerpath =
                            Directory.GetParent(Environment.SystemDirectory).ToString() +
                            Path.DirectorySeparatorChar +
                            "explorer";
                        
                        System.Diagnostics.Process.Start($"{explorerpath}", $"{path}");
                    }
                    else
                    {
                        throw new DirectoryNotFoundException($"Directory \"{path}\" could not be found.");
                    }
                    break;
            }
        }
    }
}
