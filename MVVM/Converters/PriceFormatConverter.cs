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
            string s = value?.ToString();
            if (string.IsNullOrEmpty(s)) return DependencyProperty.UnsetValue;
            return s.ToString(culture.NumberFormat);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}