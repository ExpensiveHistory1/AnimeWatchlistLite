using AnimeWatchlistLite.Helper;
using AnimeWatchlistLite.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimeWatchlistLite.ViewModels
{
    public class ConfigViewModel : BaseViewModel
    {
        public ConfigViewModel()
        {
            this.Settings = new MySettings();
        }
        public ICommand SaveChangesCommand { get { return new RelayCommand(this.SaveChanges, e => true); } }

        private MySettings _Settings;
        public MySettings Settings
        {
            get
            {
                return _Settings;
            }
            set
            {
                _Settings = value;
                OnPropertyChanged("Settings");
            }
        }

        private void SaveChanges(object obj)
        {
            ConfigWindow configWindow = (ConfigWindow)obj;
            ConfigurationManager.AppSettings["IsDarkMode"] = Settings.DarkMode.ToString(); 
            configWindow.Close();
        }
    }
}
