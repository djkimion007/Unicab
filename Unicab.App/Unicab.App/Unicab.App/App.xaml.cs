using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unicab.App.Services;
using Unicab.Api.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Unicab.App
{
    public partial class App : Application
    {
        public static CredentialsManager CredentialsManager { get; private set; }
        public static CarpoolManager CarpoolManager { get; private set; }

        public static Driver CurrentDriver { get; set; }
        public static Passenger CurrentPassenger { get; set; }

        public App()
        {
            InitializeComponent();

            CredentialsManager = new CredentialsManager(new CredentialsService());
            CarpoolManager = new CarpoolManager(new CarpoolService());

            MainPage = new NavigationPage(new Landing.PassengerMainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
