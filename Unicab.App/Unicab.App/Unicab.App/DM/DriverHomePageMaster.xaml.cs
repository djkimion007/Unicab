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

namespace Unicab.App.DM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverHomePageMaster : ContentPage
    {
        public ListView ListView;

        public DriverHomePageMaster()
        {
            InitializeComponent();

            BindingContext = new DriverHomePageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class DriverHomePageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DriverHomePageMenuItem> MenuItems { get; set; }
            
            public DriverHomePageMasterViewModel()
            {
                MenuItems = new ObservableCollection<DriverHomePageMenuItem>(new[]
                {
                    new DriverHomePageMenuItem { Id = 0, Title = "Home", TargetType = typeof(DriverDashboardPage) },
                    new DriverHomePageMenuItem { Id = 1, Title = "Available Cab Requests", TargetType = typeof(AvailableCabRequestsPage) },
                    new DriverHomePageMenuItem { Id = 2, Title = "Offer Carpool Rides", TargetType = typeof(OfferCarpoolRidesPage) },
                    new DriverHomePageMenuItem { Id = 3, Title = "Fare Table", TargetType = typeof(DriverFareTablePage) },
                    new DriverHomePageMenuItem { Id = 4, Title = "History", TargetType = typeof(DriverHistoryPage) },

                    new DriverHomePageMenuItem { Id = 99, Title = "Log Out", TargetType = null }
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

        private void ProfileTapper_Tapped(object sender, EventArgs e)
        {
            DriverHomePage DvrHomePage = (DriverHomePage)App.Current.MainPage;
            DvrHomePage.Detail = new NavigationPage(new DriverProfilePage()) {
                BarBackgroundColor = Color.Teal,
                BarTextColor = Color.White
            };
            DvrHomePage.IsPresented = false;

        }
    }
}