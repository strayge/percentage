using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using TrayIconLibrary;
using System.Management;

namespace CpuIcon
{
    class CustomTrayIcon: TrayIcon
    {
        private CustomSettings settings;
        PerformanceCounter cpuCounter;
        List<Tuple<float, bool>> measurents = new List<Tuple<float, bool>>();

        public CustomTrayIcon()
        {
            settings = CustomSettings.Instance;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

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

        public float GetCpuUsage()
        {
            return cpuCounter.NextValue();
        }

        public override void UpdateIconTick(object sender = null, EventArgs e = null)
        {
            Color foregroundColor = settings.foregroundColor;
            Color foregroundThrottliingColor = settings.foregroundThrottlingColor;
            Color backgroundColor = settings.backgroundColor;
            Color borderColor = settings.borderColor;

            int pointWidth = WidthSingleMeasurement();

            float newValue = GetCpuUsage();
            int freq = Utils.CpuFreqMhz();

            bool isThrottling = false;
            if ((freq < 800) && (newValue > 40))
            {
                isThrottling = true;
            }

            int iconSize = GetTrayIconsSize();
            using (Bitmap bitmap = new Bitmap(iconSize, iconSize))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColor);

                    
                    measurents.Add(Tuple.Create(newValue, isThrottling));
                    if (measurents.Count > (bitmap.Width / pointWidth))
                    {
                        measurents.RemoveAt(0);
                    }

                    for (int i = measurents.Count - 1; i >= 0; i--)
                    {
                        float value = measurents[i].Item1;
                        bool wasThrottling = measurents[i].Item2;
                        var pos = bitmap.Width - (measurents.Count - 1 - i) * pointWidth;

                        Color color = foregroundColor;
                        if (wasThrottling)
                        {
                            color = foregroundThrottliingColor;
                        }
                        graphics.DrawLine(new Pen(color, pointWidth), pos, bitmap.Height, pos, bitmap.Height - bitmap.Height * value / 100);
                    }

                    int borderWidth = 1;
                    graphics.DrawRectangle(new Pen(borderColor, borderWidth), 0, 0, (int)bitmap.Width - borderWidth, (int)bitmap.Height - borderWidth);

                    graphics.Save();
                    string tooltip = String.Format("CPU: {0:F0}%\nAvg: {1:F0}%\n{2} Mhz", newValue, measurents.Average(x => x.Item1), freq);
                    ChangeIcon(bitmap, tooltip);
                }
            }
        }

        public override void IconHovered()
        {
        }

        void CalcAndShowBaloonInBackground()
        {
            string output = "";
            foreach (var item in GetCpuTopProcesses())
            {
                output += String.Format("{0,-30}\t{1:F1}%\n", item.Item1, item.Item2);
            }
            if (output == "")
            {
                output = "No processes with usage > 3%";
            }
            Console.WriteLine(output);
            SetBalloon(output, "CpuIcon");

            ShowBalloon(balloonText, balloonTitle);
        }

        public override void IconMouseDoubleClickAction()
        {
            Task.Run( () => Utils.StartProgram("taskmgr.exe") );
        }

        public override void IconMouseClickAction()
        {
            // Task task = Task.Run((Action)CalcAndShowBaloonInBackground);
        }

        static List<Tuple<string, float>> GetCpuTopProcesses()
        {
            long startTime = Utils.UtcNowMilliseconds();
            List<Tuple<string, float>> list = new List<Tuple<string, float>>();

            int cpuCoresCount = Environment.ProcessorCount;

            // used threshold for significantly increase query time
            int cpuTreshhold = 3 * cpuCoresCount;
            string query = String.Format("SELECT * FROM Win32_PerfFormattedData_PerfProc_Process WHERE PercentProcessorTime > {0}", cpuTreshhold);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", query);

            var queryResult = searcher.Get();
            foreach (ManagementObject queryObj in queryResult)
            {
                //Console.WriteLine("    GetCpuTopProcesses foreach iteration runned for {0} ms from start", Utils.UtcNowMilliseconds() - startTime);
                string name = queryObj["Name"].ToString();
                string processId = queryObj["IDProcess"].ToString();
                name = String.Format("{0} ({1})", name.Split('#')[0], processId);
                float.TryParse(queryObj["PercentProcessorTime"].ToString(), out float percent);
                percent /= cpuCoresCount;

                // skip Idle
                if (processId == "0")
                {
                    continue;
                }

                if (percent != 0)
                {
                    list.Add(Tuple.Create(name, percent));
                }
            }
            list.Sort((x, y) => -1 * x.Item2.CompareTo(y.Item2));
            Console.WriteLine("GetCpuTopProcesses runned for {0} ms", Utils.UtcNowMilliseconds() - startTime);
            return list;
        }

    }
}
