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
	public partial class PassengerMainPage : ContentPage
	{
		public PassengerMainPage ()
		{
            InitializeComponent ();
		}

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterNewPassengerPage());
        }

        // Validation required
        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            // Login logic come here
            Passenger passenger = await App.CredentialsManager.TryPassengerLogIn(loginUsernameEntry.Text, loginPasswordEntry.Text);

            if (passenger.EmailAddress != null)
            {
                DependencyService.Get<IToasts>().ShortToast("Login success");
                App.CurrentPassenger = passenger;
                App.CurrentDriver = null;
                App.Current.MainPage = new PassengerModule.PassengerHomePage();
            }
            else
            {
                DependencyService.Get<IToasts>().ShortToast("Login failed, credentials incorrect");
            }

        }

        private async void ForgotPasswordLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassengerPasswordPage());
        }

        private void DriverInterfaceBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new DriverMainPage());
        }
    }
}