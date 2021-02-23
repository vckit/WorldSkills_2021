using System;
using System.Globalization;
using System.Windows.Data;

namespace ServiceApp.Intefaces
{
    class IConverterTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int seconds = (int)value;
            if (seconds > 60 && seconds < 3600)
                return seconds / 60 + " минут ";
            else if (seconds >= 3600 && seconds < 7200)
                return seconds / 3600 + " час " + (seconds / 60 - 60) + " минут";
            else
                return (seconds / 3600 + " часа " + (seconds / 60 - 120) + " минут");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
