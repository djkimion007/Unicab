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
    public partial class RegisterNewDriver_MainPage : ContentPage
    {
        private byte[] MatricsCardPhotoCapture { get; set; }

        public RegisterNewDriver_MainPage()
        {
            InitializeComponent();
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(emailEntry.Text)
                || !string.IsNullOrEmpty(matricsnoEntry.Text)
                || !string.IsNullOrEmpty(newPasswordAgainEntry.Text)
                || !string.IsNullOrEmpty(phonenumberEntry.Text)
                || !string.IsNullOrEmpty(firstNameEntry.Text)
                || !string.IsNullOrEmpty(lastNameEntry.Text)
                || genderPicker.SelectedIndex != -1
                || MatricsCardPhotoCapture != null
                || MatricsCardPhotoCapture.Length != 0)
            {
                DriverApplicant applicant = new DriverApplicant()
                {
                    EmailAddress = emailEntry.Text,
                    MatricsNo = matricsnoEntry.Text,
                    Password = newPasswordAgainEntry.Text,
                    PhoneNumber = phonenumberEntry.Text,
                    FirstName = firstNameEntry.Text,
                    LastName = lastNameEntry.Text,
                    Gender = Convert.ToChar((string)genderPicker.SelectedItem),
                    DateOfBirth = dateOfBirthPicker.Date,
                    MatricsCardPhoto = MatricsCardPhotoCapture
                };

                await Navigation.PushAsync(new RegisterNewDriver_CarDetailsPage(applicant));
            }
            
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void MatricsCardPhotoButton_Clicked(object sender, EventArgs e)
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

            MatricsCardPhotoCapture = File.ReadAllBytes(file.Path);
            MatricsCardPhotoButton.Text = "Matrics Card Photo Added!";

        }
    }
}