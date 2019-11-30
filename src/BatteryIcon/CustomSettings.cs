using System.Reflection;
using System.Drawing;
using IconLibrary;

namespace BatteryIcon
{
    class CustomSettings : Settings<CustomSettings>
    {
        public CustomSettings()
        {
            this.section = "battery";
        }

        public Color foregroundColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#FFFFFFFF"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public Color foregroundChargingColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#FF00FF00"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public Color backgroundColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#B0525252"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public Color borderColor
        {
            get { return GetValueByMethod_Color(MethodBase.GetCurrentMethod(), "#59FFFFFF"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public string fontName
        {
            get { return GetValueByMethod(MethodBase.GetCurrentMethod(), "Microsoft Sans Serif"); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public int fontSize
        {
            get { return GetValueByMethod(MethodBase.GetCurrentMethod(), 14); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public int scaling
        {
            get { return GetValueByMethod(MethodBase.GetCurrentMethod(), 1); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

        public int updateInterval
        {
            get { return GetValueByMethod(MethodBase.GetCurrentMethod(), 1000); }
            set { SetValueByMethod(MethodBase.GetCurrentMethod(), value); }
        }

    }
}
