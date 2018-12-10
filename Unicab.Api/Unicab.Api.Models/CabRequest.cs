using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class CabRequest
    {
        public int CabRequestId { get; set; }

        public int PassengerId { get; set; }

        public string PickUpLocation { get; set; }
        public DateTime PickUpDateTime { get; set; }

        public string DropOffLocation { get; set; }

        public int NoOfPassengers { get; set; }

        public bool IsLadiesOnly { get; set; }

        public string AdditionalNotes { get; set; }

        public int RequestPeriod { get; set; } // in no. of seconds

        public DateTime AddedDateTime { get; set; }

        public bool IsAccepted { get; set; }
        public int AcceptedByDriverId { get; set; }
        public DateTime AcceptedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}
