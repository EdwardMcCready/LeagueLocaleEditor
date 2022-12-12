using System;
using System.Collections.Generic;
using System.Text;


namespace LeagueLocalEditor.UI.ViewModels
{
    public class MainWindowViewModel
    {
        private System.Windows.Input.ICommand runLeagueCommand;
        public System.Windows.Input.ICommand RunLeagueCommand => runLeagueCommand ?? (runLeagueCommand = new Command(RunLeague));
        
        public LeagueLocalEditor.Enums.LocaleNames.Code LocaleCode { get; set; } = Import.ClientSettingsSeralization.GetLocaleName(string.Empty);
        
        public List<Tuple<string, LeagueLocalEditor.Enums.LocaleNames.Language>> languages;
        public List<Tuple<string, Enums.LocaleNames.Language>> Languages => languages ?? (languages = LeagueLocalEditor.Enums.LocaleNames.GetAllDisplayNames());

        public MainWindowViewModel()
        {

        }

        private void RunLeague()
        {
        }
    }
}
