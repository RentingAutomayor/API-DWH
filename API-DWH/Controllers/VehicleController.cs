using API_DWH.Models;
using API_DWH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;

namespace API_DWH.Controllers
{
    public class VehicleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get() {
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities()) {
										var lsVehicle = db.vehicle
																		.Select( vh =>
																				new VehicleViewModel
																				{
																						licensePlate = vh.veh_licensePlate,
																						brand = vh.veh_brand,
																						model = vh.veh_model,
																						year = vh.veh_year,
																						chasisCode = vh.veh_chassisCode,
																						engineCode = vh.veh_engineCode,
																						loadingCapacity = vh.veh_loadingCapacity,
																						cylinder = vh.veh_cylinder,
																						clasification = vh.veh_clasification,
																						color = vh.veh_color,
																						passangerCapacity = vh.veh_passangerCapacity,
																						serviceType = vh.veh_serviceType,
																						mileage = vh.veh_mileage,
																						status = vh.veh_status,
																						purchaseDate = vh.veh_purchaseDate,
																						accesoriesPrice = vh.veh_accesoriesPrice,
																						deliveredDate = vh.veh_deliveredDate,
																						lastInspectionDate =vh.veh_lastInspectionDate,
																						provider = new AllyViewModel { document = vh.ally_id},
																						contract = vh.contract_id,
																						contratedMileage = vh.veh_contratedMileage
																				}
																		).ToList();
										return Ok(lsVehicle);
								}								
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);	
						}
        }
    }
}
