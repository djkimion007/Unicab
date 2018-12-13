using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.App.Services
{
    public static class AppServerConstants
    {
        public static string AppServerUrl = "http://10.207.142.52";
        public static int AppServerPort = 53940;

        public static string DriverApplicantsUrl = AppServerUrl + ":" + AppServerPort + "/api/DriverApplicants/{0}";
        public static string PassengerApplicantsUrl = AppServerUrl + ":" + AppServerPort + "/api/PassengerApplicants/{0}";
    }
}
