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
    public class PartnerWorkController : Controller
    {
        IRepositoryPartner repoP;
        IRepositoryWork repoW;
        public PartnerWorkController(IRepositoryPartner repositoryPartner, IRepositoryWork repositoryWork)
        {
            this.repoP = repositoryPartner;
            this.repoW = repositoryWork;
        }

        // GET: PartnerWork
        public ActionResult Index()
        {
            return View();
        }

        //GET: PARTNERS
        public ActionResult Partners()
        {
            List<WORKER> p = this.repoP.GetPartners();
            return View(p);
        }

        //POST: Partners
        [HttpPost]
        public ActionResult Partners(String name, String contact, String urlContact, int option, int? id)
        {
            if (option == 1)
            {
                this.repoP.InsertPartner(name, contact, urlContact);
            }
            else
            if (option == 2)
            {
                this.repoP.UpdatePartner(id.Value, name, contact, urlContact);
            }
            
            List<WORKER> p = this.repoP.GetPartners();
            return View(p);
        }

        public ActionResult DeletePartner(int id)
        {
            this.repoP.RemovePartner(id);
            return RedirectToAction("Partners");
        }

        //GET: WORKS
        public ActionResult Works()
        {
            List<WORK> works = this.repoW.GetWORKs();
            return View(works);
        }

        //POST: WORKS
        [HttpPost]
        public ActionResult Works(String work, int option, int? id)
        {
            if (option == 0)
            {
                this.repoW.InsertWork(work);
            }

            List<WORK> works = this.repoW.GetWORKs();
            return View(works);
        }

        public ActionResult DeleteWork(int id)
        {
            this.repoW.DeleteWork(id);

            return RedirectToAction("Works");
        }


    }
}