using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.Web.Services
{
    public class PassengerManagementService : IPassengerManagementService
    {
        private readonly HttpClient client;

        public List<PassengerApplicant> PassengerApplicantsList { get; private set; }
        public List<PassengerBlacklist> PassengerBlacklistsList { get; private set; }
        public List<Passenger> PassengersList { get; private set; }

        public PassengerManagementService()
        {
            client = new HttpClient()
            {
                MaxResponseContentBufferSize = 2048000
            };
        }

        public async Task<bool> ApprovePassengerApplicant(int passengerApplicantId)
        {
            Passenger newPassenger = new Passenger(ViewPassengerApplicant(passengerApplicantId).Result);

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(newPassenger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"SUCCESS: New passenger added to table!");

                    bool isApplicantHidden = await HidePassengerAppllicant(passengerApplicantId);

                    if (isApplicantHidden)
                        Debug.WriteLine(@"SUCCESS: PassengerApplicant record hidden!");
                    else
                        Debug.WriteLine(@"ERROR: PassengerApplicant record could not be hidden!");

                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }

        public Task AddToPassengerBlacklist(int passengerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Passenger>> GetApprovedPassengersList()
        {
            PassengersList = new List<Passenger>();

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    PassengersList = JsonConvert.DeserializeObject<List<Passenger>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return PassengersList;
        }

        public async Task<List<PassengerBlacklist>> GetPassengerBlacklistsList()
        {
            PassengerBlacklistsList = new List<PassengerBlacklist>();

            var uri = new Uri(string.Format(AppServerConstants.PassengerBlacklistsUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    PassengerBlacklistsList = JsonConvert.DeserializeObject<List<PassengerBlacklist>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return PassengerBlacklistsList;
        }

        public async Task<PassengerApplicant> ViewPassengerApplicant(int passengerApplicantId)
        {
            PassengerApplicant applicant = new PassengerApplicant();

            var uri = new Uri(string.Format(AppServerConstants.PassengerApplicantsUrl, passengerApplicantId));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    applicant = JsonConvert.DeserializeObject<PassengerApplicant>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return applicant;
        }

        public async Task<List<PassengerApplicant>> GetPassengerApplicantsList()
        {
            PassengerApplicantsList = new List<PassengerApplicant>();

            var uri = new Uri(string.Format(AppServerConstants.PassengerApplicantsUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    PassengerApplicantsList = JsonConvert.DeserializeObject<List<PassengerApplicant>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return PassengerApplicantsList;
        }

        public Task<bool> RejectPassengerApplicant(int passengerApplicantId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromPassengerBlacklist(int passengerId)
        {
            throw new NotImplementedException();
        }

        public async Task<PassengerBlacklist> ViewPassengerBlacklist(int passengerBlacklistId)
        {
            PassengerBlacklist passengerBlacklist = new PassengerBlacklist();

            var uri = new Uri(string.Format(AppServerConstants.PassengerBlacklistsUrl, passengerBlacklistId));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    passengerBlacklist = JsonConvert.DeserializeObject<PassengerBlacklist>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return passengerBlacklist;
        }

        public async Task<Passenger> ViewPassenger(int passengerId)
        {
            Passenger passenger = new Passenger();

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, passengerId));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    passenger = JsonConvert.DeserializeObject<Passenger>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return passenger;
        }

        // Private methods

        private async Task<bool> HidePassengerAppllicant(int passengerApplicantId)
        {
            PassengerApplicant applicant = ViewPassengerApplicant(passengerApplicantId).Result;

            applicant.IsApproved = true;
            applicant.ApprovedDateTime = DateTime.Now;
            applicant.ApprovedByAdminId = 1;
            //applicant.IsHidden = true;
            //applicant.HiddenDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.PassengerApplicantsUrl, passengerApplicantId));

            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(applicant);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"SUCCESS: PassengerApplicant hidden!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}: {1}", response.StatusCode, ex.Message);
            }

            return false;
        }

        private async Task<bool> HidePassenger(int passengerId)
        {
            Passenger passenger = ViewPassenger(passengerId).Result;

            //passenger.IsHidden = true;
            //passenger.HiddenDateTime = DateTime.Now;
            passenger.ModifiedDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, passengerId));

            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(passenger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"SUCCESS: Passenger hidden!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}: {1}", response.StatusCode, ex.Message);
            }

            return false;
        }
    }
}
