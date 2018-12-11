using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.Web.Services
{
    public class AdminManagementService : IAdminManagementService
    {
        private readonly HttpClient client;

        private List<Admin> AdminsList { get; set; }

        public AdminManagementService()
        {
            client = new HttpClient()
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<List<Admin>> GetAdminsList()
        {
            AdminsList = new List<Admin>();

            var uri = new Uri(string.Format(AppServerConstants.AdminsUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    AdminsList = JsonConvert.DeserializeObject<List<Admin>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return AdminsList;
        }

        public async Task<Admin> ViewAdmin(int adminId)
        {
            Admin admin = new Admin();

            var uri = new Uri(string.Format(AppServerConstants.AdminsUrl, adminId));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    admin = JsonConvert.DeserializeObject<Admin>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: {0}", ex.Message);
            }

            return admin;
        }
    }
}
