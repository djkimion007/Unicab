using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Unicab.Api.Models;

namespace Unicab.App.PassengerModule
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RequestCabPage : ContentPage
	{
		public RequestCabPage ()
		{
			InitializeComponent ();

            List<string> pickupLocationList = new List<string>
            {
                "RST Guard House, USM",
                "M05 (belakang kafe), Desasiswa Tekun, USM",
                "M05 (hadapan kafe), Desasiswa Tekun, USM",
                "M04, Desasiswa Saujana, USM",
                "M01 (parkir motor). Desasiswa Restu, USM",
                "M03 (parkir motor), Desasiswa Saujana, USM",
                "Kafe Restu / Saujana, USM",
                "M02 (tingkat bawah), Desasiswa Restu, USM",
                "M02 (tingkat atas), Desasiswa Restu, USM",
                "Dewan Utama Desasiswa (DUD), USM",
                "Kafe D'Tekun Bistro, Desasiswa Tekun, USM",
                "M06 (Pondok), Desasiswa Tekun, USM",
                "Hentian Bas Padang Kawad, USM",
                "Hentian Bas Indah Kembara, USM",
                "Hentian Bas Aman Damai, USM",
                "Hentian Bas Jabatan Keselamatan (JK), USM",
                "Hentian Bas Stor Kimia, USM",
                "Hentian Bas Padang Bola Keranjang, Desasiswa Bakti Permai, USM",
                "Hentian Bas Pusat Sejahtera, USM",
                "Hentian Bas DK SK, USM",
                "Hentian Bas SOLLAT, USM",
                "Hentian Bas HBP, USM",
                "Hentian Bas PHS II, USM",
                "Hentian Bas Kompleks Eureka, USM",
                "Hentian Bas Fajar Harapan, USM",
                "Stadium Hoki / Pusat Sukan, USM",
                "Padang Minden / Batu Uban, USM",
                "Glugor",
                "Sungai Dua",
                "Terminal Bas Sungai Nibong",
                "Lip Sin",
                "Queensbay Mall",
                "Kompleks Bukit Jambul",
                "Penang International Airport",
                "Hospital Pulau Pinang"
            };

            List<string> dropoffLocationList = new List<string>
            {
                "RST Guard House, USM",
                "M05 (belakang kafe), Desasiswa Tekun, USM",
                "M05 (hadapan kafe), Desasiswa Tekun, USM",
                "M04, Desasiswa Saujana, USM",
                "M01 (parkir motor). Desasiswa Restu, USM",
                "M03 (parkir motor), Desasiswa Saujana, USM",
                "Kafe Restu / Saujana, USM",
                "M02 (tingkat bawah), Desasiswa Restu, USM",
                "M02 (tingkat atas), Desasiswa Restu, USM",
                "Dewan Utama Desasiswa (DUD), USM",
                "Kafe D'Tekun Bistro, Desasiswa Tekun, USM",
                "M06 (Pondok), Desasiswa Tekun, USM",
                "Hentian Bas Padang Kawad, USM",
                "Hentian Bas Indah Kembara, USM",
                "Hentian Bas Aman Damai, USM",
                "Hentian Bas Jabatan Keselamatan (JK), USM",
                "Hentian Bas Stor Kimia, USM",
                "Hentian Bas Padang Bola Keranjang, Desasiswa Bakti Permai, USM",
                "Hentian Bas Pusat Sejahtera, USM",
                "Hentian Bas DK SK, USM",
                "Hentian Bas SOLLAT, USM",
                "Hentian Bas HBP, USM",
                "Hentian Bas PHS II, USM",
                "Hentian Bas Kompleks Eureka, USM",
                "Hentian Bas Fajar Harapan, USM",
                "Stadium Hoki / Pusat Sukan, USM",
                "Padang Minden / Batu Uban, USM",
                "Glugor",
                "Sungai Dua",
                "Terminal Bas Sungai Nibong",
                "Lip Sin",
                "Queensbay Mall",
                "Kompleks Bukit Jambul",
                "Penang International Airport",
                "Hospital Pulau Pinang"
            };

            PickupLocationPicker.ItemsSource = pickupLocationList;
            DropoffLocationPicker.ItemsSource = dropoffLocationList;
		}

        private async void BookCabBtn_Clicked(object sender, EventArgs e)
        {
            string confirmBookingText = string.Format("Do you wish to confirm your cab request as follows:\n\nPickup Location: {0}\nDropoff Location: {1}\nPickup Date: {2:D}\nPickup Time: {3}\nNo. of Passengers: {4}\nLadies Only?: {5}\nAdditional Notes: {6}",
                PickupLocationPicker.SelectedItem,
                DropoffLocationPicker.SelectedItem,
                PickupDatePicker.Date.ToString("ddd, d MMM yyyy"),
                DateTime.Today.Add(PickupTimePicker.Time).ToString("h:mm tt"),
                NoOfPassengersPicker.SelectedItem,
                LadiesOnlyPicker.SelectedItem,
                AdditionalNotesEditor.Text);

            bool confirmBooking = await DisplayAlert("Request Cab", confirmBookingText, "Yes", "No");

            if (confirmBooking)
            {
                // add operations to book a cab
                await DisplayAlert("Request Cab", "Your cab request is being processed. You will be notified once it is accepted by any of our drivers.", "OK");
                
            }
            else
            {
                await DisplayAlert("Request Cab", "You have not proceeded with your cab request.", "OK");
            }
        }

    }
}