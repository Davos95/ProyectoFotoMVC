//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PHOTO
    {
        public int ID { get; set; }
        public string PICTURE { get; set; }
        public Nullable<int> IDSESION { get; set; }
        public Nullable<int> ORDERPHOTO { get; set; }
    
        public virtual SESION SESION { get; set; }
    }
}
