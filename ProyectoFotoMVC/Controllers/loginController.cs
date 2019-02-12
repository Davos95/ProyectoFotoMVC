using RepositorioPictureManager.Models;
using RepositorioPictureManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoFotoMVC.Controllers
{
    public class loginController : Controller
    {

        IRepositoryLogin repoLogin;
        public loginController(IRepositoryLogin repository)
        {
            this.repoLogin = repository;
        }
        #region LOGIN
        // GET: Login
        public ActionResult login()
        {
            USERS user = new USERS();
            return View(user);
        }

        //POST: Login
        [HttpPost]
        public ActionResult login(String nick, String password)
        {
            USERS user = repoLogin.GetUser(nick, password);
            if (user != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.ID, DateTime.Now, DateTime.Now.AddMinutes(30), true, user.ROLE);
                String ticketEncrypt = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie("PICTUREMANAGER", ticketEncrypt);
                Response.Cookies.Add(cookie);
                return RedirectToAction("menu", "admin");
            }
            else
            {
                ViewBag.Mensaje = "Usuario/Password incorrectos.";
            }
            return View();
        }

        #endregion

        #region ErrorAcceso
        
        // GET: ErrorAcceso
        public ActionResult ErrorAcceso()
        {
            return View();
        }

        #endregion


        public ActionResult CerrarSesion()
        {
            //DEBEMOS QUITAR AL USUARIO Y SU IDENTIDAD
            HttpContext.User = new GenericPrincipal(new GenericIdentity(""), null);
            //SALIR DE LA AUTENTIFICACION
            FormsAuthentication.SignOut();
            //RECUPERAR LA COOKIE Y EXPIRARLA
            HttpCookie cookie = Request.Cookies["PICTUREMANAGER"];
            cookie.Expires = DateTime.Now.AddYears(-1);
            //VOLVER A ESCRIBIR LA COOKIE
            Response.Cookies.Add(cookie);

            return RedirectToAction("login","login");
        }


    }
}