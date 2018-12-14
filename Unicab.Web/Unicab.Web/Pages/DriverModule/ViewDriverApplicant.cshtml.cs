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
        [BindProperty]
        public string MatricsCardPhotoImgSrc { get; set; }
        [BindProperty]
        public string DriversLicensePhotoImgSrc { get; set; }
        [BindProperty]
        public string CarInsuranceGrantPhotoImgSrc { get; set; }

        public ViewDriverApplicantModel(IDriverManagementService service)
        {
            driverManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            driverApplicant = await driverManagementService.ViewDriverApplicant(id);

            if (driverApplicant.MatricsCardPhoto != null)
            {
                var base64 = Convert.ToBase64String(driverApplicant.MatricsCardPhoto);
                MatricsCardPhotoImgSrc = string.Format("data:image;base64,{0}", base64);
            }

            if (driverApplicant.DriversLicensePhoto != null)
            {
                var base64 = Convert.ToBase64String(driverApplicant.DriversLicensePhoto);
                DriversLicensePhotoImgSrc = string.Format("data:image;base64,{0}", base64);
            }

            if (driverApplicant.CarInsuranceGrantPhoto != null)
            {
                var base64 = Convert.ToBase64String(driverApplicant.CarInsuranceGrantPhoto);
                CarInsuranceGrantPhotoImgSrc = string.Format("data:image;base64,{0}", base64);
            }
        }

        public async Task<IActionResult> OnPostRejectDriverApplicantAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (driverApplicant != null)
                await driverManagementService.RejectDriverApplicant(driverApplicant.DriverApplicantId);

            return RedirectToPage("/DriverModule/Index");
        }

        public async Task<IActionResult> OnPostApproveDriverApplicantAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (driverApplicant != null)
                await driverManagementService.ApproveDriverApplicant(driverApplicant.DriverApplicantId);

            return RedirectToPage("/DriverModule/Index");
        }
    }
}