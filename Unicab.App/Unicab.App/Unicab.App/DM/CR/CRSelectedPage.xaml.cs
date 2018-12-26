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

        public CRSelectedPage(CabRequest cabRequest)
        {
            InitializeComponent();
            selectedCabRequest = cabRequest;

            BindingContext = selectedCabRequest;

            FullName.Text = string.Format("{0} {1}", cabRequest.Passenger.FirstName, cabRequest.Passenger.LastName);

        }

        private async void AcceptRequestBtn_Clicked(object sender, EventArgs e)
        {
            bool confirmAccept = await DisplayAlert("Accept Request", "Are you sure you wish to accept this cab request? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (!confirmAccept)
                return;

            // accept the request

            bool requestAccepted = await App.CabManager.AcceptCabRequest(selectedCabRequest);

            if (requestAccepted)
                await DisplayAlert("Accept Request", "You have accepted this cab request, and a notification has been sent to the passenger. You will be reminded to fetch the passenger at the appointed schedule and location. Use the Cab Fulfillment feature upon completing the ride. Thank you.", "OK");
            else
                await DisplayAlert("Accept Request", "Sorry, there's an issue accepting the request. Please contact technical service. Thank you.", "OK");

            await Navigation.PopToRootAsync();

        }

    }
}