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

        public byte[] ProfilePhoto { get; set; }

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
        public int AddedByAdminId { get; set; }
        public string Notes { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public bool IsActive { get; set; }

        public Driver()
        {
        }

        public Driver(DriverApplicant driverApplicant)
        {
            MatricsNo = driverApplicant.MatricsNo;

            EmailAddress = driverApplicant.EmailAddress;
            PhoneNumber = driverApplicant.PhoneNumber;
            Password = driverApplicant.Password;

            FirstName = driverApplicant.FirstName;
            LastName = driverApplicant.LastName;
            Gender = driverApplicant.Gender;
            DateOfBirth = driverApplicant.DateOfBirth;

            MatricsCardPhoto = driverApplicant.MatricsCardPhoto;
            DriversLicensePhoto = driverApplicant.DriversLicensePhoto;

            DriversLicenseDueDate = driverApplicant.DriversLicenseDueDate;

            CarPlateNo = driverApplicant.CarPlateNo;
            CarMake = driverApplicant.CarMake;
            CarModel = driverApplicant.CarModel;
            CarMakeYear = driverApplicant.CarMakeYear;
            CarColour = driverApplicant.CarColour;
            CarRoadTaxDueDate = driverApplicant.CarRoadTaxDueDate;

            CarInsuranceGrantPhoto = driverApplicant.CarInsuranceGrantPhoto;
    }
    }
}
