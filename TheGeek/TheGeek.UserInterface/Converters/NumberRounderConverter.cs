using System;
using Windows.UI.Xaml.Data;

namespace TheGeek.UserInterface.Converters
{
    public class NumberRounderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
                return Math.Round(System.Convert.ToDouble(value), System.Convert.ToInt32(parameter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
