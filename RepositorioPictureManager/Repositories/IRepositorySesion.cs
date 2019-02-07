using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioPictureManager.Repositories
{
    public interface IRepositorySesion
    {
        List<SESION> GetSesions();
        void InsertSesion(String name, String description, DateTime date, int comision);
        
    }
}
