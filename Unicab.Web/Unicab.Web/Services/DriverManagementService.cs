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
                MaxResponseContentBufferSize = 2048000
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

        public async Task<bool> ApproveDriverApplicant(int driverApplicantId)
        {
            Driver newDriver = new Driver(ViewDriverApplicant(driverApplicantId).Result)
            {
                AddedDateTime = DateTime.Now,
                AddedByAdminId = 1,
                ModifiedDateTime = DateTime.Now
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

                    bool isApplicantHidden = await HideDriverAppllicant(driverApplicantId);

                    if (isApplicantHidden)
                        Debug.WriteLine(@"SUCCESS: DriverApplicant record hidden!");
                    else
                        Debug.WriteLine(@"ERROR: DriverApplicant record could not be hidden!");

                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;

        }

        public Task<bool> RejectDriverApplicant(int driverApplicantId)
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

        public Task AddToDriverBlacklist(int driverId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromDriverBlacklist(int driverId)
        {
            throw new NotImplementedException();
        }

        // Private methods

        private async Task<bool> HideDriverAppllicant(int driverApplicantId)
        {
            DriverApplicant applicant = ViewDriverApplicant(driverApplicantId).Result;

            applicant.IsApproved = true;
            applicant.ApprovedDateTime = DateTime.Now;
            applicant.ApprovedByAdminId = 1;
            //applicant.IsHidden = true;
            //applicant.HiddenDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.DriverApplicantsUrl, driverApplicantId));

            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(applicant);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"SUCCESS: DriverApplicant hidden!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}: {1}", response.StatusCode, ex.Message);
            }

            return false;
        }

        private async Task<bool> HideDriver(int driverId)
        {
            Driver driver = ViewDriver(driverId).Result;

            //driver.IsHidden = true;
            //driver.HiddenDateTime = DateTime.Now;
            driver.ModifiedDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, driverId));

            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(driver);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"SUCCESS: Driver hidden!");
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