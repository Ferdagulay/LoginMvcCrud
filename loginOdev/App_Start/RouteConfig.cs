using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace loginOdev
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PageRoute",
                url: "pages/{url}",
                defaults: new { controller = "AnyPage", action = "Test" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{url}",
                defaults: new { controller = "Login", action = "Index", url = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            //);



        }
    }
}
