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
        Task<DriverApplicant> ViewDriverApplicant(int driverApplicantId);
        Task<bool> ApproveDriverApplicant(int driverApplicantId);
        Task<bool> RejectDriverApplicant(int driverApplicantId);

        Task<List<Driver>> GetApprovedDriversList();
        Task<Driver> ViewDriver(int driverId);

        Task<List<DriverBlacklist>> GetDriverBlacklistsList();
        Task<DriverBlacklist> ViewDriverBlacklist(int driverId);
        Task AddToDriverBlacklist(int driverId);
        Task RemoveFromDriverBlacklist(int driverId);

    }
}