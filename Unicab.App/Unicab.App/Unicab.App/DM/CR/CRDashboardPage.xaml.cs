using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM.CR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRDashboardPage : ContentPage
    {
        public ObservableCollection<CabRequest> Items { get; set; }

        bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        public CRDashboardPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var cabRequestsList = await LoadItemsAsync();

            Items = new ObservableCollection<CabRequest>(cabRequestsList);

            AvailableCRListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new CRSelectedPage(e.Item as CabRequest));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async Task<List<CabRequest>> LoadItemsAsync()
        {
            List<CabRequest> items = null;
            try
            {
                IsLoading = true;

                // Call your web service here
                items = await App.CabManager.GetAvailableCabRequests();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                IsLoading = false;
            }

            return items;
        }
    }
}
