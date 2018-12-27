using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM.CP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CPFulfillmentListPage : ContentPage
	{
        public ObservableCollection<CarpoolOfferFulfillment> Items { get; set; }

        public CPFulfillmentListPage()
        {
            InitializeComponent();

            YourCPListView.RefreshCommand = new Command(async () =>
            {
                await RefreshData();
                YourCPListView.IsRefreshing = false;
            });

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            await RefreshData();

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new CPFulfillmentPage(e.Item as CarpoolOfferFulfillment));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async Task RefreshData()
        {
            var carpoolOffersList = await App.CarpoolManager.GetAvailableCarpoolOfferFulfillmentsByDriverId(App.CurrentDriver.DriverId);

            Items = new ObservableCollection<CarpoolOfferFulfillment>(carpoolOffersList);

            YourCPListView.ItemsSource = Items;
        }
    }
}