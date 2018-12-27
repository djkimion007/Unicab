using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM.CR
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRFulfillmentsListPage : ContentPage
	{
        public ObservableCollection<CabRequestFulfillment> Items { get; set; }

        public CRFulfillmentsListPage()
        {
            InitializeComponent();

            FulfillmentCRListView.RefreshCommand = new Command(async () =>
            {
                await RefreshData();
                FulfillmentCRListView.IsRefreshing = false;
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

            await Navigation.PushAsync(new CRFulfillmentPage(e.Item as CabRequestFulfillment));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async Task RefreshData()
        {
            var CRFulfillmentsList = await App.CabManager.GetCabRequestFulfillmentsByPassengerId(App.CurrentPassenger.PassengerId);

            Items = new ObservableCollection<CabRequestFulfillment>(CRFulfillmentsList);

            FulfillmentCRListView.ItemsSource = Items;

        }
    }
}