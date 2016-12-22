using Xamarin.Forms;

namespace surfnsail.Views.CommonPages
{
    public class MonitoringPage : ContentPage
    {
        public MonitoringPage()
        {
            Title = "Monitoring";

            Content = new BoxView
            {
                Color = Color.Blue,
                HeightRequest = 100f,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}
