using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.MVVM.ViewModel
{
    internal class FahrzeugViewModel : INotifyPropertyChanged
    {
        public Page ContextView { get; set; }

        public ObservableCollection<Model.Fahrzeug> Fahrzeugliste
        {
            get { return Model.Fahrzeug.Fahrzeugliste; }
            set { Model.Fahrzeug.Fahrzeugliste = value; }
        }

        public Model.Fahrzeug NeuesFahrzeug { get; set; }

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

        private Model.Fahrzeug selectedFahrzeug;
        public Model.Fahrzeug SelectedFahrzeug
        {
            get { return selectedFahrzeug; }
            set { selectedFahrzeug = value; LoeschenCmd.ChangeCanExecute(); }
        }


        public Command HinzufuegenCmd { get; set; }
        public Command LoeschenCmd { get; set; }


        public FahrzeugViewModel()
        {
            NeuesFahrzeug = new Model.Fahrzeug();

            HinzufuegenCmd = new Command(FügeFahrzeugHinzu, CanFügeFahrzeugHinzu);
            LoeschenCmd = new Command(LöscheFahrzeug, CanLöscheFahrzeug);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FügeFahrzeugHinzu()
        {
            Fahrzeugliste.Add(NeuesFahrzeug);

            NeuesFahrzeug = new Model.Fahrzeug();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeuerHersteller)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeueMaxGeschwindigkeit)));
        }

        private bool CanFügeFahrzeugHinzu()
        {
            return !String.IsNullOrEmpty(NeuesFahrzeug.Hersteller) && NeuesFahrzeug.MaxGeschwindigkeit > 0;
        }

        private async void LöscheFahrzeug(object parameter)
        {
            if(await ContextView.DisplayAlert("Löschen", "Soll das Fahrzueg wirklich gelöscht werden?", "Ja", "Nein"))
                Fahrzeugliste.Remove(parameter as Model.Fahrzeug);

            SelectedFahrzeug = null;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFahrzeug)));
            LoeschenCmd.ChangeCanExecute();
        }

        private bool CanLöscheFahrzeug(object parameter)
        {
            return parameter is Model.Fahrzeug;
        }

    }
}
