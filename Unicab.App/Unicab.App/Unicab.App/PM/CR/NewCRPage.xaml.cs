using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unicab.Api.Models;

namespace Unicab.App.PM.CR
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCRPage : ContentPage
	{
		public NewCRPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<Location> pickupLocationList = await App.LocationManager.GetStationLocationsAll();

            List<Location> dropoffLocationList = await App.LocationManager.GetStationLocationsAll();

            PickUpPicker.ItemsSource = pickupLocationList;
            DropOffPicker.ItemsSource = dropoffLocationList;
        }

        private async void RequestCabBtn_Clicked(object sender, EventArgs e)
        {
            string confirmBookingText = string.Format("Do you wish to confirm your cab request as follows:\n\nPickup Location: {0}\nDropoff Location: {1}\nPickup Date: {2:D}\nPickup Time: {3}\nNo. of Passengers: {4}\nLadies Only?: {5}\nAdditional Notes: {6}",
                (PickUpPicker.SelectedItem as Location).LocationName,
                (DropOffPicker.SelectedItem as Location).LocationName,
                PickUpDatePicker.Date.ToString("ddd, d MMM yyyy"),
                DateTime.Today.Add(PickUpTimePicker.Time).ToString("h:mm tt"),
                NoOfPassengersPicker.SelectedItem,
                LadiesOnlyPicker.SelectedItem,
                AdditionalNotesEditor.Text);

            bool confirmBooking = await DisplayAlert("Request Cab", confirmBookingText, "Yes", "No");

            if (confirmBooking)
            {
                // add operations to book a cab
                DateTime dateTime = PickUpDatePicker.Date + PickUpTimePicker.Time;

                CabRequest cabRequest = new CabRequest
                {
                    PickUpLocationId = (PickUpPicker.SelectedItem as Location).LocationId,
                    DropOffLocationId = (DropOffPicker.SelectedItem as Location).LocationId,
                    PickUpDateTime = dateTime,
                    NoOfPassengers = Convert.ToInt32(NoOfPassengersPicker.SelectedItem),
                    IsLadiesOnly = (LadiesOnlyPicker.SelectedItem.Equals("Yes")) ? true : false,
                    AdditionalNotes = AdditionalNotesEditor.Text,
                    PassengerId = App.CurrentPassenger.PassengerId
                };

                bool IsSubmitted = await App.CabManager.CreateNewCabRequest(cabRequest);

                if (IsSubmitted)
                    await DisplayAlert("Request Cab", "Your cab request is being processed. You will be notified once it is accepted by any of our drivers.", "OK");
                else
                    await DisplayAlert("Request Cab", "Your cab request could not be processed. Please contact technical support.", "OK");
            }
            else
            {
                await DisplayAlert("Request Cab", "You have not proceeded with your cab request.", "OK");
            }

            await Navigation.PopToRootAsync();
        }
    }
}