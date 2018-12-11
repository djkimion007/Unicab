using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unicab.Api.Models;
using Unicab.Web.Services;

namespace Unicab.Web.Pages.DriverModule
{
    public class ViewDriverApplicantModel : PageModel
    {
        private IDriverManagementService driverManagementService;

        [BindProperty]
        public DriverApplicant driverApplicant { get; set; }

        public ViewDriverApplicantModel(IDriverManagementService service)
        {
            driverManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            driverApplicant = await driverManagementService.ViewDriverApplicant(id);
        }

        public async Task<IActionResult> OnPostRejectDriverApplicantAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (driverApplicant != null)
                await driverManagementService.RejectDriverApplicant(driverApplicant);

            return RedirectToPage("/DriverModule/Index");
        }

        public async Task<IActionResult> OnPostApproveDriverApplicantAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (driverApplicant != null)
                await driverManagementService.ApproveDriverApplicant(driverApplicant);

            return RedirectToPage("/DriverModule/Index");
        }
    }
}