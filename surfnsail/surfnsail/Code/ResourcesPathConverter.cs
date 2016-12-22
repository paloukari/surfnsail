using System;
using System.Globalization;
using Xamarin.Forms;

namespace surfnsail.Code
{
    public class ResourcesPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return BuildResourcePath(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public static string BuildResourcePath(string value)
        {
            if (Device.OS == TargetPlatform.WinPhone)
                return @"Assets/" + value;
            else if (Device.OS == TargetPlatform.Android)
                return @"Resources/Drawable/" + value;
            else if (Device.OS == TargetPlatform.iOS)
                return @"Resources/" + value;
            throw new NotImplementedException();
        }
    }
}
