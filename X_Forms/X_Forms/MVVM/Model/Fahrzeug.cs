using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.MVVM.Model
{
    public class Fahrzeug
    {
        public string Hersteller { get; set; }
        public int MaxGeschwindigkeit { get; set; }


        public static ObservableCollection<Fahrzeug> Fahrzeugliste { get; set; } = new ObservableCollection<Fahrzeug>();

    }
}
