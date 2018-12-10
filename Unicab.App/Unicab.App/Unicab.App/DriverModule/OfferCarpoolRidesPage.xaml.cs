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
	public partial class OfferCarpoolRidesPage : ContentPage
	{
		public OfferCarpoolRidesPage ()
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

            DrivingFromPicker.ItemsSource = pickupLocationList;
            DrivingToPicker.ItemsSource = dropoffLocationList;
        }

        private async void OfferCarpoolBtn_Clicked(object sender, EventArgs e)
        {
            string confirmBookingText = string.Format("Do you wish to confirm your carpool offer as follows:\n\nDriving From: {0}\nDriving To: {1}\nDeparting Date: {2:D}\nDeparting Time: {3}\nNo. of Seats: {4}\nLadies Only?: {5}\nAdditional Notes: {6}",
                DrivingFromPicker.SelectedItem,
                DrivingToPicker.SelectedItem,
                DepartingDatePicker.Date.ToString("ddd, d MMM yyyy"),
                DateTime.Today.Add(DepartingTimePicker.Time).ToString("h:mm tt"),
                NoOfSeatsPicker.SelectedItem,
                LadiesOnlyPicker.SelectedItem,
                AdditionalNotesEditor.Text);

            bool confirmBooking = await DisplayAlert("Offer Carpool", confirmBookingText, "Yes", "No");

            if (confirmBooking)
            {
                // add operations to carpool
                await DisplayAlert("Offer Carpool", "Your carpool offer is being processed. You will be notified once it is accepted by any of our passengers.", "OK");

            }
            else
            {
                await DisplayAlert("Offer Carpool", "You have not proceeded with your carpool offer.", "OK");
            }
        }
    }
}