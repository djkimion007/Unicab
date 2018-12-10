using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PassengerModule
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedDriverPage : ContentPage
    {
        public SelectedDriverPage(Driver driver)
        {
            InitializeComponent();

            this.Title = string.Format("{0} {1}", driver.FirstName, driver.LastName);

            FullNameLabel.Text = string.Format("{0} {1}", driver.FirstName, driver.LastName);
            VehiclePlateNoLabel.Text = driver.CarPlateNo;
            RoadTaxExpiryLabel.Text = "null";
            VehicleMakeLabel.Text = driver.CarMake;
            VehicleModelLabel.Text = driver.CarModel;
            EmailAddressLabel.Text = driver.EmailAddress;
            PhoneNumberLabel.Text = "null";


        }

        private async void CallDriverBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Call Driver", "Are you sure you wish to call this driver? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (continueNextSteps)
            {
                await DisplayAlert("Call Driver", "Not implemented yet, sorry.", "OK");

                //await Navigation.PopAsync();
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

                //await Navigation.PopAsync();
            }
            else
            {

            }
        }
    }
}