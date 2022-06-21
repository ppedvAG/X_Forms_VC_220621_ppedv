using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace X_Forms
{
    internal class Person : INotifyPropertyChanged
    {

        public string Name { get; set; }

        private int alter;


        public int Alter
        {
            get => alter;
            set 
            { 
                alter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public ObservableCollection<DateTime> WichtigeTage { get; set; } = new ObservableCollection<DateTime>()
        {
            new DateTime(2003, 12,1),
            new DateTime(2006, 11,11),
            new DateTime(2012, 10,12),
            new DateTime(2022, 1,13),
        };

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
