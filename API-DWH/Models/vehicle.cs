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
    
    public partial class vehicle
    {
        public string veh_licensePlate { get; set; }
        public string veh_brand { get; set; }
        public string veh_model { get; set; }
        public string veh_year { get; set; }
        public string veh_chassisCode { get; set; }
        public string veh_engineCode { get; set; }
        public string veh_loadingCapacity { get; set; }
        public string veh_cylinder { get; set; }
        public string veh_clasification { get; set; }
        public string veh_color { get; set; }
        public string veh_passangerCapacity { get; set; }
        public string veh_serviceType { get; set; }
        public string veh_vehicleType { get; set; }
        public string veh_mileage { get; set; }
        public string veh_status { get; set; }
        public Nullable<System.DateTime> veh_purchaseDate { get; set; }
        public Nullable<long> veh_purchasePrice { get; set; }
        public Nullable<long> veh_accesoriesPrice { get; set; }
        public Nullable<System.DateTime> veh_deliveredDate { get; set; }
        public Nullable<System.DateTime> veh_lastInspectionDate { get; set; }
        public string ally_id { get; set; }
        public string contract_id { get; set; }
        public string veh_contratedMileage { get; set; }
    }
}
