using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedRideHistoryPage : ContentPage
	{
		public SelectedRideHistoryPage (CabRequest upcomingRide)
		{
			InitializeComponent ();

            this.Title = string.Format("{0} {1} {2}", upcomingRide.PickUpLocation, char.ConvertFromUtf32(0x2197), upcomingRide.DropOffLocation);

            StatusLabel.Text = "ON SCHEDULE";
            RideFromLabel.Text = upcomingRide.PickUpLocation;
            RideToLabel.Text = upcomingRide.DropOffLocation;
            PickupDateLabel.Text = upcomingRide.PickUpDateTime.ToLongDateString();
            PickupTimeLabel.Text = upcomingRide.PickUpDateTime.ToShortTimeString();
            NoOfSeatsLabel.Text = upcomingRide.NoOfPassengers.ToString();
            LadiesOnlyLabel.Text = (upcomingRide.IsLadiesOnly) ? "Yes" : "No";
            AdditionalNotesLabel.Text = upcomingRide.AdditionalNotes;
        }
        private async void CallDriverBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Call Driver", "Are you sure you wish to call this driver? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Message Driver", "Not implemented yet, sorry.", "OK");
            }
            else
            {

            }
        }

        private async void MessageDriverBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Message Driver", "Are you sure you wish to message this driver? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Message Driver", "Not implemented yet, sorry.", "OK");

            }
            else
            {

            }
        }

    }
}