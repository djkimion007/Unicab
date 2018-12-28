using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.App.SM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM.DP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DPPage : ContentPage
	{
        private byte[] ProfilePhotoCapture { get; set; }

        public DPPage ()
		{
			InitializeComponent ();

            BindingContext = App.CurrentDriver;

            FullName.Text = string.Format("{0} {1}", App.CurrentDriver.FirstName, App.CurrentDriver.LastName);
        }

        private async void UpdateProfilePhotoButton_Clicked(object sender, EventArgs e)
        {

            var response = await DisplayActionSheet("Update Profile Photo", "Cancel", null, "Take Photo", "Select from Gallery", "Remove");

            if (response == "Camera")
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Update Profile Photo", "No camera detected", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                    CustomPhotoSize = 10,
                    AllowCropping = true,
                    SaveToAlbum = true,
                    Directory = "Unicab Service"
                });

                if (file == null)
                {
                    await DisplayAlert("Update Profile Photo", "Could not complete action, please try again.", "OK");
                    return;
                }


                DvrPhoto.Source = ImageSource.FromStream(() => file.GetStream());
                ProfilePhotoCapture = File.ReadAllBytes(file.Path);

                bool updatedAtDatabase = await App.DriverManager.UpdateProfilePhoto(App.CurrentDriver, ProfilePhotoCapture);

                if (updatedAtDatabase)
                    DependencyService.Get<IToasts>().LongToast("Profile photo updated");
                else
                    DependencyService.Get<IToasts>().LongToast("Profile photo couldn't be updated");
            }
            else if (response == "Select from Gallery")
            {
                await CrossMedia.Current.Initialize();

                var pickerOptions = new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Custom,
                    CustomPhotoSize = 10
                };

                var file = await CrossMedia.Current.PickPhotoAsync(pickerOptions);

                DvrPhoto.Source = ImageSource.FromStream(() => file.GetStream());
                ProfilePhotoCapture = File.ReadAllBytes(file.Path);

                bool updatedAtDatabase = await App.DriverManager.UpdateProfilePhoto(App.CurrentDriver, ProfilePhotoCapture);

                if (updatedAtDatabase)
                    DependencyService.Get<IToasts>().LongToast("Profile photo updated");
                else
                    DependencyService.Get<IToasts>().LongToast("Profile photo couldn't be updated");
            }
            
            else if (response == "Remove")
            {
                DvrPhoto.Source = null;
                ProfilePhotoCapture = null;

                bool updatedAtDatabase = await App.DriverManager.UpdateProfilePhoto(App.CurrentDriver, ProfilePhotoCapture);

                if (updatedAtDatabase)
                    DependencyService.Get<IToasts>().LongToast("Profile photo updated");
                else
                    DependencyService.Get<IToasts>().LongToast("Profile photo couldn't be updated");
            }

            

            
        }
    }
}