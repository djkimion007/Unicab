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
        private CabRequest selectedCabRequest;

        public CRSelectedPage(CabRequest selectedRequest)
        {
            InitializeComponent();

            selectedCabRequest = selectedRequest;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Title = string.Format("{0}", selectedCabRequest.DropOffLocation.LocationName);

            DrivingFromLabel.Text = selectedCabRequest.PickUpLocation.LocationName;
            DrivingToLabel.Text = selectedCabRequest.DropOffLocation.LocationName;
            DepartingDateLabel.Text = selectedCabRequest.PickUpDateTime.ToLongDateString();
            DepartingTimeLabel.Text = selectedCabRequest.PickUpDateTime.ToShortTimeString();
            NoOfSeatsLabel.Text = selectedCabRequest.NoOfPassengers.ToString();
            LadiesOnlyLabel.Text = (selectedCabRequest.IsLadiesOnly) ? "Yes" : "No";
            AdditionalNotesLabel.Text = selectedCabRequest.AdditionalNotes;

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