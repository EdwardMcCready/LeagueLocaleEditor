using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LeagueLocaleEditor.UI.Converters
{
    public class CodeToLanguageConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumIndex = (int)value;
            var languageLocale = (Enums.LocaleNames.Language)enumIndex;

            if (languageLocale.ToString() == enumIndex.ToString())
            {
                return Enums.LocaleNames.Language.invalidCode;
            }

            return Enums.LocaleNames.GetDisplayName(languageLocale);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // We only care about convert so this has not been implemented
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
}
