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
                MaxResponseContentBufferSize = 2048000
            };
        }

        public async Task<Driver> LogInDriver(string emailAddress, string password)
        {
            Driver driver = new Driver();

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, emailAddress + "/" + password));
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await client.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    driver = JsonConvert.DeserializeObject<Driver>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return driver;
        }

        public async Task<HttpStatusCode> RegisterDriver(DriverApplicant applicant)
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

        public async Task<Passenger> LogInPassenger(string emailAddress, string password)
        {
            Passenger passenger = new Passenger();

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, emailAddress + "/" + password));
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await client.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    passenger = JsonConvert.DeserializeObject<Passenger>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return passenger;
        }

        public async Task<HttpStatusCode> RegisterPassenger(PassengerApplicant applicant)
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

        public Task RetrievePassword(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
