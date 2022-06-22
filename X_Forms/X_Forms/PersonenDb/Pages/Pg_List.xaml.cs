using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pg_List : ContentPage
    {
        public ObservableCollection<Model.Person> Personenliste 
        {
            get { return Model.StaticObjects.Personenliste; }
            set { Model.StaticObjects.Personenliste= value; }
        }

        public Pg_List()
        {
            //GUI-Initialisierung
            InitializeComponent();

            //Alternatives Setzen des BindingContexts
            //this.BindingContext = this;
        }

        //EventHandler zum Löschen einer Person
        private async void CaMenu_Delete_Clicked(object sender, EventArgs e)
        {
            //Cast des Inhalts der CommandParameter-Property des Sender-Objekts (das ausgewählte ListView-Item) in Person-Objekt
            Model.Person person = (sender as MenuItem).CommandParameter as Model.Person;

            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Person löschen", $"Soll {person.Vorname} {person.Nachname} wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen aus lokaler Liste
                Personenliste.Remove(person);
                //Löschen aus Datenbank
                Model.StaticObjects.Datenbank.DeletePerson(person);
                //Ausgabe eines Toasts
                Services.ToastController.ShowToast($"{person.Vorname} wurde gelöscht");
            }
        }
    }
}