using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unicab.App.Services;
using Unicab.Api.Models;
using Plugin.Connectivity;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Unicab.App
{
    public partial class App : Application
    {
        public static CredentialsManager CredentialsManager { get; private set; }
        public static CarpoolManager CarpoolManager { get; private set; }
        public static DriverManager DriverManager { get; private set; }
        public static PassengerManager PassengerManager { get; set; }

        public static Driver CurrentDriver { get; set; }
        public static Passenger CurrentPassenger { get; set; }

        public App()
        {
            InitializeComponent();

            CredentialsManager = new CredentialsManager(new CredentialsService());
            CarpoolManager = new CarpoolManager(new CarpoolService());
            DriverManager = new DriverManager(new DriverService());
            PassengerManager = new PassengerManager(new PassengerService());

            MainPage = new NavigationPage(new Landing.PassengerMainPage());

            //var seconds = TimeSpan.FromSeconds(1);
            //Device.StartTimer(seconds,
            //    () =>
            //    {
            //        DoIHaveInternet();
            //        return false;
            //    });
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

        //public bool DoIHaveInternet()
        //{
        //    if (!CrossConnectivity.IsSupported)
        //        return true;

        //    return CrossConnectivity.Current.IsConnected;
        //}
    }
}
