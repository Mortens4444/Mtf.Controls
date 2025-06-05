using Microsoft.Win32;
using Mtf.Controls.Video.ActiveX.Dto;
using Mtf.WmiHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mtf.Controls.Video.ActiveX.Services
{
    public static class SiliconVideoRegistryReader
    {
        private const string VideoServerUsersRegistryPath = "SOFTWARE\\Graffiti\\Video Server\\Users";
        private const string VideoRecorderRegistryPath = "SOFTWARE\\Graffiti\\NonStop Video Recorder";

        public static List<VideoServerUser> GetVideoServerUsersFromRegistry(string ipAddress, string osUsername, string osPassword)
        {
            var usersCount = (uint)Wmi.ReadRemoteRegistry(ipAddress, osUsername, osPassword, RegistryHive.LocalMachine, VideoServerUsersRegistryPath, "NumUsers", RegistryValueKind.DWord);

            var result = new List<VideoServerUser>();
            for (var i = 0; i < usersCount; i++)
            {
                result.Add(new VideoServerUser
                {
                    Id = (string)Wmi.ReadRemoteRegistry(ipAddress, osUsername, osPassword, RegistryHive.LocalMachine, VideoServerUsersRegistryPath, $"ID-{i}"),
                    FullName = (string)Wmi.ReadRemoteRegistry(ipAddress, osUsername, osPassword, RegistryHive.LocalMachine, VideoServerUsersRegistryPath, $"Full Name-{i}"),
                    Username = (string)Wmi.ReadRemoteRegistry(ipAddress, osUsername, osPassword, RegistryHive.LocalMachine, VideoServerUsersRegistryPath, $"Login Name-{i}"),
                    Password = (string)Wmi.ReadRemoteRegistry(ipAddress, osUsername, osPassword, RegistryHive.LocalMachine, VideoServerUsersRegistryPath, $"Password-{i}")
                });
            }
            return result;
        }

        public static string GetVideoServerFolder()
        {
            string result = null;
            try
            {
                using (var programDirectory = Wmi.GetRegistryKey(RegistryHive.LocalMachine, VideoRecorderRegistryPath))
                {
                    result = (string)programDirectory.GetValue("Program Folder");
                    programDirectory.Close();
                }
            }
            catch
            {
                try
                {
                    var basePath = GetProgramFilesX86Folder();
                    var folders = new[] { "Sziltech\\Video Server", "Sziltech\\IPVS27 Video Server",
                        "Sziltech\\IPVS37 Video Server", "Sziltech\\IPVS47 Video Server"};

                    result = folders
                        .Select(folder => Path.Combine(basePath, folder))
                        .FirstOrDefault(Directory.Exists) ?? Path.Combine(basePath, folders.Last());
                }
                catch { }
            }
            return result;
        }

        public static string GetProgramFilesX86Folder()
        {
            var x86Path = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            if (!String.IsNullOrEmpty(x86Path) && Directory.Exists(x86Path))
            {
                return x86Path;
            }

            return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        }
    }
}
