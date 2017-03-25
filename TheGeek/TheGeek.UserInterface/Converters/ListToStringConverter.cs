using System;
using System.Collections.Generic;
using System.Linq;
using TheGeek.Data.Models;
using Windows.UI.Xaml.Data;

namespace TheGeek.UserInterface.Converters
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            IEnumerable<Model> list = value as IEnumerable<Model>;

            if (list == null)
            {
                return string.Empty;
            }

            List<string> basicList = new List<string>();

            foreach (Model model in list)
            {
                basicList.Add(model.name);
            }

            if (basicList.Count > 6)
            {
                return string.Join(", ", basicList.Take(4)) + "... " + " + " + basicList.Count + " More";
            }
            else
            {
                return string.Join(", ", basicList);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
