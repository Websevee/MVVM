using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MVVM.Selectors
{
    public class MyItemsSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null)
            {
                var isEdit = (bool)element.Tag;

                if (isEdit)
                    return
                        element.FindResource("editTemplate") as DataTemplate;
                else
                    return
                        element.FindResource("readTemplate") as DataTemplate;
            }

            return null;
        }
    }

    public class MyItemsSelectorExtension : MarkupExtension
    {
        public override object ProvideValue(System.IServiceProvider serviceProvider)
        {
            return new MyItemsSelector();
        }
    }
}
