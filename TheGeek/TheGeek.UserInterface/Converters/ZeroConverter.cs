using System;
using Windows.UI.Xaml.Data;

namespace TheGeek.UserInterface.Converters
{
    public class ZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (System.Convert.ToInt32(value) == 0)
            {
                return "N/A";
            }
            else
            {
                return value.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
