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
        Task TryPassengerLogin(string emailAddress, string password);

        Task TryDriverLogin(string emailAddress, string password);

        Task<HttpStatusCode> TryPassengerSignUp(PassengerApplicant applicant);

        Task<HttpStatusCode> TryDriverSignUp(DriverApplicant applicant);

        Task TryRetrievePassword(string emailAddress);

    }
}
