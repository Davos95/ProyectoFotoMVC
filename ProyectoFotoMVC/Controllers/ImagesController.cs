using RepositorioPictureManager.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFotoMVC.Controllers
{
    public class ImagesController : Controller
    {
        IRepositorySesion repoSesion;
        public ImagesController(IRepositorySesion repoS)
        {
            this.repoSesion = repoS;
        }

        // GET: Images
        public ActionResult UploadImages()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadImages(HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/images/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }
            }
            return View();
        }


    }
}