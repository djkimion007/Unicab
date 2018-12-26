using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public interface ILocationService
    {
        Task<List<Location>> GetStationLocationsExcludeUSM();

        Task<List<Location>> GetStationLocationsIncludeUSM();

        Task<List<Location>> GetStationLocationsAll();

        Task<Location> GetLocationById(int locationId);
    }
}
