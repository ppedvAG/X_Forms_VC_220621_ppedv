using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //Codeseitige Veränderung einer Ressource in der App.xaml (bzw hier im ResourceDictionary, das in der App.xaml angemeldet ist-->
            Application.Current.Resources["GlobalFontSize"] = 25.0;

            InitializeComponent();

            (this.Content as StackLayout).Resources["BtnString"] = "Neuer String";
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            Lbl_Output.Text = "Glückwunsch";

            (sender as Button).Text = "Button wurde geklickt";
        }

        private void Ent_Input_Completed(object sender, EventArgs e)
        {
            Lbl_Output.Text = Ent_Input.Text;
        }

        //EventHandler eines Slider-ValueChanged-Events (reagiert auf Wert-Veränderung in Slider.Value)
        private void Sdr_Wert_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Sdr_Wert.Value = Math.Round(Sdr_Wert.Value);
        }

        private void IBtn_Beispiel_Clicked(object sender, EventArgs e)
        {
            Ent_Input.Text = Pkr_Names.SelectedItem?.ToString();
        }

        private void Btn_Show_Clicked(object sender, EventArgs e)
        {
            Person person = Sly_DataBinding.BindingContext as Person;
            DisplayAlert("Person:", $"{person.Name} ({person.Alter})", "Ok");
        }

        private void Btn_Altern_Clicked(object sender, EventArgs e)
        {
            Person person = Sly_DataBinding.BindingContext as Person;
            person.Alter++;
        }

        private void Btn_Add_Clicked(object sender, EventArgs e)
        {
            Person person = Sly_DataBinding.BindingContext as Person;
            person.WichtigeTage.Add(DateTime.Now);
        }

        private void Btn_Delete_Clicked(object sender, EventArgs e)
        {
            if (LstV_Tage.SelectedItem != null)
            {
                DateTime tag = (DateTime)LstV_Tage.SelectedItem;
                (Sly_DataBinding.BindingContext as Person).WichtigeTage.Remove(tag);
            }
        }

        private async void MItm_Delete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Löschen", "Möchtest du diesen Tag wirklich löschen?", "Ja", "Nein"))
                (Sly_DataBinding.BindingContext as Person).WichtigeTage.Remove((DateTime)(sender as MenuItem).CommandParameter);
        }
    }
}
