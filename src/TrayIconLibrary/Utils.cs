using System;
using System.Collections.Generic;
using System.Drawing;


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

    }
}
