using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.Services
{
    public class CredentialsManager
    {
        ICredentialsService credentialsService;

        public CredentialsManager(ICredentialsService service)
        {
            credentialsService = service;
        }

        public Task<HttpStatusCode> RegisterDriver(DriverApplicant applicant)
        {
            return credentialsService.RegisterDriver(applicant);
        }

        public Task<HttpStatusCode> RegisterPassenger(PassengerApplicant applicant)
        {
            return credentialsService.RegisterPassenger(applicant);
        }

        public Task<Driver> LogInDriver(string emailAddress, string password)
        {
            return credentialsService.LogInDriver(emailAddress, password);
        }

        public Task<Passenger> LogInPassenger(string emailAddress, string password)
        {
            return credentialsService.LogInPassenger(emailAddress, password);
        }
    }
}
