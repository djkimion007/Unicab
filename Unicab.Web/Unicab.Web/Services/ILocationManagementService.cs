using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.Web.Services
{
    public interface ILocationManagementService
    {
        Task<List<Location>> GetLocations();
        Task<Location> GetLocation(int locationId);
        Task<bool> SaveNewLocation(Location newLocation);
        Task<bool> RemoveLocation(int locationId);
    }
}
