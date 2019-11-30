using System.IO;
using System.Text;
using TrayIconLibrary;

namespace IconLibrary
{
    class IniFile
    {
        string Path;

        public IniFile(string IniPath)
        {
            Path = new FileInfo(IniPath).FullName.ToString();
        }

        public string ReadString(string Section, string Key)
        {
            var RetVal = new StringBuilder(255);
            WinApi.GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void WriteString(string Section, string Key, string Value)
        {
            WinApi.WritePrivateProfileString(Section, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            WriteString(Section, Key, null);
        }

        public void DeleteSection(string Section = null)
        {
            WriteString(Section, null, null);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return ReadString(Section, Key).Length > 0;
        }
    }
}
