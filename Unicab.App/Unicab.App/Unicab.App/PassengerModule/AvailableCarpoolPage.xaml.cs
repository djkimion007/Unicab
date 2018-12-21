using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unicab.Api.Models;

namespace Unicab.App.PassengerModule
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvailableCarpoolPage : ContentPage
    {

        public AvailableCarpoolPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            AvailableCarpoolListView.ItemsSource = await App.CarpoolManager.TryGetAvailableCarpoolOffers();
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
    }
}
