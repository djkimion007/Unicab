using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public double LocationLatitude { get; set; }

        public double LocationLongitude { get; set; }

        public bool IsWithinUSM { get; set; }

        public DateTime AddedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}
