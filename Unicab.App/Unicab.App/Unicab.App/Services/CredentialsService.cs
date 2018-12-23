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
                    bool IsLoginDataUpdated = await UpdateDriverLoginData(driver);

                    if (!IsLoginDataUpdated)
                        Debug.WriteLine(@"ERROR: Login data is not updated!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return driver;
        }

        public async Task<bool> RegisterDriver(DriverApplicant applicant)
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
                    Debug.WriteLine("POST {0} OK: DriverApplicant registration successful", responseMessage.StatusCode);

                    return true;
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

            return false;
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
                    bool IsLoginDataUpdated = await UpdatePassengerLoginData(passenger);

                    if (!IsLoginDataUpdated)
                        Debug.WriteLine(@"ERROR: Login data is not updated!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return passenger;
        }

        public async Task<bool> RegisterPassenger(PassengerApplicant applicant)
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
                    Debug.WriteLine("POST {0} OK: PassengerApplicant registration successful", responseMessage.StatusCode);

                    return true;
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

            return false;
        }

        private async Task<bool> UpdateDriverLoginData(Driver loginDriver)
        {
            loginDriver.IsLoggedIn = true;
            loginDriver.CurrentLoginUniqueId = Guid.NewGuid().ToString();
            loginDriver.CurrentLoginDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, loginDriver.DriverId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(loginDriver);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"POST {0} OK: Driver login data updated!", responseMessage.StatusCode);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Driver login data update failed!", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;

        }

        private async Task<bool> UpdateDriverLogoutData(Driver loginDriver)
        {
            loginDriver.IsLoggedIn = false;
            loginDriver.CurrentLoginUniqueId = null;
            loginDriver.LastLoginDateTime = loginDriver.CurrentLoginDateTime;
            loginDriver.CurrentLoginDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, loginDriver.DriverId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(loginDriver);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"POST {0} OK: Driver logout data updated!", responseMessage.StatusCode);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Driver logout data update failed!", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;

        }

        private async Task<bool> UpdatePassengerLoginData(Passenger loginPassenger)
        {
            loginPassenger.IsLoggedIn = true;
            loginPassenger.CurrentLoginUniqueId = Guid.NewGuid().ToString();
            loginPassenger.CurrentLoginDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, loginPassenger.PassengerId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(loginPassenger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"POST {0} OK: Passenger login data updated!", responseMessage.StatusCode);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Passenger login data update failed!", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;

        }

        private async Task<bool> UpdatePassengerLogoutData(Passenger loginPassenger)
        {
            loginPassenger.IsLoggedIn = false;
            loginPassenger.CurrentLoginUniqueId = null;
            loginPassenger.LastLoginDateTime = loginPassenger.CurrentLoginDateTime;
            loginPassenger.CurrentLoginDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, loginPassenger.PassengerId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(loginPassenger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"POST {0} OK: Passenger logout data updated!", responseMessage.StatusCode);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Passenger logout data update failed!", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;

        }

        public Task<bool> LogOutPassenger(Passenger passenger)
        {
            return UpdatePassengerLogoutData(passenger);
        }

        public Task<bool> LogOutDriver(Driver driver)
        {
            return UpdateDriverLogoutData(driver);
        }

        public Task<bool> RetrieveDriverPassword(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RetrievePassengerPassword(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
