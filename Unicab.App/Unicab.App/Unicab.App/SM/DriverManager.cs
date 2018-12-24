﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unicab.Api.Models;

namespace Unicab.App.SM
{
    public class DriverManager
    {
        IDriverService driverService;

        public DriverManager(IDriverService service)
        {
            driverService = service;
        }

        public Task<Driver> GetDriverById(int driverId)
        {
            return driverService.GetDriverById(driverId);
        }
    }
}