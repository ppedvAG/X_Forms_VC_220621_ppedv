using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.NavigationBsp.FlyoutBsp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageBsp : FlyoutPage
    {
        public FlyoutPageBsp()
        {
            InitializeComponent();
            //Eventzuordnung (unten stehende Methode zu ItemSelected-Event des Flyouts (vgl. FlyoutNavigationBspFlyout.xaml)
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutPageBspFlyoutMenuItem;
            if (item == null)
                return;

            //Instanziierung der 'neuen' Page
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            //Aufruf der neuen Page
            Detail = new NavigationPage(page);
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}