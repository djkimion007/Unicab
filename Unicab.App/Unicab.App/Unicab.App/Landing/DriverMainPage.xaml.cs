using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Unicab.App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.Landing
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriverMainPage : ContentPage
	{
		public DriverMainPage ()
		{
            InitializeComponent ();
		}

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterNewDriver_MainPage());
        }

        // Validation required
        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            // Login logic come here
            Driver driver = await App.CredentialsManager.TryDriverLogIn(loginUsernameEntry.Text, loginPasswordEntry.Text);

            if (driver.EmailAddress != null)
            {
                DependencyService.Get<IToasts>().ShortToast("Login success");
                App.CurrentDriver = driver;
                App.CurrentPassenger = null;
                App.Current.MainPage = new DriverModule.DriverHomePage();
            }
            else
            {
                DependencyService.Get<IToasts>().ShortToast("Login failed, credentials incorrect");
            }

        }

        private async void ForgotPasswordLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotDriverPasswordPage());
        }

        private void PassengerInterfaceBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new PassengerMainPage());
        }
    }
}