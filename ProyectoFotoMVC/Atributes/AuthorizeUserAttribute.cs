using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoFotoMVC.Atributes
{
    public class AuthorizeUserAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                GenericPrincipal user = (GenericPrincipal)filterContext.HttpContext.User;
                if (user.IsInRole("ADMINISTRATOR") == false)
                {
                    filterContext.Result = GetRutaRedirect("login", "ErrorAcceso");
                }
            }
            else
            {
                filterContext.Result = GetRutaRedirect("login", "login");
            }
        }

        public RedirectToRouteResult GetRutaRedirect(String controlador, String accion)
        {
            RouteValueDictionary ruta = new RouteValueDictionary(new { controller = controlador, action = accion });
            RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);
            return direccion;
        }
    }
}