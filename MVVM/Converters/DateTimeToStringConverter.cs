using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mvvm.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime?) value;
            if (dateTime == null) return DependencyProperty.UnsetValue;
            return dateTime?.ToString("g", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}