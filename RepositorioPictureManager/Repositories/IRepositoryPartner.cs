
using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioPictureManager.Repositories
{
    public interface IRepositoryPartner
    {
        List<WORKER> GetPartners();
        void InsertPartner(String name, String contact, String urlContact);
        void RemovePartner(int id);
        void UpdatePartner(int id, String name, String contact, String urlContact);

    }
}
