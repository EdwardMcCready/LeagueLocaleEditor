using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueLocalEditor.Import
{
    public static class ImportClientSettings
    {
        public static void GetLocale()
        {
           var files = System.IO.File.ReadLines(@"C:\Riot Games\League of Legends\Config\LeagueClientSettings.yaml");
           
           
        }

    }
}
