using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();


            
        }


        private TreeView tw = new TreeView();
        public void ShowTree()
        {
            var win = new Window();
            win.Title = "LogicTreeDisplay";
            win.Height = 400;
            win.Width = 250;

            Grid grid = new Grid();

            IAddChild container = grid;
            container.AddChild(tw);

            container = win;
            container.AddChild(grid);
            ShowLogicalTree(this);

            win.ShowDialog();
        }

        public void ShowLogicalTree(DependencyObject element)
        {
            // Очистить дерево
            tw.Items.Clear();
            // Начать обработку элементов
            ProcessElement(element, null);
        }


        public void ProcessElement(DependencyObject element, TreeViewItem previousItem)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;
            if (previousItem == null)
            {
                tw.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                ProcessElement(VisualTreeHelper.GetChild(element, i), item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowTree();
        }
    }
}
