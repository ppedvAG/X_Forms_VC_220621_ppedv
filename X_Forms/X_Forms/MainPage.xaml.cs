using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {
        //Konstruktor
        public MainPage()
        {
            //Codeseitige Veränderung einer Ressource in der App.xaml (bzw hier im ResourceDictionary, das in der App.xaml angemeldet ist-->
            Application.Current.Resources["GlobalFontSize"] = 25.0;

            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Neuzuweisung einer Ressource des StyckLayouts (nur DynamicResource-Bindungen reagieren auf die Veränderung
            ((this.Content as ScrollView).Content as StackLayout).Resources["BtnString"] = "Neuer String";

            Lbl_Battery.Text = $"{Battery.ChargeLevel * 100}% geladen | {Battery.State}";
        }

        //EventHandler eines Button-Click-Events (reagiert auf Button-Klick oder -Tab)
        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
            Lbl_Output.Text = "Button wurde geklickt";

            //Neuzuweisung einer Property des Eventauslösenden Steuerelements
            if (sender is Button)
                (sender as Button).BackgroundColor = Color.HotPink;

            //Zugriff auf Value (ausgewählten Wert) des Sliders
            Ent_Input.Text = Sdr_Wert.Value.ToString();
            }


        //EventHandler eines ImageButton-Click-Events (reagiert auf Button-Klick oder -Tab)
        private void IBtn_Beispiel_Clicked(object sender, EventArgs e)
        {
            //Zugriff auf in Picker ausgewählten Eintrag
            Ent_Input.Text = Pkr_Namen.SelectedItem?.ToString();
        }

        //EventHandler eines Entry-Completed-Events (reagiert auf 'Haken' in Tastatur dieses Entries)
        private void Ent_Input_Completed(object sender, EventArgs e)
        {
            Lbl_Output.Text = Ent_Input.Text;
        }

        //EventHandler eines Slider-ValueChanged-Events (reagiert auf Wert-Veränderung in Slider.Value)
        private void Sdr_Wert_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Sdr_Wert.Value = Math.Round(Sdr_Wert.Value);
        }

       

        private void Btn_Show_Clicked(object sender, EventArgs e)
        {
            //Zugriff auf Person-Objekt in BindingContext des StackLayouts
            Person person = Sly_DataBinding.BindingContext as Person;
            //Anzeigen eines DisplayAlerts (MessageBox-Äquivalent)
            DisplayAlert("Person:", $"{person.Name} ({person.Alter})", "Ok");
        }

        private void Btn_Altern_Clicked(object sender, EventArgs e)
        {
            //Zugriff auf Person-Objekt in BindingContext des StackLayouts
            Person person = Sly_DataBinding.BindingContext as Person;
            //Erhöhung des Alters (INotifyPropertyChanged informiert die GUI, vgl. Person.cs)
            person.Alter++;
        }

        private void Btn_Add_Clicked(object sender, EventArgs e)
        {
            //Zugriff auf Person-Objekt in BindingContext des StackLayouts
            Person person = Sly_DataBinding.BindingContext as Person;
            //Hinzufügen eines neuen Objekts zu der Liste (ObservableCollection informiert die GUI, vgl. Person.cs)
            person.WichtigeTage.Add(DateTime.Now);
        }

        private void Btn_Delete_Clicked(object sender, EventArgs e)
        {
            //Prüfung, ob in ListView ein Objekt ausgewählt wurde
            if (LstV_Tage.SelectedItem != null)
            {
                //Erfragen des zu löschenden Items über ListView.SelectedItem
                DateTime tag = (DateTime)LstV_Tage.SelectedItem;
                //Löschen des Items
                (Sly_DataBinding.BindingContext as Person).WichtigeTage.Remove(tag);
            }
        }

        private async void MItm_Delete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Löschen", "Möchtest du diesen Tag wirklich löschen?", "Ja", "Nein"))
                //Erfragen des zu löschenden Items über den Event-Sender und die CommandParameter-Eigenschaft sowie Löschung aus der Liste
                (Sly_DataBinding.BindingContext as Person).WichtigeTage.Remove((DateTime)(sender as MenuItem).CommandParameter);
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //löschen der kompletten Liste
            (Sly_DataBinding.BindingContext as Person).WichtigeTage.Clear();
        }

        //Navigationsbeispiele
        private void Btn_NavToGrid_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage 
            Navigation.PushAsync(new Übungen.U_GridLayout());
        }

        private void Btn_NavToAbsolute_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage, welche aber keine Navigationsleiste anzeigt
            Navigation.PushModalAsync(new Übungen.U_AbsoluteLayout());
        }

        private void Btn_NavToTabbed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationBsp.TabbedPageBsp());

            //Aufruf einer Shell-Route (nur in Shell möglich (vgl. NavigationBsp/AppShellBsp.xaml)
            //Shell.Current.GoToAsync("//flyout/tabbed");
        }

        private void Btn_NavToCarousel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationBsp.CarouselPageBsp());
        }

        private async void Btn_Flashlight_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Turn On
                await Flashlight.TurnOnAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
            }
        }

        private async void Btn_Youtube_Clicked(object sender, EventArgs e)
        {
            //Öffnen der Youtube-App über die Xamarin-Essentials mit Übergabe des Package-Namens
            if (await Launcher.CanOpenAsync("vnd.youtube://"))
                await Launcher.OpenAsync("vnd.youtube://rLKnqR9Oqh8");
        }

        //Bsp für Verwendung des MessagingCenters
        private void Btn_MCSender_Clicked(object sender, EventArgs e)
        {
            //Instanzieren des Empängerobjekts
            Page page = new MCSubscriberPage();
            //Senden der Nachricht mit Angabe des Senders, des Titels und des Inhalts
            MessagingCenter.Send(this, "Nachricht", Pkr_Namen.SelectedItem?.ToString());
            //Öffnen der Bsp-Seite
            Navigation.PushAsync(page);
        }
    }
}
