
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
    using System.ComponentModel.DataAnnotations;

    public partial class WORKER
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public WORKER()
    {

        this.SESION_WORKER = new HashSet<SESION_WORKER>();

    }


    public int ID { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string NAME { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string CONTACT { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string URLCONTACT { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SESION_WORKER> SESION_WORKER { get; set; }

}

}
