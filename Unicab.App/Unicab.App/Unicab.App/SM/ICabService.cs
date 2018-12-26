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

        Task<List<CabRequest>> GetCabRequestsByDriverId(int driverId);

        Task<bool> CompleteCabRequestDriverSide(CabRequest fulfillment);

        Task<bool> CompleteCabRequestPassengerSide(CabRequest fulfillment);

        Task<bool> CancelCabRequestByDriver(CabRequest fulfillment);

        Task<bool> CancelCabRequestByPassenger(CabRequest fulfillment);

    }
}
