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
    
    public partial class ally
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ally()
        {
            this.branch = new HashSet<branch>();
        }
    
        public string ally_document { get; set; }
        public Nullable<int> kod_id { get; set; }
        public string ally_name { get; set; }
        public string ally_lastName { get; set; }
        public Nullable<double> ally_percentCommission { get; set; }
        public Nullable<bool> ally_state { get; set; }
        public Nullable<System.DateTime> ally_registrationDate { get; set; }
        public string ally_providerType { get; set; }
        public Nullable<int> koa_id { get; set; }
    
        public virtual kindOfDocument kindOfDocument { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<branch> branch { get; set; }
        public virtual kindOfAlly kindOfAlly { get; set; }
    }
}