using System;
using System.Globalization;
using System.Windows.Data;

namespace ServiceApp.Intefaces
{
    class IConverterTimeConstraint : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int seconds = (int)value;
            if (seconds <= 3600)
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
