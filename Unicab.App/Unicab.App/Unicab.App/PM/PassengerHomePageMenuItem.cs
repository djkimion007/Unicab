using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicab.App.PM
{

    public class PassengerHomePageMenuItem
    {
        public PassengerHomePageMenuItem()
        {
            //TargetType = typeof(PassengerHomePageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public String IconSource { get; set; }
    }
}