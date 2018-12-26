using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PM.PP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PPPage : ContentPage
	{

		public PPPage ()
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