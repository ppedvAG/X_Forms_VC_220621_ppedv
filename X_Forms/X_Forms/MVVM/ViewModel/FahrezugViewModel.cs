using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.MVVM.ViewModel
{
    //Im ViewModel-Teil eines MVVM-Programms werden Klassen definiert, welche als Verbindungsstück zwischen den Views und den Modelklassen fungieren.
    //Diese Klassen sind die einzigen Programmteile, welche Referenzen auf Model-Klassen beinhalten. Sie selbst sind jeweils einem View zugrordnet,
    //mit welchem sie (nur) über den BindingContext des jeweiligen Views verbunden sind.
    //INotifyPropertyChanged informiert die GUI über Veränderungen in den Daten
    internal class FahrzeugViewModel : INotifyPropertyChanged
    {
        //View-Property für z.B. DisplayAlerts
        public Page ContextView { get; set; }

        //Property zur Repräsentation der geladenen Personen in ListView (verweist an die Model-Klasse)
        public ObservableCollection<Model.Fahrzeug> Fahrzeugliste
        {
            get { return Model.Fahrzeug.Fahrzeugliste; }
            set { Model.Fahrzeug.Fahrzeugliste = value; }
        }

        //Property für Neues Fahrzeug
        public Model.Fahrzeug NeuesFahrzeug { get; set; }

        //Properties für Anbindung an Entries (verweisen auf NeuesFahrzeug). Nötig, um Hinzufügen.CanExecute() neu zu prüfen.
        public string NeuerHersteller 
        { 
            get { return NeuesFahrzeug.Hersteller; }
            set { NeuesFahrzeug.Hersteller = value; HinzufuegenCmd.ChangeCanExecute(); }
        }
        public int NeueMaxGeschwindigkeit 
        { 
            get { return NeuesFahrzeug.MaxGeschwindigkeit; }
            set { NeuesFahrzeug.MaxGeschwindigkeit = value; HinzufuegenCmd.ChangeCanExecute(); }
        }

        //Property zur Anbindung von ListView.SelectedItem zur Überprüfung von LoeschenCmd.CanExecute()
        private Model.Fahrzeug selectedFahrzeug;
        public Model.Fahrzeug SelectedFahrzeug
        {
            get { return selectedFahrzeug; }
            set { selectedFahrzeug = value; LoeschenCmd.ChangeCanExecute(); }
        }

        //Command-Properties (angebunden an Command-Eigenschaften der Buttons)
        public Command HinzufuegenCmd { get; set; }
        public Command LoeschenCmd { get; set; }


        //Konstruktor
        public FahrzeugViewModel()
        {
            //Propertiyinitialisierung
            NeuesFahrzeug = new Model.Fahrzeug();
            //Commandinitialisierung
            HinzufuegenCmd = new Command(FügeFahrzeugHinzu, CanFügeFahrzeugHinzu);
            LoeschenCmd = new Command(LöscheFahrzeug, CanLöscheFahrzeug);
        }

        //Event des Interfaces
        public event PropertyChangedEventHandler PropertyChanged;

        //Command-Methoden
        private void FügeFahrzeugHinzu()
        {
            //Hinzufügen des neuen Fahrzeugs
            Fahrzeugliste.Add(NeuesFahrzeug);
            //Initialisieren des nächsten neuen Fahrzeugs
            NeuesFahrzeug = new Model.Fahrzeug();
            //Informieren der GUI, dass sich die Eigenschaften veränder haben -> Entries werden geleert
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuerHersteller)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeueMaxGeschwindigkeit)));
        }

        private bool CanFügeFahrzeugHinzu()
        {
            //Prüfung, ob in die Entries etwas eingetragen wurde
            return !String.IsNullOrEmpty(NeuesFahrzeug.Hersteller) && NeuesFahrzeug.MaxGeschwindigkeit > 0;
        }

        private async void LöscheFahrzeug(object parameter)
        {
            //Fragen, ob das Fahrzeug wirklich gelöscht werden soll (DisplayAlert über ContextPage-Eigenschaft)
            if (await ContextView.DisplayAlert("Löschen", "Soll das Fahrzeug wirklich gelöscht werden?", "Ja", "Nein"))
                //Löschen des Fahrzeugs aus der Liste (CommandParameter enthält ListView.SelectedItem, vgl. View/FahrzeugView.xaml)
                Fahrzeugliste.Remove(parameter as Model.Fahrzeug);

            SelectedFahrzeug = null;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFahrzeug)));
        }

        private bool CanLöscheFahrzeug(object parameter)
        {
            //Prüfung, ob ein ListView-Eintrag ausgewählt wurde (Wenn nicht Fahrzeug, dann Null)
            return parameter is Model.Fahrzeug;
        }

    }
}
