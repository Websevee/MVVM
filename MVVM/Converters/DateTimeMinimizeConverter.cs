using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace MVVM.Converters
{
    public class DateTimeMinimizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = value;

            if (value is DateTime dateTimeValue)
            {
                result = dateTimeValue.ToString("dd.MM.yyyy");
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class DateTimeMinimizeConverterExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new DateTimeMinimizeConverter();
        }
    }

}
