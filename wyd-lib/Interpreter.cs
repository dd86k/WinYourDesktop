using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using static System.Console;
using static System.Reflection.Assembly;

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
        /// Runs a desktop file.
        /// </summary>
        /// <param name="pPath">Path to the desktop file.</param>
        /// <param name="pVerbose"></param>
        /// <returns></returns>
        public static ErrorCode Run(string pPath, bool pVerbose = false)
        {
            if (string.IsNullOrEmpty(pPath))
            {
                if (pVerbose)
                    WriteLine($"Path is {(pPath == null ? "null" : "empty")}.");

                return pPath == null ?
                    ErrorCode.NullPath : ErrorCode.EmptyPath;
            }

            if (!File.Exists(pPath))
            {
                if (pVerbose)
                    WriteLine($"Error: Specified file doesn't exist at {pPath})");

                return ErrorCode.FileNotFound;
            }
            else if (pVerbose)
                WriteLine("File found.");
            
            // Defaults
            DesktopFileType type = DesktopFileType.Unknown;
            string CurrentLine;
            ushort CurrentLineIndex = 0;
            string[] LineValues;
            // User set
            string value = string.Empty;
            bool terminal = false;

            char[] DELIM = new char[] { DELIMITER };

            if (pVerbose)
                WriteLine($"Reading {Path.GetFileName(pPath)}...");

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
                            if (pVerbose)
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

                                if (pVerbose)
                                    WriteLine($"TYPE SET AS {type}");
                                break;
                                
                            case "Exec":
                            case "TryExec":
                                value = LineValues[1];

                                if (pVerbose)
                                    WriteLine($"EXEC SET {value}");
                                break;

                            case "Url":
                            case "URL":
                                value = LineValues[1];

                                if (pVerbose)
                                    WriteLine($"URL SET {value}");
                                break;
                                
                            case "Path":
                                value = LineValues[1];

                                if (pVerbose)
                                    WriteLine($"PATH SET {value}");
                                break;
                                
                            case "Terminal":
                                if (LineValues[1].ToUpper() == "TRUE")
                                    terminal = true;

                                if (pVerbose)
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

            if (value.Contains("%") || value.Contains("$"))
                ReplaceVars(ref value, pVerbose);

            if (value.Contains("~"))
                ReplaceHome(ref value, pVerbose);

            if (pVerbose)
                WriteLine($"Starting {value}...");

            if (string.IsNullOrWhiteSpace(value))
                return ErrorCode.FileMissingValue;

                switch (type)
            {
                #region Application
                // Launch an application.
                case DesktopFileType.Application:
                    try
                    {
                        if (terminal)
                        {
                            Process.Start("cmd", $"/c {value}");
                        }
                        else
                        {
                            Process.Start(value);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        return ErrorCode.ExecInvalidOperation;
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        if (pVerbose)
                            WriteLine($"Exception: {Ex(ex.InnerException ?? ex)}");

                        return ErrorCode.ExecWin32Error;
                    }
                    catch (Exception ex)
                    {
                        if (pVerbose)
                            WriteLine($"Exception: {Ex(ex)}");

                        return ErrorCode.ExecError;
                    }
                    break;
                #endregion App

                #region Link
                // Launch the user's default application that handles URLs.
                case DesktopFileType.Link:
                    try
                    {
                        Process.Start(value);
                    }
                    catch (Exception ex)
                    {
                        if (pVerbose)
                            WriteLine($"Exception: {Ex(ex)}");

                        return ErrorCode.LinkError;
                    }
                    break;
                #endregion Link

                #region Directory
                // Open File Explorer with a specific path/directory with File Explorer.
                case DesktopFileType.Directory:
                    if (Directory.Exists(value))
                    {
                        try
                        {
                            string explorer =
                                $"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\\explorer";

                            Process.Start(explorer,
                                value.Replace("/", @"\"));
                        }
                        catch (Exception ex)
                        {
                            if (pVerbose)
                                WriteLine($"{Ex(ex)}");

                            return ErrorCode.DirectoryError;
                        }
                    }
                    else
                    {
                        if (pVerbose)
                            WriteLine($"Error: Directory \"{value}\" could not be found.");

                        return ErrorCode.DirectoryNotFound;
                    }
                    break;
                #endregion Directory
            } // End of switch()

            if (pVerbose)
                WriteLine("Started successfully.");

            return 0;
        }

        static void ReplaceVars(ref string value, bool pVerbose)
        {
            if (pVerbose)
                WriteLine("Variables detected! Running parser...");

            MatchCollection Results =
                new Regex(@"(\$\w+)|(%\w+%)", RegexOptions.ECMAScript).Matches(value);

            IDictionary machineEnvs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            IDictionary userEnvs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (DictionaryEntry i in
                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine))
            {
                machineEnvs.Add(i.Key, i.Value);
            }
            foreach (DictionaryEntry i in
                Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User))
            {
                userEnvs.Add(i.Key, i.Value);
            }
            
            foreach (Match result in Results)
            {
                string t = result.Value.StartsWith("%") ?
                    result.Value.Trim('%') :
                    result.Value.TrimStart('$');

                if (pVerbose)
                    WriteLine($"VAR: {result.Value} -> {t}");

                if (userEnvs.Contains(t))
                {
                    if (pVerbose)
                        WriteLine($"NEW VAR: {userEnvs [t]}");

                    value = value.Replace(result.Value, userEnvs [t].ToString());
                }
                else if (machineEnvs.Contains(t))
                {
                    if (pVerbose)
                        WriteLine($"NEW VAR: {machineEnvs [t]}");

                    value = value.Replace(result.Value, machineEnvs [t].ToString());
                }
                else if (pVerbose)
                    WriteLine($"ENV NOT FOUND: {result.Value}");
            }
        }

        static void ReplaceHome(ref string value, bool pVerbose)
        {
            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (pVerbose)
                WriteLine($"HOME: ~ -> {home}");

            value = value.Replace("~", home);
        }

        /// <summary>
        /// Quickly get a formatted string with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="e"><see cref="Exception"/></param>
        /// <returns>Formatted information</returns>
        static string Ex(Exception ex) => $"{ex.GetType()} (0x{ex.HResult:X8})";

        /// <summary>
        /// Creates a dummy/example file in the current directory.
        /// </summary>
        static public void CreateExample()
        {
            using (TextWriter tw = new StreamWriter("Dummy.desktop", false))
            {
                tw.WriteLine("[Desktop Entry]");
                tw.WriteLine("# This is a simple generated dummy desktop file.");
                tw.WriteLine($"# Interpreter version: {ProjectVersion}");
                tw.WriteLine("Type=Directory");
                tw.WriteLine("Name=Open Windows Directory");
                tw.WriteLine(@"Path=%WINDIR%");
            }
        }
        #endregion Public Methods
    }
    #endregion
    
    #region Public enumerations
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
        FileMissingValue = 0x24,

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
