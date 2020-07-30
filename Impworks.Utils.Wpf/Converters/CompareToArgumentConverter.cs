using System;
using System.Globalization;
using System.Windows.Data;
// ReSharper disable UnusedType.Global

namespace Impworks.Utils.Wpf.Converters
{
    /// <summary>
    /// Compares a binding value to a predefined argument.
    /// </summary>
    public class CompareToArgumentConverter: IValueConverter
    {
        /// <summary>
        /// Argument to compare the value with.
        /// </summary>
        public object Argument { get; set; }

        /// <summary>
        /// Flag indicating that the comparison is inverted (true = not equal).
        /// </summary>
        public bool IsInverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, Argument ?? parameter) ^ IsInverted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
