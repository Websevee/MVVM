using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{
    public class MyObject : INotifyPropertyChanged
    {
        bool _isPinned;

        static Random Random = new Random();

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPinned 
        {
            get { return _isPinned; }
            set
            {
                _isPinned = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate { get; set; } = DateTime.Now.AddDays(Random.Next(0, 5));


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
