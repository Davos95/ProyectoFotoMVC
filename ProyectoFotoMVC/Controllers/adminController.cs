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
        IRepositoryComision repoComision;

        public adminController( IRepositoryPartner repoP, IRepositoryWork repoW)
        {
            this.repoPartner = repoP;
            this.repoWork = repoW;
        }

        public ActionResult menu()
        {
            return View();
        }



    }
}