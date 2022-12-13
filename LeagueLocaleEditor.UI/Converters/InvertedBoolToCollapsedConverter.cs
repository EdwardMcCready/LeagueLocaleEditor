using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace LeagueLocaleEditor.UI.Converters
{
    public class BoolToCollapsedConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ?
                   Visibility.Visible :
                   Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // We only care about convert so this has not been implemented
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }

    public class InvertedBoolToCollapsedConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ?
                   Visibility.Collapsed :
                   Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // We only care about convert so this has not been implemented
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
}
