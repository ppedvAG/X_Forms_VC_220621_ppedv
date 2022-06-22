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

namespace X_Forms.PersonenDb.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenueFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutMenueFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutMenueFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FlyoutMenueFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutMenueFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutMenueFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutMenueFlyoutMenuItem>(new[]
                {
                    new FlyoutMenueFlyoutMenuItem { Id = 0, Title = "Personenliste", TargetType=typeof(Pages.Pg_List) },
                    new FlyoutMenueFlyoutMenuItem { Id = 1, Title = "Neue Person", TargetType=typeof(Pages.Pg_Add) },
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