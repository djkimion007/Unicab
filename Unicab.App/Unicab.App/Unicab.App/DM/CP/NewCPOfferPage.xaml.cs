using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Unicab.App.CM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM.CP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCPOfferPage : ContentPage
    {
        public NewCPOfferPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<Location> pickupLocationList = await App.LocationManager.GetStationLocationsAll();

            List<Location> dropoffLocationList = await App.LocationManager.GetStationLocationsAll();

            DrivingFromPicker.ItemsSource = pickupLocationList;
            DrivingToPicker.ItemsSource = dropoffLocationList;
        }

        private async void OfferCarpoolBtn_Clicked(object sender, EventArgs e)
        {
            string confirmBookingText = string.Format("Do you wish to confirm your carpool offer as follows:\n\nDriving From: {0}\nDriving To: {1}\nDeparting Date: {2:D}\nDeparting Time: {3}\nNo. of Seats: {4}\nLadies Only?: {5}\nAdditional Notes: {6}",
                DrivingFromPicker.SelectedItem,
                DrivingToPicker.SelectedItem,
                DepartingDatePicker.Date.ToString("ddd, d MMM yyyy"),
                DateTime.Today.Add(DepartingTimePicker.Time).ToString("h:mm tt"),
                NoOfSeatsPicker.SelectedItem,
                LadiesOnlyPicker.SelectedItem,
                AdditionalNotesEditor.Text);

            bool confirmBooking = await DisplayAlert("Offer Carpool", confirmBookingText, "Yes", "No");

            if (confirmBooking)
            {

                DateTime dateTime = DepartingDatePicker.Date + DepartingTimePicker.Time;

                CarpoolOffer carpoolOffer = new CarpoolOffer
                {
                    DestinationLocation = Convert.ToString(DrivingToPicker.SelectedItem),
                    OriginLocation = Convert.ToString(DrivingFromPicker.SelectedItem),
                    OriginDateTime = dateTime,
                    NoOfPassengers = Convert.ToInt32(NoOfSeatsPicker.SelectedItem),
                    IsLadiesOnly = (LadiesOnlyPicker.SelectedItem.Equals("Yes")) ? true : false,
                    AdditionalNotes = AdditionalNotesEditor.Text,

                    DriverId = App.CurrentDriver.DriverId
                };

                bool IsSubmitted = await App.CarpoolManager.CreateNewCarpoolOffer(carpoolOffer);

                if (IsSubmitted)
                    await DisplayAlert("Offer Carpool", "Your carpool offer is being processed. You will be notified once it is accepted by any of our passengers.", "OK");
                else
                    await DisplayAlert("Offer Carpool", "Your carpool offer could not be processed. Please contact technical support.", "OK");

            }
            else
            {
                await DisplayAlert("Offer Carpool", "You have not proceeded with your carpool offer.", "OK");
            }

            await Navigation.PopToRootAsync();
        }

    }

}