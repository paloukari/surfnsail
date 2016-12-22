using Foundation;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;
using Xam.Plugin.MapExtend.iOSUnified;
using Xamarin.Forms;

namespace surfnsail.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            Forms.Init();

            Xamarin.FormsMaps.Init();

            MapExtendRenderer.Init();

            string dbPath = FileAccessHelper.GetLocalFilePath("surfnsailSQLite.db3");

            LoadApplication(new App(dbPath, new SQLitePlatformIOS()));

            return base.FinishedLaunching(app, options);

        }
    }
}
