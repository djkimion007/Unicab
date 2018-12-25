using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedCarpoolPage : ContentPage
	{
		public SelectedCarpoolPage (CarpoolOffer carpoolOffer)
		{
			InitializeComponent ();
		}
	}
}