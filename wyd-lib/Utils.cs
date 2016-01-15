using System;
using System.IO;

namespace WinYourDesktopLibrary
{
    public static class Utils
    {
        public static string ExplorerPath =
            $"{Directory.GetParent(Environment.SystemDirectory)}{Path.DirectorySeparatorChar}explorer";
    }
}
