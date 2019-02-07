﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepositorioPictureManager.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EntidadPicturesManager : DbContext
    {
        public EntidadPicturesManager()
            : base("name=EntidadPicturesManager")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COMISION> COMISION { get; set; }
        public virtual DbSet<PHOTO> PHOTO { get; set; }
        public virtual DbSet<SESION> SESION { get; set; }
        public virtual DbSet<SESION_WORKER> SESION_WORKER { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<WORK> WORK { get; set; }
        public virtual DbSet<WORKER> WORKER { get; set; }
    
        public virtual ObjectResult<WORKER> MOSTRARPARTICIPANTES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WORKER>("MOSTRARPARTICIPANTES");
        }
    
        public virtual ObjectResult<WORKER> MOSTRARPARTICIPANTES(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WORKER>("MOSTRARPARTICIPANTES", mergeOption);
        }
    
        public virtual ObjectResult<WORK> MOSTRARTRABAJOS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WORK>("MOSTRARTRABAJOS");
        }
    
        public virtual ObjectResult<WORK> MOSTRARTRABAJOS(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WORK>("MOSTRARTRABAJOS", mergeOption);
        }
    
        public virtual int ADDPARTICIPANTE(string nAME, string cONTACT, string uRLCONTACT)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var cONTACTParameter = cONTACT != null ?
                new ObjectParameter("CONTACT", cONTACT) :
                new ObjectParameter("CONTACT", typeof(string));
    
            var uRLCONTACTParameter = uRLCONTACT != null ?
                new ObjectParameter("URLCONTACT", uRLCONTACT) :
                new ObjectParameter("URLCONTACT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ADDPARTICIPANTE", nAMEParameter, cONTACTParameter, uRLCONTACTParameter);
        }
    
        public virtual int DELETEPARTICIPANTE(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DELETEPARTICIPANTE", iDParameter);
        }
    
        public virtual int UPDATEPARTICIPANTE(Nullable<int> iD, string nAME, string cONTACT, string uRLCONTACT)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var cONTACTParameter = cONTACT != null ?
                new ObjectParameter("CONTACT", cONTACT) :
                new ObjectParameter("CONTACT", typeof(string));
    
            var uRLCONTACTParameter = uRLCONTACT != null ?
                new ObjectParameter("URLCONTACT", uRLCONTACT) :
                new ObjectParameter("URLCONTACT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UPDATEPARTICIPANTE", iDParameter, nAMEParameter, cONTACTParameter, uRLCONTACTParameter);
        }
    
        public virtual int ADDTRABAJO(string nAME)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ADDTRABAJO", nAMEParameter);
        }
    
        public virtual int DELETETRABAJO(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DELETETRABAJO", iDParameter);
        }
    
        public virtual ObjectResult<SESION> MOSTRARSESIONES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SESION>("MOSTRARSESIONES");
        }
    
        public virtual ObjectResult<SESION> MOSTRARSESIONES(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SESION>("MOSTRARSESIONES", mergeOption);
        }
    
        public virtual int INSERTCOMISION(string nAME, string dESCRIPTION, string pATH, Nullable<double> pRICE)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var dESCRIPTIONParameter = dESCRIPTION != null ?
                new ObjectParameter("DESCRIPTION", dESCRIPTION) :
                new ObjectParameter("DESCRIPTION", typeof(string));
    
            var pATHParameter = pATH != null ?
                new ObjectParameter("PATH", pATH) :
                new ObjectParameter("PATH", typeof(string));
    
            var pRICEParameter = pRICE.HasValue ?
                new ObjectParameter("PRICE", pRICE) :
                new ObjectParameter("PRICE", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INSERTCOMISION", nAMEParameter, dESCRIPTIONParameter, pATHParameter, pRICEParameter);
        }
    
        public virtual ObjectResult<COMISION> GETCOMISIONS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<COMISION>("GETCOMISIONS");
        }
    
        public virtual ObjectResult<COMISION> GETCOMISIONS(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<COMISION>("GETCOMISIONS", mergeOption);
        }
    
        public virtual int DELETECOMISION(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DELETECOMISION", iDParameter);
        }
    
        public virtual int MODIFYSESSION(Nullable<int> iD, string nAME, string pHOTO, string dESCRIPTION, Nullable<double> pRICE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var pHOTOParameter = pHOTO != null ?
                new ObjectParameter("PHOTO", pHOTO) :
                new ObjectParameter("PHOTO", typeof(string));
    
            var dESCRIPTIONParameter = dESCRIPTION != null ?
                new ObjectParameter("DESCRIPTION", dESCRIPTION) :
                new ObjectParameter("DESCRIPTION", typeof(string));
    
            var pRICEParameter = pRICE.HasValue ?
                new ObjectParameter("PRICE", pRICE) :
                new ObjectParameter("PRICE", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MODIFYSESSION", iDParameter, nAMEParameter, pHOTOParameter, dESCRIPTIONParameter, pRICEParameter);
        }
    
        public virtual ObjectResult<USERS> GETUSER(string nICK, string pWD)
        {
            var nICKParameter = nICK != null ?
                new ObjectParameter("NICK", nICK) :
                new ObjectParameter("NICK", typeof(string));
    
            var pWDParameter = pWD != null ?
                new ObjectParameter("PWD", pWD) :
                new ObjectParameter("PWD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USERS>("GETUSER", nICKParameter, pWDParameter);
        }
    
        public virtual ObjectResult<USERS> GETUSER(string nICK, string pWD, MergeOption mergeOption)
        {
            var nICKParameter = nICK != null ?
                new ObjectParameter("NICK", nICK) :
                new ObjectParameter("NICK", typeof(string));
    
            var pWDParameter = pWD != null ?
                new ObjectParameter("PWD", pWD) :
                new ObjectParameter("PWD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USERS>("GETUSER", mergeOption, nICKParameter, pWDParameter);
        }
    
        public virtual int MODIFYORDERCOMISION(Nullable<int> iD, Nullable<int> oRDER)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var oRDERParameter = oRDER.HasValue ?
                new ObjectParameter("ORDER", oRDER) :
                new ObjectParameter("ORDER", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MODIFYORDERCOMISION", iDParameter, oRDERParameter);
        }
    
        public virtual int INSERTSESION(string nAME, string dESCRIPTION, Nullable<System.DateTime> dATE, Nullable<int> iDCOMISION)
        {
            var nAMEParameter = nAME != null ?
                new ObjectParameter("NAME", nAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var dESCRIPTIONParameter = dESCRIPTION != null ?
                new ObjectParameter("DESCRIPTION", dESCRIPTION) :
                new ObjectParameter("DESCRIPTION", typeof(string));
    
            var dATEParameter = dATE.HasValue ?
                new ObjectParameter("DATE", dATE) :
                new ObjectParameter("DATE", typeof(System.DateTime));
    
            var iDCOMISIONParameter = iDCOMISION.HasValue ?
                new ObjectParameter("IDCOMISION", iDCOMISION) :
                new ObjectParameter("IDCOMISION", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("INSERTSESION", nAMEParameter, dESCRIPTIONParameter, dATEParameter, iDCOMISIONParameter);
        }
    
        public virtual ObjectResult<SESION> GETSESION()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SESION>("GETSESION");
        }
    
        public virtual ObjectResult<SESION> GETSESION(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SESION>("GETSESION", mergeOption);
        }
    }
}
