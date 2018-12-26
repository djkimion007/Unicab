using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class CabRequestFulfillment
    {
        public int CabRequestFulfillmentId { get; set; }

        public int CabRequestId { get; set; }
        public CabRequest CabRequest { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public bool DriverHasCompleted { get; set; }
        public DateTime DriverCompletedDateTime { get; set; }

        public bool PassengerHasCompleted { get; set; }
        public DateTime PassengerCompletedDateTime { get; set; }

        public double DistanceTravelled { get; set; }
        public double FareCharge { get; set; }
        public bool IsFarePaid { get; set; }

        public bool DriverHasCancelled { get; set; }
        public DateTime DriverCancelledDateTime { get; set; }

        public bool PassengerHasCancelled { get; set; }
        public DateTime PassengerCancelledDateTime { get; set; }

    }
}
