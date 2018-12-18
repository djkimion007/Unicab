using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class CabRequestFulfillment
    {
        public CabRequest CabReq { get; set; }

        public bool DriverHasCompleted { get; set; }
        public DateTime DriverCompletedDateTime { get; set; }

        public bool PassengerHasCompleted { get; set; }
        public DateTime PassengerCompletedDateTime { get; set; }
        
        public double DistanceTravelled { get; set; }
        public double FareCharge { get; set; }

    }
}
