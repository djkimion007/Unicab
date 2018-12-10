using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.Web.Services
{
    public class PassengerManagementService : IPassengerManagementService
    {
        private readonly HttpClient client;

        public List<PassengerApplicant> PassengerApplicantsList { get; private set; }
        public List<Passenger> PassengersList { get; private set; }

        public PassengerManagementService()
        {
            client = new HttpClient()
            {
                MaxResponseContentBufferSize = 25600
            };
        }

        public Task ApprovePassengerApplicant(int passengerApplicantId)
        {
            throw new NotImplementedException();
        }

        public Task BlacklistPassenger(int passengerId)
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

        public Task GetBlacklistedPassengersList()
        {
            throw new NotImplementedException();
        }

        public async Task<PassengerApplicant> GetPassengerApplicant(int passengerApplicantId)
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

        public Task RejectPassengerApplicant(int passengerApplicantId)
        {
            throw new NotImplementedException();
        }

        public Task SetActivePassenger(int passengerId)
        {
            throw new NotImplementedException();
        }

        public Task SetInactivePassenger(int passengerId)
        {
            throw new NotImplementedException();
        }

        public Task UnblacklistPassenger(int passengerId)
        {
            throw new NotImplementedException();
        }

        public Task ViewBlacklistedPassenger(int passengerId)
        {
            throw new NotImplementedException();
        }

        public Task<Passenger> ViewPassenger(int passengerId)
        {
            throw new NotImplementedException();
        }
    }
}
