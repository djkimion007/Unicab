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
    public class LocationService : ILocationService
    {
        private readonly HttpClient client;

        public LocationService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 2048000
            };
        }

        public async Task<List<Location>> GetStationLocationsAll()
        {
            List<Location> locationList = new List<Location>();

            var uri = new Uri(string.Format(AppServerConstants.LocationsUrl, string.Empty));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    locationList = JsonConvert.DeserializeObject<List<Location>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return locationList;
        }

        public async Task<List<Location>> GetStationLocationsExcludeUSM()
        {
            List<Location> locationList = new List<Location>();

            var uri = new Uri(string.Format(AppServerConstants.LocationsUrl, "ExUSM"));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    locationList = JsonConvert.DeserializeObject<List<Location>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return locationList;
        }

        public async Task<List<Location>> GetStationLocationsIncludeUSM()
        {
            List<Location> locationList = new List<Location>();

            var uri = new Uri(string.Format(AppServerConstants.LocationsUrl, "InUSM"));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    locationList = JsonConvert.DeserializeObject<List<Location>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return locationList;
        }
    }
}
