using System.IO;
using System.Text;

namespace TrayIconLibrary
{
    abstract class AbstractStorage
    {
        public abstract string ReadString(string Section, string Key);
        public abstract void WriteString(string Section, string Key, string Value);
    }

    class IniFile: AbstractStorage
    {
        string Path;

        public IniFile(string IniPath)
        {
            Path = new FileInfo(IniPath).FullName.ToString();
        }

        public override string ReadString(string Section, string Key)
        {
            var RetVal = new StringBuilder(255);
            WinApi.GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public override void WriteString(string Section, string Key, string Value)
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
