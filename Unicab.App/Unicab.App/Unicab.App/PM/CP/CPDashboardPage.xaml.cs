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

        public CPDashboardPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            AvailableCarpoolListView.ItemsSource = await App.CarpoolManager.GetAvailableCarpoolOffers();
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var carpoolOfferItem = e.SelectedItem as CarpoolOffer;
            var selectedCarpoolPage = new CPSelectedPage(carpoolOfferItem)
            {
                BindingContext = carpoolOfferItem
            };

            await Navigation.PushAsync(selectedCarpoolPage);

        }
    }
}
