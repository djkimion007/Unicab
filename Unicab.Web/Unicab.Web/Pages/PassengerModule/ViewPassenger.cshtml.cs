using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unicab.Api.Models;
using Unicab.Web.Services;

namespace Unicab.Web.Pages.PassengerModule
{
    public class ViewPassengerModel : PageModel
    {
        private IPassengerManagementService passengerManagementService;

        [BindProperty]
        public Passenger passenger { get; set; }
        [BindProperty]
        public string ImgSrc { get; set; }

        public ViewPassengerModel(IPassengerManagementService service)
        {
            passengerManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            passenger = await passengerManagementService.ViewPassenger(id);

            if (passenger.MatricsCardPhoto != null)
            {
                var base64 = Convert.ToBase64String(passenger.MatricsCardPhoto);
                ImgSrc = string.Format("data:image;base64,{0}", base64);
            }

        }
    }
}