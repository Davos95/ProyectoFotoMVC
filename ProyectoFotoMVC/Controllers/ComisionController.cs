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
    public class ComisionController : Controller
    {
        IRepositoryComision repo;
        public ComisionController(IRepositoryComision repo)
        {
            this.repo = repo;
        }
        public ActionResult Comision()
        {
            List<COMISION> comisions = this.repo.GetCOMISIONS();
            System.Diagnostics.Debug.WriteLine(comisions);
            return View(comisions);
        }

        [HttpPost]
        public ActionResult Comision(String name, String description, HttpPostedFileBase photo, float price)
        {
            if (photo != null && photo.ContentLength > 0)
            {
                String ruta = Server.MapPath("~/images/Comision");
                ToolImage.UploadImage(photo, ruta);
                repo.InsertComision(name, description, "~/images/Comision", photo, price);
            }

            List<COMISION> comisions = this.repo.GetCOMISIONS();
            System.Diagnostics.Debug.WriteLine(comisions);
            return View(comisions);
        }
        
    }
}