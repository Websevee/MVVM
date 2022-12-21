using DevExpress.Mvvm.CodeGenerators;
using System;
using System.Collections.ObjectModel;

namespace MVVM.ViewModels
{
    [GenerateViewModel]
    public partial class MainViewModel
    {
        [GenerateProperty]
        string _Status;
        [GenerateProperty]
        string _UserName;

        [GenerateProperty]
        ObservableCollection<string> _MyList = new ObservableCollection<string>()
        {
            "Yoo",
            "Test1"
        };

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


        [GenerateCommand]
        void Login() => Status = "User: " + UserName;
        bool CanLogin() => !string.IsNullOrEmpty(UserName);
    }
}
