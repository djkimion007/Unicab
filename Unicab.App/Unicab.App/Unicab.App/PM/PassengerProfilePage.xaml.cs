using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PassengerProfilePage : ContentPage
	{

		public PassengerProfilePage ()
		{
			InitializeComponent ();

            BindingContext = App.CurrentPassenger;

            FullName.Text = string.Format("{0} {1}", App.CurrentPassenger.FirstName, App.CurrentPassenger.LastName);
		}

        private void UpdateProfileButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}