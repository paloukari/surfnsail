using surfnsail.Data;
using surfnsail.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace surfnsail
{
    public class App : Application
    {
        static AppDatabase _database;

        static App()
        {
            _database = new AppDatabase();
        }


        public App(string dbPath, SQLite.Net.Interop.ISQLitePlatform platformDB)
        {
            MainPage = new NavigationPage(new LoadingPage());

            Page normalPage = null;
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Device.BeginInvokeOnMainThread(() =>
                {
                    normalPage = new NavigationPage(new AppRootPage());
                    //emulate delay
                });
            }).ContinueWith((e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MainPage = normalPage;
                });
            }
            );
        }

        public int ResumeAtPageSportID { get; set; }

        public static AppDatabase Database
        {
            get
            {
                return _database;
            }
        }


        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep saving ResumeAtPage = " + ResumeAtPageSportID);
            // the app should keep updating this value, to
            // keep the "state" in case of a sleep/resume
            Properties["ResumeAtPage"] = ResumeAtPageSportID;
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");

            if (Properties.ContainsKey("ResumeAtPage"))
            {
                var resumeAtSportID = Properties["ResumeAtPage"].ToString();
                Debug.WriteLine("   resumeAtPage = " + resumeAtSportID);
                if (!String.IsNullOrEmpty(resumeAtSportID))
                {
                    ResumeAtPageSportID = Convert.ToInt32(resumeAtSportID);
                    var sport = Database.Sports.SingleOrDefault(e => e.ID == ResumeAtPageSportID);
                    if (sport != null)
                    {
                        if (sport.ID == ResumeAtPageSportID)
                        {
                            var sportPage = SportPage.GetPage(sport.ID);
                            sportPage.BindingContext = Database.GetSportContext(ResumeAtPageSportID);

                            // no animation
                            MainPage.Navigation.PushAsync(sportPage, false);
                        }
                    }
                }
            }
        }
    }
}
