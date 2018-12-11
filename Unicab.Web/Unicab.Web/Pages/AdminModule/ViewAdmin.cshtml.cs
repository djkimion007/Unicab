using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unicab.Api.Models;
using Unicab.Web.Services;

namespace Unicab.Web.Pages.AdminModule
{
    public class ViewAdminModel : PageModel
    {
        public Admin admin { get; private set; }

        private IAdminManagementService adminManagementService;

        public ViewAdminModel(IAdminManagementService service)
        {
            adminManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            admin = await adminManagementService.ViewAdmin(id);
        }
    }
}