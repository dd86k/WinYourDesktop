using System;
using System.IO;

namespace WinYourDesktop
{
    static class SettingsHandler
    {
        public const string SettingFile = "wyd-settings.toml";

        public static bool SettingFileExists
        {
            get
            {
                return File.Exists(SettingFile);
            }
        }
        
        // Settings
        public static string Language;

        public static void Save()
        {
            using (StreamWriter sw = new StreamWriter(SettingFile, false))
            {
                sw.WriteLine("[Settings]");
                sw.WriteLine($"Language = {Language}");
            }
        }

        public static void Load()
        {
            using (StreamReader sr = new StreamReader(SettingFile))
            {
                while (!sr.EndOfStream)
                {
                    string l = sr.ReadLine();

                    if (!l.StartsWith("[") && l.Length > 0)
                    {
                        if (l.StartsWith("Language"))
                            Language = Split(l);
                    }
                }
            }
        }

        static string Split(string pLine)
        {
            if (pLine.Contains("="))
            {
                char[] c = { '=' };

                string[] v = pLine.Split(c,
                    StringSplitOptions.RemoveEmptyEntries);

                if (v.Length > 1)
                    return v[1];
                else
                    return null;
            }
            else return null;
        }
    }
}
