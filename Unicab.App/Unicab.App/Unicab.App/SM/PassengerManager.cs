using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public class PassengerManager
    {
        IPassengerService passengerService;

        public PassengerManager(IPassengerService service)
        {
            passengerService = service;
        }

        public Task<Passenger> GetPassengerById(int passengerId)
        {
            return passengerService.GetPassengerById(passengerId);
        }

        public Task<bool> UpdateProfilePhoto(Passenger passenger, byte[] profilePhoto)
        {
            return passengerService.UpdateProfilePhoto(passenger, profilePhoto);
        }
    }
}
