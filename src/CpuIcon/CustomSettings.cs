using System.Reflection;
using System.Drawing;
using TrayIconLibrary;

namespace CpuIcon
{
    class CustomSettings : Settings<CustomSettings>
    {
        public CustomSettings()
        {
            this.section = "cpu";
        }

        public Color foregroundColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#FFFFFFFF"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public Color foregroundThrottlingColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#FFFF0000"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public Color backgroundColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#00000000"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public Color borderColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#99FFFFFF"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public int updateInterval
        {
            get { return GetValueByMethod(MethodBase.GetCurrentMethod(), 1000); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

    }
}
