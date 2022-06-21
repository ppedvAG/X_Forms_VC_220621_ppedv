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
            Application.Current.Resources["GlobalFontSize"] = 25.0;

            InitializeComponent();

            Sly_Main.Resources["BtnString"] = "Neuer String";            
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

        private void IBtn_Beispiel_Clicked(object sender, EventArgs e)
        {
            Ent_Input.Text = Pkr_Names.SelectedItem?.ToString();
        }
    }
}
