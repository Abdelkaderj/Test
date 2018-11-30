using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlightMonitoring
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{DestinationAirportId}/{ArrivalAirportId}/{FlightId}",
                defaults: new { controller = "Home", action = "Distance", DestinationAirportId = UrlParameter.Optional, ArrivalAirportId = UrlParameter.Optional, FlightId= UrlParameter.Optional }
            );
        }
    }
}
