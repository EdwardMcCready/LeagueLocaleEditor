using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LeagueLocaleEditor.Import
{
    public static class ClientSettingsHelpers
    {
        // we only care about the locale so we don't bother with seralizing the entire file to an object
        private const string localeHeader = "locale:";

        public static Enums.LocaleNames.Code GetLocaleName(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");
                    var localeLine = DesersalizeClientSettings(filePath);

                    if (!string.IsNullOrWhiteSpace(localeLine))
                    {
                        var locale = localeLine.Substring(localeLine.IndexOf("\""))
                                                .Replace("\"", string.Empty);

                        if (Enum.TryParse<Enums.LocaleNames.Code>(locale, out var language))
                        {
                            return language;
                        }
                    }
                }
                else
                    throw new Exception("File path " + filePath + "does not exist");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return Enums.LocaleNames.Code.invalidCode;
        }

        private static string DesersalizeClientSettings(string filePath)
        {
            // only gets the locale line
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.ToString().Contains(localeHeader))
                    {
                        return line.ToString();
                    }
                }
                return string.Empty;
            }
        }

        public static string GetFileLocation()
        {
            string filePath = string.Empty;

            //var key = string.Empty;
            var key = Helpers.RegistryHelper.ReadRegistryKey();

            if (!string.IsNullOrEmpty(key))
            {
                filePath = key;
            }
            else if (string.IsNullOrWhiteSpace(filePath))
            {
                // Figure out if not given
                filePath = LocateFile();
                Helpers.RegistryHelper.CreateRegistryKey(filePath);
            }

            return filePath;
        }

        private static string LocateFile()
        {
            var enumerationOptions = new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = true
            };

            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    var files = Directory.GetDirectories(drive.RootDirectory.FullName,
                        "League of Legends",
                        enumerationOptions);

                    foreach (var file in files)
                    {
                        var newFile = Directory.GetFiles(file,
                            "LeagueClientSettings.yaml",
                            enumerationOptions);

                        if (newFile.Length > 0)
                        {
                            return newFile[0];
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
