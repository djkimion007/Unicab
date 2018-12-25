using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarpoolDashboardPage : ContentPage
    {
        public List<CarpoolOffer> Items { get; set; }

        public CarpoolDashboardPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            CarpoolDashboardListView.ItemsSource = await App.CarpoolManager.GetAvailableCarpoolOffers();
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var carpoolOfferItem = e.SelectedItem as CarpoolOffer;
            var selectedCarpoolPage = new SelectedCarpoolPage(carpoolOfferItem)
            {
                BindingContext = carpoolOfferItem
            };

            await Navigation.PushAsync(selectedCarpoolPage);

        }

        private void OfferCarpoolFrameTapGesture_Tapped(object sender, EventArgs e)
        {
            DriverHomePage DvrHomePage = (DriverHomePage)App.Current.MainPage;
            DvrHomePage.Detail = new NavigationPage(new OfferCarpoolRidesPage());
            DvrHomePage.IsPresented = false;
        }
    }
}