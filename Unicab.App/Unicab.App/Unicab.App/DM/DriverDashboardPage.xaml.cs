using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverDashboardPage : ContentPage
    {
        public DriverDashboardPage()
        {
            InitializeComponent();
        }

        private void AcceptCabFrameTapGesture_Tapped(object sender, EventArgs e)
        {
            DriverHomePage DvrHomePage = (DriverHomePage)App.Current.MainPage;
            DvrHomePage.Detail = new NavigationPage(new CR.CRDashboardPage());
            DvrHomePage.IsPresented = false;
        }

        private void OfferCarpoolFrameTapGesture_Tapped(object sender, EventArgs e)
        {
            DriverHomePage DvrHomePage = (DriverHomePage)App.Current.MainPage;
            DvrHomePage.Detail = new NavigationPage(new CP.NewCPOfferPage());
            DvrHomePage.IsPresented = false;
        }
    }
}