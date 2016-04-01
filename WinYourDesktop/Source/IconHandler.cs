using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using SharpShell;
using SharpShell.Attributes;
using SharpShell.SharpIconHandler;
using SharpShell.Extensions;
using SharpShell.Interop;
using SharpShell.Diagnostics;
using SharpShell.NativeBridge;
using System.ComponentModel;

/*
    IconHandler
    Used to change icons, independent on extension.
*/

// SharpShell Project Home
// http://www.codeproject.com/Articles/522665/NET-Shell-Extensions-Shell-Icon-Handlers
//TODO: SharpShell Server (?) (v0.9)

// Icon handling in Windows:
// Also why this will be pretty hard to implement.
// WARNING: C++ WOULD HAVE TO BE USED.
//https://msdn.microsoft.com/en-us/library/windows/desktop/ff521690(v=vs.85).aspx

namespace WinYourDesktop
{
    [ComVisible(true)]
  //[COMServerAssocation(AssociationType.ClassOfExtension, ".dll")]
    [COMServerAssocation(AssociationType.ClassOfExtension, ".desktop")]
    class IconHandler : SharpIconHandler
    {
        static IconConverter ic = new IconConverter();

        /// <summary>
        /// Change the icon of a desktop file to a user specified icon.
        /// </summary>
        /// <param name="pPathDesktopFile">Desktop Entry file path.</param>
        /// <param name="pPathIcon">Icon path.</param>
        internal static void ChangeIcon(string pPathDesktopFile, string pPathIcon)
        {
            //TODO: IconHandler (v0.9)
            if (!File.Exists(pPathIcon))
                throw new FileNotFoundException("File not found.", pPathDesktopFile);

            Icon newicon = new Icon(pPathIcon);


        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <param name="smallIcon">if set to <c>true</c> provide a small icon.</param>
        /// <param name="iconSize">Size of the icon.</param>
        /// <returns>
        /// The icon for the file.
        /// </returns>
        protected override Icon GetIcon(bool smallIcon, uint iconSize)
        {
            throw new NotImplementedException();
        }
    }
}
