using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.App.SM
{
    public static class AppServerConstants
    {
        public static string AppServerUrl = "http://172.20.10.3";
        public static int AppServerPort = 53940;

        public static string DriverApplicantsUrl = AppServerUrl + ":" + AppServerPort + "/api/DriverApplicants/{0}";
        public static string PassengerApplicantsUrl = AppServerUrl + ":" + AppServerPort + "/api/PassengerApplicants/{0}";

        public static string DriversUrl = AppServerUrl + ":" + AppServerPort + "/api/Drivers/{0}";
        public static string PassengersUrl = AppServerUrl + ":" + AppServerPort + "/api/Passengers/{0}";

        public static string LocationsUrl = AppServerUrl + ":" + AppServerPort + "/api/Locations/{0}";

        public static string CarpoolOffersUrl = AppServerUrl + ":" + AppServerPort + "/api/CarpoolOffers/{0}";
        public static string CabRequestsUrl = AppServerUrl + ":" + AppServerPort + "/api/CabRequests/{0}";
    }
}
