using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unicab.App.PassengerModule
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerFareTablePage : TabbedPage
    {
        public PassengerFareTablePage ()
        {
            InitializeComponent();
        }
    }
}