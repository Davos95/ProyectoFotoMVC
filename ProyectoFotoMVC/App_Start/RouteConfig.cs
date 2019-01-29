using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoFotoMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            //routes.MapRoute(
            //    name: "EliminarEnfermo",
            //    url: "Enfermos/Delete/{inscripcion}/{}",
            //    defaults: new {

            //        controller = "Enfermos",
            //        action = "EliminarEnfermo"
            //    },
            //    constraints: new { httpMethod = new HttpMethodConstraint("POST") });

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "admin", action = "login", id = UrlParameter.Optional }
            );
        }
    }
}
