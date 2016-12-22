using Xamarin.Forms;

namespace surfnsail.Views.CommonPages
{
    public class StartPage : ContentPage
    {
        Button _start;
        Button _stop;

        public StartPage()
        {
            Title = "Start";


            _start = new Button
            {
                Text = "Start"
            };
            _start.Clicked += Start_Clicked;


            _stop = new Button
            {
                Text = "Stop",
                IsEnabled = false
            };
            _stop.Clicked += Stop_Clicked;

            var stack = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            stack.Children.Add(_start);
            stack.Children.Add(_stop);

            Content = stack;
        }

        private void Start_Clicked(object sender, System.EventArgs e)
        {
            _stop.IsEnabled = true;
            _start.IsEnabled = false;
        }

        private void Stop_Clicked(object sender, System.EventArgs e)
        {
            _stop.IsEnabled = false;
            _start.IsEnabled = true;
        }
    }
}
