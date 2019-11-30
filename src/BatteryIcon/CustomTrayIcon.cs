using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IconLibrary;

namespace BatteryIcon
{
    class CustomTrayIcon: TrayIcon
    {
        private CustomSettings settings;

        public CustomTrayIcon()
        {
            settings = CustomSettings.Instance;

            SetUpdateInterval(settings.updateInterval);
            EnableIcon();
        }

        public override void ContextMenuSettings(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
            // immediatly see changes
            SetUpdateInterval(settings.updateInterval);
            UpdateIconTick();
        }

        public override void UpdateIconTick(object sender = null, EventArgs e = null)
        {
            PowerStatus powerStatus = SystemInformation.PowerStatus;

            string batteryPercentage = (powerStatus.BatteryLifePercent * 100).ToString();
            bool isCharging = powerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Charging);
            bool isConnected = powerStatus.PowerLineStatus.HasFlag(PowerLineStatus.Online);

            string tooltip;
            if (powerStatus.BatteryLifeRemaining != -1)
            {
                if (powerStatus.BatteryLifeRemaining > 3600)
                {
                    int hours = powerStatus.BatteryLifeRemaining / 3600;
                    int minutes = powerStatus.BatteryLifeRemaining % 3600 / 60;
                    tooltip = String.Format("{0} hr {1} min ({2}%) remaining", hours, minutes, batteryPercentage);
                }
                else
                {
                    int minutes = powerStatus.BatteryLifeRemaining / 60;
                    tooltip = String.Format("{0} min ({1}%) remaining", minutes, batteryPercentage);
                }
            }
            else
            {
                tooltip = String.Format("{0}%", batteryPercentage);
            }

            Color foregroundColor = settings.foregroundColor;

            if (isCharging)
            {
                tooltip += " (charging)";
                foregroundColor = settings.foregroundChargingColor;
            }
            else if (isConnected)
            {
                tooltip += " (plugged in, not charging)";
            }

            string iconFont = settings.fontName;
            int iconFontSize = settings.fontSize;
            
            Color backgroundColor = settings.backgroundColor;
            Color borderColor = settings.borderColor;

            using (Bitmap bitmap = new Bitmap(DrawText(batteryPercentage, new Font(iconFont, iconFontSize, FontStyle.Bold), foregroundColor, backgroundColor, borderColor)))
            {
                ChangeIcon(bitmap, tooltip);
            }
        }

        private Image DrawText(String text, Font font, Color textColor, Color backColor, Color borderColor)
        {
            var textSize = GetImageSize(text, font);
            int iconSize = GetTrayIconsSize();
            Image image = new Bitmap(iconSize, iconSize);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                // paint the background
                graphics.Clear(backColor);

                // create a brush for the text
                using (Brush textBrush = new SolidBrush(textColor))
                {
                    int borderWidth = 1;
                    graphics.DrawRectangle(new Pen(borderColor, borderWidth), 0, 0, (int)image.Width - borderWidth, (int)image.Height - borderWidth);

                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    float xScale = 1;
                    float yScale = 1;
                    int allowedCrop = 1;
                    if (settings.scaling > 0)
                    {
                        if (text.Length == 1)
                        {
                            // with defaut size digit shifted to the left
                            textSize.Width = (float)(textSize.Width * 0.7);
                            // draw single digit with same width as 2 digits
                            var textSizeForScale = GetImageSize("99", font);
                            xScale = (iconSize + 2 * allowedCrop) / textSizeForScale.Width;
                            yScale = (iconSize + 2 * allowedCrop) / textSizeForScale.Height;
                        }
                        else
                        {
                            xScale = (iconSize + 2 * allowedCrop) / textSize.Width;
                            yScale = (iconSize + 2 * allowedCrop) / textSize.Height;
                        }
                        graphics.ScaleTransform(xScale, yScale);
                    }
                    float xPos = (image.Width + 2 * allowedCrop - textSize.Width * xScale) / 2 - allowedCrop;
                    float yPos = (image.Height + 2 * allowedCrop - textSize.Height * yScale) / 2;
                    // move "100" to left, because '1' thinner than '0'
                    if (text.Length == 3)
                    {
                        xPos -= iconSize / 14;
                    }
                    graphics.DrawString(text, font, textBrush, xPos, yPos);
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
    }

}
