using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NextSalaryCalculator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{dto}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    //dto = UrlParameter.Optional

                }
            );
        }
    }
}