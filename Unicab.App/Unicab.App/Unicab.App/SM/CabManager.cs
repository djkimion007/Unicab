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

        public Task<List<CabRequest>> GetCabRequestsByDriverId(int driverId)
        {
            return cabService.GetCabRequestsByDriverId(driverId);
        }

        public Task<bool> AcceptCabRequest(CabRequest cabRequest)
        {
            return cabService.AcceptCabRequest(cabRequest);
        }

        public Task<bool> CompleteCabRequestDriverSide(CabRequest fulfillment)
        {
            return cabService.CompleteCabRequestDriverSide(fulfillment);
        }

        public Task<bool> CompleteCabRequestPassengerSide(CabRequest fulfillment)
        {
            return cabService.CompleteCabRequestPassengerSide(fulfillment);
        }

        public Task<bool> CancelCabRequestByDriver(CabRequest fulfillment)
        {
            return cabService.CancelCabRequestByDriver(fulfillment);
        }

        public Task<bool> CancelCabRequestByPassenger(CabRequest fulfillment)
        {
            return cabService.CancelCabRequestByPassenger(fulfillment);
        }

    }
}
