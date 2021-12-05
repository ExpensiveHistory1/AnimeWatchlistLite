using AnimeWatchlistLite.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AnimeWatchlistLite.Models
{
    public class Anime : BaseViewModel
    {
        public string Titel { get; set; }

        private int _Reihenfolge;
        public int Reihenfolge { get { return _Reihenfolge; } set { _Reihenfolge = value; OnPropertyChanged("Reihenfolge"); } }

        public int ID { get; set; }

        private string _Bild;
        public string Bild
        {
            get
            {
                return _Bild;
            }
            set
            {
                _Bild = value;
                OnPropertyChanged("Bild");
            }
        }
        private ImageSource _BildSource;
        public ImageSource BildSource
        {
            get
            {
                return _BildSource;
            }
            set
            {
                _BildSource = value;
                OnPropertyChanged("BildSource");
            }
        }
        private BitmapImage _Status_Image;
        public BitmapImage Status_Image
        {
            get
            {
                return _Status_Image;
            }
            set
            {
                _Status_Image = value;
                OnPropertyChanged("Status_Image");
            }
        }

        private string _Status;
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                switch (_Status)
                {
                    case "Unwatched":
                        Status_Image = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Status\\Unwatched.png"));
                        break;

                    case "Watched":
                        Status_Image = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Status\\Watched.png"));
                        break;

                    case "InProgress":
                        Status_Image = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Status\\InProgress.png"));
                        break;

                    case "Waiting":
                        Status_Image = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Status\\Waiting.png"));
                        break;
                }
                OnPropertyChanged("Status");
            }
        }
    }
}
