using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace LeagueLocaleEditor.UI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string ConfigLocation;
        private System.Windows.Input.ICommand runLeagueCommand;
        public System.Windows.Input.ICommand RunLeagueCommand => runLeagueCommand ?? (runLeagueCommand = new Command(RunLeague));

        public List<Tuple<string, Enums.LocaleNames.Language>> languages;
        public List<Tuple<string, Enums.LocaleNames.Language>> Languages => languages ?? (languages = Enums.LocaleNames.GetAllDisplayNames());

        private Enums.LocaleNames.Code localeCode = Enums.LocaleNames.Code.invalidCode;
        public Enums.LocaleNames.Code LocaleCode
        {
            get { return localeCode; }
            set 
            {
                localeCode = value;
                OnPropertyChanged(nameof(LocaleCode));
            }
        }

        private Enums.LocaleNames.Language selectedLanguage = Enums.LocaleNames.Language.invalidCode;
        public Enums.LocaleNames.Language SelectedLanguage 
        {
            get { return selectedLanguage; }
            set
            {
                selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        } 

        private bool foundFile = false;
        public bool FoundFile {
            get { return foundFile; }
            set
            {
                foundFile = value;
                OnPropertyChanged(nameof(FoundFile));
            }
        }

        public MainWindowViewModel()
        {
            BackgroundWorker FileLocationBackgroundWorker = new BackgroundWorker();
            FileLocationBackgroundWorker.DoWork += FileLocationBackgroundWorker_DoWork;
            FileLocationBackgroundWorker.RunWorkerCompleted += FileLocationBackgroundWorker_RunWorkerCompleted;
            FileLocationBackgroundWorker.RunWorkerAsync();
        }

        private void FileLocationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConfigLocation = Import.ClientSettingsHelpers.GetFileLocation();
            LocaleCode = Import.ClientSettingsHelpers.GetLocaleName(ConfigLocation);
        }

        private void FileLocationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Removes the progress bar
            FoundFile = true;
            SelectedLanguage = (Enums.LocaleNames.Language)LocaleCode;
        }

        private void RunLeague()
        {
            string executableLocation = ConfigLocation.Replace("\\Config", string.Empty);
            executableLocation += "\\LeagueClient.exe";
            if (System.IO.File.Exists(executableLocation))
                System.Diagnostics.Process.Start(executableLocation);
        }

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!= null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
