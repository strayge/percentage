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

namespace RamIcon
{
    class CustomTrayIcon: TrayIcon
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYSTATUSEX
        {
            public int dwLength;
            public int dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool GlobalMemoryStatusEx([In, Out] ref MEMORYSTATUSEX lpBuffer);

        private CustomSettings settings;
        List<float> measurents = new List<float>();

        public CustomTrayIcon()
        {
            settings = CustomSettings.Instance;

            SetUpdateInterval(settings.updateInterval);
            EnableIcon();
        }

        public override void menuSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
            // immediatly see changes (works only on current icon)
            UpdateIcon(null, null);
        }

        public bool GetRamLoad(out float load, out float available, out float total)
        {
            MEMORYSTATUSEX memoryStatus = new MEMORYSTATUSEX();
            memoryStatus.dwLength = (int)Marshal.SizeOf(typeof(MEMORYSTATUSEX));

            if (GlobalMemoryStatusEx(ref memoryStatus))
            {
                load = memoryStatus.dwMemoryLoad;
                available = memoryStatus.ullAvailPhys;
                total = memoryStatus.ullTotalPhys;
                //return memoryStatus.dwMemoryLoad;
                return true;
            }
            load = available = total = 0;
            return false;
        }

        public override void UpdateIcon(object sender, EventArgs e)
        {
            Color foregroundColor = settings.foregroundColor;
            Color backgroundColor = settings.backgroundColor;
            Color borderColor = settings.borderColor;

            int pointWidth = GetWidthOfPoint();

            int iconSize = GetSmallIconSize();
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
                }
            }
        }
    }
}
