using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM.CR
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRSelectedPage : ContentPage
	{
        private CabRequest selectedRequest = null;

		public CRSelectedPage (CabRequest cabRequest)
		{
			InitializeComponent ();

            selectedRequest = cabRequest;

            BindingContext = selectedRequest;

        }

        private async void CancelRequestBtn_Clicked(object sender, EventArgs e)
        {
            bool confirmCancel = await DisplayAlert("Cancel Cab Request", "Are you sure you wish to cancel your cab request?", "Yes", "No");

            if (!confirmCancel)
                return;

            // perform cancellation

            bool cancelSuccess = await App.CabManager.CancelCabRequestByPassenger(selectedRequest);

            if (cancelSuccess)

                await DisplayAlert("Cancel Cab Request", "You have cancelled your cab request.", "OK");

            else
                await DisplayAlert("Cancel Cab Request", "There's an issue cancelling your cab request. Kindly contact technical service.", "OK");

            await Navigation.PopToRootAsync();
        }

    }
}