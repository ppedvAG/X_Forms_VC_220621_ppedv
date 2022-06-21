using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbsoluteLayoutBsp : ContentPage
    {
        public AbsoluteLayoutBsp()
        {
            InitializeComponent();
        }

        private void Btn_Box_Clicked(object sender, EventArgs e)
        {
            //Der Zugriff auf AttachedProperties (Eigenschaften, welche von Lyaoutcontainern an Controls verteilt werden) erfolgt über statische
            //Methoden der Container-Klasse
            AbsoluteLayout.SetLayoutBounds(Bxv_Green, new Rectangle(200, 300, 200, 300));

            (sender as Button).Text = AbsoluteLayout.GetLayoutBounds(Bxv_Green).X.ToString();
        }
    }
}