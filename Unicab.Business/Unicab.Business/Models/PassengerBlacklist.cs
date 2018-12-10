using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Business.Models
{
    public class PassengerBlacklist
    {
        public int PassengerBlacklistId { get; set; }

        public int PassengerId { get; set; }

        public DateTime BlacklistedDateTime { get; set; }
        public string BlacklistedReason { get; set; }
        public int BlacklistedByAdminId { get; set; }
        public int BlacklistedDuration { get; set; } // in no. of days

        public DateTime UnblacklistedDateTime { get; set; }
        public string UnblacklistedReason { get; set; }
        public int UnblacklistedByAdminId { get; set; }
    }
}
