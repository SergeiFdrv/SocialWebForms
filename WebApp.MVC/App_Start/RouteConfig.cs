using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "DefaultNoIndex",
                url: "{controller}/{id}/{name}",
                defaults: new { controller = "Home", action = "Index", name = UrlParameter.Optional },
                constraints: new { id = "\\d+" }
            );

            /*routes.MapRoute(
                name: "DefaultNoID",
                url: "{controller}/{id}",
                defaults: new { controller = "Home", action = "Index" }
            );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
