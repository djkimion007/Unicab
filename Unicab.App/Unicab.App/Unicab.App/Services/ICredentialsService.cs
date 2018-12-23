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

        Task<HttpStatusCode> RegisterPassenger(PassengerApplicant applicant);

        Task<HttpStatusCode> RegisterDriver(DriverApplicant applicant);

        Task RetrievePassword(string emailAddress);

    }
}
