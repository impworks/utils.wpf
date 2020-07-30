using System.Windows;
using System.Windows.Controls;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace Impworks.Utils.Wpf.Behaviors
{
    /// <summary>
    /// Helper class for attaching control focus.
    /// </summary>
    public static class FocusBehavior
    {
        public static readonly DependencyProperty FocusFirstProperty = DependencyProperty.RegisterAttached(
            "FocusFirst",
            typeof(bool),
            typeof(FocusBehavior),
            new PropertyMetadata(false, OnFocusFirstPropertyChanged)
        );

        public static bool GetFocusFirst(Control control)
        {
            return (bool)control.GetValue(FocusFirstProperty);
        }

        public static void SetFocusFirst(Control control, bool value)
        {
            control.SetValue(FocusFirstProperty, value);
        }

        /// <summary>
        /// Subscribes the control to a Focus event on load.
        /// </summary>
        private static void OnFocusFirstPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if(!(obj is Control control) || !(args.NewValue is bool isSet))
                return;

            if (isSet)
                control.Loaded += (sender, e) => control.Focus();
        }
    }
}
