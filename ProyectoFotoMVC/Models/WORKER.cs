
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
    
public partial class WORKER
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public WORKER()
    {

        this.SESION_WORKER = new HashSet<SESION_WORKER>();

    }


    public int ID { get; set; }

    public string NAME { get; set; }

    public string CONTACT { get; set; }

    public string URLCONTACT { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SESION_WORKER> SESION_WORKER { get; set; }

}

}