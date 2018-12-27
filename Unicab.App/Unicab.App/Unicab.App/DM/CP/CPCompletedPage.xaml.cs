using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM.CP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CPCompletedPage : ContentPage
	{
        private CarpoolOfferFulfillment CPFulfillment;

        public CPCompletedPage(CarpoolOfferFulfillment carpoolOfferFulfillment)
        {
            InitializeComponent();

            CPFulfillment = carpoolOfferFulfillment;

            BindingContext = CPFulfillment.CarpoolOffer;

        }

        private async void NotCompletedBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void CompletedBtn_Clicked(object sender, EventArgs e)
        {
            bool confirmCompleted = await DisplayAlert("Complete Carpool Ride", "Confirm completion of carpool ride?", "Yes", "No");

            if (!confirmCompleted)
                return;

            //perform completion

            bool completedSuccess = await App.CarpoolManager.CompleteCarpoolOfferDriverSide(CPFulfillment);

            if (completedSuccess)
                await DisplayAlert("Complete Carpool Ride", "Your carpool ride has been completed. Thank you for using Unicab Service!", "OK");
            else
                await DisplayAlert("Complete Carpool Ride", "Oops, some technical issue, kindly contact technical service.", "OK");

            await Navigation.PopToRootAsync();
        }
    }
}