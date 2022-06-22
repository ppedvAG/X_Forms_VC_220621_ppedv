using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.PersonenDb.Model
{
    //Model-Klasse für die PersonenDb-App. Auf SQLite-Datenbank optimiert
    public class Person
    {
        //SQLite-Attribute zur Verwaltung innerhalb der DB
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }   
}

