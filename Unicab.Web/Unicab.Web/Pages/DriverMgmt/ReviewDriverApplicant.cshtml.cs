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
    public class ReviewDriverApplicantModel : PageModel
    {
        private IDriverManagementService driverManagementService;

        [BindProperty]
        public DriverApplicant driverApplicant { get; set; }

        public ReviewDriverApplicantModel(IDriverManagementService service)
        {
            driverManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            driverApplicant = await driverManagementService.GetDriverApplicant(id);
        }

        public async Task<IActionResult> OnPostRejectDriverApplicantAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (driverApplicant != null)
                await driverManagementService.RejectDriverApplicant(driverApplicant);

            return RedirectToPage("/DriverMgmt/Index");
        }

        public async Task<IActionResult> OnPostApproveDriverApplicantAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (driverApplicant != null)
                await driverManagementService.ApproveDriverApplicant(driverApplicant);

            return RedirectToPage("/DriverMgmt/Index");
        }
    }
}