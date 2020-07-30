using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
// ReSharper disable UnusedType.Global

namespace Impworks.Utils.Wpf.Converters
{
    /// <summary>
    /// Checks if all specified values are equal.
    /// </summary>
    public class EqualityConverter: IMultiValueConverter
    {
        /// <summary>
        /// Flag indicating that the convertor must return true if not all given elements are equal.
        /// </summary>
        public bool IsInverted { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return DependencyProperty.UnsetValue;

            return values.Skip(1).All(x => Compare(values[0], x)) ^ IsInverted;

            static bool Compare(object a, object b) => a switch
            {
                null when b == null => true,
                null => false,
                _ => a.Equals(b)
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
