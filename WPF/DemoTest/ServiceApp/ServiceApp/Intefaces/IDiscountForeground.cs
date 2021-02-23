using System;
using System.Globalization;
using System.Windows.Data;

namespace ServiceApp.Intefaces
{
    class IDiscountForeground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double discout = (double)value;
            if (discout != 0)
                return "LightGreen";
            else
                return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
