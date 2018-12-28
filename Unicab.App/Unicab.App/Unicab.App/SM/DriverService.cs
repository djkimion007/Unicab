using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public class DriverService : IDriverService
    {
        private readonly HttpClient client;

        public DriverService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 2048000
            };
        }

        public async Task<List<Driver>> GetAvailableDrivers()
        {
            List<Driver> driversList = new List<Driver>();

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, string.Empty));
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await client.GetAsync(uri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    driversList = JsonConvert.DeserializeObject<List<Driver>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return driversList;
        }

        public async Task<Driver> GetDriverById(int driverId)
        {
            Driver driver = new Driver();

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, driverId));
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

        public async Task<bool> UpdateProfilePhoto(Driver driver, byte[] profilePhoto)
        {
            driver.ModifiedDateTime = DateTime.Now;
            driver.MatricsCardPhoto = profilePhoto;

            var uri = new Uri(string.Format(AppServerConstants.DriversUrl, driver.DriverId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(driver);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST {0} OK: Driver update successful", responseMessage.StatusCode);

                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Driver update failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }
    }
}
