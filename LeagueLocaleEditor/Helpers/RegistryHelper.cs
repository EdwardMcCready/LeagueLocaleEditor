using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueLocaleEditor.Helpers
{
    public static class RegistryHelper
    {
        private const string SoftwareKeyName = "SOFTWARE";
        private const string AppKeyName = "LeagueLocaleEditor";
        private const string RegistryName = "ClientSettingsPath";
        // not const as it can't be done at compile time
        private const string FullRegistrypath = SoftwareKeyName + "\\" + AppKeyName;


        public static void CreateRegistryKey(string filePath)
        {
            var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(SoftwareKeyName, true);
            key = key.CreateSubKey(AppKeyName);

            key.SetValue(RegistryName, filePath);
        }

        public static string ReadRegistryKey()
        {
            var registryValue = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(FullRegistrypath)?.GetValue(RegistryName);

            return registryValue as string ?? string.Empty;
        }
    }
}
