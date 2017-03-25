using System;
using Windows.UI.Xaml.Data;

namespace TheGeek.UserInterface.Converters
{
    public class GamesCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return "Your Collection - " + value + " Games:";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
