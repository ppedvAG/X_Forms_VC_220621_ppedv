using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace X_Forms
{
    //Kontext-Klasse zur Verwendung in dem DataBinding-Beispiel (vgl. MainPage.xaml / Bereich: DataBinding)
    //Zur Kommunikation der angebundenen Eigenschaften mit der GUI wird das INotifyPropertyChanged-Interface benötigt (vgl. unten)
    internal class Person : INotifyPropertyChanged
    {
        //Beispiel-Properties
        public string Name { get; set; }

        private int alter;
        public int Alter
        {
            get => alter;
            set
            {
                alter = value;
                //Aufruf des durch das Interface verlangten Events zur Informierung der Oberfläche über Veränderung der 'Alter'-Eigenschaft
                //-> Bindungen reagieren auf die Veränderung
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        //Beispiel-Liste zur Anbindung an ein ItemControl
        //ObservableCollection ist eine List-Klasse, welche die GUI über Veränderungen in Anzahl und Reihenfolge seiner Objekte informiert
        public ObservableCollection<DateTime> WichtigeTage { get; set; } = new ObservableCollection<DateTime>()
        {
            new DateTime(2003, 12, 5),
            new DateTime(2004, 11, 4),
            new DateTime(2005, 10, 3),
            new DateTime(2006, 9, 2),
            new DateTime(2007, 8, 1),
        };

        //Durch Interface verlangtes Event (bindet sich die GUI automatisch an)
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
