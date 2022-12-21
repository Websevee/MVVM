using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MVVM.Controls
{
    public partial class CustomControls : ResourceDictionary
    {
        public void PinnedButtonClick(object sender, RoutedEventArgs e)
        {

        }

        public void EditButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as ItemsControl;
            var grid = parent.Parent as Grid;

            

            var isEdit = (bool)grid.FindResource("isEdit");
            grid.Resources["isEdit"] = !isEdit;
        }

        public void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var parent = button.Parent as ItemsControl;
            var myObject = parent.DataContext;
            var test = button.Tag as ListCollectionView;

            test.Remove(myObject);
        }
    }
}
