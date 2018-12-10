using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class PassengerApplicant
    {
        public int PassengerApplicantId { get; set; }

        public string MatricsNo { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public byte[] MatricsCardPhoto { get; set; }

        public DateTime AddedDateTime { get; set; }

        public bool IsApproved { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public int ApprovedByAdminId { get; set; }
        public string Notes { get; set; }
    }
}
