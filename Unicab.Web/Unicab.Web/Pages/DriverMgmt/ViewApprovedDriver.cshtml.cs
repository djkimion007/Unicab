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
    public class ViewApprovedDriverModel : PageModel
    {
        private IDriverManagementService driverManagementService;
        public Driver driver;

        public ViewApprovedDriverModel(IDriverManagementService service)
        {
            driverManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            driver = await driverManagementService.ViewDriver(id);
        }
    }
}