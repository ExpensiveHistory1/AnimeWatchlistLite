using AnimeWatchlistLite.Helper;
using AnimeWatchlistLite.Models;
using AnimeWatchlistLite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimeWatchlistLite
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mvm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mvm;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            Anime anime = (Anime)image.DataContext;
            DataObject dataobj = new DataObject(anime);
            DragDrop.DoDragDrop(image, dataobj, DragDropEffects.Move);
        }

        private async void Image_Drop(object sender, DragEventArgs e)
        {
            Anime DraggedAnime = (Anime)e.Data.GetData(typeof(Anime));
            Anime DroppedAtAnime = (Anime)((Image)sender).DataContext;
            if (DraggedAnime.ID != DroppedAtAnime.ID)
            {
                int indexdragged = mvm.AnimeCollection.IndexOf(DraggedAnime);
                int indexdroppedat = mvm.AnimeCollection.IndexOf(DroppedAtAnime);
                int zwischenspeicher = DraggedAnime.Reihenfolge;
                await Task.Run(() => updateReihenfolgeOnDB(DraggedAnime.ID, DroppedAtAnime.Reihenfolge));
                await Task.Run(() => updateReihenfolgeOnDB(DroppedAtAnime.ID, zwischenspeicher));
                mvm.LoadDBAnime();
            }
        }
        private void updateReihenfolgeOnDB(int animeid, int newreihenfolge)
        {
            try
            {
                SqliteDataAccess.UpdateRankNumberOnDB(animeid, newreihenfolge);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
