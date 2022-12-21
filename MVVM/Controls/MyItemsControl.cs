using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MVVM.Controls
{
    public class MyItemsControl : ItemsControl
    {
        public static readonly DependencyProperty IsEditableProperty = DependencyProperty.Register(
            nameof(IsEditable), typeof(bool),
            typeof(MyItemsControl)
            );

        public static readonly DependencyProperty CollectionViewBaseProperty = DependencyProperty.Register(
            nameof(CollectionViewBase), typeof(ListCollectionView),
            typeof(MyItemsControl)
            );

        public static readonly DependencyProperty CollectionViewPinnedProperty = DependencyProperty.Register(
            nameof(CollectionViewPinned), typeof(ListCollectionView),
            typeof(MyItemsControl)
            );

        public bool IsEditable
        {
            get => (bool)GetValue(IsEditableProperty);
            set => SetValue(IsEditableProperty, value);
        }

        public ListCollectionView CollectionViewBase
        {
            get => (ListCollectionView)GetValue(CollectionViewBaseProperty);
            set => SetValue(CollectionViewBaseProperty, value);
        }

        public ListCollectionView CollectionViewPinned
        {
            get => (ListCollectionView)GetValue(CollectionViewPinnedProperty);
            set => SetValue(CollectionViewPinnedProperty, value);
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            if (newValue is IList<MyObject> newValueList)
            {
                var pinnedList = newValueList.Where(x => x.IsPinned).ToList();
                var baseList = newValueList.Where(x => !x.IsPinned).ToList();

                CollectionViewPinned = new ListCollectionView(pinnedList);

                CollectionViewBase = new ListCollectionView(baseList);
                CollectionViewBase.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
                CollectionViewBase.SortDescriptions.Add(new SortDescription("IsPinned", ListSortDirection.Descending));
                CollectionViewBase.IsLiveSorting = true;
            }
        }

        static MyItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyItemsControl), new FrameworkPropertyMetadata(typeof(MyItemsControl)));
        }

        public MyItemsControl()
        {
            IsEditable = true;
        }

        public override void OnApplyTemplate()
        {
            var editButton = GetTemplateChild("EditButton");
            var removeButton = GetTemplateChild("RemoveButton");

            var testBorder = GetTemplateChild("TestBorder");
        }
    }
}
