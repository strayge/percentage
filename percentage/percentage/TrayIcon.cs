﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace percentage
{
    class TrayIcon
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool DestroyIcon(IntPtr handle);

        private string batteryPercentage;
        private NotifyIcon notifyIcon;

        private Settings settings;

        public TrayIcon()
        {
            settings = new Settings();

            notifyIcon = new NotifyIcon();

            // initialize contextMenu
            notifyIcon.ContextMenu = new ContextMenu(new[]
            {
                new MenuItem("&Settings", menuSettings_Click),
                new MenuItem("E&xit", menuExit_Click),
                
            });

            notifyIcon.Visible = true;

            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = settings.updateInterval; // in miliseconds
            timer.Start();
            timer_Tick(timer, null);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PowerStatus powerStatus = SystemInformation.PowerStatus;

            batteryPercentage = (powerStatus.BatteryLifePercent * 100).ToString();

            string iconFont = settings.fontName;
            int iconFontSize = settings.fontSize;
            Color foregroundColor = settings.foregroundColor;
            Color backgroundColor = settings.backgroundColor;

            using (Bitmap bitmap = new Bitmap(DrawText(batteryPercentage, new Font(iconFont, iconFontSize, FontStyle.Bold), foregroundColor, backgroundColor)))
            {
                System.IntPtr intPtr = bitmap.GetHicon();
                try
                {
                    using (Icon icon = Icon.FromHandle(intPtr))
                    {
                        notifyIcon.Icon = icon;
                        notifyIcon.Text = batteryPercentage + "%";
                    }
                }
                finally
                {
                    DestroyIcon(intPtr);
                }
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        private Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            var textSize = GetImageSize(text, font);
            Image image = new Bitmap((int) textSize.Width, (int) textSize.Height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                // paint the background
                graphics.Clear(backColor);

                // create a brush for the text
                using (Brush textBrush = new SolidBrush(textColor))
                {
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    graphics.DrawString(text, font, textBrush, 0, 0);
                    graphics.Save();
                }
            }

            return image;
        }

        private static SizeF GetImageSize(string text, Font font)
        {
            using (Image image = new Bitmap(1, 1))
            using (Graphics graphics = Graphics.FromImage(image))
                return graphics.MeasureString(text, font);
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
            settings.Reload();
            timer_Tick(sender, e);
        }
    }
}
