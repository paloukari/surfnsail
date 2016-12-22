using Xamarin.Forms;

namespace surfnsail.Views.CommonPages
{
    public class PlaningPage : ContentPage
    {
        public PlaningPage()
        {
            Title = "Planing";

            Content = new BoxView
            {
                Color = Color.Aqua,
                HeightRequest = 100f,
                VerticalOptions = LayoutOptions.Center
            };
        }
    }
}
