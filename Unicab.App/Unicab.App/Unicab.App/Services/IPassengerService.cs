using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.Services
{
    public interface IPassengerService
    {
        Task<Passenger> GetPassengerById(int passengerId);
    }
}
