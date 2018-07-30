using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using IconLibrary;

namespace NetIcon
{
    class CustomTrayIcon: TrayIcon
    {
        private CustomSettings settings;
        List<float> measurementsPercents = new List<float>();
        List<PerformanceCounter> counters = new List<PerformanceCounter>();

        public CustomTrayIcon()
        {
            settings = CustomSettings.Instance;

            UpdateNICList();

            // periodical check for new network interfaces
            Timer checkNICTimer = new Timer();
            checkNICTimer.Interval = 60 * 1000;
            checkNICTimer.Tick += CheckNICList;
            checkNICTimer.Start();

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

        public override void IconMouseDoubleClickAction()
        {
            Task.Run(() => Utils.StartProgram("perfmon.exe", "/res"));
        }

        private void CheckNICList(object sender, EventArgs e)
        {
            PerformanceCounterCategory pcg = new PerformanceCounterCategory("Network Adapter");
            if (counters.Count != pcg.GetInstanceNames().Length)
            {
                UpdateNICList();
            }
        }

        private void UpdateNICList()
        {
            counters.Clear();
            PerformanceCounterCategory pcg = new PerformanceCounterCategory("Network Adapter");
            foreach (var networkInterface in pcg.GetInstanceNames())
            {
                var counter = new PerformanceCounter("Network Adapter", "Bytes Total/sec", networkInterface);
                counters.Add(counter);
            }
        }

        public float GetNetworkLoad()
        {
            float totalBytes = 0;
            foreach (var counter in counters)
            {
                try
                {
                    totalBytes += counter.NextValue();
                }
                catch (System.InvalidOperationException)
                {
                    // ignore disappeared network interfaces
                }

            }
            return totalBytes;
        }

        public override void UpdateIconTick(object sender = null, EventArgs e = null)
        {
            Color foregroundColor = settings.foregroundColor;
            Color backgroundColor = settings.backgroundColor;
            Color borderColor = settings.borderColor;

            int pointWidth = WidthSingleMeasurement();
            int bandwidthMaxMbit = settings.maxBandwithBitPerSecond / 1024 / 1024;

            int iconSize = GetTrayIconsSize();
            using (Bitmap bitmap = new Bitmap(iconSize, iconSize))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColor);

                    float newValueMbit = GetNetworkLoad() * 8 / 1024 / 1024;
                    measurementsPercents.Add(100 * newValueMbit / bandwidthMaxMbit);
                    if (measurementsPercents.Count > bitmap.Width / pointWidth)
                    {
                        measurementsPercents.RemoveAt(0);
                    }

                    for (int i = measurementsPercents.Count - 1; i >= 0; i--)
                    {
                        float value = measurementsPercents[i];
                        var pos = bitmap.Width - (measurementsPercents.Count - 1 - i) * pointWidth;
                        graphics.DrawLine(new Pen(foregroundColor, pointWidth), pos, bitmap.Height, pos, bitmap.Height - bitmap.Height * value / 100);
                    }

                    int borderWidth = 1;
                    graphics.DrawRectangle(new Pen(borderColor, borderWidth), 0, 0, (int)bitmap.Width - borderWidth, (int)bitmap.Height - borderWidth);

                    graphics.Save();
                    float averageBandwithMbit = measurementsPercents.Average() * bandwidthMaxMbit / 100;
                    int averageTime = measurementsPercents.Count * settings.updateInterval / 1000;
                    string tooltip = String.Format("Network\nCurrent: {0:F0} Mbit/s\nAvg ({2}s): {1:F0} Mbit/s", newValueMbit, averageBandwithMbit, averageTime);
                    ChangeIcon(bitmap, tooltip);
                }
            }
        }
    }
}
