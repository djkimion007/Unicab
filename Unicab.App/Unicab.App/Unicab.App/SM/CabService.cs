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

        public async Task<bool> AcceptCabRequest(CabRequest fulfillment, int driverId)
        {

            CabRequestFulfillment newFulfillment = new CabRequestFulfillment
            {
                CabRequestId = fulfillment.CabRequestId,
                DriverId = driverId
            };

            var uri = new Uri(string.Format(AppServerConstants.CabRequestFulfillmentsUrl, string.Empty));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(newFulfillment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Cab request fulfillment successfully submitted");

                    await UpdateAcceptedCabRequest(fulfillment.CabRequestId, fulfillment);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Cab request fulfillment failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;

        }

        private async Task<bool> UpdateAcceptedCabRequest(int cabRequestId, CabRequest request)
        {
            request.IsAccepted = true;
            request.ModifiedDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.CabRequestsUrl, cabRequestId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Cab request successfully updated");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Cab request update failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
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

        public async Task<List<CabRequestFulfillment>> GetCabRequestFulfillmentsByDriverId(int driverId)
        {
            List<CabRequestFulfillment> cabRequestFulfillments = new List<CabRequestFulfillment>();

            var uri = new Uri(string.Format(AppServerConstants.CabRequestFulfillmentsUrl, "FulfillmentByDriverId/" + driverId));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cabRequestFulfillments = JsonConvert.DeserializeObject<List<CabRequestFulfillment>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return cabRequestFulfillments;
        }

        public async Task<bool> CompleteCabRequestDriverSide(CabRequestFulfillment fulfillment)
        {
            fulfillment.DriverHasCompleted = true;
            fulfillment.DriverCompletedDateTime = DateTime.Now;
            fulfillment.IsFarePaid = true;

            var uri = new Uri(string.Format(AppServerConstants.CabRequestFulfillmentsUrl, fulfillment.CabRequestFulfillmentId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(fulfillment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Cab request fulfillment successfully completed (driver)");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Cab request fulfillment failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> CompleteCabRequestPassengerSide(CabRequestFulfillment fulfillment)
        {
            if (!fulfillment.DriverHasCompleted)
                return false;
            
            // Complete ride
            fulfillment.PassengerHasCompleted = true;
            fulfillment.PassengerCompletedDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.CabRequestFulfillmentsUrl, fulfillment.CabRequestFulfillmentId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(fulfillment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Cab request fulfillment successfully completed (passenger)");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Cab request fulfillment failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> CancelCabRequestByDriver(CabRequestFulfillment fulfillment)
        {
            fulfillment.DriverHasCancelled = true;
            fulfillment.DriverCancelledDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.CabRequestFulfillmentsUrl, fulfillment.CabRequestFulfillmentId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(fulfillment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Cab request fulfillment successfully cancelled (driver)");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Cab request fulfillment cancellation failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> CancelCabRequestByPassenger(CabRequestFulfillment fulfillment)
        {
            fulfillment.PassengerHasCancelled = true;
            fulfillment.PassengerCancelledDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.CabRequestFulfillmentsUrl, fulfillment.CabRequestFulfillmentId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(fulfillment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Cab request fulfillment successfully cancelled (passenger)");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Cab request fulfillment cancellation failed", responseMessage.StatusCode);
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
