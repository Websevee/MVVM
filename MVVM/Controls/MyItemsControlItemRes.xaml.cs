using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MVVM.Controls
{
    [TemplatePart(Name="PART_Test")]
    public partial class MyItemsControlItemRes : ResourceDictionary
    {
        public void PinnedButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.TemplatedParent as MyItemsControlItem;
            var myObject = parent.DataContext as MyObject;

            myObject.IsPinned = !myObject.IsPinned;

            parent.PinnedButtonClickInvoke(sender, e);
        }

        public void EditButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.TemplatedParent as MyItemsControlItem;
            var isSetEdit = parent.EditTemplate == parent.FindResource("readTemplate") as DataTemplate;

            if (isSetEdit)
                parent.ChangeEditTemplate();
        }

        public void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as ItemsControl;
            var myObject = parent.DataContext;

            if (button.Tag is ListCollectionView listCollectionView)
            {
                listCollectionView.Remove(myObject);
            }
            else if (button.Tag is IList obsCollection)
            {
                obsCollection.Remove(myObject);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            var parent = ((FrameworkElement)textBox.TemplatedParent).TemplatedParent as MyItemsControlItem;

            parent.ChangeEditTemplate(true);
        }

        private void editBox_Loaded(object sender, RoutedEventArgs e)
        {
            var s = sender as TextBox;
            s.CaretIndex = s.Text.Length;
        }
    }
}
