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

        Task<PassengerApplicant> GetPassengerApplicant(int passengerApplicantId);

        Task ApprovePassengerApplicant(int passengerApplicantId);

        Task RejectPassengerApplicant(int passengerApplicantId);

        Task<List<Passenger>> GetApprovedPassengersList();

        Task<Passenger> ViewPassenger(int passengerId);

        Task SetInactivePassenger(int passengerId);

        Task SetActivePassenger(int passengerId);

        Task GetBlacklistedPassengersList();

        Task ViewBlacklistedPassenger(int passengerId);

        Task BlacklistPassenger(int passengerId);

        Task UnblacklistPassenger(int passengerId);
    }
}
