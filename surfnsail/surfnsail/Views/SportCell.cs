using surfnsail.Code;
using Xamarin.Forms;

namespace surfnsail.Views
{
    public class SportCell : ViewCell
    {
        public SportCell()
        {
            var image = new Image();
            var text = new Label()
            {
                FontSize = 40,
                FontFamily = "System",
                TextColor = Color.White,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Start,
                TranslationX = 10
            };

            text.SetBinding(Label.TextProperty, "Name");

            image.SetBinding(Image.SourceProperty, "PictureName", BindingMode.OneWay, new ResourcesPathConverter());

            RelativeLayout layout = new RelativeLayout();
            layout.Children.Add(image,
                Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            layout.Children.Add(text,
                Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            StackLayout cellWrapper = new StackLayout();
            cellWrapper.Padding = 10;
            cellWrapper.HeightRequest = 250;
            cellWrapper.VerticalOptions = LayoutOptions.FillAndExpand;
            cellWrapper.HorizontalOptions = LayoutOptions.FillAndExpand;
            cellWrapper.BackgroundColor = Color.Black;
            cellWrapper.Children.Add(layout);

            View = cellWrapper;
        }
    }
}