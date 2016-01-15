using System;
using System.IO;

namespace wyd_lib
{
    public static class Utils
    {
        public static string ExplorerPath =
            $"{Directory.GetParent(Environment.SystemDirectory)}{Path.DirectorySeparatorChar}explorer";
    }
}
