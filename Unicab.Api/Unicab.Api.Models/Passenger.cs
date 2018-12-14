using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.Api.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }

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

        public DateTime AddedDateTime { get; set; }
        public int AddedByAdminId { get; set; }
        public string Notes { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public bool IsActive { get; set; }

        public Passenger()
        {

        }

        public Passenger(PassengerApplicant passengerApplicant)
        {
            MatricsNo = passengerApplicant.MatricsNo;

            EmailAddress = passengerApplicant.EmailAddress;
            PhoneNumber = passengerApplicant.PhoneNumber;
            Password = passengerApplicant.Password;

            FirstName = passengerApplicant.FirstName;
            LastName = passengerApplicant.LastName;
            Gender = passengerApplicant.Gender;
            DateOfBirth = passengerApplicant.DateOfBirth;

            MatricsCardPhoto = passengerApplicant.MatricsCardPhoto;
        }
    }
}
