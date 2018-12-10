using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DriverModule
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedRideHistoryPage : ContentPage
	{
		public SelectedRideHistoryPage (CabRequest CabRequest)
		{
			InitializeComponent ();

            this.Title = string.Format("{0} {1} {2}", CabRequest.PickUpLocation, char.ConvertFromUtf32(0x2197), CabRequest.DropOffLocation);

            StatusLabel.Text = "ON SCHEDULE";
            RideFromLabel.Text = CabRequest.PickUpLocation;
            RideToLabel.Text = CabRequest.DropOffLocation;
            PickupDateLabel.Text = CabRequest.PickUpDateTime.ToLongDateString();
            PickupTimeLabel.Text = CabRequest.PickUpDateTime.ToShortTimeString();
            NoOfSeatsLabel.Text = CabRequest.NoOfPassengers.ToString();
            LadiesOnlyLabel.Text = (CabRequest.IsLadiesOnly) ? "Yes" : "No";
            AdditionalNotesLabel.Text = CabRequest.AdditionalNotes;
        }
        private async void CallPassengerBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Call Passenger", "Are you sure you wish to call this passenger? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Call Passenger", "Not implemented yet, sorry.", "OK");
            }
            else
            {

            }
        }

        private async void MessagePassengerBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Message Passenger", "Are you sure you wish to message this passenger? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Message Passenger", "Not implemented yet, sorry.", "OK");

            }
            else
            {

            }
        }

    }
}