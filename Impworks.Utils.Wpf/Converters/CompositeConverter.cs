using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
// ReSharper disable UnusedType.Global

namespace Impworks.Utils.Wpf.Converters
{
    /// <summary>
    /// Applies a chain of converters sequentially.
    /// </summary>
    [ContentProperty(nameof(Converters))]
    public class CompositeConverter: IValueConverter
    {
        /// <summary>
        /// Converters to apply.
        /// </summary>
        public List<IValueConverter> Converters { get; } = new List<IValueConverter>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (IsTerminalValue(value))
                return value;

            foreach (var converter in Converters)
            {
                value = converter.Convert(value, targetType, parameter, culture);
                if (IsTerminalValue(value))
                    return value;
            }

            return value;

            static bool IsTerminalValue(object obj) => obj == DependencyProperty.UnsetValue || obj == Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
