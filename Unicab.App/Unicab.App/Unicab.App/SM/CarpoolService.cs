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
    public class CarpoolService : ICarpoolService
    {
        private readonly HttpClient client;

        public CarpoolService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 2048000
            };
        }

        public async Task<bool> CreateNewCarpoolOffer(CarpoolOffer carpoolOffer)
        {

            var uri = new Uri(string.Format(AppServerConstants.CarpoolOffersUrl, string.Empty));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(carpoolOffer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Carpool offer successfully submitted");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Carpool offer failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;

        }


        public async Task<CarpoolOffer> GetCarpoolOfferById(int carpoolOfferId)
        {
            CarpoolOffer carpoolOffer = new CarpoolOffer();

            var uri = new Uri(string.Format(AppServerConstants.CarpoolOffersUrl, carpoolOfferId));

            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    carpoolOffer = JsonConvert.DeserializeObject<CarpoolOffer>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return carpoolOffer;

        }

        public async Task<List<CarpoolOffer>> GetAvailableCarpoolOffers()
        {
            List<CarpoolOffer> carpoolOffers = new List<CarpoolOffer>();

            var uri = new Uri(string.Format(AppServerConstants.CarpoolOffersUrl, string.Empty));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    carpoolOffers = JsonConvert.DeserializeObject<List<CarpoolOffer>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return carpoolOffers;
        }

        public async Task<List<CarpoolOffer>> GetAvailableCarpoolOffersByDriverId(int driverId)
        {
            List<CarpoolOffer> carpoolOffers = new List<CarpoolOffer>();

            var uri = new Uri(string.Format(AppServerConstants.CarpoolOffersUrl, "ByDriverId/" + driverId));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    carpoolOffers = JsonConvert.DeserializeObject<List<CarpoolOffer>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return carpoolOffers;
        }

        public async Task<bool> CancelCarpoolOffer(int carpoolOfferId)
        {
            var uri = new Uri(string.Format(AppServerConstants.CarpoolOffersUrl, carpoolOfferId));
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await client.DeleteAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Carpool offer successfully cancelled");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Carpool offer cancellation failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> CompleteCarpoolOfferDriverSide(CarpoolOfferFulfillment fulfillment)
        {
            fulfillment.DriverHasCompleted = true;
            fulfillment.DriverCompletedDateTime = DateTime.Now;
            fulfillment.IsFarePaid = true;

            var uri = new Uri(string.Format(AppServerConstants.CarpoolOfferFulfillmentsUrl, fulfillment.CarpoolOfferFulfillmentId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(fulfillment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Carpool fulfillment successfully completed (driver)");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Carpool request fulfillment failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> CompleteCarpoolOfferPassengerSide(CarpoolOfferFulfillment fulfillment)
        {
            if (!fulfillment.DriverHasCompleted)
                return false;

            fulfillment.DriverHasCompleted = true;
            fulfillment.DriverCompletedDateTime = DateTime.Now;

            var uri = new Uri(string.Format(AppServerConstants.CarpoolOfferFulfillmentsUrl, fulfillment.CarpoolOfferFulfillmentId));
            HttpResponseMessage responseMessage = null;

            try
            {
                var json = JsonConvert.SerializeObject(fulfillment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                responseMessage = await client.PutAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("POST 201 OK: Carpool fulfillment successfully completed (driver)");
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"POST {0} NOT OK: Carpool request fulfillment failed", responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return false;
        }

        public async Task<List<CarpoolOfferFulfillment>> GetAvailableCarpoolOfferFulfillmentsByDriverId(int driverId)
        {
            List<CarpoolOfferFulfillment> coFulfillment = new List<CarpoolOfferFulfillment>();

            var uri = new Uri(string.Format(AppServerConstants.CarpoolOfferFulfillmentsUrl, "ByDriverId/" + driverId));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    coFulfillment = JsonConvert.DeserializeObject<List<CarpoolOfferFulfillment>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return coFulfillment;
        }

        public async Task<List<CarpoolOfferFulfillment>> GetAvailableCarpoolOfferFulfillmentsByPassengerId(int passengerId)
        {
            List<CarpoolOfferFulfillment> coFulfillment = new List<CarpoolOfferFulfillment>();

            var uri = new Uri(string.Format(AppServerConstants.CarpoolOfferFulfillmentsUrl, "ByPassengerId/" + passengerId));
            HttpResponseMessage response = null;

            try
            {
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    coFulfillment = JsonConvert.DeserializeObject<List<CarpoolOfferFulfillment>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
                throw;
            }

            return coFulfillment;
        }

        public Task<bool> AcceptCarpoolOffer(int carpoolOfferId)
        {
            throw new NotImplementedException();
        }
    }
}
