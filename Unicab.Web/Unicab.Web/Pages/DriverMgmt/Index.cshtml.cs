using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unicab.Api.Models;
using Unicab.Web.Services;

namespace Unicab.Web.Pages.DriverMgmt
{
    public class IndexModel : PageModel
    {
        public List<DriverApplicant> DriverApplicants { get; set; }
        public List<DriverBlacklist> DriverBlacklists { get; set; }
        public List<Driver> Drivers { get; set; }

        private IDriverManagementService driverManagementService;

        public IndexModel(IDriverManagementService service)
        {
            driverManagementService = service;
        }

        public async Task OnGetAsync()
        {
            DriverApplicants = await driverManagementService.GetDriverApplicantsList();
            DriverBlacklists = await driverManagementService.GetDriverBlacklistsList();
            Drivers = await driverManagementService.GetApprovedDriversList();
        }
    }
}