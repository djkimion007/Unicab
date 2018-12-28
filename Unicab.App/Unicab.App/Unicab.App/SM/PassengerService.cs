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

        public async Task<bool> UpdateProfilePhoto(Passenger passenger, byte[] profilePhoto)
        {
            passenger.ModifiedDateTime = DateTime.Now;
            passenger.MatricsCardPhoto = profilePhoto;

            var uri = new Uri(string.Format(AppServerConstants.PassengersUrl, passenger.PassengerId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(passenger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST {0} OK: Passenger update successful", responseMessage.StatusCode);

                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Passenger update failed", responseMessage.StatusCode);
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
