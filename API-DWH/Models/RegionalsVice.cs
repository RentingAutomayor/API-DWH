//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_DWH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegionalsVice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegionalsVice()
        {
            this.additionalInformationByContact = new HashSet<additionalInformationByContact>();
        }
    
        public int rv_id { get; set; }
        public string rv_description { get; set; }
        public Nullable<bool> rv_state { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<additionalInformationByContact> additionalInformationByContact { get; set; }
    }
}
