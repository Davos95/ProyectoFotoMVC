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
        public ActionResult Comision(String name, String description, HttpPostedFileBase photo, float price, int? id, int option)
        {
            String ruta = Server.MapPath("~/images/Comision");
            if (option == 0)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    
                    ToolImage.UploadImage(photo, ruta);
                    repo.InsertComision(name, description, "~/images/Comision", photo, price);
                }
            } else if(option == 1)
            {
                repo.ModifyComision(id.Value, name, description, ruta , "~/images/Comision", photo, price);
            } else if (option == 2)
            {
                repo.DeleteComision(id.Value, ruta);
            }
            
            List<COMISION> comisions = this.repo.GetCOMISIONS();
            System.Diagnostics.Debug.WriteLine(comisions);
            return View(comisions);
        }
        
        
        public void OrderComision(String[] order)
        {
            this.repo.OrderComision(order);
        }
    }
}