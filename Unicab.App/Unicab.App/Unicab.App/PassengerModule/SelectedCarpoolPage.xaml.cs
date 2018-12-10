using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unicab.Api.Models;

namespace Unicab.App.PassengerModule
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedCarpoolPage : ContentPage
	{
		public SelectedCarpoolPage (CarpoolOffer selectedOffer)
		{
			InitializeComponent ();

            this.Title = string.Format("{0} {1} {2}", selectedOffer.OriginLocation, char.ConvertFromUtf32(0x2197), selectedOffer.DestinationLocation);

            DrivingFromLabel.Text = selectedOffer.OriginLocation;
            DrivingToLabel.Text = selectedOffer.DestinationLocation;
            DepartingDateLabel.Text = selectedOffer.OriginDateTime.ToLongDateString();
            DepartingTimeLabel.Text = selectedOffer.OriginDateTime.ToShortTimeString();
            NoOfSeatsLabel.Text = selectedOffer.NoOfPassengers.ToString();
            LadiesOnlyLabel.Text = (selectedOffer.IsLadiesOnly) ? "Yes" : "No";
            AdditionalNotesLabel.Text = selectedOffer.AdditionalNotes;

		}

        private async void AcceptCarpoolBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Accept Carpool", "Are you sure you wish to accept this carpool offer? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Accept Carpool", "You have accepted this carpool offer. Kindly wait for driver's confirmation. Thank you.", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                
            }
            
        }

        private async void MessageDriverBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Message Driver", "Are you sure you wish to message the driver regarding this carpool offer? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Message Driver", "Not implemented yet, sorry.", "OK");

                //await Navigation.PopAsync();
            }
            else
            {

            }
        }

        private async void CallDriverBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Call Driver", "Are you sure you wish to call the driver regarding this carpool offer? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Call Driver", "Not implemented yet, sorry.", "OK");

                //await Navigation.PopAsync();
            }
            else
            {

            }
        }
    }
}