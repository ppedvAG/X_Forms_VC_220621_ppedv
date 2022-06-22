using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pg_Add : ContentPage, INotifyPropertyChanged
    {
        //Properties, an welche die XAML-Objekte (aus Pg_Add.xaml) angebunden sind
        public Model.Person NeuePerson { get; set; }

        //Konstruktor
        public Pg_Add()
        {
            //GUI-Initialisierung
            InitializeComponent();

            //Completed-EventHandler-Zuweisung (User-Komfort)
            Entry_Vorname.Completed += (s, e) => Entry_Nachname.Focus();
            Entry_Nachname.Completed += Btn_AddPerson_Clicked;
            Entry_Nachname.Completed += (s, e) => Entry_Vorname.Focus();

            //Instanziierung eines leeren Personen-Objekts (zur Befüllung durch die GUI)
            NeuePerson = new Model.Person();
        }

        //EventHandler zum Hinzufügen einer neuen Person
        private void Btn_AddPerson_Clicked(object sender, EventArgs e)
        {
            //Hinzufügen der Person zu Personenliste (vgl. Model/StaticObjects.cs)
            Model.StaticObjects.Personenliste.Add(NeuePerson);
            //Neue Person für die nächste Eingabe
            NeuePerson = new Model.Person();
            //Informieren der GUI über neue (leere) Person -> leert angebundene Eingeschaften in Entries
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuePerson)));
        }

        //INotifyPropertyChanged-Event
        public event PropertyChangedEventHandler PropertyChanged;

    }
}