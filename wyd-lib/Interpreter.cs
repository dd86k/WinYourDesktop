using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using static System.Console;
using static System.Reflection.Assembly;
using static System.Environment;

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

            FileInfo file = new FileInfo(pPath);

            if (!file.Exists)
            {
                if (pVerbose)
                    WriteLine($"Error: \"{pPath}\" does not exist.");

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

            char[] SPLITTER = new char[] { DELIMITER };

            if (pVerbose)
                WriteLine($"Reading {file.Name}...");

            using (StreamReader sr = file.OpenText())
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

                        LineValues = CurrentLine.Split(SPLITTER,
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
                                    default:
                                        return ErrorCode.FileMissingType;
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
                } // End while
            } // End using

            if (pVerbose)
                WriteLine($"Starting...");
            
            if (string.IsNullOrWhiteSpace(value))
                switch (type)
                {
                    case DesktopFileType.Application:
                        return ErrorCode.FileMissingExecValue;
                    case DesktopFileType.Link:
                        return ErrorCode.FileMissingUrlValue;
                    case DesktopFileType.Directory:
                        return ErrorCode.FileMissingPathValue;
                }

            if (value.Contains("%") || value.Contains("$"))
                ReplaceVars(ref value, pVerbose);

            if (value.Contains("~"))
                ReplaceHome(ref value, pVerbose);

            switch (type)
            {
                #region Application
                // Launch an application.
                case DesktopFileType.Application:
                    try
                    {
                        if (terminal)
                            Process.Start("cmd", $"/c {value}");
                        else
                            Process.Start(value);
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
                            Process.Start(
                                $"{GetFolderPath(SpecialFolder.Windows)}\\explorer",
                                value); // .Replace("/", @"\")
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
            } // End switch

            if (pVerbose)
                WriteLine("Started successfully.");

            return 0; /// 0 is <see cref="ErrorCode.Success"/>
        }

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
        #endregion

        #region Private methods
        static void ReplaceVars(ref string value, bool pVerbose)
        {
            if (pVerbose)
                WriteLine("Variables detected! Running parser...");

            /**
             * A collection of regex results ("%USERNAME%", "$USER", etc.).
             */
            MatchCollection Results =
                new Regex(@"(\$\w+)|(%\w+%)",
                    RegexOptions.ECMAScript | RegexOptions.CultureInvariant
                ).Matches(value);

            /**
             * You may be wondering: Why one dictionary?
             * If you spawn a cmd session (command prompt), and say, type in
             * echo %TMP%
             * You will get the user variable (C:\Users\DD\AppData\Local\Temp) rather than
             * the system variable (C:\WINDOWS\TEMP).
             */
            IDictionary envs =
                new Dictionary<string, string>(128, StringComparer.OrdinalIgnoreCase);

            string userprofile = GetFolderPath(SpecialFolder.UserProfile);

            /**
             * Linux common examples
                HOME=/home/dd
                HOSTNAME=dd-vm
                HOSTTYPE=x86_64
                PWD=/home/dd/Desktop
                SHELL=/bin/bash
                UID=1000
                USER=dd
              * USERNAME=dd
               
                Notes:
              * Windows already has that variable with the same value.
             */
            envs.Add("HOME", userprofile);
            envs.Add("HOSTNAME", MachineName);
            /*envs.Add("HOSTTYPE", Environment.Is64BitOperatingSystem ?
                "x86_64" ? "");*/
            envs.Add("USER", UserName);

            /**
             * Windows auto-generated variables
             */
            envs.Add("SYSTEMROOT", Path.GetDirectoryName(SystemDirectory));
            envs.Add("SYSTEMDRIVE", Path.GetPathRoot(SystemDirectory));
            //envs.Add("TMP", $@"{userprofile}\AppData\Local\Temp");  // Already a user variable
            //envs.Add("TEMP", $@"{userprofile}\AppData\Local\Temp"); // Already a user variable
            // HKEY_CURRENT_USER\Volatile Environment
            envs.Add("APPDATA", $@"{userprofile}\AppData\Roaming");
            envs.Add("HOMEDRIVE", Path.GetPathRoot(userprofile).Replace("\\", "")); // C:
            envs.Add("HOMEPATH", userprofile.Replace(envs["HOMEDRIVE"].ToString(), "")); // \Users\DD
            envs.Add("LOCALAPPDATA", $@"{userprofile}\AppData\Local");
            envs.Add("LOGONSERVER", $@"\\{UserDomainName}"); // Unsure
            envs.Add("USERDOMAIN", UserDomainName);
            envs.Add("USERDOMAIN_ROAMINGPROFILE", UserDomainName); // Unsure
            envs.Add("USERPROFILE", userprofile);
            //envs.Add("", "");

            foreach (DictionaryEntry i in
                GetEnvironmentVariables(EnvironmentVariableTarget.User))
                if (!envs.Contains(i.Key))
                    envs.Add(i.Key, i.Value);

            foreach (DictionaryEntry i in
                GetEnvironmentVariables(EnvironmentVariableTarget.Machine))
                if (!envs.Contains(i.Key))
                    envs.Add(i.Key, i.Value);
            
            foreach (Match result in Results)
            {
                string t = result.Value.StartsWith("$") ?
                    result.Value.TrimStart('$') :
                    result.Value.Trim('%');

                if (envs.Contains(t))
                {
                    if (pVerbose)
                        WriteLine($"Variable: {result.Value} -> {envs[t]}");

                    value =
                        value.Replace(result.Value, envs[t].ToString());
                }
                else if (pVerbose)
                    WriteLine($"ENV NOT FOUND: {t}");
            }
        }

        static void ReplaceHome(ref string value, bool pVerbose)
        {
            string home =
                GetFolderPath(SpecialFolder.UserProfile);

            if (pVerbose)
                WriteLine($"HOME: ~ -> {home}");

            value = value.Replace("~", home);
        }

        /// <summary>
        /// Quickly get a formatted string with an <see cref="Exception"/>.
        /// </summary>
        /// <param name="e"><see cref="Exception"/></param>
        /// <returns>Formatted information</returns>
        static string Ex(Exception e) => $"{e.GetType()} (0x{e.HResult:X8})";
        #endregion Private Methods
    }
    #endregion
    
    #region Public enumerations
    /// <remarks>
    /// For error messages, see
    /// <see cref="Extensions.GetErrorMessage(ErrorCode)"/>
    /// </remarks>
    public enum ErrorCode : byte
    {
        Success = 0,

        NullPath = 0x8,
        EmptyPath = 0x9,
        
        FileNotFound = 0x16,
        FileEmpty = 0x17,
        FileNoSignature = 0x18,
        FileMissingDelimiter = 0x19,
        FileMissingType = 0x20,
        FileMissingExecValue = 0x21,
        FileMissingUrlValue = 0x22,
        FileMissingPathValue = 0x23,
        
        ExecError = 0x32,
        ExecInvalidOperation = 0x33,
        ExecWin32Error = 0x34,
        ExecFileNotFound = 0x35,
        
        LinkError = 0x40,
        
        DirectoryError = 0x48,
        DirectoryNotFound = 0x49,
    }

    public static class Extensions
    {
        public static int ToInt(this ErrorCode e) => (int)e;
        public static string Hex(this ErrorCode e) => $"0x{(int)e:X4}";
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
                    return $"Missing \"=\" delimiter.";
                case ErrorCode.FileMissingType:
                    return "Missing Type.";
                case ErrorCode.FileMissingExecValue:
                    return "Missing Exec value.";
                case ErrorCode.FileMissingUrlValue:
                    return "Missing URL value.";
                case ErrorCode.FileMissingPathValue:
                    return "Missing Path value.";

                    // Exec
                case ErrorCode.ExecError:
                    return "Generic Exec error.";
                case ErrorCode.ExecInvalidOperation:
                    return "Invalid operation at Exec.";
                case ErrorCode.ExecWin32Error:
                    return "Could not start the application (Win32 error).";
                case ErrorCode.ExecFileNotFound:
                    return "File not found (Exec).";

                    // Link (URL)
                case ErrorCode.LinkError:
                    return "Generic Link error. (URL)";

                    // Directory (Path)
                case ErrorCode.DirectoryError:
                    return "Generic Directory error. (Path)";
                case ErrorCode.DirectoryNotFound:
                    return "Directory not found (invalid path).";
            }

            return $"Unknown error. - {e}";
        }
    }
    #endregion
}
