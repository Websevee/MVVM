using DevExpress.Mvvm.CodeGenerators;
using System.Collections.ObjectModel;

namespace MVVM.ViewModels
{
    [GenerateViewModel]
    public partial class MyTestViewModel
    {
        [GenerateProperty]
        ObservableCollection<MyObject> _MyObjectList = new ObservableCollection<MyObject>()
        {
            new MyObject { Id = 1, Name = "Nikolay" },
            new MyObject { Id = 2, Name = "Max" },
            new MyObject { Id = 3, Name = "Nikolay" },
            new MyObject { Id = 3, Name = "Nikolay" },
            new MyObject { Id = 3, Name = "Nikolay" },
            new MyObject { Id = 3, Name = "Nikolay" },
            new MyObject { Id = 3, Name = "Nikolay" },
            new MyObject { Id = 3, Name = "Nikolay" },
        };
    }
}
