using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.Web.Services
{
    public interface IPassengerManagementService
    {
        Task<List<PassengerApplicant>> GetPassengerApplicantsList();
        Task<PassengerApplicant> ViewPassengerApplicant(int passengerApplicantId);
        Task ApprovePassengerApplicant(PassengerApplicant passengerApplicant);
        Task RejectPassengerApplicant(PassengerApplicant passengerApplicant);

        Task<List<Passenger>> GetApprovedPassengersList();
        Task<Passenger> ViewPassenger(int passengerId);

        Task<List<PassengerBlacklist>> GetPassengerBlacklistsList();
        Task<PassengerBlacklist> ViewPassengerBlacklist(int passengerId);
        Task AddToPassengerBlacklist(int passengerId);
        Task RemoveFromPassengerBlacklist(int passengerId);
    }
}
