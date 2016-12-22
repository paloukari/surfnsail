using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;
using surfnsail.Models;

namespace surfnsail.Views
{
    public class AppRootPage : ContentPage
    {
        ListView _listView;
        public AppRootPage()
        {
            Title = "Sunset Surfing";

            _listView = new ListView();

            _listView.ItemTemplate = new DataTemplate(typeof(SportCell)); 

            _listView.ItemsSource = App.Database.Sports;

            _listView.ItemTapped += (sender, e) =>
            {
                var sport = (SportItem)e.Item;
                var sportPage = SportPage.GetPage(sport.ID);
                sportPage.BindingContext = sport;

                ((App)App.Current).ResumeAtPageSportID = sport.ID;
                Debug.WriteLine("setting ResumeAtPageSportID = " + sport.ID);

                Navigation.PushAsync(sportPage);
            };

            var layout = new StackLayout();

            #region WinPhone
            if (Device.OS == TargetPlatform.WinPhone)
            {
                layout.Children.Add(new Label
                {
                    Text = Title,
                    TranslationX=10,
                    FontSize = 30
                });
            }
            #endregion

            layout.Children.Add(_listView);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;

            //?
            var sportID = 0;

            ToolbarItem tbi = null;
            #region iOS
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    var sport = App.Database.Sports.SingleOrDefault(e => e.ID == sportID);
                    var sportPage = SportPage.GetPage(sport.ID);
                    sportPage.BindingContext = App.Database.GetSportContext(sportID);
                    Navigation.PushAsync(sportPage);
                }, 0, 0);
            }
            #endregion
            #region Android

            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var sport = App.Database.Sports.SingleOrDefault(e => e.ID == sportID);
                    var sportPage = SportPage.GetPage(sport.ID);
                    sportPage.BindingContext = App.Database.GetSportContext(sportID);
                    Navigation.PushAsync(sportPage);
                }, 0, 0);
            }
            #endregion
            #region WinPhone

            if (Device.OS == TargetPlatform.WinPhone)
            {
                tbi = new ToolbarItem("Add", "add.png", () =>
                {
                    var sport = App.Database.Sports.SingleOrDefault(e => e.ID == sportID);
                    var sportPage = SportPage.GetPage(sport.ID);
                    sportPage.BindingContext = App.Database.GetSportContext(sportID);
                    Navigation.PushAsync(sportPage);
                }, 0, 0);
            }
            #endregion

            ToolbarItems.Add(tbi);
            #region iOS

            //if (Device.OS == TargetPlatform.iOS)
            //{
            //    var tbi2 = new ToolbarItem("?", null, () =>
            //    {
            //        var todos = App.Database.GetItemsNotDone();
            //        var tospeak = "";
            //        foreach (var t in todos)
            //            tospeak += t.Name + " ";
            //        if (tospeak == "") tospeak = "there are no tasks to do";

            //        DependencyService.Get<ITextToSpeech>().Speak(tospeak);
            //    }, 0, 0);
            //    ToolbarItems.Add(tbi2);
            //}
            #endregion
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtPageSportID = -1;
           // _listView.ItemsSource = App.Database.Sports;
        }
    }
}