using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite.Net.Platform.WindowsPhone8;
using Xam.Plugin.MapExtend.WindowsPhone;

namespace surfnsail.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Xamarin.FormsMaps.Init("appID", "authToken");

            MapExtendRenderer.Init("appID", "authToken");

            global::Xamarin.Forms.Forms.Init();

            string dbPath = FileAccessHelper.GetLocalFilePath("surfnsailSQLite.db3");

            LoadApplication(new surfnsail.App(dbPath, new SQLitePlatformWP8()));

        }
    }
}
