using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class CarpoolOffer
    {
        public int CarpoolOfferId { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int OriginLocationId { get; set; }
        public Location OriginLocation { get; set; }

        public int DestinationLocationId { get; set; }
        public Location DestinationLocation { get; set; }

        public DateTime OriginDateTime { get; set; }

        public int NoOfPassengers { get; set; }

        public bool IsLadiesOnly { get; set; }

        public string AdditionalNotes { get; set; }

        public int OfferPeriod { get; set; } // in days?

        public DateTime AddedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public bool IsAccepted { get; set; }
    }
}
