using System;
using System.Drawing;
using System.Windows.Forms;

/*
    NotificationHandler
    Manages notifications.
*/

namespace WinYourDesktop
{
    class NotificationHandler
    {
        #region Properties
        ToolStripMenuItem _toolStrip;
        ImageList _imageList;
        #endregion

        #region Enumerations
        internal enum Importance : byte
        {
            Low, Normal, High, Crucial
        }

        internal enum Action : byte
        {
            None
        }
        #endregion

        #region Construction
        public NotificationHandler(ToolStripMenuItem pToolStripMenuItem, ImageList pImageList)
        {
            _toolStrip = pToolStripMenuItem;
            _imageList = pImageList;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Displays a notification (in the app's notification thingy).
        /// </summary>
        /// <param name="pMessage">Text to display.</param>
        internal void AddNotification(string pMessage)
        {
            AddNotification(pMessage, Importance.Normal, Action.None);
        }

        /// <summary>
        /// Displays a notification (in the app's notification thingy).
        /// </summary>
        /// <param name="pMessage">Text to display.</param>
        /// <param name="pImportance">The level of importance.</param>
        internal void AddNotification(string pMessage, Importance pImportance)
        {
            AddNotification(pMessage, pImportance, Action.None);
        }

        /// <summary>
        /// Displays a notification (in the app's notification thingy).
        /// </summary>
        /// <param name="pMessage">Text to display.</param>
        /// <param name="pImportance">The level of importance.</param>
        /// <param name="pTag">Custom action. By default, it just closes the notification.</param>
        internal void AddNotification(string pMessage, Importance pImportance, Action pTag)
        {
            ToolStripMenuItem tsmi = new ToolStripMenuItem();
            tsmi.Text = pMessage;
            tsmi.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            tsmi.Tag = pTag;
            switch (pImportance)
            {
                case Importance.Low:
                    tsmi.Image =
                        _imageList.Images["NotificationLow.png"]; break;
                case Importance.Normal:
                    tsmi.Image =
                        _imageList.Images["Dot.png"]; break;
                case Importance.High:
                    tsmi.Image =
                        _imageList.Images["NotificationHigh.png"]; break;
                case Importance.Crucial:
                    tsmi.Image =
                        _imageList.Images["NotificationCrucial.png"]; break;
            }

            tsmi.Click += Notification_Click;

            _toolStrip.DropDownItems.Add(tsmi);

            UpdateNotificationArea();
        }

        internal void CloseNotification(ToolStripMenuItem pTsmi)
        {
            _toolStrip.DropDownItems.Remove(pTsmi);

            UpdateNotificationArea();
        }

        void UpdateNotificationArea()
        {
            _toolStrip.Font = (_toolStrip.DropDownItems.Count > 0) ?
                _toolStrip.Font = new Font("Segoe UI", 10, FontStyle.Bold) :
                _toolStrip.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            _toolStrip.Text = _toolStrip.DropDownItems.Count.ToString();
        }
        #endregion

        #region Events
        void Notification_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmiSender = (ToolStripMenuItem)sender;

            Action tag = (Action)tsmiSender.Tag;
            
            switch (tag)
            {
                // Action.None falls into this category
                default:
                    break;
            }

            CloseNotification(tsmiSender);
        }
        #endregion
    }
}
