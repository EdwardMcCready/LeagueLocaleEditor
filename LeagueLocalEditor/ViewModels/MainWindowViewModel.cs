using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueLocalEditor.ViewModels
{
    public class MainWindowViewModel
    {
        private System.Windows.Input.ICommand runLeagueCommand;
        public System.Windows.Input.ICommand RunLeagueCommand => runLeagueCommand ?? (runLeagueCommand = new Command(RunLeague));
        
        public Enums.LocaleNames.Code LocaleCode { get; set; } = Import.ClientSettingsHelper.GetLocalName();
        
        public List<Tuple<string, Enums.LocaleNames.Language>> languages;
        public List<Tuple<string, Enums.LocaleNames.Language>> Languages => languages ?? (languages = Enums.LocaleNames.GetAllDisplayNames());

        public MainWindowViewModel()
        {

        }

        private void RunLeague()
        {
        }
    }
}
