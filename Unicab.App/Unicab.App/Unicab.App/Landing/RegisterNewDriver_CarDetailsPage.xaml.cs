using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        private byte[] DriversLicensePhotoCapture { get; set; }
        private byte[] CarInsuranceGrantPhotoCapture { get; set; }
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

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void DriversLicensePhotoButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera detected.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                CustomPhotoSize = 10,
                SaveToAlbum = true,
                Directory = "Unicab Service"
            });

            if (file == null)
                return;

            DriversLicensePhotoCapture = File.ReadAllBytes(file.Path);
            DriversLicensePhotoButton.Text = "Driver's License Photo Added!";
        }

        private async void CarInsuranceGrantPhotoButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera detected.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                CustomPhotoSize = 10,
                SaveToAlbum = true,
                Directory = "Unicab Service"
            });

            if (file == null)
                return;

            CarInsuranceGrantPhotoCapture = File.ReadAllBytes(file.Path);
            CarInsuranceGrantPhotoButton.Text = "Car Insurance Grant Photo Added!";
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            SubmitButton.Text = "Submitting ...";
            SubmitButton.IsEnabled = false;

            if (!string.IsNullOrEmpty(CarPlateNoEntry.Text)
                || !string.IsNullOrEmpty(CarMakeEntry.Text)
                || !string.IsNullOrEmpty(CarModelEntry.Text)
                || !string.IsNullOrEmpty(CarMakeYearEntry.Text)
                || !string.IsNullOrEmpty(CarColourEntry.Text)
                || DriversLicensePhotoCapture != null
                || DriversLicensePhotoCapture.Length != 0
                || CarInsuranceGrantPhotoCapture != null
                || CarInsuranceGrantPhotoCapture.Length != 0)
            {
                driverApplicant.DriversLicenseDueDate = DriversLicenseDueDatePicker.Date;
                driverApplicant.DriversLicensePhoto = DriversLicensePhotoCapture;
                driverApplicant.CarPlateNo = CarPlateNoEntry.Text;
                driverApplicant.CarMake = CarMakeEntry.Text;
                driverApplicant.CarModel = CarModelEntry.Text;
                driverApplicant.CarMakeYear = CarMakeYearEntry.Text;
                driverApplicant.CarColour = CarColourEntry.Text;
                driverApplicant.CarRoadTaxDueDate = CarRoadTaxDueDatePicker.Date;
                driverApplicant.CarInsuranceGrantPhoto = CarInsuranceGrantPhotoCapture; 
            }

            HttpStatusCode statusCode = await App.CredentialsManager.TryDriverSignUp(driverApplicant);

            if (statusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Driver Sign Up", "Sign up successful. Kindly wait for admin approval before using the service. Thank you.", "OK");
            }
            else
            {
                await DisplayAlert("Driver Sign Up", "Sign up failed. Please try again. (status code: " + statusCode.ToString() + ")", "OK");
            }

            await Navigation.PopToRootAsync();
        }
    }
}