using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;
using Newtonsoft.Json;
using System.Net;

namespace Unicab.App.Services
{
    public class CredentialsService : ICredentialsService
    {
        private readonly HttpClient client;

        public CredentialsService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 1024000
            };
        }

        public Task TryDriverLogin(string emailAddress, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> TryDriverSignUp(DriverApplicant applicant)
        {
            applicant.AddedDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.DriverApplicantsUrl, string.Empty));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(applicant);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: DriverApplicant registration successful");
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: DriverApplicant registration failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            if (responseMessage != null)
                return responseMessage.StatusCode;
            else
                return HttpStatusCode.InternalServerError;
        }

        public Task TryPassengerLogin(string emailAddress, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> TryPassengerSignUp(PassengerApplicant applicant)
        {
            applicant.AddedDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.PassengerApplicantsUrl, string.Empty));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(applicant);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: PassengerApplicant registration successful");
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: PassengerApplicant registration failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            if (responseMessage != null)
                return responseMessage.StatusCode;
            else
                return HttpStatusCode.InternalServerError;
        }

        public Task TryRetrievePassword(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
