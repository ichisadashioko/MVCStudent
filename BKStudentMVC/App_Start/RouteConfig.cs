using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BKStudentMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BKStudents", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "ReactView",
            //    url: "{controller}/{action}/{page}",
            //    defaults: new { controller = "Home", action = "Rules", page = UrlParameter.Optional }
            //);
        }
    }
}
