using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.Web.Services
{
    public class DriverManagementService : IDriverManagementService
    {
        private readonly HttpClient client;

        public List<DriverApplicant> DriverApplicantsList { get; private set; }
        public List<DriverBlacklist> DriverBlacklistsList { get; private set; }
        public List<Driver> DriversList { get; private set; }

        public DriverManagementService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<List<DriverApplicant>> GetDriverApplicantsList()
        {
            DriverApplicantsList = new List<DriverApplicant>();

            var uri = new Uri(string.Format(AppServerConstants.DriverApplicantsUrl, string.Empty));
            
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    DriverApplicantsList = JsonConvert.DeserializeObject<List<DriverApplicant>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return DriverApplicantsList;

        }

        public async Task<DriverApplicant> ViewDriverApplicant(int driverApplicantId)
        {
            DriverApplicant applicant = new DriverApplicant();

            var uri = new Uri(string.Format(AppServerConstants.DriverApplicantsUrl, driverApplicantId));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    applicant = JsonConvert.DeserializeObject<DriverApplicant>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return applicant;
        }

        public async Task ApproveDriverApplicant(DriverApplicant driverApplicant)
        {
            Driver newDriver = new Driver()
            {
                FirstName = driverApplicant.FirstName,
                LastName = driverApplicant.LastName,
                MatricsNo = driverApplicant.MatricsNo,
                Password = driverApplicant.Password,
                EmailAddress = driverApplicant.EmailAddress,
                CarPlateNo = driverApplicant.CarPlateNo,
                CarRoadTaxDueDate = driverApplicant.CarRoadTaxDueDate
            };

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(newDriver);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"SUCCESS: New driver added to table!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

        }

        public Task RejectDriverApplicant(DriverApplicant driver)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Driver>> GetApprovedDriversList()
        {
            DriversList = new List<Driver>();

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    DriversList = JsonConvert.DeserializeObject<List<Driver>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return DriversList;
        }

        public async Task<Driver> ViewDriver(int driverId)
        {
            Driver driver = new Driver();

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, driverId));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    driver = JsonConvert.DeserializeObject<Driver>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return driver;
        }

        public async Task<List<DriverBlacklist>> GetDriverBlacklistsList()
        {
            DriverBlacklistsList = new List<DriverBlacklist>();

            var uri = new Uri(string.Format(AppServerConstants.DriverBlacklistsUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    DriverBlacklistsList = JsonConvert.DeserializeObject<List<DriverBlacklist>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return DriverBlacklistsList;
        }

        public async Task<DriverBlacklist> ViewDriverBlacklist(int driverBlacklistId)
        {
            DriverBlacklist driverBlacklist = new DriverBlacklist();

            var uri = new Uri(string.Format(AppServerConstants.DriverBlacklistsUrl, driverBlacklistId));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    driverBlacklist = JsonConvert.DeserializeObject<DriverBlacklist>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return driverBlacklist;
        }

        public Task AddDriverBlacklist(int driverId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDriverBlacklist(int driverId)
        {
            throw new NotImplementedException();
        }
    }
}