using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.Xpf.Editors.Internal;
using System;
using System.Reflection;

namespace MVVM.Controls
{
    /// <summary>
    /// Сделан для обхода бага Devexpress
    /// <see cref="https://supportcenter.devexpress.com/ticket/details/t369116/listboxedit-raises-the-nullreferenceexception-if-an-outer-searchcontrol-is-used"/>
    /// </summary>
    public class MyListBoxEdit : ListBoxEdit
    {
        protected override EditStrategyBase CreateEditStrategy()
        {
            return new MyListBoxEditStrategy(this);
        }
    }

    public class MyListBoxEditStrategy : ListBoxEditStrategy
    {
        public MyListBoxEditStrategy(ListBoxEdit editor)
            : base(editor)
        {
        }

        protected override void SyncWithEditorInternal()
        {
            var itemsProvider = (this as ISelectorEditStrategy).ItemsProvider as ItemsProvider2;
            var defaultView = itemsProvider.DataController.DefaultDataView;
            Type dataViewType = typeof(DataView);
            FieldInfo viewField = dataViewType.GetField("view", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var internalView = viewField.GetValue(defaultView);
            if (internalView != null)
                base.SyncWithEditorInternal();
        }
    }
}
