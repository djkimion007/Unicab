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
    public class ViewDriverBlacklistModel : PageModel
    {
        private IDriverManagementService driverManagementService;

        [BindProperty]
        public DriverBlacklist driverBlacklist { get; set; }

        public ViewDriverBlacklistModel(IDriverManagementService service)
        {
            driverManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            driverBlacklist = await driverManagementService.ViewDriverBlacklist(id);
        }

    }
}