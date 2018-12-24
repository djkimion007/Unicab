using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unicab.App.SM;
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
        public static LocationManager LocationManager { get; set; }

        public static Driver CurrentDriver { get; set; }
        public static Passenger CurrentPassenger { get; set; }

        public App()
        {
            InitializeComponent();

            CredentialsManager = new CredentialsManager(new CredentialsService());
            CarpoolManager = new CarpoolManager(new CarpoolService());
            DriverManager = new DriverManager(new DriverService());
            PassengerManager = new PassengerManager(new PassengerService());
            LocationManager = new LocationManager(new LocationService());

            MainPage = new NavigationPage(new LM.PassengerMainPage());

        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            
        }

    }
}
