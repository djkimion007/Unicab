using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.Services
{
    public interface ICredentialsService
    {
        Task<Passenger> LogInPassenger(string emailAddress, string password);

        Task<Driver> LogInDriver(string emailAddress, string password);

        Task<bool> LogOutPassenger(Passenger passenger);

        Task<bool> LogOutDriver(Driver driver);

        Task<bool> RegisterPassenger(PassengerApplicant applicant);

        Task<bool> RegisterDriver(DriverApplicant applicant);

        Task<bool> RetrieveDriverPassword(string emailAddress);

        Task<bool> RetrievePassengerPassword(string emailAddress);

    }
}
