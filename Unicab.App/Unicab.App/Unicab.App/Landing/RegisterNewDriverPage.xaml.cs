using System;
using System.Collections.Generic;
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
    public partial class RegisterNewDriverPage : ContentPage
    {
        public RegisterNewDriverPage()
        {
            InitializeComponent();
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

            DriverApplicant applicant = new DriverApplicant()
            {
                EmailAddress = emailEntry.Text,
                MatricsNo = matricsnoEntry.Text,
                FirstName = firstNameEntry.Text,
                LastName = lastNameEntry.Text,
                Password = newPasswordAgainEntry.Text,
                CarPlateNo = carPlateNoEntry.Text,
                CarRoadTaxDueDate = roadTaxDueDatePicker.Date
            };

            HttpStatusCode statusCode = await App.CredentialsManager.TryDriverSignUp(applicant);

            if (statusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Driver Sign Up", "Sign up successful. Kindly wait for admin approval before using the service. Thank you.", "OK");
            }
            else
            {
                await DisplayAlert("Driver Sign Up", "Sign up failed. Please try again. (status code: " + statusCode.ToString() + ")", "OK");
            }

            await Navigation.PopAsync();

        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //private async void MatricsCardCaptureBtn_Clicked(object sender, EventArgs e)
        //{
        //    await CrossMedia.Current.Initialize();

        //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
        //    {
        //        await DisplayAlert("No Camera", "No camera detected.", "OK");
        //        return;
        //    }

        //    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
        //    {
        //        SaveToAlbum = true,
        //        Directory = "Unicab Service"
        //    });

        //    if (file == null)
        //        return;

        //    //await DisplayAlert("File Location", file.AlbumPath, "OK");
        //    MatricsCardCaptureBtn.Text = "Matrics Card Photo Added!";

        //}
    }
}