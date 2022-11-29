using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueLocalEditor.ViewModels
{
    public class MainWindowViewModel
    {
        private System.Windows.Input.ICommand runLeagueCommand;
        public System.Windows.Input.ICommand RunLeagueCommand => runLeagueCommand ??= new Command(RunLeague);


        private void RunLeague()
        {
        }
    }
}
