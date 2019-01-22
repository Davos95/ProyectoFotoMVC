using RepositorioPictureManager.Models;
using RepositorioPictureManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFotoMVC.Controllers
{
    public class loginController : Controller
    {

        IRepositoryLogin repoLogin;
        public loginController(IRepositoryLogin repository)
        {
            this.repoLogin = repository;
        }

        // GET: Login
        public ActionResult login()
        {
            USERS user = new USERS();
            return View(user);
        }
        //POST: Login
        [HttpPost]
        public ActionResult login(USERS user)
        {
            if (user.NICK != null && user.PWD != null)
            {
                if (repoLogin.GetLogin(user.NICK, user.PWD))
                {
                    return RedirectToAction("menu", "admin");
                }
            }
            return View();
        }
    }
}