
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ProyectoFotoMVC.Models
{

using System;
    using System.Collections.Generic;
    
public partial class PHOTO
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PHOTO()
    {

        this.SESION1 = new HashSet<SESION>();

    }


    public int ID { get; set; }

    public string NAME { get; set; }

    public byte[] PICTURE { get; set; }

    public Nullable<int> IDSESION { get; set; }

    public Nullable<int> ORDERPHOTO { get; set; }



    public virtual SESION SESION { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SESION> SESION1 { get; set; }

}

}