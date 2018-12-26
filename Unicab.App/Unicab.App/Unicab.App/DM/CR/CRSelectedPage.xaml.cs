using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unicab.Api.Models;

namespace Unicab.App.DM.CR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRSelectedPage : ContentPage
    {
        public CRSelectedPage(CabRequest selectedRequest)
        {
            InitializeComponent();

            this.Title = string.Format("{0} {1} {2}", selectedRequest.PickUpLocation, char.ConvertFromUtf32(0x2197), selectedRequest.DropOffLocation);

            DrivingFromLabel.Text = selectedRequest.PickUpLocation;
            DrivingToLabel.Text = selectedRequest.DropOffLocation;
            DepartingDateLabel.Text = selectedRequest.PickUpDateTime.ToLongDateString();
            DepartingTimeLabel.Text = selectedRequest.PickUpDateTime.ToShortTimeString();
            NoOfSeatsLabel.Text = selectedRequest.NoOfPassengers.ToString();
            LadiesOnlyLabel.Text = (selectedRequest.IsLadiesOnly) ? "Yes" : "No";
            AdditionalNotesLabel.Text = selectedRequest.AdditionalNotes;

        }

        private async void AcceptRequestBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Accept Request", "Are you sure you wish to accept this cab request? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Accept Request", "You have accepted this cab request, and a notification has been sent to the passenger. You will be reminded to fetch the passenger at the appointed schedule and location. Thank you.", "OK");

                await Navigation.PopAsync();
            }
            else
            {

            }

        }

        private async void MessagePassengerBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Message Passenger", "Are you sure you wish to message the passenger regarding this cab request? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Message Passenger", "Not implemented yet, sorry.", "OK");

                //await Navigation.PopAsync();
            }
            else
            {

            }
        }

        private async void CallPassengerBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Call Passenger", "Are you sure you wish to call the passenger regarding this cab request? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Call Passenger", "Not implemented yet, sorry.", "OK");

                //await Navigation.PopAsync();
            }
            else
            {

            }
        }
    }
}