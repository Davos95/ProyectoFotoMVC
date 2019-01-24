using ProyectoFotoMVC.Atributes;
using RepositorioPictureManager.Models;
using RepositorioPictureManager.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFotoMVC.Controllers
{
    [AuthorizeUser]
    public class adminController : Controller
    {

        IRepositoryPartner repoPartner;
        IRepositoryWork repoWork;
        
        public adminController( IRepositoryPartner repoP, IRepositoryWork repoW)
        {
            this.repoPartner = repoP;
            this.repoWork = repoW;
        }

        public ActionResult menu()
        {
            return View();
        }

        #region PARTNERS

        //GET: PARTNERS
        public ActionResult Partners()
        {
            List<WORKER> p = this.repoPartner.GetPartners();
            return View(p);
        }

        //POST: Partners
        [HttpPost]
        public ActionResult Partners(String name, String contact, String urlContact, int option, int? id)
        {
            if(option == 1)
            {
                this.repoPartner.InsertPartner(name, contact, urlContact);
            } else
            if(option == 2)
            {
                this.repoPartner.UpdatePartner(id.Value, name, contact, urlContact);
            } else
            if (option == 3)
            {
                this.repoPartner.RemovePartner(id.Value);
            }
            List<WORKER> p = this.repoPartner.GetPartners();
            return View(p);
        }
        #endregion

        #region WORKS

        //GET: WORKS
        public ActionResult Works()
        {
            List<WORK> works = this.repoWork.GetWORKs();
            return View(works);
        }

        //POST: WORKS
        [HttpPost]
        public ActionResult Works(String work, int option, int? id )
        {
            if(option == 0)
            {
                this.repoWork.InsertWork(work);
            } else if(option == 1)
            {
                this.repoWork.DeleteWork(id.Value);
            }

            List<WORK> works = this.repoWork.GetWORKs();
            return View(works);
        }
        #endregion

        #region COMISION
        public ActionResult Comision()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Comision(HttpPostedFileBase photo)
        {
            if (photo != null && photo.ContentLength > 0)
            {
                String ruta = Server.MapPath("~/images/Comision");
                //ToolImage.UploadImage(photo, ruta);
                ToolImage.RemoveImage(photo, ruta);
            }
            return View();
        }
        #endregion

    }
}