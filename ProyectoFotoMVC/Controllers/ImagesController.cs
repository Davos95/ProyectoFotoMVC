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

            String sessionName = this.repoSesion.GetSESIONID(idSesion).NAME;

            String rootpath = Server.MapPath("~/images");
            String path = Path.Combine(rootpath + "\\Sesion\\" + sessionName);

            foreach (String id in idPhotos)
            {
                String namePhoto = this.repoPhoto.GetPhotoById(int.Parse(id)).PICTURE;
                this.repoPhoto.RemovePhotos(int.Parse(id));
                ToolImage.RemoveImage(namePhoto, path);
            }

            return Json(true);
        }

        [HttpPost]
        public async Task<ActionResult> OrderPhotos()
        {
            String[] idPhotos = Request.Form["idPhotos"].Split(',');
            for (int i = 0; i < idPhotos.Length; i++)
            {
                this.repoPhoto.OrderPhotos(int.Parse(idPhotos[i]), i);
            }
            return Json(true);
        }

        [HttpPost]
        public async Task<ActionResult> MovePhotos(int session)
        {
            String[] idPhotos = Request.Form["idPhotos"].Split(',');
            String oldSession = Request.Form["oldSession"];

            String rootpath = Server.MapPath("~/images");

            String sessionName = this.repoSesion.GetSESIONID(session).NAME;            
            String oldSessionName = this.repoSesion.GetSESIONID(int.Parse(oldSession)).NAME;
            String oldFolder = Path.Combine(rootpath + "\\Sesion\\" + oldSessionName);
            String destinationFolder = Path.Combine(rootpath + "\\Sesion\\" + sessionName);

            foreach (String id in idPhotos)
            {
                int idPhoto = int.Parse(id);
                String imageName = this.repoPhoto.GetPhotoById(idPhoto).PICTURE;
                ToolImage.MoveImage(imageName, oldFolder, destinationFolder);
                this.repoPhoto.MovePhotosSesion(idPhoto, session);
            }
            return Json(true);
        }
    }
}