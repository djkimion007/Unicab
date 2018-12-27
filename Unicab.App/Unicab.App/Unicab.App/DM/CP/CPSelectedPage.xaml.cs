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
	public partial class CPSelectedPage : ContentPage
	{
        private CarpoolOffer selectedOffer;

		public CPSelectedPage (CarpoolOffer carpoolOffer)
		{
			InitializeComponent ();

            BindingContext = carpoolOffer;

            selectedOffer = carpoolOffer;

            FullName.Text = string.Format("{0} {1}", carpoolOffer.Driver.FirstName, carpoolOffer.Driver.LastName);

		}

        private async void CancelOfferBtn_Clicked(object sender, EventArgs e)
        {
            bool confirmCancel = await DisplayAlert("Cancel Offer", "Are you sure you wish to cancel this carpool offer?", "Yes", "No");
            if (!confirmCancel)
                return;

            bool cancelSuccess = await App.CarpoolManager.CancelCarpoolOffer(selectedOffer.CarpoolOfferId);

            if (cancelSuccess)
                await DisplayAlert("Cancel Offer", "You have cancelled your carpool offer.", "OK");
            else
                await DisplayAlert("Cancel Offer", "Something's wrong with cancelling your carpool offer. Please contact technical service.", "OK");
        }

    }
}