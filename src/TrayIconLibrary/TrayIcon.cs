using System;
using System.Drawing;
using System.Windows.Forms;
using TrayIconLibrary;

namespace IconLibrary
{
    class TrayIcon
    {
        private NotifyIcon notifyIcon;

        // for store state and divide enable/disable clicks
        MenuItem contextMenuAutostartItem;

        public TrayIcon()
        {
            notifyIcon = new NotifyIcon();
            CreateContextMenu();

            updateIconTimer = new Timer();
            updateIconTimer.Interval = 100;
            updateIconTimer.Tick += new EventHandler(UpdateIconTick);

            // icon's tooltip
            notifyIcon.MouseMove += IconMouseMoveEvent;
            // balloon tip
            notifyIcon.MouseClick += IconMouseClickEvent;

            notifyIcon.MouseDoubleClick += IconMouseDoubleClickEvent;
        }

        public void SetUpdateInterval(int interval)
        {
            updateIconTimer.Interval = interval;
        }

        private void CreateContextMenu()
        {
            contextMenuAutostartItem = new MenuItem("&Autostart", ContextMenuAutostart)
            {
                Checked = Autostart.IsEnabled()
            };
            notifyIcon.ContextMenu = new ContextMenu(new[]
            {
                contextMenuAutostartItem,
                new MenuItem("-"),
                new MenuItem("&Settings", ContextMenuSettings),
                new MenuItem("E&xit", ContextMenuExit),
            });
        }

        private void ContextMenuExit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        // custom form with settings can be showed here
        public virtual void ContextMenuSettings(object sender, EventArgs e) { }

        private void ContextMenuAutostart(object sender, EventArgs e)
        {
            if (contextMenuAutostartItem.Checked)
            {
                Autostart.Disable();
            }
            else
            {
                Autostart.Enable();
            }
            contextMenuAutostartItem.Checked = Autostart.IsEnabled();
        }

        public void DisableIcon()
        {
            updateIconTimer.Stop();
            notifyIcon.Visible = false;
        }

        public void EnableIcon()
        {
            updateIconTimer.Start();
            notifyIcon.Visible = true;
            UpdateIconTick();
        }

        // for update icon
        public virtual void UpdateIconTick(object sender = null, EventArgs e = null) { }

        private Timer updateIconTimer;

        protected int GetTrayIconsSize()
        {
            // get size for tray icons on current system (depends on DPI)
            return WinApi.GetSystemMetrics(WinApi.SM_CXSMICON);
        }

        // depends on DPI
        public int WidthSingleMeasurement()
        {
            if (GetTrayIconsSize() <= 16)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        // old icon cached to allow changing only tooltip
        private Bitmap cachedIconBitmap;

        // update both icon and tooltip
        public void ChangeIcon(Bitmap bitmap = null, string tooltip = null)
        {
            // always get bitmap for set
            if (bitmap == null)
            {
                bitmap = cachedIconBitmap;
            }
            else
            {
                if (cachedIconBitmap != null)
                {
                    cachedIconBitmap.Dispose();
                }
                cachedIconBitmap = (Bitmap)bitmap.Clone();
            }
            if (bitmap == null)
            {
                return;
            }

            System.IntPtr intPtr = bitmap.GetHicon();
            try
            {
                using (Icon icon = Icon.FromHandle(intPtr))
                {
                    notifyIcon.Icon = icon;

                    // changing tooltip only while valid icon handler
                    if (tooltip != null)
                    {
                        notifyIcon.Text = tooltip;
                    }
                }
            }
            finally
            {
                WinApi.DestroyIcon(intPtr);
            }
        }

        // update only icon
        public void SetIcon(Bitmap bitmap)
        {
            ChangeIcon(bitmap, null);
        }

        // update only tooltip
        public void SetTooltip(string text)
        {
            ChangeIcon(null, text);
        }

        // will be executed only after hovering mouse
        // it allow contains here more heavy calculations
        // than at each icon updating
        public virtual void IconHovered() { }

        private long latestTooltipHoverUpdate;

        protected int tooltipHoverMinimumDelay = 1000;

        private void IconMouseMoveEvent(object sender = null, EventArgs e = null)
        {
            long now = Utils.UtcNowMilliseconds();
            // fire TooltipHovered event with minimum delay equals 1000 ms
            if ((now - latestTooltipHoverUpdate) > tooltipHoverMinimumDelay)
            {
                // update timestamp immedialty to prevent several calculation at same time
                latestTooltipHoverUpdate = now + 10000;
                    
                IconHovered();
                // calculate time delta from end of calculation
                latestTooltipHoverUpdate = now;
            }
        }

        private Timer timerForWaitDoubleClick;

        // show balloontip on left moube button
        private void IconMouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // check time from latest double click
                if (timerForWaitDoubleClick != null)
                {
                    int latestDoubleClick = (int)timerForWaitDoubleClick.Tag;
                    int now = System.Environment.TickCount;
                    if ((now - latestDoubleClick) < SystemInformation.DoubleClickTime)
                    {
                        return;
                    }
                }
                timerForWaitDoubleClick = new Timer();
                timerForWaitDoubleClick.Interval = SystemInformation.DoubleClickTime;
                timerForWaitDoubleClick.Tag = 0; // double click timing
                timerForWaitDoubleClick.Tick += (s, a) =>
                {
                    IconMouseClickAction();
                    timerForWaitDoubleClick.Stop();
                };
                timerForWaitDoubleClick.Start();
            }
        }

        private void IconMouseDoubleClickEvent(object sender, MouseEventArgs e)
        {
            if (timerForWaitDoubleClick != null)
            {
                timerForWaitDoubleClick.Stop();
                // set time to prevent fire event on second click
                timerForWaitDoubleClick.Tag = System.Environment.TickCount;
            }
            IconMouseDoubleClickAction();
        }

        // default actions
        public virtual void IconMouseClickAction()
        {
            if (balloonText != null)
            {
                ShowBalloon(balloonText, balloonTitle);
            }
        }

        public virtual void IconMouseDoubleClickAction() { }

        private Timer balloonTimer;
        protected string balloonText;
        protected string balloonTitle;

        // set data for balloontip
        public void SetBalloon(string text = null, string title = null)
        {
            balloonText = text;
            balloonTitle = title;
        }

        protected void ShowBalloon(string text, string title = null)
        {
            if (balloonTimer != null)
            {
                return;
            }
            balloonTimer = new Timer();
            balloonTimer.Interval = 2000;
            balloonTimer.Tick += HideBalloon;
            balloonTimer.Start();
            notifyIcon.BalloonTipClosed += HideBalloon;
            notifyIcon.ShowBalloonTip(2000, title, text, ToolTipIcon.Info);
        }

        private void HideBalloon(object sender = null, EventArgs e = null)
        {
            if (balloonTimer == null)
            {
                return;
            }
            balloonTimer.Stop();
            balloonTimer.Dispose();
            balloonTimer = null;
        }

    }
}
