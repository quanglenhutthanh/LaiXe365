using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace code
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            "Page by name",
            "{title}.html/",
                new { controller = "Home", action = "PageByTitle" }
            );
            routes.MapRoute(
           "post type 2",
           "y-kien-khach-hang/",
               new { controller = "post", action = "comment" }
           );
            routes.MapRoute(
           "post detail",
           "bai-viet/{alias}",
               new { controller = "post", action = "PostDetail" }
           );
             routes.MapRoute(
            "admin",
            "admin/",
                new { controller = "admin", action = "index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}