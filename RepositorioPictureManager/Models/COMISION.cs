
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
    
public partial class COMISION
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public COMISION()
    {

        this.SESION = new HashSet<SESION>();

    }


    public int ID { get; set; }

    public string NAME { get; set; }

    public string PHOTO { get; set; }

    public string DESCRIPTION { get; set; }

    public Nullable<int> ORDERCOMISION { get; set; }

    public Nullable<double> PRICE { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SESION> SESION { get; set; }

}

}
