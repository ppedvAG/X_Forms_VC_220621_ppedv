using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.MVVM.Model
{
    //Der Model-Teil beinhaltet alle Modelklassen und evtl. Klassen, welche nur mit diesen interagieren.
    //Keine Model-Klasse darf einen Referenz auf den ViewModel- oder den Model-Teil beinhalten
    public class Fahrzeug
    {
        public string Hersteller { get; set; }
        public int MaxGeschwindigkeit { get; set; }


        public static ObservableCollection<Fahrzeug> Fahrzeugliste { get; set; } = new ObservableCollection<Fahrzeug>();

    }
}
