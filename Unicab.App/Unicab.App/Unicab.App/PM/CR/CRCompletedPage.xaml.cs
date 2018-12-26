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
	public partial class CRCompletedPage : ContentPage
	{
        private CabRequest fulfillment;
		public CRCompletedPage (CabRequest cabRequest)
		{
			InitializeComponent ();
            fulfillment = cabRequest;

            BindingContext = fulfillment;
		}

        private async void NotCompletedBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void CompletedBtn_Clicked(object sender, EventArgs e)
        {
            bool confirmCompleted = await DisplayAlert("Complete Cab Ride", "Confirm completion of cab ride?", "Yes", "No");

            if (!confirmCompleted)
                return;

            // perform completion

            bool completedSuccess = await App.CabManager.CompleteCabRequestPassengerSide(fulfillment);

            if (completedSuccess)
                await DisplayAlert("Complete Cab Ride", "Your cab ride has been completed. Thank you for using Unicab Service!", "OK");
            else
                await DisplayAlert("Complete Cab Ride", "There's an issue completing your ride, or the driver has yet to initiate ride completion.", "OK");

            await Navigation.PopToRootAsync();
        }
    }
}