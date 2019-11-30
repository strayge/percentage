using System;
using System.Diagnostics;
using System.Drawing;
using TrayIconLibrary;

namespace IconLibrary
{
    public class Utils
    {
        public static String ColorToString(Color c)
        {
            return "#" + c.A.ToString("X2") + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static Color ColorFromString(string str)
        {
            var mediaColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(str);
            Color result = Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
            return result;
        }

        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long UtcNowMilliseconds()
        {
            return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
        }

        public static void StartProgram(string path, string args = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.FileName = path;
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = args;
            Process exeProcess = Process.Start(startInfo);
        }

        public static int CpuFreqMhz(int numIterations = 10000)
        {
            // https://stackoverflow.com/a/31889271
            // returns wrong results under debugger
            // for max accuracy numIterations = int.MaxValue
            long frequency, start, stop;
            double multiplier = 1000 * 1000 * 1000;//nano
            if (WinApi.QueryPerformanceFrequency(out frequency) == false)
                return -1;

            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            const int known_instructions_per_loop = 1;

            // decreased num of iteration to decrease calculation time with less accuracy
            int iterations = numIterations;
            int g = 0;

            WinApi.QueryPerformanceCounter(out start);
            for (int i = 0; i < iterations; i++)
            {
                g++;
                g++;
                g++;
                g++;
            }
            WinApi.QueryPerformanceCounter(out stop);

            //normal ticks differs from the WMI data, i.e 3125, when WMI 3201, and CPUZ 3199
            var normal_ticks_per_second = frequency * 1000;
            var ticks = (double)(stop - start);
            var time = (ticks * multiplier) / frequency;
            var loops_per_sec = iterations / (time / multiplier);
            var instructions_per_loop = normal_ticks_per_second / loops_per_sec;

            var ratio = (instructions_per_loop / known_instructions_per_loop);
            var actual_freq = normal_ticks_per_second / ratio;

            if (actual_freq < 0)
            {
                return -1;
            }
            Console.WriteLine((int)(actual_freq / 1000000));

            return (int)(actual_freq / 1000000);
        }
    }
}
