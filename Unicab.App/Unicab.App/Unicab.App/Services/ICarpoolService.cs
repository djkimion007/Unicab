using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.Services
{
    public interface ICarpoolService
    {
        Task<bool> CreateNewCarpoolOffer(CarpoolOffer carpoolOffer);

        Task<CarpoolOffer> GetCarpoolOfferById(int carpoolOfferId);

        Task<List<CarpoolOffer>> GetAvailableCarpoolOffers();

        //Task<bool> AcceptCarpoolOffer(int carpoolOfferId);

    }
}
