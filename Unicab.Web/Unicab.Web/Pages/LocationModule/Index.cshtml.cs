using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unicab.Api.Models;
using Unicab.Web.Services;

namespace Unicab.Web.Pages.LocationModule
{
    public class IndexModel : PageModel
    {
        public List<Location> LocationsList { get; set; }

        [BindProperty]
        public Location location { get; set; }

        private ILocationManagementService locationManagementService;

        public IndexModel(ILocationManagementService service)
        {
            locationManagementService = service;
        }

        public async Task OnGetAsync()
        {
            LocationsList = await locationManagementService.GetLocations();
        }

        public async Task<IActionResult> OnPostSaveNewLocationAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (location != null)
                await locationManagementService.SaveNewLocation(location);

            return RedirectToPage("/LocationModule/Index");
        }
    }
}