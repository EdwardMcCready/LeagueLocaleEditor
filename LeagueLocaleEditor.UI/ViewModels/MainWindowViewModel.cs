using System;
using System.Collections.Generic;
using System.Text;


namespace LeagueLocaleEditor.UI.ViewModels
{
    public class MainWindowViewModel
    {
        private System.Windows.Input.ICommand runLeagueCommand;
        public System.Windows.Input.ICommand RunLeagueCommand => runLeagueCommand ?? (runLeagueCommand = new Command(RunLeague));
        
        public LeagueLocaleEditor.Enums.LocaleNames.Code LocaleCode { get; set; } = Import.ClientSettingsSeralization.GetLocaleName(string.Empty);
        
        public List<Tuple<string, LeagueLocaleEditor.Enums.LocaleNames.Language>> languages;
        public List<Tuple<string, Enums.LocaleNames.Language>> Languages => languages ?? (languages = LeagueLocaleEditor.Enums.LocaleNames.GetAllDisplayNames());

        public MainWindowViewModel()
        {

        }

        private void RunLeague()
        {
        }
    }
}
