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

            String path = "";
            if(name != null)
            {
                String type = image.ContentType.Split('/')[1];
                path = Path.Combine(folder, name + "." + type);
            }
            else
            {
                path = Path.Combine(folder, image.FileName);
            }
            
            image.SaveAs(path);
        }
        public static void RemoveImage(String image, String folder)
        {
            String path = Path.Combine(folder, image);
            File.Delete(path);
        }

        public static void CreateFolder(String path, String name)
        {
            String routeFolder = Path.Combine(path + "/"+ name);
            Directory.CreateDirectory(routeFolder);
        }

        public static void DeleteFolder(String path, String name)
        {
            String routeFolder = Path.Combine(path + "/" + name);
            Directory.Delete(routeFolder,true);
        }
        
    }
}
