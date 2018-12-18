using ProyectoFotoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFotoMVC.Controllers
{
    public class adminController : Controller
    {
        HelperLogin helper;
        public adminController()
        {
            helper = new HelperLogin();
        }
        // GET: admin

        public ActionResult login()
        {
            return View();
        }
        //POST: admin
        [HttpPost]
        public ActionResult login(String nick, String pwd)
        {
            if (helper.GetLogin(nick,pwd))
            {
                return RedirectToAction("menu","admin");
            }
            return View();
        }
        public ActionResult menu()
        {
            return View();
        }
    }
}