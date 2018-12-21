using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PassengerModule
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerHomePage : MasterDetailPage
    {
        public PassengerHomePage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is PassengerHomePageMenuItem item))
                return;
            else if (item.Id == 99)
            {
                App.CurrentPassenger = null;
                App.Current.MainPage = new Landing.PassengerMainPage();
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