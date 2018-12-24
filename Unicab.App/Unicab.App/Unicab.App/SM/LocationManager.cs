using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public class LocationManager
    {
        ILocationService locationService;

        public LocationManager(ILocationService service)
        {
            locationService = service;
        }

        public Task<List<Location>> GetStationLocationsAll()
        {
            return locationService.GetStationLocationsAll();
        }

        public Task<List<Location>> GetStationLocationsIncludeUSM()
        {
            return locationService.GetStationLocationsIncludeUSM();
        }

        public Task<List<Location>> GetStationLocationsExcludeUSM()
        {
            return locationService.GetStationLocationsExcludeUSM();
        }
    }
}
