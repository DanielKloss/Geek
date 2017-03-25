using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TheGeek.UserInterface.Converters
{
    public class GamesListVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((int)value <= 0)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
