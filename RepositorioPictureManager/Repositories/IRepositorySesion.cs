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
        void DeleteSesion(int id);
        SESION GetSESIONID(int id);
        void AddPartnerWorkIntoSesion(int idSesion, int idPartner, int idWork);
        List<GETPARTNERWORKBYSESION_Result> GetPartnerWorkBySesion(int idSesion);
        void DeletePartnerWorkFromSesion(int idSesion, int idPartner, int idWork);

        void ModifySesion(int idSesion, String name, String desciption, DateTime date, int idComision);
    }
}
