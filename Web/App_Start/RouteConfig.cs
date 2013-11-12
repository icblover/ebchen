using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //文章列表
            routes.MapRoute("Articles", "{controller}/{channel}",
                            defaults: new { controller = "Article", action = "List", channel = @"\w{1,}" }, 
                            namespaces: new[] { "Web.Controllers" });

            //文章详细内容
            routes.MapRoute("Article", "{controller}/{channel}/{id}",
                defaults: new { controller = "Article", action = "Index", channel = @"\w{1,}", id = UrlParameter.Optional });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}