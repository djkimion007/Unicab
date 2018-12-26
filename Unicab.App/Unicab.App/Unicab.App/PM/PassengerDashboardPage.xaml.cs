using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PassengerDashboardPage : ContentPage
	{
        public ObservableCollection<CabRequest> Items { get; set; }

        public PassengerDashboardPage ()
		{
			InitializeComponent ();

            //Items = new ObservableCollection<CabRequest>
            //{
            //    new CabRequest
            //    {
            //        PickUpLocation = "USM",
            //        DropOffLocation = "KL",
            //        PickUpDateTime = new DateTime(2018, 12, 1, 6, 0, 0),
            //        NoOfPassengers = 4,
            //        IsLadiesOnly = false,
            //        AdditionalNotes = "Carrying two luggages"

            //    },
            //    new CabRequest
            //    {
            //        PickUpLocation = "KL",
            //        DropOffLocation = "USM",
            //        PickUpDateTime = new DateTime(2018, 12, 6, 13, 30, 0),
            //        NoOfPassengers = 4,
            //        IsLadiesOnly = false,
            //        AdditionalNotes = "Extra space for a luggage"

            //    },
            //    new CabRequest
            //    {
            //        PickUpLocation = "USM",
            //        DropOffLocation = "Ipoh",
            //        PickUpDateTime = new DateTime(2018, 12, 9, 15, 10, 0),
            //        NoOfPassengers = 2,
            //        IsLadiesOnly = false,
            //        AdditionalNotes = "Carrying musical instruments"

            //    },
            //    new CabRequest
            //    {
            //        PickUpLocation = "Kampar",
            //        DropOffLocation = "George Town",
            //        PickUpDateTime = new DateTime(2018, 12, 12, 10, 0, 0),
            //        NoOfPassengers = 4,
            //        IsLadiesOnly = false,
            //        AdditionalNotes = "Bring warm jacket"

            //    },
            //    new CabRequest
            //    {
            //        PickUpLocation = "USM",
            //        DropOffLocation = "KL",
            //        PickUpDateTime = new DateTime(2018, 12, 23, 9, 30, 0),
            //        NoOfPassengers = 4,
            //        IsLadiesOnly = false,
            //        AdditionalNotes = "Christmas trip"

            //    }
            //};

            //DashboardListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //await Navigation.PushAsync(new SelectedUpcomingRidePage(e.Item as CabRequest));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void RequestCabFrameTapGesture_Tapped(object sender, EventArgs e)
        {
            PassengerHomePage PgrHomePage = (PassengerHomePage)App.Current.MainPage;
            //PgrHomePage.Detail = new NavigationPage(new RequestCabPage());
            PgrHomePage.IsPresented = false;
        }

        private void AvailableCarpoolFrameTapGesture_Tapped(object sender, EventArgs e)
        {
            PassengerHomePage PgrHomePage = (PassengerHomePage)App.Current.MainPage;
            //PgrHomePage.Detail = new NavigationPage(new AvailableCarpoolPage());
            PgrHomePage.IsPresented = false;
        }
    }
}