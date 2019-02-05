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
            return View(comisions);
        }

        [HttpPost]
        public ActionResult Comision(String name, String description, HttpPostedFileBase photo, float price, int? id, String option)
        {
            String ruta = Server.MapPath("~/images/Comision");
            if (option == "ADD")
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    ToolImage.UploadImage(photo, ruta, name);
                    repo.InsertComision(name, description, "~/images/Comision", photo, price);
                }
            } else if(option == "UPDATE")
            {
                COMISION comision = this.repo.GetComisionByID(id.Value);
                if (comision != null) 
                {
                    String image = null;
                    if (photo != null)
                    {
                        String photoRemove = comision.PHOTO.Split('\\')[1];
                        ToolImage.RemoveImage(photoRemove, ruta);
                        ToolImage.UploadImage(photo, ruta, name);

                        String type = photo.ContentType.Split('/')[1];
                        image = name + "." + type;
                    }

                    repo.ModifyComision(id.Value, name, description, "~/images/Comision\\", image, price);
                }
                
            } else if (option == "DELETE")
            {
                COMISION comision = this.repo.GetComisionByID(id.Value);
                if (comision != null)
                {
                    repo.DeleteComision(id.Value, ruta);
                }
            }
            
            return RedirectToAction("Comision");
        }
        
        
        public void OrderComision(String[] order)
        {
            this.repo.OrderComision(order);
        }
    }
}