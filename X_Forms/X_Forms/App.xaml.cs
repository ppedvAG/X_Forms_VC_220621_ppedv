using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    public partial class App : Application
    {
        //Die App-Klasse beinhaltet eine grundlegen Initialisierung der App sowie die MainPage-Property, welche defniert,
        //welche Page gerade in der App angezeigt wird. Diese Property wird auch als Einstiegspunkt verwendet.
        public App()
        {
            InitializeComponent();

            //Zuweisung einer Page zu der MainPage-Property (Startseite)
            //MainPage = new MainPage();

            //Innerhalb einer NavigationPage kann die Property Page.Navigation verwendet werden, um die Page zu wechslen (vgl. MainPage.cs)
            //MainPage = new NavigationPage(new MainPage());

            MainPage = new NavigationBsp.FlyoutBsp.FlyoutPageBsp();

            //MainPage = new NavigationBsp.AppShellBsp();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
