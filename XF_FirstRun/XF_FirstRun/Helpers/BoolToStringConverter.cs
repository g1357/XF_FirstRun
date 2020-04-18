using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XF_FirstRun.Helpers
{
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "true" : "false";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value == "true";
        }
    }
}
