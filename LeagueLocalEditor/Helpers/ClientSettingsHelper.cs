using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueLocalEditor.UI.Import
{
    public static class ClientSettingsHelper
    {
        private const string filePath = @"C:\Riot Games\League of Legends\Config\LeagueClientSettings.yaml";
        private const string localeHeader = "locale:";

        public static Enums.LocaleNames.Code GetLocalName()
        {
            try
            {
                var localeLine = GetLine();

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
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "Getting Current Locale");
            }
            return Enums.LocaleNames.Code.invalidCode;
        }

        private static string GetLine()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
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
    }
}
