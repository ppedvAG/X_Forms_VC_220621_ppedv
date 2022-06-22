using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MCSubscriberPage : ContentPage
    {
        public MCSubscriberPage()
        {
            InitializeComponent();
            //Anmelden an MessaginCenter für eine Nachricht namens "Nachricht" von einem "Hauptseite"-Objekt.
            //Bei Ankunft wird Methode "CallBack" ausgeführt
            MessagingCenter.Subscribe<MainPage, string>(this, "Nachricht", Callback);
        }

        private void Callback(MainPage sender, string inhalt)
        {
            //Übertragen des Nachrichten-Inhalts in das Label
            Lbl_Main.Text = inhalt;
        }
    }
}