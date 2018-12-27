using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public interface ICarpoolService
    {
        Task<bool> CreateNewCarpoolOffer(CarpoolOffer carpoolOffer);

        Task<CarpoolOffer> GetCarpoolOfferById(int carpoolOfferId);

        Task<List<CarpoolOffer>> GetAvailableCarpoolOffers();

        Task<List<CarpoolOffer>> GetAvailableCarpoolOffersByDriverId(int driverId);

        Task<bool> AcceptCarpoolOffer(int carpoolOfferId);

        Task<bool> CancelCarpoolOffer(int carpoolOfferId);

        Task<bool> CompleteCarpoolOfferDriverSide(CarpoolOfferFulfillment fulfillment);

        Task<bool> CompleteCarpoolOfferPassengerSide(CarpoolOfferFulfillment fulfillment);

        Task<List<CarpoolOfferFulfillment>> GetAvailableCarpoolOfferFulfillmentsByDriverId(int driverId);

        Task<List<CarpoolOfferFulfillment>> GetAvailableCarpoolOfferFulfillmentsByPassengerId(int passengerId);

    }
}
