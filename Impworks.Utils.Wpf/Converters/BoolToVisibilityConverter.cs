using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
// ReSharper disable UnusedType.Global

namespace Impworks.Utils.Wpf.Converters
{
    /// <summary>
    /// UI converter for showing or hiding an object depending on a flag.
    /// </summary>
    public class BoolToVisibilityConverter: IValueConverter
    {
        /// <summary>
        /// Flag indicating that the converter returns "Hidden" for truth values.
        /// </summary>
        public bool IsInverted { get; set; }

        /// <summary>
        /// Type of visibility to use when the object should not be shown - hidden or collapsed.
        /// Defaults to collapsed.
        /// </summary>
        public Visibility InvisibleMode { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool flag)
                return flag ^ IsInverted ? Visibility.Visible : InvisibleMode;

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility vis)
                return vis == Visibility.Visible ^ IsInverted;

            return DependencyProperty.UnsetValue;
        }
    }
}
