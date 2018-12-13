using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.Landing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterNewDriver_CarDetailsPage : ContentPage
    {
        private DriverApplicant driverApplicant;

        public RegisterNewDriver_CarDetailsPage(DriverApplicant applicant)
        {
            InitializeComponent();

            driverApplicant = applicant;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void DriversLicensePhotoButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}