using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unicab.Api.Models;
using Unicab.Web.Services;

namespace Unicab.Web.Pages.PassengerMgmt
{
    public class ViewPassengerApplicantModel : PageModel
    {
        private IPassengerManagementService passengerManagementService;
        public PassengerApplicant passengerApplicant;

        public ViewPassengerApplicantModel(IPassengerManagementService service)
        {
            passengerManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            passengerApplicant = await passengerManagementService.ViewPassengerApplicant(id);
        }
    }
}