using Xamarin.Forms;

namespace surfnsail.Views.CommonPages
{
    public class TodayPage : ContentPage
    {
        public TodayPage()
        {
            Title = "Today";


            Content = new BoxView
            {
                Color = Color.Gray,
                HeightRequest = 100f,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}
