using System.Reflection;
using System.Drawing;
using TrayIconLibrary;

namespace NetIcon
{
    class CustomSettings : Settings<CustomSettings>
    {
        public CustomSettings()
        {
            this.section = "network";
        }

        public Color foregroundColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#FF00FF00"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public Color backgroundColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#00000000"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public Color borderColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#9900FF00"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public int maxBandwithBitPerSecond
        {
            get { return GetValueByMethod(MethodBase.GetCurrentMethod(), 10 * 1024 * 1024); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public int updateInterval
        {
            get { return GetValueByMethod(MethodBase.GetCurrentMethod(), 1000); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

    }
}
