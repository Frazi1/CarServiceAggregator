using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mvvm.Converters
{
    public class BooleanToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum parameterEnum = parameter as Enum;
            if (parameterEnum == null) return DependencyProperty.UnsetValue;
            return value.Equals(parameterEnum);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum parameterEnum = parameter as Enum;
            if (parameterEnum == null) return DependencyProperty.UnsetValue;
            return parameterEnum;
        }
    }
}