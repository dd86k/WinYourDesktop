using System;
using System.IO;

namespace WinYourDesktopLibrary
{
    /// <summary>
    /// Desktop entry file interpreter.
    /// </summary>
    /// <remarks>
    /// Standard used:
    /// http://standards.freedesktop.org/desktop-entry-spec/latest/index.html
    /// Most useful page:
    /// http://standards.freedesktop.org/desktop-entry-spec/latest/ar01s05.html
    /// </remarks>
    static public class Interpreter
    {
        #region Constants
        const char DELIMITER = '=';
        #endregion

        #region Properties
        /// <summary>
        /// Get the current version of the library.
        /// </summary>
        public static string ProjectVersion
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
        enum DesktopFileType : byte
        {
            /// <summary>
            /// Application type. (UI and CLI apps)
            /// </summary>
            Application,
            /// <summary>
            /// Link type. (Values)
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

        public enum ErrorCode : ushort
        {
            // -- Path related errors --

            NullPath = 0x8,
            EmptyPath = 0x9,

            // -- Desktop files related errors --

            EmptyFile = 0x16,
            /// <summary>
            /// Generic Desktop Entry error.
            /// </summary>
            /// <remarks>
            /// Includes [Desktop Entry]
            /// </remarks>
            NoDesktopEntry = 0x17,
            MissingDelimiter = 0x18,
            MissingTypeValue = 0x20,
            MissingExecValue = 0x21,
            MissingUrlValue = 0x22,
            MissingPathValue = 0x23,

            // -- Value/TryValue related errors --

            /// <summary>
            /// Generic Value error.
            /// </summary>
            ExecError = 0x32,

            // -- Link type related errors --

            /// <summary>
            /// Generic Link error.
            /// </summary>
            LinkError = 0x40,

            // -- Directory type related errors --

            /// <summary>
            /// Generic Directory error.
            /// </summary>
            DirectoryError = 0x48,
            DirectoryNotFound = 0x49,
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Interpret a Desktop file.
        /// </summary>
        /// <param name="pPath">Path of the Desktop file.</param>
        /// <returns>ErrorCode.</returns>
        public static int Run(string pPath)
        {
            //TODO: pVerboise (debug)
            
            if (string.IsNullOrEmpty(pPath))
            {
                Console.WriteLine("Error: Specified path is null or empty.");
                return pPath == null ? (int)ErrorCode.NullPath : (int)ErrorCode.EmptyPath;
            }

            if (!File.Exists(pPath))
                Console.WriteLine($"Error: Specified file doesn't exist.{Environment.NewLine}Path: {pPath}");
            else
                Console.WriteLine("File found.");
            
            // Defaults
            DesktopFileType type = DesktopFileType.Unknown;
            string CurrentLine;
            ushort CurrentLineIndex = 0;
            string[] LineValues;
            string Value = string.Empty;
            bool TerminalMode = false;

            char[] DELIM = new char[] { DELIMITER };

            Console.WriteLine($"Starting {Path.GetFileName(pPath)}...");

            using (StreamReader sr = new StreamReader(pPath))
            {
                if (sr.ReadLine() != "[Desktop Entry]")
                {
                    Console.WriteLine("Error: First line must be [Desktop Entry]");
                    return (int)ErrorCode.NoDesktopEntry;
                }

                while (!sr.EndOfStream)
                {
                    CurrentLine = sr.ReadLine();

                    // line[0] == '[' // Group header (Soon?)
                    if (CurrentLine[0] != '#') // Avoid comments.
                    {
                        if (!CurrentLine.Contains("="))
                        {
                            Console.WriteLine($"Error: Failed to split key and value at line #{CurrentLineIndex + 1}.");
                            Console.WriteLine($"Missing '{DELIMITER}' delimiter?");
                            return (int)ErrorCode.MissingDelimiter;
                        }

                        LineValues = CurrentLine.Split(DELIM,
                            StringSplitOptions.RemoveEmptyEntries);

                        switch (LineValues[0])
                        {
                            case "Type":
                                switch (LineValues[1])
                                {
                                    case "Application":
                                        type = DesktopFileType.Application;
                                        break;
                                    case "Link":
                                        type = DesktopFileType.Link;
                                        break;
                                    case "Directory":
                                        type = DesktopFileType.Directory;
                                        break;
                                    // Skip/Ignore by default
                                }
                                Console.WriteLine($"TYPE SET {type}");
                                break;
                                
                            case "Exec":
                            case "TryExec":
                                Value = LineValues[1];
                                break;
                                
                            case "Url":
                                Value = LineValues[1];
                                Console.WriteLine($"URL SET {Value}");
                                break;
                                
                            case "Path":
                                Value = LineValues[1];
                                Console.WriteLine($"PATH SET {Value}");
                                break;
                                
                            case "Terminal":
                                if (LineValues[1].ToUpper() == "TRUE")
                                    TerminalMode = true;

                                Console.WriteLine($"TERMINAL SET TRUE");
                                break;
                        }
                    }

                    CurrentLineIndex++;
                }
            }
            
            if (type == DesktopFileType.Unknown)
            {
                // Because the "unknown" part is checked in the earlier switch()
                Console.WriteLine($"Error: Missing Type value!");
                return (int)ErrorCode.MissingTypeValue;
            }

            Console.WriteLine("Starting...");
            switch (type)
            {
                // Launch an application.
                case DesktopFileType.Application:
                    if (Value.Length > 0)
                    {
                        Console.WriteLine($"Value: {Value}");
                        try
                        {
                            System.Diagnostics.Process.Start(TerminalMode ?
                                $"start cmd {Value}" :
                                Value,
                                Value.Contains(" ") ?
                                Value.Substring(Value.IndexOf(" ") + 1) :
                                string.Empty);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: Could not start the application.");
                            Console.WriteLine($"{ex.GetType()} (0x{ex.HResult:X8})");
                            return (int)ErrorCode.ExecError;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Missing Exec value, while Type is set to Application.");
                        return (int)ErrorCode.MissingExecValue;
                    }
                    break;

                // Launch the user's default application that handles Values.
                case DesktopFileType.Link:
                    if (Value.Length > 0)
                    {
                        Console.WriteLine($"Value: {Value}");
                        try
                        {
                            System.Diagnostics.Process.Start(Value);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Could not start with the provided link.");
                            Console.WriteLine($"Error: {ex.GetType()} (0x{ex.HResult:X8})");
                            return (int)ErrorCode.LinkError;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Missing Url value, while Type is set to Link.");
                        return (int)ErrorCode.MissingUrlValue;
                    }
                    break;

                // Open File Explorer with a specific path/directory.
                case DesktopFileType.Directory:
                    if (Value.Length > 0)
                    {
                        Console.WriteLine($"DIR: {Value}");
                        if (Directory.Exists(Value))
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(Utils.ExplorerPath,
                                    Value.Replace("/", @"\"));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: Could not open the directory.");
                                Console.WriteLine($"{ex.GetType()} (0x{ex.HResult:X8})");
                                return (int)ErrorCode.LinkError;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error: Directory \"{Value}\" could not be found.");
                            return (int)ErrorCode.DirectoryNotFound;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Missing Path value, while Type is set to Directory.");
                        return (int)ErrorCode.MissingPathValue;
                    }
                    break;
            } // End of switch()

            Console.WriteLine("Started successfully.");

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
                tw.WriteLine($"# Interpreter version: {ProjectVersion}");
                tw.WriteLine("Type=Directory");
                tw.WriteLine("Name=Open Windows Directory");
                tw.WriteLine(@"Path=%WinDir%");
            }
        }
        #endregion Public Methods
    }
}
