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
    public class LocationManagementService : ILocationManagementService
    {
        private readonly HttpClient client;

        public List<Location> LocationsList { get; private set; }

        public LocationManagementService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 2048000
            };
        }

        public async Task<Location> GetLocation(int locationId)
        {
            Location loc = new Location();

            var uri = new Uri(string.Format(AppServerConstants.LocationsUri, locationId));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    loc = JsonConvert.DeserializeObject<Location>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return loc;
        }

        public async Task<List<Location>> GetLocations()
        {
            LocationsList = new List<Location>();

            var uri = new Uri(string.Format(AppServerConstants.LocationsUri, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LocationsList = JsonConvert.DeserializeObject<List<Location>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return LocationsList;
        }

        public Task<bool> RemoveLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveNewLocation(Location newLocation)
        {

            var uri = new Uri(string.Format(AppServerConstants.LocationsUri, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(newLocation);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"SUCCESS: New location added to table!");

                    return true;
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
