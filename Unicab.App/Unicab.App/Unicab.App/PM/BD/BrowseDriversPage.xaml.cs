using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM.BD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseDriversPage : ContentPage
    {
        public ObservableCollection<Driver> Items { get; set; }

        public BrowseDriversPage()
        {
            InitializeComponent();

            BrowseDriversListView.RefreshCommand = new Command(async () =>
            {
                await RefreshData();
                BrowseDriversListView.IsRefreshing = false;
            });
        }

        private async Task RefreshData()
        {
            var driversList = await App.DriverManager.GetAvailableDrivers();

            Items = new ObservableCollection<Driver>(driversList);

            BrowseDriversListView.ItemsSource = Items;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await RefreshData();

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new SelectedDriverPage(e.Item as Driver));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
