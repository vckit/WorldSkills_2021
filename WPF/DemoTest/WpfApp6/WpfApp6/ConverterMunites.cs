using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp6
{
    public class ConverterMunites : IValueConverter
    {
        public object Convert(object value, Type targetType, object parametr, CultureInfo culture)
        {
            if (value == null)
                return "Информация отсутствует";

            int seconds = int.Parse(value.ToString());
            if (seconds < 0)
                return 0;

            if (seconds > 60 && seconds < 3600)
                return (seconds / 60 + " Минут ");
            else if (seconds >= 3600 && seconds < 7200)
                return (seconds / 3600 + " Час " + (seconds / 60 - 60) + " минут");
            else if (seconds >= 7200 && seconds <= 14400)
                return (seconds / 3600 + " Часа " + (seconds / 60 - 120) + " минут");

            return seconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}