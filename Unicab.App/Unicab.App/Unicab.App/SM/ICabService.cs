using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public interface ICabService
    {
        Task<bool> CreateNewCabRequest(CabRequest cabRequest);

        Task<CabRequest> GetCabRequestById(int cabRequestId);

        Task<List<CabRequest>> GetAvailableCabRequests();

        Task<List<CabRequest>> GetAvailableCabRequestsByPassengerId(int passengerId);

        Task<bool> AcceptCabRequest(CabRequest fulfillment);

        Task<List<CabRequestFulfillment>> GetCabRequestFulfillmentsByDriverId(int driverId);

        Task<bool> CompleteCabRequestDriverSide(CabRequestFulfillment fulfillment);

        Task<bool> CompleteCabRequestPassengerSide(CabRequestFulfillment fulfillment);

        Task<bool> CancelCabRequestByDriver(CabRequestFulfillment fulfillment);

        Task<bool> CancelCabRequestByPassenger(CabRequestFulfillment fulfillment);

    }
}
