using Microsoft.Win32;
using System.Text;

namespace TrayIconLibrary
{
    class RegistryStorage: AbstractStorage
    {
        string Path;
        const string userRoot = "HKEY_CURRENT_USER";
        const string mainRoot = "RegistrySetValueExample";

        public RegistryStorage(string RegistryPath)
        {
            Path = RegistryPath;
        }

        public override string ReadString(string Section, string Key)
        {

            string FullPath = Path + "\\" + Section;
            var result = Registry.GetValue(FullPath, Key, "");
            if (result == null)
            {
                return "";
            }
            return (string)result;
        }

        public override void WriteString(string Section, string Key, string Value)
        {
            string FullPath = Path + "\\" + Section;
            Registry.SetValue(FullPath, Key, Value);
        }
    }
}
