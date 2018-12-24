using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Unicab.Api.Models;
using Unicab.Web.Services;

namespace Unicab.Web.Pages.LocationModule
{
    public class IndexModel : PageModel
    {
        public List<Location> LocationsList { get; set; }

        public List<SelectListItem> IsWithinUSMOptions { get; } = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = null, Text = "Select"
            },
            new SelectListItem
            {
                Value = "true", Text = "Yes"
            },
            new SelectListItem
            {
                Value = "false", Text = "No"
            }
        };

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

        [HttpPost]
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