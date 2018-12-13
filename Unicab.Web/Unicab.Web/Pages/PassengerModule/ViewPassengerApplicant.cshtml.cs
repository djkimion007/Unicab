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
    public class ViewPassengerApplicantModel : PageModel
    {
        private IPassengerManagementService passengerManagementService;

        [BindProperty]
        public PassengerApplicant passengerApplicant { get; set; }
        [BindProperty]
        public string ImgSrc { get; set; }

        public ViewPassengerApplicantModel(IPassengerManagementService service)
        {
            passengerManagementService = service;
        }

        public async Task OnGetAsync(int id)
        {
            passengerApplicant = await passengerManagementService.ViewPassengerApplicant(id);

            if (passengerApplicant.MatricsCardPhoto != null)
            {
                var base64 = Convert.ToBase64String(passengerApplicant.MatricsCardPhoto);
                ImgSrc = string.Format("data:image;base64,{0}", base64);
            }

        }

        public async Task<IActionResult> OnPostRejectPassengerApplicantAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (passengerApplicant != null)
                await passengerManagementService.RejectPassengerApplicant(passengerApplicant.PassengerApplicantId);

            return RedirectToPage("/PassengerModule/Index");
        }

        public async Task<IActionResult> OnPostApprovePassengerApplicantAsync()
        {
            bool isSuccessful = false;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (passengerApplicant != null)
            {
                isSuccessful = await passengerManagementService.ApprovePassengerApplicant(passengerApplicant.PassengerApplicantId);
            }

            if (isSuccessful)
                return RedirectToPage("/PassengerModule/Index");
            else
                return Page();
        }
    }
}