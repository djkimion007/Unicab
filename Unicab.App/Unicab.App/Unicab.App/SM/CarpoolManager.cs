using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public class CarpoolManager
    {
        ICarpoolService carpoolService;

        public CarpoolManager(ICarpoolService service)
        {
            carpoolService = service;
        }

        public Task<bool> CreateNewCarpoolOffer(CarpoolOffer carpoolOffer)
        {
            return carpoolService.CreateNewCarpoolOffer(carpoolOffer);
        }

        public Task<CarpoolOffer> GetCarpoolOfferById(int carpoolOfferId)
        {
            return carpoolService.GetCarpoolOfferById(carpoolOfferId);
        }

        public Task<List<CarpoolOffer>> GetAvailableCarpoolOffers()
        {
            return carpoolService.GetAvailableCarpoolOffers();
        }

        public Task<List<CarpoolOffer>> GetAvailableCarpoolOffersByDriverId(int driverId)
        {
            return carpoolService.GetAvailableCarpoolOffersByDriverId(driverId);
        }

        public Task<bool> CancelCarpoolOffer(int carpoolOfferId)
        {
            return carpoolService.CancelCarpoolOffer(carpoolOfferId);
        }

        public Task<bool> CompleteCarpoolOfferDriverSide(CarpoolOfferFulfillment fulfillment)
        {
            return carpoolService.CompleteCarpoolOfferDriverSide(fulfillment);
        }

        public Task<bool> CompleteCarpoolOfferPassengerSide(CarpoolOfferFulfillment fulfillment)
        {
            return carpoolService.CompleteCarpoolOfferPassengerSide(fulfillment);
        }

        public Task<List<CarpoolOfferFulfillment>> GetAvailableCarpoolOfferFulfillmentsByDriverId(int driverId)
        {
            return carpoolService.GetAvailableCarpoolOfferFulfillmentsByDriverId(driverId);
        }

        public Task<List<CarpoolOfferFulfillment>> GetAvailableCarpoolOfferFulfillmentsByPassengerId(int passengerId)
        {
            return carpoolService.GetAvailableCarpoolOfferFulfillmentsByPassengerId(passengerId);
        }

    }
}
