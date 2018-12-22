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
        HelperPartnerWork helperPW;
        public adminController()
        {
            helper = new HelperLogin();
            helperPW = new HelperPartnerWork();
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

        /* ---- PARTNERS ---- */
        //GET: PARTNERS
        public ActionResult Partners()
        {
            List<WORKER> p = helperPW.GetPartners();
            return View(p);
        }
        //POST: Partners
        [HttpPost]
        public ActionResult Partners(String name, String contact, String urlContact, int option, int? id)
        {
            if(option == 1)
            {
                helperPW.InsertPartner(name, contact, urlContact);
            } else
            if(option == 2)
            {
                helperPW.UpdatePartner(id.Value, name, contact, urlContact);
            } else
            if (option == 3)
            {
                helperPW.RemovePartner(id.Value);
            }
            List<WORKER> p = helperPW.GetPartners();
            return View(p);
        }
    }
}