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
    public class CabService : ICabService
    {
        private readonly HttpClient client;

        public CabService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 2048000
            };
        }

        public async Task<bool> CreateNewCabRequest(CabRequest cabRequest)
        {
            var uri = new Uri(string.Format(AppServerConstants.CabRequestsUrl, string.Empty));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(cabRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Cab request successfully submitted");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Cab request failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }

        public async Task<List<CabRequest>> GetAvailableCabRequests()
        {
            List<CabRequest> cabRequests = new List<CabRequest>();

            var uri = new Uri(string.Format(AppServerConstants.CabRequestsUrl, string.Empty));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cabRequests = JsonConvert.DeserializeObject<List<CabRequest>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return cabRequests;
        }

        public async Task<List<CabRequest>> GetAvailableCabRequestsByPassengerId(int passengerId)
        {
            List<CabRequest> cabRequests = new List<CabRequest>();

            var uri = new Uri(string.Format(AppServerConstants.CabRequestsUrl, "ByPassengerId/" + passengerId));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cabRequests = JsonConvert.DeserializeObject<List<CabRequest>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return cabRequests;
        }

        public async Task<CabRequest> GetCabRequestById(int cabRequestId)
        {
            CabRequest cabRequest = new CabRequest();

            var uri = new Uri(string.Format(AppServerConstants.CabRequestsUrl, cabRequestId));

            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cabRequest = JsonConvert.DeserializeObject<CabRequest>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return cabRequest;
        }
    }
}
