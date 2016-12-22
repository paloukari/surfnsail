using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;
using surfnsail.Models;
using surfnsail.Code;

namespace surfnsail.Views
{
    public class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            var activity = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsRunning = true
            };
            var image = new Image
            {
                Source = ResourcesPathConverter.BuildResourcePath("Loading.jpg")
            };
        Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,

                Children = { activity, image}
            };
        }
    }
}
