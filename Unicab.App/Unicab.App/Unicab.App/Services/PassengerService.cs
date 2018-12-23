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
    public class PassengerService : IPassengerService
    {
        private readonly HttpClient client;

        public PassengerService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 2048000
            };
        }

        public async Task<Passenger> GetPassengerById(int passengerId)
        {
            Passenger passenger = new Passenger();

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, passengerId));
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
    }
}
