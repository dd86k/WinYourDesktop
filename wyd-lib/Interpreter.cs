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

        /// <summary>
        /// Get the name of the library (assembly name).
        /// </summary>
        public static string ProjectName
        {
            get
            {
                return
                    System.Reflection.Assembly
                    .GetExecutingAssembly().GetName().Name;
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
            /// Application type.
            /// </summary>
            Application,
            /// <summary>
            /// Link type. (URL)
            /// </summary>
            Link,
            /// <summary>
            /// Directory type.
            /// </summary>
            Directory,
            /// <summary>
            /// Unknown header type. Default.
            /// </summary>
            Unknown
        }

        public enum ErrorCode : byte
        {
            // -- Generic errors --
            
            
            // -- Path related errors --

            NullPath = 0x8,
            EmptyPath = 0x9,

            // -- Desktop File related errors --

            /// <summary>
            /// Desktop file not found.
            /// </summary>
            FileNotFound = 0x16,
            FileEmpty = 0x17,
            /// <remarks>
            /// Missing "[Desktop Entry]"
            /// </remarks>
            FileNoDesktopEntry = 0x18,
            FileMissingDelimiter = 0x19,
            FileMissingTypeValue = 0x20,
            FileMissingExecValue = 0x21,
            FileMissingUrlValue = 0x22,
            FileMissingPathValue = 0x23,

            // -- Value/TryValue related errors --

            /// <summary>
            /// Generic Value error.
            /// </summary>
            ExecError = 0x32,
            ExecInvalidOperation = 0x33,
            ExecWin32Error = 0x34,
            ExecFileNotFound = 0x35, // Sorry if it's not 0x404!


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
                bool isNull = pPath == null;
                Console.WriteLine($"Error: Specified path is null or empty. ({(isNull ? H(ErrorCode.NullPath) : H(ErrorCode.EmptyPath))})");
                return isNull ?
                    (int)ErrorCode.NullPath : (int)ErrorCode.EmptyPath;
            }

            if (!File.Exists(pPath))
            {
                Console.WriteLine($"Error: Specified file doesn't exist. ({H(ErrorCode.FileNotFound)})");
                Console.WriteLine($"Path: {pPath}");
                return (int)ErrorCode.FileNotFound;
            }
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
                    Console.WriteLine($"Error: First line must be [Desktop Entry]. ({H(ErrorCode.FileNoDesktopEntry)})");
                    return (int)ErrorCode.FileNoDesktopEntry;
                }

                while (!sr.EndOfStream)
                {
                    CurrentLine = sr.ReadLine();

                    // line[0] == '[' // Group header (Soon?)
                    if (CurrentLine[0] != '#') // Avoid comments.
                    {
                        if (!CurrentLine.Contains("="))
                        {
                            Console.WriteLine($"Error: Failed to split key and value at line #{CurrentLineIndex + 1}. ({H(ErrorCode.FileMissingDelimiter)})");
                            Console.WriteLine($"Missing '{DELIMITER}' delimiter.");
                            return (int)ErrorCode.FileMissingDelimiter;
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
                            case "URL":
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
                // So.. It's missing.
                Console.WriteLine($"Error: Missing Type value! ({H(ErrorCode.FileMissingTypeValue)})");
                return (int)ErrorCode.FileMissingTypeValue;
            }

            Console.WriteLine("Starting...");
            Console.WriteLine($"Value: {Value}");
            switch (type)
            {
                #region App
                // Launch an application.
                case DesktopFileType.Application:
                    if (Value.Length > 0)
                    {
                        try
                        {
                            //TODO: [Soon as possible, messy] if (TerminalMode) =>
                            // StartProcessInfo (UseShellExecude = true), add "/c"
                            // If implemented and works, bump Minor version

                            System.Diagnostics.Process.Start(
                                TerminalMode ?
                                $"start cmd {Value}" :
                                Value,
                                Value.Contains(" ") ?
                                Value.Substring(Value.IndexOf(" ") + 1) :
                                string.Empty);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine($"Error: Invalid operation. ({H(ErrorCode.ExecInvalidOperation)})");
                            return (int)ErrorCode.ExecInvalidOperation;
                        }
                        catch (System.ComponentModel.Win32Exception)
                        {
                            Console.WriteLine($"Error: A Win32 error occurred. ({H(ErrorCode.ExecWin32Error)})");
                            return (int)ErrorCode.ExecWin32Error;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: Could not start the application. ({H(ErrorCode.ExecError)}");
                            Console.WriteLine($"{Ex(ex)}");
                            return (int)ErrorCode.ExecError;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: Missing Exec value, while Type is set to Application. ({H(ErrorCode.FileMissingExecValue)})");
                        return (int)ErrorCode.FileMissingExecValue;
                    }
                    break;
                #endregion App

                #region Link
                // Launch the user's default application that handles URLs.
                case DesktopFileType.Link:
                    if (Value.Length > 0)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(Value);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: Could not start with the provided URL. ({H(ErrorCode.LinkError)})");
                            Console.WriteLine($"{Ex(ex)}");
                            return (int)ErrorCode.LinkError;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: Missing Url value, while Type is set to Link. ({H(ErrorCode.FileMissingUrlValue)})");
                        return (int)ErrorCode.FileMissingUrlValue;
                    }
                    break;
                #endregion Link

                #region Directory
                // Open File Explorer with a specific path/directory with Explorer.
                case DesktopFileType.Directory:
                    if (Value.Length > 0)
                    {
                        if (Directory.Exists(Value))
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(Utils.ExplorerPath,
                                    Value.Replace("/", @"\"));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: Could not open the directory. ({H(ErrorCode.DirectoryError)})");
                                Console.WriteLine($"{Ex(ex)}");
                                return (int)ErrorCode.DirectoryError;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error: Directory \"{Value}\" could not be found. ({H(ErrorCode.DirectoryNotFound)})");
                            return (int)ErrorCode.DirectoryNotFound;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: Missing Path value, while Type is set to Directory. ({H(ErrorCode.FileMissingPathValue)})");
                        return (int)ErrorCode.FileMissingPathValue;
                    }
                    break;
                #endregion Directory
            } // End of switch()

            Console.WriteLine("Started successfully.");

            return 0;
        }

        /// <summary>
        /// Quickly get a hexadecimal number from a number with a leading zero
        /// from an <see cref="ErrorCode"/>.
        /// </summary>
        /// <param name="i">Number</param>
        /// <returns>Formatted number</returns>
        static string H(ErrorCode i) => $"0x{i:X8}";

        /// <summary>
        /// Quickly get a formatted string with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="e"><see cref="Exception"/></param>
        /// <returns>Formatted information</returns>
        static string Ex(Exception ex) => $"{ex.GetType()} (0x{ex.HResult:X8})";

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
