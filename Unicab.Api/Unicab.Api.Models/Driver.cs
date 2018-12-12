using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class Driver
    {
        public int DriverId { get; set; }

        public string MatricsNo { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string MatricsCardPhotoAddress { get; set; }
        public string DriversLicensePhotoAddress { get; set; }

        public DateTime DriversLicenseDueDate { get; set; }

        public string CarPlateNo { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarMakeYear { get; set; }
        public string CarColour { get; set; }
        public DateTime CarRoadTaxDueDate { get; set; }

        public string CarInsuranceGrantPhotoAddress { get; set; }

        public DateTime AddedDateTime { get; set; }
        public int AddedByAdminId { get; set; }
        public string Notes { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}
