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

        public Task<HttpStatusCode> TryDriverSignUp(DriverApplicant applicant)
        {
            return credentialsService.TryDriverSignUp(applicant);
        }

        public Task<HttpStatusCode> TryPassengerSignUp(PassengerApplicant applicant)
        {
            return credentialsService.TryPassengerSignUp(applicant);
        }
    }
}
