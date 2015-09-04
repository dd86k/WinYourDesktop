using System;

namespace WinYourDesktop
{
    /// <summary>
    /// Standard used:
    /// http://standards.freedesktop.org/desktop-entry-spec/latest/index.html
    /// Most useful page:
    /// http://standards.freedesktop.org/desktop-entry-spec/latest/ar01s05.html
    /// </summary>
    class Interpreter
    {
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
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i][0] != '#') // Avoid comments
                {
                    line = lines[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    if (line.Length < 2)
                        throw new Exception($"Failed to split key and value at line {i}.{Environment.NewLine}Missing operator? ('=')");

                    switch (line[0].Trim())
                    {
                        case "Exec":
                            System.Diagnostics.Process.Start(lines[1]);
                            break;
                    }
                }
            }
        }
    }
}
