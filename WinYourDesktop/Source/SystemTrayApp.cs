using System;
using System.Drawing;
using System.Windows.Forms;

//TODO: SystemTrayApp (v0.9)

namespace WinYourDesktop
{
    class SystemTrayApp : Form
    {
        NotifyIcon TrayIcon;
        ContextMenu TrayMenu;

        public SystemTrayApp()
        {
            // Create a simple tray menu with only one item.
            TrayMenu = new ContextMenu();
            TrayMenu.MenuItems.Add("Exit", OnExit);
            
            TrayIcon = new NotifyIcon();
            TrayIcon.Text = "WinYourDesktop";
            TrayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            
            TrayIcon.ContextMenu = TrayMenu;
            TrayIcon.Visible = true;

            Visible = false;
            ShowInTaskbar = false;
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
