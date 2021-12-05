using AnimeWatchlistLite.Helper;
using AnimeWatchlistLite.Models;
using AnimeWatchlistLite.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AnimeWatchlistLite.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _AnimeTitel;
        private string _Search;
        private MySettings _Settings;
        private ObservableCollection<Anime> _AnimeCollection;
        public MainViewModel()
        {
            try
            {
                AnimeCollection = new ObservableCollection<Anime>();
                Settings = new MySettings();
                LoadDBAnime();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ICommand AddToDBCommand { get { return new RelayCommand(this.AddToDatabase, e => true); } }
        public ICommand SearchDbCommand { get { return new RelayCommand(this.SearchMatches, e => true); } }
        public ICommand PicClickCommand { get { return new RelayCommand(this.Picture_Click, e => true); } }
        public ICommand SortAnimesCommand { get { return new RelayCommand(this.sortAnimes, e => true); } }
        public ICommand SortByAlphabetCommand { get { return new RelayCommand(this.SortByAlphabet, e => true); } }
        public ICommand OpenSettingsCommand { get { return new RelayCommand(this.OpenSettingsWindow, e => true); } }

        public ObservableCollection<Anime> AnimeCollection
        {
            get { return _AnimeCollection; }
            set
            {
                _AnimeCollection = value;
                OnPropertyChanged();
            }
        }
        public MySettings Settings
        {
            get
            {
                return _Settings;
            }
            set
            {
                _Settings = value;
                OnPropertyChanged();
            }
        }
        public string AnimeTitel
        {
            get
            {
                return _AnimeTitel;
            }
            set
            {
                _AnimeTitel = value;
                OnPropertyChanged("AnimeTitel");
            }
        }
        public string Search
        {
            get
            {
                return _Search;
            }
            set
            {
                _Search = value;
                OnPropertyChanged();
            }
        }
        private void OpenSettingsWindow(object obj)
        {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.Owner = App.Current.MainWindow;
            configWindow.ShowDialog();
            Settings = new MySettings();
        }
        private void SearchMatches(object obj)
        {
            if (Search == "" || Search == null)
                LoadDBAnime();
            else
            {
                try
                {
                    AnimeCollection.Clear();
                    foreach (Anime anime in SqliteDataAccess.GetMatchAnimes(Search))
                    {
                        anime.BildSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Bilder\\" + anime.Bild));
                        AnimeCollection.Add(anime);
                    }
                    AnimeCollection = new ObservableCollection<Anime>(AnimeCollection.OrderBy(a => a.Reihenfolge));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void sortAnimes(object obj)
        {
            if (AnimeCollection.Count > 0)
                AnimeCollection.Clear();
            string state = (string)obj;
            if (state != "Alle")
            {
                try
                {
                    foreach (Anime anime in SqliteDataAccess.GetAnimesByStatus(state))
                    {
                        anime.BildSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Bilder\\" + anime.Bild));
                        AnimeCollection.Add(anime);
                    }
                    AnimeCollection = new ObservableCollection<Anime>(AnimeCollection.OrderBy(a => a.Reihenfolge));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                LoadDBAnime();
            }
        }
        private void SortByAlphabet(object obj)
        {
            if (AnimeCollection.Count > 0)
                AnimeCollection.Clear();
            try
            {
                foreach (Anime anime in SqliteDataAccess.GetAnimesSortedByAlphabet())
                {
                    anime.BildSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Bilder\\" + anime.Bild));
                    AnimeCollection.Add(anime);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Picture_Click(object obj)
        {
            Anime selectedAnime = (Anime)obj;
            EditWindow editWindow = new EditWindow(selectedAnime);
            editWindow.ShowDialog();
            LoadDBAnime();
        }
        private void AddToDatabase(object obj)
        {
            Anime anime = new Anime()
            {
                Status = "Unwatched",
                Titel = $"{AnimeTitel}",
                Bild = "NoPicture.png",
                Reihenfolge = SqliteDataAccess.GetHighestRankNumber().Reihenfolge + 1
            };
            SqliteDataAccess.InsertAnime(anime);
            AnimeTitel = "";
            LoadDBAnime();
        }
        public void LoadDBAnime()
        {
            if (AnimeCollection.Count > 0)
                AnimeCollection.Clear();
            try
            {
                foreach (Anime anime in SqliteDataAccess.LoadAnimes())
                {
                    anime.BildSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Bilder\\" + anime.Bild));
                    AnimeCollection.Add(anime); 
                }
                AnimeCollection = new ObservableCollection<Anime>(AnimeCollection.OrderBy(a => a.Reihenfolge));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
