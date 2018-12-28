using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public interface IDriverService
    {
        Task<Driver> GetDriverById(int driverId);

        Task<List<Driver>> GetAvailableDrivers();

        Task<bool> UpdateProfilePhoto(Driver driver, byte[] profilePhoto);
    }
}
