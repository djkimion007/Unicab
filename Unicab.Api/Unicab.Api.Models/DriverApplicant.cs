using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class DriverApplicant
    {
        public int DriverApplicantId { get; set; }

        public string MatricsNo { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public byte[] MatricsCardPhoto { get; set; }
        public byte[] DriversLicensePhoto { get; set; }

        public DateTime DriversLicenseDueDate { get; set; }

        public string CarPlateNo { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarMakeYear { get; set; }
        public string CarColour { get; set; }
        public DateTime CarRoadTaxDueDate { get; set; }

        public byte[] CarInsuranceGrantPhoto { get; set; }

        public DateTime AddedDateTime { get; set; }

        public bool IsApproved { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public int ApprovedByAdminId { get; set; }
        public string Notes { get; set; }
    }
}
