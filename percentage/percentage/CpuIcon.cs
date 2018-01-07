﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace percentage
{
    class CpuIcon: TrayIcon
    {
        private SettingsCpu settings;

        PerformanceCounter cpuCounter;
        List<float> measurents = new List<float>();

        public CpuIcon()
        {
            settings = SettingsCpu.Instance;
            if (settings.enabled <= 0)
            {
                DisableIcon();
                return;
            }

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            SetUpdateInterval(settings.updateInterval);
            // show icon immediatly after start because timer interval can be large
            UpdateIcon(null, null);
        }

        public float GetCpuUsage()
        {
            return cpuCounter.NextValue();
        }

        public override void UpdateIcon(object sender, EventArgs e)
        {
            Color foregroundColor = settings.foregroundColor;
            Color backgroundColor = settings.backgroundColor;
            Color borderColor = settings.borderColor;

            int pointWidth = settings.pointWidth;

            using (Bitmap bitmap = new Bitmap(32, 32))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColor);

                    float newValue = GetCpuUsage();
                    measurents.Add(newValue);
                    if (measurents.Count > bitmap.Width / pointWidth)
                    {
                        measurents.RemoveAt(0);
                    }

                    for (int i=measurents.Count-1; i>=0; i--)
                    {
                        float value = measurents[i];
                        var pos = bitmap.Width - (measurents.Count - 1 - i) * pointWidth;
                        graphics.DrawLine(new Pen(foregroundColor, pointWidth), pos, bitmap.Height, pos, bitmap.Height - bitmap.Height * value / 100);
                    }

                    int borderWidth = 1;
                    graphics.DrawRectangle(new Pen(borderColor, borderWidth), 0, 0, (int)bitmap.Width - borderWidth, (int)bitmap.Height - borderWidth);

                    graphics.Save();
                    string tooltip = String.Format("CPU: {0:F0}%\nAvg: {1:F0}%", newValue, measurents.Average());
                    ChangeIcon(bitmap, tooltip);
                }
            }
        }

        protected override void menuSettings_Click(object sender, EventArgs e)
        {
            base.menuSettings_Click(sender, e);
            SetUpdateInterval(settings.updateInterval);
        }
    }
}
