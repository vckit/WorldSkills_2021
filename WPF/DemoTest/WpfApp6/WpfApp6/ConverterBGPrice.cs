using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp6
{
    class ConverterBGPrice : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double discount = (double)value;
            if (discount >= 50 || discount != 0)
                return "Green";
            else
                return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
