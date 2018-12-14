using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class Admin
    {
        public int AdminId { get; set; }

        public string StaffNo { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StaffPosition { get; set; }

        public byte[] ProfilePhoto { get; set; }

        public DateTime AddedDateTime { get; set; }
        public string Notes { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public bool IsActive { get; set; }
    }
}
