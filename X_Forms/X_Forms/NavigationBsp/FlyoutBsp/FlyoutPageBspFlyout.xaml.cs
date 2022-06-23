using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.NavigationBsp.FlyoutBsp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageBspFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPageBspFlyout()
        {
            InitializeComponent();

            //Zuordnung des BindingContexts (damit die Bindung der ListViews funktioniert)
            BindingContext = new FlyoutPageBspFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        //Genestete Klasse als Context-Objekt dieser ContextPage
        private class FlyoutPageBspFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPageBspFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPageBspFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPageBspFlyoutMenuItem>(new[]
                {
                    //Definition der beinhaltenden Menüitems, TargetType gibt die Klasse der 'neuen' Pages an
                    new FlyoutPageBspFlyoutMenuItem { Id = 0, Title = "MainPage", TargetType=typeof(MainPage) },
                    new FlyoutPageBspFlyoutMenuItem { Id = 1, Title = "TabbedBsp", TargetType=typeof(NavigationBsp.TabbedPageBsp) },
                    new FlyoutPageBspFlyoutMenuItem { Id = 2, Title = "GridÜbung", TargetType=typeof(Übungen.U_GridLayout) },
                    new FlyoutPageBspFlyoutMenuItem { Id = 3, Title = "PersonenDb", TargetType=typeof(PersonenDb.Nav.FlyoutMenue) },
                    new FlyoutPageBspFlyoutMenuItem { Id = 4, Title = "MVVM", TargetType=typeof(MVVM.View.FahrzeugView) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}