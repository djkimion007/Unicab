using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Unicab.App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.Landing
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterNewPassengerPage : ContentPage
	{
        public RegisterNewPassengerPage ()
		{
			InitializeComponent ();

		}

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            //IPStatus testStatus = GeneralService.TestServerStatus(string.Format(Common.AppServerConstants.PassengerApplicantsUrl, string.Empty));
            //if (testStatus != IPStatus.Success)
            //{
            //    await DisplayAlert("Passenger Sign Up", "App server unreachable, please try again later. (ping status: " + testStatus.ToString() + ")", "OK");
            //    await Navigation.PopModalAsync();
            //    return;
            //}

            SubmitButton.Text = "Submitting ...";
            SubmitButton.IsEnabled = false;

            PassengerApplicant applicant = new PassengerApplicant()
            {
                EmailAddress = emailEntry.Text,
                MatricsNo = matricsnoEntry.Text,
                Password = newPasswordAgainEntry.Text,
                PhoneNumber = phonenumberEntry.Text,
                FirstName = firstNameEntry.Text,
                LastName = lastNameEntry.Text,
                Gender = Convert.ToChar((string)genderPicker.SelectedItem),
                DateOfBirth = dateOfBirthPicker.Date,
                //MatricsCardPhotoAddress = MatricsCardCapturePhoto
            };

            HttpStatusCode statusCode = await App.CredentialsManager.TryPassengerSignUp(applicant);

            if (statusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Passenger Sign Up", "Sign up successful. Kindly wait for admin approval before using the service. Thank you.", "OK");
            }
            else
            {
                await DisplayAlert("Passenger Sign Up", "Sign up failed. Please try again. (status code: " + statusCode.ToString() + ")", "OK");
            }

            await Navigation.PopAsync();

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
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                SaveToAlbum = true,
                Directory = "Unicab Service"
            });

            if (file == null)
                return;

            //MatricsCardCapturePhotoPath = File.ReadAllBytes(file.Path);

            await DisplayAlert("File Location", file.AlbumPath, "OK");
            MatricsCardPhotoButton.Text = "Matrics Card Photo Added!";

        }
    }
}