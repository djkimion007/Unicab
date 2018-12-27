using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM.CP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CPFulfillmentPage : ContentPage
	{
        public CarpoolOfferFulfillment selectedCPFulfillment { get; set; }

        public CPFulfillmentPage(CarpoolOfferFulfillment fulfillment)
        {
            InitializeComponent();

            selectedCPFulfillment = fulfillment;

            BindingContext = fulfillment.CarpoolOffer;

            FullName.Text = string.Format("{0} {1}", fulfillment.CarpoolOffer.Driver.FirstName, fulfillment.CarpoolOffer.Driver.LastName);

        }

        private async void CompleteRideBtn_Clicked(object sender, EventArgs e)
        {
            bool confirmAccept = await DisplayAlert("Complete Carpool Ride", "Complete this carpool ride?", "Yes", "No");
            if (!confirmAccept)
                return;

            // accept the request

            await Navigation.PushAsync(new CPCompletedPage(selectedCPFulfillment));
        }
    }
}