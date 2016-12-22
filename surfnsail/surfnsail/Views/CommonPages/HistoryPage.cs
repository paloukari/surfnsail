using Xamarin.Forms;

namespace surfnsail.Views.CommonPages
{
    public class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            Title = "History";

            Content = new BoxView
            {
                Color = Color.Maroon,
                HeightRequest = 100f,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}
