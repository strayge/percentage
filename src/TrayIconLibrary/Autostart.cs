using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Windows.Forms;

namespace TrayIconLibrary
{
    static class Autostart
    {
        public static void Enable()
        {
            string curent_filename = Application.ExecutablePath;
            string shortcut_name = Path.GetFileNameWithoutExtension(curent_filename);
            WshShell wshShell = new WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut;
            string startup_folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            shortcut = (IWshRuntimeLibrary.IWshShortcut) wshShell.CreateShortcut(startup_folder_path + "\\" + shortcut_name + ".lnk");
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Save();
        }

        public static void Disable()
        {
            string curent_filename = Application.ExecutablePath;
            string startup_folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            DirectoryInfo startup_folder_info = new DirectoryInfo(startup_folder_path);
            FileInfo[] links = startup_folder_info.GetFiles("*.lnk");

            foreach (FileInfo link in links)
            {
                string link_target = GetShortcutTargetFile(link.FullName);

                if (link_target.Equals(curent_filename, StringComparison.InvariantCultureIgnoreCase))
                {
                    System.IO.File.Delete(link.FullName);
                }
            }
        }

        public static bool IsEnabled()
        {
            string curent_filename = Application.ExecutablePath;
            string startup_folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            DirectoryInfo startup_folder_info = new DirectoryInfo(startup_folder_path);
            FileInfo[] links = startup_folder_info.GetFiles("*.lnk");

            foreach (FileInfo link in links)
            {
                string link_target = GetShortcutTargetFile(link.FullName);

                if (link_target.Equals(curent_filename, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = Path.GetFileName(shortcutFilename);

            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return string.Empty;
        }

    }
}