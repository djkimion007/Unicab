using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DriverModule
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverHomePage : MasterDetailPage
    {
        public DriverHomePage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is DriverHomePageMenuItem item))
                return;
            else if (item.Id == 99)
            {
                App.CurrentDriver = null;
                App.Current.MainPage = new Landing.DriverMainPage();
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page)
            {
                BarBackgroundColor = Color.Teal,
                BarTextColor = Color.White
            };
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }


    }
}