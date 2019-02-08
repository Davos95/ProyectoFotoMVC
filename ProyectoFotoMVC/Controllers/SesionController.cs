using ProyectoFotoMVC.Atributes;
using RepositorioPictureManager.Models;
using RepositorioPictureManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFotoMVC.Controllers
{
    [AuthorizeUser]
    public class SesionController : Controller
    {
        IRepositoryComision repoComision;
        IRepositorySesion repoSesion;
        public SesionController(IRepositoryComision repoC,IRepositorySesion repoS)
        {
            this.repoComision = repoC;
            this.repoSesion = repoS;
        }

        public ActionResult Sesion()
        {
            List<SESION> sesions = this.repoSesion.GetSesions().ToList();
            return View(sesions);
        }

        // GET: CreateSesion
        public ActionResult CreateSesion()
        {
            return View(this.repoComision.GetCOMISIONS().ToList());
        }

        [HttpPost]
        public ActionResult CreateSesion(String name, String description, DateTime date, int comision) {
            String path = Server.MapPath("~/images/Sesion");
            ToolImage.CreateFolder(path,name);
            this.repoSesion.InsertSesion(name, description, date, comision);
            return RedirectToAction("Sesion");
        }

        public ActionResult DeleteSesion(int id, String name)
        {
            String path = Server.MapPath("~/images/Sesion");
            ToolImage.DeleteFolder(path, name);
            this.repoSesion.DeleteSesion(id);

            return RedirectToAction("Sesion");
        }
    }
}