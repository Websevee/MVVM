using System.Windows;
using System.Windows.Controls;

namespace MVVM.Controls
{
    //[TemplateVisualState(Name = "Read", GroupName = "TemplateStates")]
    //[TemplateVisualState(Name = "Edit", GroupName = "TemplateStates")]
    public class MyItemsControlItem : Control
    {
        public event RoutedEventHandler PinnedButtonClick;

        public static readonly DependencyProperty IsReadProperty = DependencyProperty.Register(
            nameof(IsRead), typeof(bool),
            typeof(MyItemsControlItem)
            );

        public static readonly DependencyProperty IsEditableProperty = DependencyProperty.Register(
            nameof(IsEditable), typeof(bool),
            typeof(MyItemsControlItem)
            );

        public static readonly DependencyProperty EditableValueProperty = DependencyProperty.Register(
            nameof(EditableValue), typeof(object),
            typeof(MyItemsControlItem)
            );

        public static readonly DependencyProperty EditTemplateProperty = DependencyProperty.Register(
            nameof(EditTemplate), typeof(DataTemplate),
            typeof(MyItemsControlItem)
            );

        public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(
            nameof(SearchText), typeof(string),
            typeof(MyItemsControlItem)
            );

        public bool IsRead
        {
            get => (bool)GetValue(IsReadProperty);
            set => SetValue(IsReadProperty, value);
        }

        public bool IsEditable
        {
            get => (bool)GetValue(IsEditableProperty);
            set => SetValue(IsEditableProperty, value);
        }

        public object EditableValue
        {
            get => GetValue(EditableValueProperty);
            set
            {
                SetValue(EditableValueProperty, value);
                ChangeEditTemplate();
            }
        }

        public DataTemplate EditTemplate
        {
            get => (DataTemplate)GetValue(EditTemplateProperty);
            set => SetValue(EditTemplateProperty, value);
        }

        public string SearchText
        {
            get => (string)GetValue(SearchTextProperty);
            set => SetValue(SearchTextProperty, value);
        }

        static MyItemsControlItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyItemsControlItem), new FrameworkPropertyMetadata(typeof(MyItemsControlItem)));
        }

        public MyItemsControlItem() : base()
        {
            IsRead = true;
            EditTemplate = FindResource("readTemplate") as DataTemplate;
        }

        public void ChangeEditTemplate(bool? isSetRead = null)
        {
            var isNeedRead = isSetRead ?? !IsRead;
            var templateName = isNeedRead ? "readTemplate" : "editTemplate";
            var result = FindResource(templateName) as DataTemplate;

            IsRead = isNeedRead;
            EditTemplate = result;
        }

        public void PinnedButtonClickInvoke(object sender, RoutedEventArgs e)
        {
            PinnedButtonClick?.Invoke(sender, e);
        }
    }
}
