using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RepositorioPictureManager.Repositories
{
    public interface IRepositoryComision
    {
        void InsertComision(String name, String description, String folder, HttpPostedFileBase image, float price);
    }
}
