using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFotoMVC.Models
{
    public class HelperPartnerWork
    {
        contextPicturesManegerDataContext c;
        public HelperPartnerWork()
        {
            c = new contextPicturesManegerDataContext();
        }

        public List<WORKER> GetPartners()
        {
            var sql = from datos in c.WORKERs
                      select datos;
            return sql.ToList();
        }

        public void InsertPartner(String name, String contact, String urlContact)
        {
            WORKER worker = new WORKER();
            worker.NAME = name;
            worker.CONTACT = contact;
            worker.URLCONTACT = urlContact;
            c.WORKERs.InsertOnSubmit(worker);
            c.SubmitChanges();
        }

        public void RemovePartner(int id)
        {
            WORKER worker = GetPartnerById(id)[0];
            c.WORKERs.DeleteOnSubmit(worker);
            c.SubmitChanges();
        }

        private List<WORKER> GetPartnerById(int id)
        {
            var sql = from datos in c.WORKERs
                      where datos.ID == id
                      select datos;

            return sql.ToList();
        }

        public void UpdatePartner(int id, String name, String contact, String urlContact)
        {
            WORKER worker = GetPartnerById(id)[0];
            worker.NAME = name;
            worker.CONTACT = contact;
            worker.URLCONTACT = urlContact;
            c.SubmitChanges();
        }


        //Works
        public List<WORK> GetWorks()
        {
            var sql = from datos in c.WORKs
                      select datos;
            return sql.ToList();
        }

        public void InsertWork(String name)
        {
            WORK work = new WORK();
            work.NAME = name;
            c.WORKs.InsertOnSubmit(work);
            c.SubmitChanges();
        }
    }
}