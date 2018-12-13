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

        private void NextButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void DriversLicensePhotoButton_Clicked(object sender, EventArgs e)
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

        private void CarInsuranceGrantPhotoButton_Clicked(object sender, EventArgs e)
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
    }
}