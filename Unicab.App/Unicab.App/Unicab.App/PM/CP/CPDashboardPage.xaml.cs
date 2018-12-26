using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unicab.Api.Models;

namespace Unicab.App.PM.CP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CPDashboardPage : ContentPage
    {
        public ObservableCollection<CarpoolOffer> Items { get; set; }

        public CPDashboardPage()
        {
            InitializeComponent();

            AvailableCPListView.RefreshCommand = new Command(async () =>
            {
                await RefreshData();
                AvailableCPListView.IsRefreshing = false;
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
            var carpoolOffersList = await App.CarpoolManager.GetAvailableCarpoolOffers();

            Items = new ObservableCollection<CarpoolOffer>(carpoolOffersList);

            AvailableCPListView.ItemsSource = Items;
        }
    }
}
