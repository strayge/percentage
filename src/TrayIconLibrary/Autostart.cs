using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TrayIconLibrary
{
    static class Autostart
    {
        public static void Enable()
        {
            string curent_filename = Application.ExecutablePath;
            string shortcut_name = Path.GetFileNameWithoutExtension(curent_filename);
            string startup_folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string lnk_fullpath = startup_folder_path + "\\" + shortcut_name + ".lnk";
            string workdir = Application.StartupPath;

            if (workdir.Contains("\\WindowsApps\\"))
            {
                var uwp_path = Path.GetDirectoryName(workdir);
                var packageFullName = Path.GetFileName(uwp_path);
                var packageFullNameParts = packageFullName.Split('_');
                var packageName = packageFullNameParts[0];
                var packageId = packageFullNameParts[packageFullNameParts.Length - 1];
                var packageFamilyName = packageName + "_" + packageId;
                var target = packageFamilyName + "!App";

                var lnk = BuildUwpShortcut(
                    packageFamilyName,
                    target,
                    uwp_path,
                    "Images\\Square44x44Logo.png"
                );
                System.IO.File.WriteAllBytes(lnk_fullpath, lnk);
            }
            else
            {
                WshShell wshShell = new WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut;
                shortcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(lnk_fullpath);
                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = workdir;
                shortcut.Save();
            }
        }

        public static void Disable()
        {
            string curent_filename = Application.ExecutablePath;
            string startup_folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            DirectoryInfo startup_folder_info = new DirectoryInfo(startup_folder_path);
            FileInfo[] links = startup_folder_info.GetFiles("*.lnk");

            string shortcut_name = Path.GetFileNameWithoutExtension(curent_filename);

            foreach (FileInfo link in links)
            {
                if (link.Name == shortcut_name + ".lnk")
                {
                    System.IO.File.Delete(link.FullName);
                    continue;
                }

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

            string shortcut_name = Path.GetFileNameWithoutExtension(curent_filename);

            foreach (FileInfo link in links)
            {
                if (link.Name == shortcut_name + ".lnk")
                {
                    return true;
                }

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

        private static byte[] ConcatArrays(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        private static byte[] SubBlockForUwpShortcut(byte block_type, string value)
        {
            var block_type_bytes = new byte[] { block_type };
            var result = ConcatArrays(block_type_bytes, BitConverter.GetBytes((UInt32)0));
            result = ConcatArrays(result, BitConverter.GetBytes((UInt32)0x1f));
            result = ConcatArrays(result, BitConverter.GetBytes((UInt32)(value.Length + 1)));
            result = ConcatArrays(result, Encoding.Unicode.GetBytes(value));
            result = ConcatArrays(result, BitConverter.GetBytes((UInt16)0));
            if (value.Length % 2 == 0)  // padding
            {
                result = ConcatArrays(result, BitConverter.GetBytes((UInt16)0));
            }
            result = ConcatArrays(BitConverter.GetBytes((UInt32)(result.Length + 4)), result);
            return result;
        }

        private static byte[] BuildUwpShortcut(string package_family_name, string target, string location, string icon)
        {
            var main1_header = new byte[] {
                0x31, 0x53, 0x50, 0x53, 0x55, 0x28, 0x4C, 0x9F, 0x79, 0x9F, 0x39, 0x4B, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3 
            };
            var main1_sub1 = SubBlockForUwpShortcut(0x11, package_family_name);
            var main1_sub2 = new byte[] { 0x11, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x00, 0x13, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00 };
            var main1_sub3 = SubBlockForUwpShortcut(0x05, target);
            var main1_sub4 = SubBlockForUwpShortcut(0x0f, location);
            var main1_footer = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            var main1 = ConcatArrays(main1_header, main1_sub1);
            main1 = ConcatArrays(main1, main1_sub2);
            main1 = ConcatArrays(main1, main1_sub3);
            main1 = ConcatArrays(main1, main1_sub4);
            main1 = ConcatArrays(main1, main1_footer);
            main1 = ConcatArrays(BitConverter.GetBytes((UInt32)(main1.Length + 4)), main1);

            var main2_header = new byte[] 
            { 
                0x31, 0x53, 0x50, 0x53, 0x4D, 0x0B, 0xD4, 0x86, 0x69, 0x90, 0x3C, 0x44, 0x81, 0x9A, 0x2A, 0x54, 0x09, 0x0D, 0xCC, 0xEC
            };
            var main2_sub = SubBlockForUwpShortcut(0x02, icon);
            var main2_footer = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            var main2 = ConcatArrays(main2_header, main2_sub);
            main2 = ConcatArrays(main2, main2_footer);
            main2 = ConcatArrays(BitConverter.GetBytes((UInt32)(main2.Length + 4)), main2);


            var idlist2_header1 = new byte[] { 0x00, 0x00 };
            var idlist2_header2 = new byte[] { 0x41, 0x50, 0x50, 0x53 };
            var idlist2_header3 = new byte[] { 0x08, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var idlist2_blocks_size = main1.Length + main2.Length + 4;
            var idlist2_other_size = idlist2_blocks_size + idlist2_header3.Length + idlist2_header2.Length + 2 + 2;
            var idlist2_footer = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            var idlist2 = ConcatArrays(idlist2_header1, BitConverter.GetBytes((UInt16)idlist2_other_size));
            idlist2 = ConcatArrays(idlist2, idlist2_header2);
            idlist2 = ConcatArrays(idlist2, BitConverter.GetBytes((UInt16)idlist2_blocks_size));
            idlist2 = ConcatArrays(idlist2, idlist2_header3);
            idlist2 = ConcatArrays(idlist2, main1);
            idlist2 = ConcatArrays(idlist2, main2);
            idlist2 = ConcatArrays(idlist2, idlist2_footer);
            idlist2 = ConcatArrays(BitConverter.GetBytes((UInt16)(idlist2.Length + 2)), idlist2);

            var idlist1 = new byte[]
            {
                0x14, 0x00, 0x1F, 0x50, 0x9B, 0xD4, 0x34, 0x42, 0x45, 0x02, 0xF3, 0x4D, 0xB7, 0x80, 0x38, 0x93, 0x94, 0x34, 0x56, 0xE1,
            };
            var idlist_end = new byte[] { 0x00, 0x00 };
            var idlist = ConcatArrays(idlist1, idlist2);
            idlist = ConcatArrays(idlist, idlist_end);
            idlist = ConcatArrays(BitConverter.GetBytes((UInt16)idlist.Length), idlist);

            var header = new byte[]
            {
                0x4C, 0x00, 0x00, 0x00, 0x01, 0x14, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x46, 0x81, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            };
            var idlist_extra_data = new byte[] { 0x00, 0x00, 0x00, 0x00 };

            var lnk = ConcatArrays(header, idlist);
            lnk = ConcatArrays(lnk, idlist_extra_data);
            return lnk;
        }

    }
}