using AnimeWatchlistLite.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWatchlistLite.Helper
{
    public class SqliteDataAccess
    {
        public static List<Anime> LoadAnimes()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Anime>("SELECT * FROM animes", new DynamicParameters());
                return output.ToList();
            }
  
        }
        public static List<Anime> GetMatchAnimes(string titel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var test = $"SELECT * FROM animes WHERE Titel LIKE '{titel}'";
                var output = cnn.Query<Anime>($"SELECT * FROM animes WHERE Titel LIKE '%{titel}%'");
                return output.ToList();
            }
        }
        public static Anime GetHighestRankNumber()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
               var output = cnn.Query<Anime>("SELECT * FROM animes ORDER BY `Reihenfolge` DESC").ToList();
                if (output.Count > 0)
                    return output.ToList()[0];
                return new Anime();
            }
        }
        public static List<Anime> GetAnimesSortedByAlphabet()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Anime>("SELECT * FROM animes ORDER BY Titel ASC;");
                return output.ToList();
            }
        }
        public static List<Anime> GetAnimesByStatus(string status)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Anime>($"SELECT * FROM animes WHERE Status= '{status}'");
                return output.ToList();
            }
        }
        public static void InsertAnime(Anime anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO animes (Titel, Status, Bild, Reihenfolge) VALUES (@Titel, @Status, @Bild, @Reihenfolge);", anime);
            }
        }
        public static void UpdateAnime(Anime anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE animes SET Titel=@Titel, Status=@Status, Bild=@Bild WHERE ID=@ID", anime);
            }
        }
        public static void DeleteAnime(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"DELETE FROM animes WHERE ID={id}");
            }
        }
        public static void UpdateRankNumberOnDB(int animeid, int newreihenfolge)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE animes SET Reihenfolge= '{newreihenfolge}' WHERE ID = '{animeid}'");
            }
        }
        private static string LoadConnectionString(string id = "default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
