using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unicab.Api.Models;

namespace Unicab.App.DriverModule
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvailableCabRequestsPage : ContentPage
    {
        public ObservableCollection<CarpoolOffer> Items { get; set; }

        public AvailableCabRequestsPage()
        {
            InitializeComponent();

            // Dummy data
            Items = new ObservableCollection<CarpoolOffer>
            {
                new CarpoolOffer
                {
                    OriginLocation = "USM",
                    DestinationLocation = "KL",
                    OriginDateTime = new DateTime(2018, 12, 1, 6, 0, 0),
                    NoOfPassengers = 4,
                    IsLadiesOnly = false,
                    AdditionalNotes = "Carrying two luggages"

                },
                new CarpoolOffer
                {
                    OriginLocation = "KL",
                    DestinationLocation = "USM",
                    OriginDateTime = new DateTime(2018, 12, 6, 13, 30, 0),
                    NoOfPassengers = 4,
                    IsLadiesOnly = false,
                    AdditionalNotes = "Extra space for a luggage"

                },
                new CarpoolOffer
                {
                    OriginLocation = "USM",
                    DestinationLocation = "Ipoh",
                    OriginDateTime = new DateTime(2018, 12, 9, 15, 10, 0),
                    NoOfPassengers = 2,
                    IsLadiesOnly = false,
                    AdditionalNotes = "Carrying musical instruments"

                },
                new CarpoolOffer
                {
                    OriginLocation = "Kampar",
                    DestinationLocation = "George Town",
                    OriginDateTime = new DateTime(2018, 12, 12, 10, 0, 0),
                    NoOfPassengers = 4,
                    IsLadiesOnly = false,
                    AdditionalNotes = "Bring warm jacket"

                },
                new CarpoolOffer
                {
                    OriginLocation = "USM",
                    DestinationLocation = "KL",
                    OriginDateTime = new DateTime(2018, 12, 23, 9, 30, 0),
                    NoOfPassengers = 4,
                    IsLadiesOnly = false,
                    AdditionalNotes = "Christmas trip"

                }

            };

            CabRequestsListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new SelectedCabRequestPage((CarpoolOffer)e.Item));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
