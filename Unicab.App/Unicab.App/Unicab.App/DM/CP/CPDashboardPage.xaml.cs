using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM.CP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CPDashboardPage : ContentPage
	{
        public ObservableCollection<CarpoolOffer> Items { get; set; }

        public CPDashboardPage()
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

            await Navigation.PushAsync(new CPSelectedPage(e.Item as CarpoolOffer));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async Task RefreshData()
        {
            var carpoolOffersList = await App.CarpoolManager.GetAvailableCarpoolOffersByDriverId(App.CurrentDriver.DriverId);

            Items = new ObservableCollection<CarpoolOffer>(carpoolOffersList);

            YourCPListView.ItemsSource = Items;
        }
    }
}