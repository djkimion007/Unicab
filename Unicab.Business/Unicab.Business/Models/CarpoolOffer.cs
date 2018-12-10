using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Business.Models
{
    public class CarpoolOffer
    {
        public int CarpoolOfferId { get; set; }

        public int DriverId { get; set; }

        public string OriginLocation { get; set; }
        public DateTime OriginDateTime { get; set; }

        public string DestinationLocation { get; set; }

        public int NoOfPassengers { get; set; }
        public List<int> PassengersList { get; set; }

        public bool IsLadiesOnly { get; set; }

        public string AdditionalNotes { get; set; }

        public int OfferPeriod { get; set; } // in no. of days

        public DateTime AddedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}
