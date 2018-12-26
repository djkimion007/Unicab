using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Unicab.Api.Models;
using System.Diagnostics;

namespace Unicab.App.PM.CP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CPSelectedPage : ContentPage
	{
        public CPSelectedPage(CarpoolOffer carpoolOffer)
        {
            InitializeComponent();

            BindingContext = carpoolOffer;

            FullName.Text = string.Format("{0} {1}", carpoolOffer.Driver.FirstName, carpoolOffer.Driver.LastName);

        }

    }
}