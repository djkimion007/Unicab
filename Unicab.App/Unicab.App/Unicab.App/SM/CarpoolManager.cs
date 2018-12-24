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
    }
}
