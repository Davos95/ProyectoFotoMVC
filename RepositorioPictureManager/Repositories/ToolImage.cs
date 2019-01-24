using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace RepositorioPictureManager.Repositories
{
    public class ToolImage
    {
        public static void UploadImage(HttpPostedFileBase image, String folder)
        {
            String path = Path.Combine(folder, Path.GetFileName(image.FileName));
            image.SaveAs(path);
        }
        public static void RemoveImage(HttpPostedFileBase image, String folder)
        {
            String path = Path.Combine(folder, Path.GetFileName(image.FileName));
            File.Delete(path);
        }
    }
}
