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
        public static void UploadImage(HttpPostedFileBase image, String folder, String name)
        {
            String type = image.ContentType.Split('/')[1];

            String path = Path.Combine(folder, name + "."+type);
            image.SaveAs(path);
        }
        public static void RemoveImage(String image, String folder)
        {
            String path = Path.Combine(folder, image);
            File.Delete(path);
        }
    }
}
