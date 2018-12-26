using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM.CR
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRSelectedPage : ContentPage
	{
		public CRSelectedPage (CabRequest cabRequest)
		{
			InitializeComponent ();

            BindingContext = cabRequest;

            //FullName.Text = string.Format("{0} {1}", cabRequest.Passenger.FirstName, cabRequest.Passenger.LastName);

        }
    }
}