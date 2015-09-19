﻿using System.Windows.Forms;
using System.Drawing;

/*
    FormMain.cs
    FormMain
    Constructors, events (delegates).
*/

namespace WinYourDesktop
{
    internal partial class FormMain : Form
    {
        #region Constructors
        internal FormMain() : this(null)
        {
            // Call FormMain(string) with this(null)
        }

        string file = null;
        internal FormMain(string pDesktopFilePath)
        {
            InitializeComponent();
            PostInitialize();

            if (pDesktopFilePath != null)
            {
                file = pDesktopFilePath;
            }
        }
        #endregion

        #region Menubar
        // ImgBurn's EzPicker-styled view
        // Do I have to say sorry for this?
        private void tsmiHome_Click(object sender, System.EventArgs e)
        {
            if (!tsmiHome.Checked)
            {
                tsmiHome.Checked = true;
                tsmiEditor.Checked = false;
                tsmiDebugger.Checked = false;
                tsmiSettings.Checked = false;
                ToggleMode(ViewingMode.Home);
            }
        }

        // Editor view
        private void tsmiEditor_Click(object sender, System.EventArgs e)
        {
            System.Console.Write("wtf");
            if (!tsmiEditor.Checked)
            {
                tsmiHome.Checked = false;
                tsmiEditor.Checked = true;
                tsmiDebugger.Checked = false;
                tsmiSettings.Checked = false;
                ToggleMode(ViewingMode.Editor);
            }
        }

        // Debugger view
        private void tsmiDebugger_Click(object sender, System.EventArgs e)
        {
            if (!tsmiDebugger.Checked)
            {
                tsmiHome.Checked = false;
                tsmiEditor.Checked = false;
                tsmiDebugger.Checked = true;
                tsmiSettings.Checked = false;
                ToggleMode(ViewingMode.Debuger);
            }
        }

        // Settings view
        private void tsmiSettings_Click(object sender, System.EventArgs e)
        {
            if (!tsmiSettings.Checked)
            {
                tsmiHome.Checked = false;
                tsmiEditor.Checked = false;
                tsmiDebugger.Checked = false;
                tsmiSettings.Checked = true;
                ToggleMode(ViewingMode.Settings);
            }
        }

        // Restart
        private void restartToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Restart();
        }

        // Quit
        private void quitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        // About
        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormAbout fAbout = new FormAbout();
            fAbout.Location = new Point
            {
                // FormAbout will show right if only it can fit into the current screen.
                X = Location.X + Size.Width + fAbout.Size.Width >
                        Screen.FromControl(this).WorkingArea.Size.Width ?
                        Location.X - fAbout.Size.Width :
                        Location.X + Size.Width,
                Y = Location.Y
            };
            fAbout.Show();
        }
        #endregion

        #region Main buttons
        // Run
        private void btnRun_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRun_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("sslblStatusbtnRun");
        }

        private void btnRun_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("Welcome");
        }

        // Create
        private void btnCreate_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCreate_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("sslblStatusbtnCreate");
        }

        private void btnCreate_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("Welcome");
        }

        // Debug
        private void btnDebug_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDebug_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("sslblStatusbtnDebug");
        }

        private void btnDebug_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("Welcome");
        }

        // Edit
        private void btnEdit_Click(object sender, System.EventArgs e)
        {

        }

        private void btnEdit_MouseEnter(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("sslblStatusbtnEdit");
        }

        private void btnEdit_MouseLeave(object sender, System.EventArgs e)
        {
            sslblStatus.Text = RM.GetString("Welcome");
        }
        #endregion

        private void cboSettingsLanguage_SelectedValueChanged(object sender, System.EventArgs e)
        {
            // I felt like doing a crazy one liner.
            string culture = cboSettingsLanguage.Items[cboSettingsLanguage.SelectedIndex]
                .ToString()
                .Split(new string[] { " - " }, System.StringSplitOptions.None)[1];
            ChangeCulture(culture);
        }
    }
}
