using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.LM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotDriverPasswordPage : ContentPage
	{
		public ForgotDriverPasswordPage ()
		{
			InitializeComponent ();
		}

        private void RetrievePasswordBtn_Clicked(object sender, EventArgs e)
        {

        }

        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}