using SQLite;
using surfnsail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var database = new SQLiteConnection(@"../../../Common/surfnsailSQLite.db3");
            // create the tables
            database.CreateTable<SettingItem>();
            database.CreateTable<SportItem>();

            SportItem[] data = new[] { new SportItem { ID = 0, Name = "surfing", PictureName = "Surfing.jpg" },
                new SportItem { ID = 1, Name = "windsurfing", PictureName = "Windsurfing.png" },
                new SportItem { ID = 2, Name = "kitesurfing", PictureName = "Kitesurfing.jpg" },
                new SportItem { ID = 3, Name = "sailing", PictureName = "Sailing.png" } };

            database.InsertAll(data);
        }
    }
}
