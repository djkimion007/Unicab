using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.Web.Services
{
    public interface IAdminManagementService
    {
        Task<List<Admin>> GetAdminsList();
        Task<Admin> ViewAdmin(int adminId);
    }
}
