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
        IRepositoryPartner repoPartner;
        IRepositoryWork repoWork;
        IRepositoryPhoto repoPhoto;

        public SesionController(IRepositoryComision repoC,IRepositorySesion repoS, IRepositoryPartner repoP, IRepositoryWork repoW, IRepositoryPhoto repoPh)
        {
            this.repoComision = repoC;
            this.repoSesion = repoS;
            this.repoPartner = repoP;
            this.repoWork = repoW;
            this.repoPhoto = repoPh;
        }

        public ActionResult Sesion()
        {
            List<SESION> sesions = this.repoSesion.GetSesions().ToList();
            return View(sesions);
        }

        public ActionResult DeleteSesion(int id, String name)
        {
            String path = Server.MapPath("~/images/Sesion");
            ToolImage.DeleteFolder(path, name);
            this.repoSesion.DeleteSesion(id);

            return RedirectToAction("Sesion");
        }

        #region Create Sesion
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
        #endregion

        #region Edit Sesion
        public ActionResult EditSesion(int id)
        {
            SESION sesion = this.repoSesion.GetSESIONID(id);

            ViewBag.Date = sesion.DATESESION.Value.ToString("yyyy-MM-dd");
            ViewBag.Comision = this.repoComision.GetCOMISIONS().ToList();
            ViewBag.Partner = this.repoPartner.GetPartners().ToList();
            ViewBag.Work = this.repoWork.GetWORKs().ToList();
            ViewBag.Workers = this.repoSesion.GetPartnerWorkBySesion(id);
            return View(sesion);
        }

        [HttpPost]
        public ActionResult EditSesion(String option, int idSesion, int? idPartner, int? idWork, String name, String description, DateTime? date, int? comision)
        {
            if (option == "ADD")
            {
                this.repoSesion.AddPartnerWorkIntoSesion(idSesion, idPartner.Value, idWork.Value);
            } else if(option == "MODIFY")
            {
                String sessionName = this.repoSesion.GetSESIONID(idSesion).NAME;
                String path = Server.MapPath("~/images/Sesion");

                ToolImage.RenameFolder(path, sessionName, name);
                this.repoSesion.ModifySesion(idSesion, name, description, date.Value, comision.Value);
            }


            SESION sesion = this.repoSesion.GetSESIONID(idSesion);
            ViewBag.Date = sesion.DATESESION.Value.ToString("yyyy-MM-dd");
            ViewBag.Comision = this.repoComision.GetCOMISIONS().ToList();
            ViewBag.Partner = this.repoPartner.GetPartners().ToList();
            ViewBag.Work = this.repoWork.GetWORKs().ToList();
            ViewBag.Workers = this.repoSesion.GetPartnerWorkBySesion(idSesion);
            return View(sesion);
        }
        

        public ActionResult DeletePartnerWorkFromSesion(int idSesion, int idPartner, int idWork)
        {
            this.repoSesion.DeletePartnerWorkFromSesion(idSesion, idPartner, idWork);

            return RedirectToAction("EditSesion","Sesion",new { id = idSesion });
        }
        #endregion

        public ActionResult ManagePhotos(int idSesion)
        {
            ViewBag.SessionName = this.repoSesion.GetSESIONID(idSesion).NAME;
            ViewBag.Sessions = this.repoSesion.GetSesions().Where(x => x.ID != idSesion).ToList();
            return View(this.repoPhoto.GetPhotos(idSesion));
        }
    }
}