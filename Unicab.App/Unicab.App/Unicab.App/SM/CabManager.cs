using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public class CabManager
    {
        ICabService cabService;

        public CabManager(ICabService service)
        {
            cabService = service;
        }

        public Task<bool> CreateNewCabRequest(CabRequest carpoolOffer)
        {
            return cabService.CreateNewCabRequest(carpoolOffer);
        }

        public Task<CabRequest> GetCabRequestById(int carpoolOfferId)
        {
            return cabService.GetCabRequestById(carpoolOfferId);
        }

        public Task<List<CabRequest>> GetAvailableCabRequests()
        {
            return cabService.GetAvailableCabRequests();
        }

        public Task<List<CabRequest>> GetAvailableCabRequestsByPassengerId(int passengerId)
        {
            return cabService.GetAvailableCabRequestsByPassengerId(passengerId);
        }
    }
}
