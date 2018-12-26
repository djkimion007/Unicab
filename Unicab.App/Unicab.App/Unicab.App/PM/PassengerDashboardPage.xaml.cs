using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PassengerDashboardPage : ContentPage
	{
        public PassengerDashboardPage ()
		{
			InitializeComponent ();

            WelcomeLabel.Text = string.Format("Welcome, {0} {1}!", App.CurrentPassenger.FirstName, App.CurrentPassenger.LastName);

        }

        private void RequestCabFrameTapGesture_Tapped(object sender, EventArgs e)
        {
            PassengerHomePage PgrHomePage = (PassengerHomePage)App.Current.MainPage;
            PgrHomePage.Detail = new NavigationPage(new CR.NewCRPage());
            PgrHomePage.IsPresented = false;
        }

        private void AvailableCarpoolFrameTapGesture_Tapped(object sender, EventArgs e)
        {
            PassengerHomePage PgrHomePage = (PassengerHomePage)App.Current.MainPage;
            PgrHomePage.Detail = new NavigationPage(new CP.CPDashboardPage());
            PgrHomePage.IsPresented = false;
        }

        private void BrowseDriversFrameTapGesture_Tapped(object sender, EventArgs e)
        {
            PassengerHomePage PgrHomePage = (PassengerHomePage)App.Current.MainPage;
            PgrHomePage.Detail = new NavigationPage(new BD.BrowseDriversPage());
            PgrHomePage.IsPresented = false;
        }
    }
}