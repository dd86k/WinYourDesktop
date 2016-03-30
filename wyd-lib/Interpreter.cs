using System;
using System.IO;
using System.Diagnostics;
using static System.Reflection.Assembly;
using static System.Console;

namespace WinYourDesktopLibrary
{
    #region Interpreter
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
        #region Enums
        /// <summary>
        /// Desktop Entry header type.
        /// </summary>
        enum DesktopFileType : byte
        {
            /// <summary>
            /// Application type. (Exec)
            /// </summary>
            Application,
            /// <summary>
            /// Link type. (URL)
            /// </summary>
            Link,
            /// <summary>
            /// Directory type. (Path)
            /// </summary>
            Directory,
            /// <summary>
            /// Unknown header type. Default.
            /// </summary>
            Unknown
        }
        #endregion

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
                    GetExecutingAssembly().GetName().Version.ToString();
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
                    GetExecutingAssembly().GetName().Name;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Interpret a Desktop file.
        /// </summary>
        /// <param name="pPath">Path of the Desktop file.</param>
        /// <returns>ErrorCode.</returns>
        public static ErrorCode Run(string pPath, bool pVerboise = false)
        {
            if (string.IsNullOrEmpty(pPath))
            {
                if (pVerboise)
                    WriteLine($"Path is {(pPath == null ? "null" : "empty")}.");

                return pPath == null ?
                    ErrorCode.NullPath : ErrorCode.EmptyPath;
            }

            if (!File.Exists(pPath))
            {
                if (pVerboise)
                    WriteLine($"Error: Specified file doesn't exist at {pPath})");

                return ErrorCode.FileNotFound;
            }
            else if (pVerboise)
                WriteLine("File found.");
            
            // Defaults
            DesktopFileType type = DesktopFileType.Unknown;
            string CurrentLine;
            ushort CurrentLineIndex = 0;
            string[] LineValues;
            string Value = string.Empty;
            bool TerminalMode = false;

            char[] DELIM = new char[] { DELIMITER };

            if (pVerboise)
                WriteLine($"Starting {Path.GetFileName(pPath)}...");

            using (StreamReader sr = new StreamReader(pPath))
            {
                if (sr.ReadLine() != "[Desktop Entry]")
                {
                    return ErrorCode.FileNoSignature;
                }

                while (!sr.EndOfStream)
                {
                    CurrentLine = sr.ReadLine();

                    // line[0] == '[' // Group header (Soon?)
                    if (CurrentLine[0] != '#') // Avoid comments.
                    {
                        if (!CurrentLine.Contains("="))
                        {
                            if (pVerboise)
                                WriteLine($"Error: Line {CurrentLineIndex + 1} missing the '=' delimiter.");

                            return ErrorCode.FileMissingDelimiter;
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

                                if (pVerboise)
                                    WriteLine($"TYPE SET {type}");
                                break;
                                
                            case "Exec":
                            case "TryExec":
                                Value = LineValues[1];
                                break;

                            case "Url":
                            case "URL":
                                Value = LineValues[1];

                                if (pVerboise)
                                    WriteLine($"URL SET {Value}");
                                break;
                                
                            case "Path":
                                Value = LineValues[1];

                                if (pVerboise)
                                    WriteLine($"PATH SET {Value}");
                                break;
                                
                            case "Terminal":
                                if (LineValues[1].ToUpper() == "TRUE")
                                    TerminalMode = true;

                                if (pVerboise)
                                    WriteLine($"TERMINAL SET TRUE");
                                break;
                        }
                    }

                    CurrentLineIndex++;
                }
            }
            
            // Unknown is default, if unchanged, it's missing.
            if (type == DesktopFileType.Unknown)
            {
                return ErrorCode.FileMissingTypeValue;
            }

            if (pVerboise)
            {
                WriteLine("Starting...");
                WriteLine($"Value: {Value}");
            }

            switch (type)
            {
                #region App
                // Launch an application.
                case DesktopFileType.Application:
                    if (Value.Length > 0)
                    {
                        try
                        {
                            if (TerminalMode)
                            {
                                //TODO: Seperate command from arguments
                                ProcessStartInfo ps = new ProcessStartInfo(Value);

                                ps.UseShellExecute = true;

                                Process.Start(ps);
                            }
                            else
                            {
                                Process.Start(Value);
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            return ErrorCode.ExecInvalidOperation;
                        }
                        catch (System.ComponentModel.Win32Exception)
                        {
                            return ErrorCode.ExecWin32Error;
                        }
                        catch (Exception ex)
                        {
                            if (pVerboise)
                                WriteLine($"{Ex(ex)}");

                            return ErrorCode.ExecError;
                        }
                    }
                    else
                    {
                        return ErrorCode.FileMissingExecValue;
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
                            Process.Start(Value);
                        }
                        catch (Exception ex)
                        {
                            if (pVerboise)
                                WriteLine($"{Ex(ex)}");

                            return ErrorCode.LinkError;
                        }
                    }
                    else
                    {
                        return ErrorCode.FileMissingUrlValue;
                    }
                    break;
                #endregion Link

                #region Directory
                // Open File Explorer with a specific path/directory with File Explorer.
                case DesktopFileType.Directory:
                    if (Value.Length > 0)
                    {
                        if (Directory.Exists(Value))
                        {
                            try
                            {
                                Process.Start(Utils.ExplorerPath,
                                    Value.Replace("/", @"\"));
                            }
                            catch (Exception ex)
                            {
                                if (pVerboise)
                                    WriteLine($"{Ex(ex)}");

                                return ErrorCode.DirectoryError;
                            }
                        }
                        else
                        {
                            if (pVerboise)
                                WriteLine($"Error: Directory \"{Value}\" could not be found.");
                            return ErrorCode.DirectoryNotFound;
                        }
                    }
                    else
                    {
                        return ErrorCode.FileMissingPathValue;
                    }
                    break;
                #endregion Directory
            } // End of switch()

            if (pVerboise)
                WriteLine("Started successfully.");

            return 0;
        }

        /// <summary>
        /// Quickly get a formatted string with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="e"><see cref="Exception"/></param>
        /// <returns>Formatted information</returns>
        static string Ex(Exception ex) => $"{ex} (0x{ex.HResult:X8})";

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
    #endregion
    
    #region Enumerations
    public enum ErrorCode : byte
    {
        Success = 0,

        NullPath = 0x8,
        EmptyPath = 0x9,

        /// <summary>
        /// Desktop file not found.
        /// </summary>
        FileNotFound = 0x16,
        FileEmpty = 0x17,

        /// <remarks>
        /// Missing "[Desktop Entry]"
        /// </remarks>
        FileNoSignature = 0x18,
        FileMissingDelimiter = 0x19,
        FileMissingTypeValue = 0x20,
        FileMissingExecValue = 0x21,
        FileMissingUrlValue = 0x22,
        FileMissingPathValue = 0x23,

        /// <summary>
        /// Generic Exec error.
        /// </summary>
        ExecError = 0x32,
        ExecInvalidOperation = 0x33,
        ExecWin32Error = 0x34,
        ExecFileNotFound = 0x35,

        /// <summary>
        /// Generic Link error.
        /// </summary>
        LinkError = 0x40,

        /// <summary>
        /// Generic Directory error.
        /// </summary>
        DirectoryError = 0x48,
        DirectoryNotFound = 0x49,
    }

    public static class Extensions
    {
        public static int S(this ErrorCode e) => (int)e;
        public static string Hex(this ErrorCode e) => $"0x{e:X4}";
        public static string GetErrorMessage(this ErrorCode e)
        {
            switch (e)
            {
                // Path
                case ErrorCode.NullPath:
                    return "Entry path was null.";
                case ErrorCode.EmptyPath:
                    return "Entry path was empty.";

                // Desktop File
                case ErrorCode.FileNotFound:
                    return "The file could not be found.";
                case ErrorCode.FileEmpty:
                    return "The desktop file is empty.";
                case ErrorCode.FileNoSignature:
                    return "Missing [Desktop Entry] at the first line.";
                case ErrorCode.FileMissingDelimiter:
                    return "Missing \"=\" delimiter.";
                case ErrorCode.FileMissingTypeValue:
                    return "Missing Type value.";
                case ErrorCode.FileMissingExecValue:
                    return "Missing Exec value.";
                case ErrorCode.FileMissingUrlValue:
                    return "Missing URL value.";
                case ErrorCode.FileMissingPathValue:
                    return "Missing Path value.";

                    // Exec
                case ErrorCode.ExecError:
                    return "Exec error.";
                case ErrorCode.ExecInvalidOperation:
                    return "Invalid operation at Exec.";
                case ErrorCode.ExecWin32Error:
                    return "Could not start the application (Win32 error).";
                case ErrorCode.ExecFileNotFound:
                    return "File not found (Exec).";

                    // Link (URL)
                case ErrorCode.LinkError:
                    return "Link error. (URL)";

                    // Directory (Path)
                case ErrorCode.DirectoryError:
                    return "Directory error. (Path)";
                case ErrorCode.DirectoryNotFound:
                    return "Directory not found (invalid path).";
            }

            return $"Unknown error. - {e}";
        }
    }
    #endregion
}
