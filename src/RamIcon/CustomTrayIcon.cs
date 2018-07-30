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
using static TrayIconLibrary.WinApi;

namespace RamIcon
{
    class CustomTrayIcon: TrayIcon
    {
        private CustomSettings settings;
        List<float> measurents = new List<float>();

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

        private bool GetRamLoad(out float load, out float available, out float total)
        {
            MEMORYSTATUSEX memoryStatus = new MEMORYSTATUSEX();
            memoryStatus.dwLength = (int)Marshal.SizeOf(typeof(MEMORYSTATUSEX));

            if (GlobalMemoryStatusEx(ref memoryStatus))
            {
                load = memoryStatus.dwMemoryLoad;
                available = memoryStatus.ullAvailPhys;
                total = memoryStatus.ullTotalPhys;
                return true;
            }
            load = available = total = 0;
            return false;
        }

        public override void UpdateIconTick(object sender = null, EventArgs e = null)
        {
            Color foregroundColor = settings.foregroundColor;
            Color backgroundColor = settings.backgroundColor;
            Color borderColor = settings.borderColor;

            int pointWidth = WidthSingleMeasurement();

            int iconSize = GetTrayIconsSize();
            using (Bitmap bitmap = new Bitmap(iconSize, iconSize))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColor);

                    float memLoad, memAvailable, memTotal;
                    GetRamLoad(out memLoad, out memAvailable, out memTotal);
                    measurents.Add(memLoad);
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
                    string tooltip = String.Format("RAM:\n{1:F1} / {2:F1} GB ({0:F0}%)", memLoad, (memTotal - memAvailable) / 1073741824, memTotal / 1073741824);
                    ChangeIcon(bitmap, tooltip);
                    //SetIcon(bitmap);
                }
            }
        }

        public override void IconHovered()
        {
            float memLoad, memAvailable, memTotal;
            GetRamLoad(out memLoad, out memAvailable, out memTotal);

            string tooltip = String.Format("RAM:\n{1:F1} / {2:F1} GB ({0:F0}%)", memLoad, (memTotal - memAvailable) / 1073741824, memTotal / 1073741824);
            SetTooltip(tooltip);
            SetBalloon(TopMemoryConsumpsionProcesses(), "RamIcon");
        }

        private string TopMemoryConsumpsionProcesses()
        {
            Process[] processes = Process.GetProcesses();
            Array.Sort<Process>(processes, (x, y) => x.WorkingSet64.CompareTo(y.WorkingSet64));
            Array.Reverse(processes);
            string output = "";
            foreach (Process process in processes.Take(5))
            {
                if ((process.SessionId == 0) && (process.HandleCount == 0))
                {
                    // skipping system's "Memory Compression", "Registry" and "Idle" processes
                    System.Console.WriteLine("skipped " + process.ProcessName);
                    continue;
                }
                string processLine = String.Format("{0} ({1})", process.ProcessName, process.Id);
                output += String.Format("{0,-25}\t{1:N0} MB\n", processLine, process.WorkingSet64 / 1048576);
            }
            return output;
        }
    }
}
