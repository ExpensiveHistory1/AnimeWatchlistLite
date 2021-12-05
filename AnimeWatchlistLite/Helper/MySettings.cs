using AnimeWatchlistLite.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimeWatchlistLite.Helper
{
    public class MySettings : BaseViewModel
    {
        public MySettings()
        {
           if (ConfigurationManager.AppSettings["IsDarkMode"] == "True")
                this.DarkMode = true;
            else
                this.DarkMode = false;
        }

        private bool _DarkMode;
        public bool DarkMode
        {
            get
            {
                return _DarkMode;
            }
            set
            {
                _DarkMode = value;
                OnPropertyChanged("DarkMode");
            }
        }

    }
}
