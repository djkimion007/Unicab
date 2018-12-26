using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.DM.CP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CPSelectedPage : ContentPage
	{

		public CPSelectedPage (CarpoolOffer carpoolOffer)
		{
			InitializeComponent ();

            BindingContext = carpoolOffer;

            FullName.Text = string.Format("{0} {1}", carpoolOffer.Driver.FirstName, carpoolOffer.Driver.LastName);

		}

    }
}