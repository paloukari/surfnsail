using SQLite;
using surfnsail.Models;
using surfnsail.Views;
using surfnsail.Views.Windsurfing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace surfnsail.Data
{
    public class AppDatabase
    {
        static object locker = new object();

        SQLiteConnection database;


        string DatabasePath
        {
            get
            {
                var sqliteFilename = "surfnsailSQLite.db3";
#if __IOS__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				var path = Path.Combine(libraryPath, sqliteFilename);
#else
#if __ANDROID__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				var path = Path.Combine(documentsPath, sqliteFilename);
#else
                // WinPhone
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename); ;
#endif
#endif
                return path;
            }
        }

        public AppDatabase()
        {
            database = new SQLiteConnection(DatabasePath);
        }

        public IEnumerable<SettingItem> Settings
        {
            get
            {
                lock (locker)
                {
                    return (from i in database.Table<SettingItem>() select i).ToList();
                }
            }
        }

        public IEnumerable<SportItem> Sports
        {
            get
            {
                lock (locker)
                {
                    return (from i in database.Table<SportItem>() select i).ToList();
                }
            }
        }


        public IEnumerable<RouteItem> Routes
        {
            get
            {
                lock (locker)
                {
                    return (from i in database.Table<RouteItem>() select i).ToList();
                }
            }
        }

        public void AddPositionItem(PositionItem item)
        {
            database.Insert(item);
        }

        public void AddRouteItem(RouteItem item)
        {
            database.Insert(item);
        }

        private readonly SportContext[] _sportContext = new[] {
                new SportContext() { ID=0, Data=new [] { "Data1", "Data2" } },
                new SportContext() { ID=1, Data=new [] { "Data1", "Data2" } }
            };

        internal static object GetContext(Page pageToResume)
        {
            throw new NotImplementedException();
        }

        internal SportContext GetSportContext(int sportID)
        {
            return _sportContext.SingleOrDefault((e) => e.ID == sportID);
        }
    }
}
