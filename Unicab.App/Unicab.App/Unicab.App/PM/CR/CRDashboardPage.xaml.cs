using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM.CR
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRDashboardPage : ContentPage
	{
        public ObservableCollection<CabRequest> Items { get; set; }

        public CRDashboardPage()
        {
            InitializeComponent();

            YourCRListView.RefreshCommand = new Command(async () =>
            {
                await RefreshData();
                YourCRListView.IsRefreshing = false;
            });

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

            await Navigation.PushAsync(new CRSelectedPage(e.Item as CabRequest));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async Task RefreshData()
        {
            var cabRequestsList = await App.CabManager.GetAvailableCabRequestsByPassengerId(App.CurrentPassenger.PassengerId);

            Items = new ObservableCollection<CabRequest>(cabRequestsList);

            YourCRListView.ItemsSource = Items;
        }
    }
}