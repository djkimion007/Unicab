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
	public partial class CPDashboardPage : ContentPage
	{
        public ObservableCollection<CarpoolOffer> Items { get; set; }

        bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        public CPDashboardPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var carpoolOffersList = await LoadItemsAsync();

            Items = new ObservableCollection<CarpoolOffer>(carpoolOffersList);

            YourCPListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new CPSelectedPage(e.Item as CarpoolOffer));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async Task<List<CarpoolOffer>> LoadItemsAsync()
        {
            List<CarpoolOffer> items = null;
            try
            {
                IsLoading = true;

                // Call your web service here
                items = await App.CarpoolManager.GetAvailableCarpoolOffersByDriverId(App.CurrentDriver.DriverId);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsLoading = false;
            }

            return items;
        }
    }
}