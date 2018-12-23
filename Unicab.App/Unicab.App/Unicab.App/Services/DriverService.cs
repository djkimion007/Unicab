using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.Services
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
    }
}
