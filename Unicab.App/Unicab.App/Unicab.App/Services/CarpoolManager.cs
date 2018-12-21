using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.Services
{
    public class CarpoolManager
    {
        ICarpoolService carpoolService;

        public CarpoolManager(ICarpoolService service)
        {
            carpoolService = service;
        }

        public Task<bool> TryCreateNewCarpoolOffer(CarpoolOffer carpoolOffer)
        {
            return carpoolService.CreateNewCarpoolOffer(carpoolOffer);
        }

        public Task<CarpoolOffer> TryGetCarpoolOfferById(int carpoolOfferId)
        {
            return carpoolService.GetCarpoolOfferById(carpoolOfferId);
        }

        public Task<List<CarpoolOffer>> TryGetAvailableCarpoolOffers()
        {
            return carpoolService.GetAvailableCarpoolOffers();
        }
    }
}
