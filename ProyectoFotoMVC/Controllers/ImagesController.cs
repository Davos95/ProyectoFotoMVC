using ProyectoFotoMVC.Atributes;
using RepositorioPictureManager.Models;
using RepositorioPictureManager.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProyectoFotoMVC.Controllers
{
    [AuthorizeUser]
    public class ImagesController : Controller
    {
        IRepositorySesion repoSesion;
        IRepositoryPhoto repoPhoto;
        public ImagesController(IRepositorySesion repoS, IRepositoryPhoto repoP)
        {
            this.repoSesion = repoS;
            this.repoPhoto = repoP;
        }

        // GET: Images
        public ActionResult UploadImages()
        {
            return View(this.repoSesion.GetSesions());
        }

        [HttpPost]
        public async Task<ActionResult> Upload()
        {
            int idSesion = int.Parse(Request.Form["idSesion"].ToString());
            String sessionName = this.repoSesion.GetSESIONID(idSesion).NAME;
            
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase fileContent = Request.Files[file];
                String rootpath = Server.MapPath("~/images");
                String path = Path.Combine(rootpath + "\\Sesion\\" + sessionName);
                ToolImage.UploadImage(fileContent, path, null);
                this.repoPhoto.InsertPhoto(fileContent.FileName, idSesion);
            }
            
            return Json(true);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteImages(int idSesion)
        {
            String[] idPhotos = Request.Form["idPhotos"].Split(',');

            String nameSession = this.repoSesion.GetSESIONID(idSesion).NAME;

            foreach (String id in idPhotos)
            {
                this.repoPhoto.RemovePhotos(int.Parse(id));
                ToolImage.RemoveImage(nameSession, nameSession);
            }

            return Json(true);
        }
    }
}