using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unicab.App.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Unicab.App
{
    public partial class App : Application
    {
        public static CredentialsManager CredentialsManager { get; private set; }

        public App()
        {
            InitializeComponent();

            CredentialsManager = new CredentialsManager(new CredentialsService());

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
