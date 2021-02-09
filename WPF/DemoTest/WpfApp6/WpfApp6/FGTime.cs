using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp6
{
    class FGTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int time = (int)value;
            if (time <= 3600)
                return "Red";
            else
                return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
