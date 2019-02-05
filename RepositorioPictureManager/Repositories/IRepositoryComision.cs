using RepositorioPictureManager.Models;
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
        List<COMISION> GetCOMISIONS();
        void InsertComision(String name, String description, String folder, HttpPostedFileBase image, float price);
        void DeleteComision(int id, String folder);
        void ModifyComision(int id, String name, String description, String folder, String image, float price);
        void OrderComision(String[] order);
        COMISION GetComisionByID(int id);
    }
}
