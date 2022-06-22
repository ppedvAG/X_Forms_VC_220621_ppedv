using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.PersonenDb.Model
{
    //Statische Klasse zur Verwaltung von globalen, statischen Objekten
    public static class StaticObjects
    {
        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Model.Person>()
        {
            new Person(){Vorname="Anna", Nachname="Nass"},
            new Person(){Vorname="Rainer", Nachname="Zufall"},
        };
    };
}
