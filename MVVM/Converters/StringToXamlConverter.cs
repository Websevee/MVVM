using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;
using MVVM.ViewModels;
using DevExpress.Xpf.Editors;

namespace MVVM.Converters
{
    /// <summary>
    /// Сделан для подсветки
    /// <see cref="https://stackoverflow.com/questions/3728584/how-to-display-search-results-in-a-wpf-items-control-with-highlighted-query-terms"/>
    /// </summary>
    public class StringToXamlConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var textBlock = values[0] as TextBlock;
            var input = values[1] as string;
            var searchText = values[2] as string;

            textBlock.Inlines.Add(new Run(input));

            if (input != null && searchText != null)
            {
                var subIndex = input.IndexOf(searchText);

                if (subIndex > -1)
                {
                    var lastIndex = subIndex + searchText.Length;

                    var firstText = input.Substring(0, subIndex);
                    var lastText = input.Substring(lastIndex);

                    textBlock.Inlines.Clear();

                    textBlock.Inlines.Add(new Run(firstText));
                    textBlock.Inlines.Add(new Run(searchText) { FontWeight = FontWeights.Bold, Background = Brushes.Yellow });
                    textBlock.Inlines.Add(new Run(lastText));
                }
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringToXamlConverterExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new StringToXamlConverter() {};
        }
    }
}
