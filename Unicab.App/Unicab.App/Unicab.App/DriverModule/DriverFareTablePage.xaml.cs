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
    public partial class DriverFareTablePage : TabbedPage
    {
        public DriverFareTablePage ()
        {
            InitializeComponent();
        }
    }
}