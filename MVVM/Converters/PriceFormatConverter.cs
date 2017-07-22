using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mvvm.Converters
{
    public class PriceFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var decimalValue = (decimal?) value;
            if (decimalValue == null) return DependencyProperty.UnsetValue;
            return decimalValue?.ToString("C", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}