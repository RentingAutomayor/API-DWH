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
    
    public partial class ConfigExternalApplication
    {
        public int cnfexap_id { get; set; }
        public Nullable<int> exap_id { get; set; }
        public string cnfexap_urlAPI { get; set; }
        public string cnfexap_method { get; set; }
        public string cnfexap_URLFormat { get; set; }
        public string cnfexap_connectionString { get; set; }
        public string cnfexap_fieldUser { get; set; }
        public string cnfexap_fieldPass { get; set; }
        public string cnfexap_user { get; set; }
        public string cnfexap_pass { get; set; }
        public string cnfexap_additionalParams { get; set; }
        public Nullable<System.DateTime> cnfexap_modificationDate { get; set; }
    
        public virtual ExternalApplication ExternalApplication { get; set; }
    }
}
