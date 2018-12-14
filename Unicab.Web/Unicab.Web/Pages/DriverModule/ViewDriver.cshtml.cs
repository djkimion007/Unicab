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
    public class ViewDriverModel : PageModel
    {
        private IDriverManagementService driverManagementService;

        [BindProperty]
        public Driver driver { get; set; }
        [BindProperty]
        public string MatricsCardPhotoImgSrc { get; set; }
        [BindProperty]
        public string DriversLicensePhotoImgSrc { get; set; }
        [BindProperty]
        public string CarInsuranceGrantPhotoImgSrc { get; set; }

        public ViewDriverModel(IDriverManagementService service)
        {
            driverManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            driver = await driverManagementService.ViewDriver(id);

            if (driver.MatricsCardPhoto != null)
            {
                var base64 = Convert.ToBase64String(driver.MatricsCardPhoto);
                MatricsCardPhotoImgSrc = string.Format("data:image;base64,{0}", base64);
            }

            if (driver.DriversLicensePhoto != null)
            {
                var base64 = Convert.ToBase64String(driver.DriversLicensePhoto);
                DriversLicensePhotoImgSrc = string.Format("data:image;base64,{0}", base64);
            }

            if (driver.CarInsuranceGrantPhoto != null)
            {
                var base64 = Convert.ToBase64String(driver.CarInsuranceGrantPhoto);
                CarInsuranceGrantPhotoImgSrc = string.Format("data:image;base64,{0}", base64);
            }
        }
    }
}