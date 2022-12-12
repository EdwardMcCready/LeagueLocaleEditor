using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace LeagueLocaleEditor.UI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private System.Windows.Input.ICommand runLeagueCommand;
        public System.Windows.Input.ICommand RunLeagueCommand => runLeagueCommand ?? (runLeagueCommand = new Command(RunLeague));

        public Enums.LocaleNames.Code LocaleCode { get; private set; } = Enums.LocaleNames.Code.invalidCode;
        
        public List<Tuple<string, Enums.LocaleNames.Language>> languages;
        public List<Tuple<string, Enums.LocaleNames.Language>> Languages => languages ?? (languages = Enums.LocaleNames.GetAllDisplayNames());

        public bool FoundFile { get; private set; } = false;
     

        public MainWindowViewModel()
        {
            BackgroundWorker FileLocationBackgroundWorker = new BackgroundWorker();
            FileLocationBackgroundWorker.DoWork += FileLocationBackgroundWorker_DoWork;
            FileLocationBackgroundWorker.RunWorkerCompleted += FileLocationBackgroundWorker_RunWorkerCompleted;
            FileLocationBackgroundWorker.RunWorkerAsync();
        }

        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FileLocationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var filePath = Import.ClientSettingsHelpers.GetFileLocation();
            LocaleCode = Import.ClientSettingsHelpers.GetLocaleName(filePath);
        }

        private void FileLocationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Removes the progress bar
            FoundFile = true;
            OnPropertyChanged(nameof(FoundFile));
            OnPropertyChanged(nameof(LocaleCode));
        }

        private void RunLeague()
        {

        }

        #region Property Changed

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
