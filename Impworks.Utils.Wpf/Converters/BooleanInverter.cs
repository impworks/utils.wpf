using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
// ReSharper disable UnusedType.Global

namespace Impworks.Utils.Wpf.Converters
{
    /// <summary>
    /// Convertor for negating boolean values.
    /// </summary>
    public class BooleanInverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
                return !b;

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
