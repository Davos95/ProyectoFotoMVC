using ProyectoFotoMVC.Atributes;
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
        public ImagesController(IRepositorySesion repoS)
        {
            this.repoSesion = repoS;
        }

        // GET: Images
        public ActionResult UploadImages()
        {
            return View(this.repoSesion.GetSesions());
        }

        [HttpPost]
        public async Task<JsonResult> Upload()
        {
            int idSesion = int.Parse(Request.Form["idSesion"].ToString());
            String sessionName = this.repoSesion.GetSESIONID(idSesion).NAME;

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase fileContent = Request.Files[file];
                String rootpath = Server.MapPath("~/images");
                String path = Path.Combine(rootpath + "\\Sesion\\" + sessionName);
                ToolImage.UploadImage(fileContent, path, null);
            }
            
            return Json(true);
        }
    }
}