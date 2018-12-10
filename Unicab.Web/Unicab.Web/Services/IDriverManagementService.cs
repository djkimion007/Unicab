using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unicab.Web;
using Unicab.Api.Models;

namespace Unicab.Web.Services
{
    public interface IDriverManagementService
    {
        Task<List<DriverApplicant>> GetDriverApplicantsList();

        Task<DriverApplicant> GetDriverApplicant(int driverApplicantId);

        Task ApproveDriverApplicant(DriverApplicant driver);

        Task RejectDriverApplicant(DriverApplicant driver);

        Task<List<Driver>> GetApprovedDriversList();

        Task<Driver> ViewDriver(int driverId);

        Task SetInactiveDriver(int driverId);

        Task SetActiveDriver(int driverId);

        Task GetBlacklistedDriversList();

        Task ViewBlacklistedDriver(int driverId);

        Task BlacklistDriver(int driverId);

        Task UnblacklistDriver(int driverId);

    }
}