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
    
    public partial class DD_ExternalObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DD_ExternalObject()
        {
            this.DD_ExternalObjectFields = new HashSet<DD_ExternalObjectFields>();
        }
    
        public int dd_exobj_id { get; set; }
        public string dd_exobj_name { get; set; }
        public string dd_exobj_description { get; set; }
        public Nullable<int> exap_id { get; set; }
        public Nullable<System.DateTime> dd_exobj_modificationDate { get; set; }
        public Nullable<int> dd_lclobj_id { get; set; }
        public string dd_exobj_attributeRoot { get; set; }
        public string dd_exobj_attributeSet { get; set; }
        public string dd_exobj_attributeResponse { get; set; }
        public Nullable<bool> dd_exobj_isActive { get; set; }
        public string dd_exobj_spToExecute { get; set; }
        public Nullable<bool> dd_exobj_isToInsert { get; set; }
        public Nullable<bool> dd_exobj_isToUpdate { get; set; }
        public string dd_exobj_spToExtractDataToUpdate { get; set; }
        public Nullable<bool> dd_exobj_hasTableAttributes { get; set; }
        public Nullable<bool> dd_exobj_hasAdditionalParams { get; set; }
        public string dd_exobj_AdditionalParams { get; set; }
        public string dd_exobj_AdditionalParamsDescription { get; set; }
        public Nullable<int> dd_exobj_order { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DD_ExternalObjectFields> DD_ExternalObjectFields { get; set; }
        public virtual ExternalApplication ExternalApplication { get; set; }
        public virtual DD_LocalObject DD_LocalObject { get; set; }
    }
}