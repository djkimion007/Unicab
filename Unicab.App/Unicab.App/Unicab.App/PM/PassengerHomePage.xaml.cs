using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.App.SM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerHomePage : MasterDetailPage
    {
        public PassengerHomePage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is PassengerHomePageMenuItem item))
                return;
            else if (item.Id == 99)
            {
                bool IsLoggedOut = await App.CredentialsManager.LogOutPassenger(App.CurrentPassenger);

                if (IsLoggedOut)
                {
                    App.CurrentPassenger = null;

                    DependencyService.Get<IToasts>().ShortToast("Logged out of Unicab Service (Passenger)");

                    App.Current.MainPage = new LM.PassengerMainPage();
                }
                
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}