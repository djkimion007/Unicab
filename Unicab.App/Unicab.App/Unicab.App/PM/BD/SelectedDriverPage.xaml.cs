using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM.BD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedDriverPage : ContentPage
    {
        private Driver driver;

        public SelectedDriverPage(Driver selectedDriver)
        {
            InitializeComponent();

            driver = selectedDriver;

            BindingContext = driver;
            
            FullNameLabel.Text = string.Format("{0} {1}", driver.FirstName, driver.LastName);


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void CallDriverBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Call Driver", "Are you sure you wish to call this driver? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (!continueNextSteps)
            {
                return;
            }

            try
            {
                PhoneDialer.Open(driver.PhoneNumber);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Call Driver", "Could not make a call, please try again later", "OK");
            }
            
        }

        private async void MessageDriverBtn_Clicked(object sender, EventArgs e)
        {
            bool continueNextSteps = await DisplayAlert("Message Driver", "Are you sure you wish to message this driver? Tap 'Yes' to proceed, or 'No' to go back.", "Yes", "No");
            if (!continueNextSteps)
            {
                return;
            }

            try
            {
                string[] recipient = { driver.PhoneNumber };
                await Sms.ComposeAsync(new SmsMessage(string.Empty, recipient));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Message Driver", "Could not create a message, please try again later", "OK");
            }
        }
    }
}