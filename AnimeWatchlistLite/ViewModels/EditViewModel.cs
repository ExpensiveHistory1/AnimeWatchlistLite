using AnimeWatchlistLite.Helper;
using AnimeWatchlistLite.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AnimeWatchlistLite.ViewModels
{
    public class EditViewModel : BaseViewModel 
    {
        private MySettings _Settings;
        private int _WatchedBorder;
        private int _UnwatchedBorder;
        private int _InProgressBorder;
        private int _WaitingBorder;
        public Anime _anime { get; set; }
        public bool ClosingPossible { get; set; }
        public EditViewModel(Anime anime)
        {
            _anime = new Anime();
            _anime.ID = anime.ID;
            _anime.Titel = anime.Titel;
            _anime.Status = anime.Status;
            _anime.Status_Image = anime.Status_Image;
            _anime.Bild = anime.Bild;
            _anime.BildSource = anime.BildSource;
            ClosingPossible = false;
            SetStatusColors();
            Settings = new MySettings();
        }
        public ICommand selStatus { get { return new RelayCommand(this.SelectStatus, e => true); } }
        public ICommand saveChanges { get { return new RelayCommand(this.SaveChange, e => true); } }
        public ICommand UploadPic { get { return new RelayCommand(this.UploadPicture, e => true); } }
        public ICommand RemoveAnime { get { return new RelayCommand(this.Remove_Anime, e => true); } }
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
        public int WatchedBorder
        {
            get
            {
                return _WatchedBorder;
            }
            set
            {
                _WatchedBorder = value;
                OnPropertyChanged("WatchedBorder");
            }
        }
        public int UnwatchedBorder
        {
            get
            {
                return _UnwatchedBorder;
            }
            set
            {
                _UnwatchedBorder = value;
                OnPropertyChanged("UnwatchedBorder");
            }
        }
        public int InProgressBorder
        {
            get
            {
                return _InProgressBorder;
            }
            set
            {
                _InProgressBorder = value;
                OnPropertyChanged("InProgressBorder");
            }
        }
        public int WaitingBorder
        {
            get
            {
                return _WaitingBorder;
            }
            set
            {
                _WaitingBorder = value;
                OnPropertyChanged("WaitingBorder");
            }
        }
        private Image resizeImage(string ImagePath)
        {
            Image imagefrompath = Image.FromFile(ImagePath);
            return (Image)(new Bitmap(imagefrompath, new System.Drawing.Size(130, 140)));
        }
        private void Remove_Anime(object obj)
        {
            Window editWindow = (Window)obj;
            try
            {
                SqliteDataAccess.DeleteAnime(_anime.ID);
                editWindow.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UploadPicture(object obj)
        {
            try
            {
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (openfiledialog.ShowDialog() == true)
                {
                    string picturepath = openfiledialog.FileName;
                    string picturename = openfiledialog.SafeFileName;
                    string destinationpath = Directory.GetCurrentDirectory() + $"\\Bilder\\{picturename}";
                    if (!File.Exists(destinationpath))
                    {
                        Image resizedImage = resizeImage(picturepath);
                        resizedImage.Save(destinationpath);
                    }
                    _anime.Bild = picturename;
                    _anime.BildSource = new BitmapImage(new Uri(picturepath));
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        private void SaveChange(object obj)
        {
            Window editWindow = (Window)obj;
            try
            {
                SqliteDataAccess.UpdateAnime(_anime);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            ClosingPossible = true;
            editWindow.Close();
        }
        private void SelectStatus(object obj)
        {
            string status = (string)obj;
            _anime.Status = status;
            SetStatusColors();
        }
        private void SetStatusColors()
        {
            string status = _anime.Status;

            switch (status)
            {
                case "Watched":
                    WatchedBorder = 3;
                    UnwatchedBorder = 1;
                    InProgressBorder = 1;
                    WaitingBorder = 1;
                    break;

                case "Unwatched":
                    WatchedBorder = 1;
                    UnwatchedBorder = 3;
                    InProgressBorder = 1;
                    WaitingBorder = 1;
                    break;

                case "InProgress":
                    WatchedBorder = 1;
                    UnwatchedBorder = 1;
                    InProgressBorder = 3;
                    WaitingBorder = 1;
                    break;

                case "Waiting":
                    WatchedBorder = 1;
                    UnwatchedBorder = 1;
                    InProgressBorder = 1;
                    WaitingBorder = 3;
                    break;
            }
        }
    }
}
