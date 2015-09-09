using System;

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
        enum dType
        {
            Application,
            Link,
            Directory,
            Unknown
        }

        static internal void Run(string pPath)
        {
            if (pPath == null || pPath == string.Empty)
                throw new NullReferenceException("Specified path is null or empty.");
            
            if (!System.IO.File.Exists(pPath))
                throw new System.IO.FileNotFoundException($"Specified desktop file doesn't exist.{Environment.NewLine}Path: {pPath}");

            string text = string.Empty;
            using (System.IO.TextReader tr = new System.IO.StreamReader(pPath))
            {
                text = tr.ReadToEnd();
                tr.Close();
            }

            if (text.Length == 0)
                throw new Exception("Specified desktop file is empty.");

            string[] lines = text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            if (lines[0] != "[Desktop Entry]")
                throw new FormatException("First line must be [Desktop Entry].");

            string[] line = new string[0];
            dType Type = dType.Unknown;
            string exec = string.Empty;
            string url = string.Empty;
            string path = string.Empty;
            bool terminal = false;
            for (int i = 1; i < lines.Length; i++)
            {
                //TODO: lines[i][0] == '[' // Group header

                if (lines[i][0] != '#' || lines[i][0] != '[') // Avoid comments. And group headers, for now.
                {
                    line = lines[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    if (line.Length < 2) // i + 1 is because we start at 1, due to [Desktop Entry]
                        throw new Exception($"Failed to split key and value at line {i + 1}.{Environment.NewLine}Missing '=' operator?");

                    switch (line[0].Trim())
                    {
                        case "Type":
                            switch (line[1].Trim())
                            {
                                case "Application": Type = dType.Application; break;
                                case "Link": Type = dType.Link; break;
                                case "Directory": Type = dType.Directory; break;
                            }
                            break;

                        case "TryExec":
                        case "Exec":
                            exec = line[1];
                            break;

                        case "URL":
                            url = line[1];
                            break;

                        case "Path":
                            path = line[1];
                            break;

                        case "Terminal":
                            if (line[1].Trim() == "true")
                                terminal = true;
                            break;
                    }
                }
            }

            if (Type == dType.Unknown)
                throw new Exception("Unknown or missing Type value!");

            switch (Type)
            {
                case dType.Application:
                    // Launch an application.
                    string[] execs = new string[0];
                    if (exec.Contains(" "))
                        execs = exec.Split(new char[] { ' ' }, 2);

                    //TODO: Check if splitting the Value with a first space is really worth it.
                    //TODO: Fix Terminal key usage.

                    try
                    {
                        if (terminal)
                        {
                            System.Diagnostics.Process.Start($"start cmd {exec}");
                        }
                        else
                        {
                            if (execs.Length > 0)
                                System.Diagnostics.Process.Start(execs[0], execs[1]);
                            else
                                System.Diagnostics.Process.Start(exec);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is System.ComponentModel.Win32Exception || ex is System.IO.FileNotFoundException)
                        {
                            string syspath = Environment.SystemDirectory + System.IO.Path.DirectorySeparatorChar;

                            if (execs.Length > 0)
                                System.Diagnostics.Process.Start($"{syspath + execs[0]}", execs[1]);
                            else
                                System.Diagnostics.Process.Start($"{syspath + exec}");
                        }
                        else
                            throw;
                    }
                    break;

                case dType.Link:
                    // Launch the user's default application that handles URLs.
                    System.Diagnostics.Process.Start(url);
                    break;

                case dType.Directory:
                    // Open File Explorer with a specific path/directory.
                    //TODO: Check if directory
                    System.Diagnostics.Process.Start($"explorer {path}");
                    break;
            }
        }
    }
}
