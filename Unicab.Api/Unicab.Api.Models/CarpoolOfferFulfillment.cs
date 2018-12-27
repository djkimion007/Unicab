using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class CarpoolOfferFulfillment
    {
        public int CarpoolOfferFulfillmentId { get; set; }

        public int CarpoolOfferId { get; set; }
        public CarpoolOffer CarpoolOffer { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public bool DriverHasCompleted { get; set; }
        public DateTime DriverCompletedDateTime { get; set; }

        public bool PassengerHasCompleted { get; set; }
        public DateTime PassengerCompletedDateTime { get; set; }

        public double DistanceTravelled { get; set; }
        public double FareCharge { get; set; }
        public bool IsFarePaid { get; set; }
        public bool IsFareSplit { get; set; }

        public bool DriverHasCancelled { get; set; }
        public DateTime DriverCancelledDateTime { get; set; }

        public bool PassengerHasCancelled { get; set; }
        public DateTime PassengerCancelledDateTime { get; set; }
    }
}
