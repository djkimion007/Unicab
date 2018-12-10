using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unicab.Web.Services
{
    public static class AppServerConstants
    {
        public static string AppServerUrl = "http://10.207.142.52";
        public static int AppServerPort = 53940;

        public static string DriverApplicantsUrl = AppServerUrl + ":" + AppServerPort + "/api/DriverApplicants/{0}";
        public static string PassengerApplicantsUrl = AppServerUrl + ":" + AppServerPort + "/api/PassengerApplicants/{0}";

        public static string DriversUrl = AppServerUrl + ":" + AppServerPort + "/api/Drivers/{0}";
        public static string PassengersUrl = AppServerUrl + ":" + AppServerPort + "/api/Passengers/{0}";
    }
}
