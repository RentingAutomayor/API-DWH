using API_DWH.Models;
using API_DWH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace API_DWH.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get() {
						try
						{
                using (BD_DWHEntities db = new BD_DWHEntities())
                {

                    var lsClient = db.Client.Where(cl => cl.cli_state == true)
                                                        .Select(cl => new ClientViewModel
                                                        {
                                                            document = cl.cli_document,
                                                            name = cl.cli_name,
                                                            lastName = cl.cli_lastName,
                                                            economicActivity = new EconomicActivityViewModel { 
                                                                                id = cl.EconomicActivity.ea_id,
                                                                                description = cl.EconomicActivity.ea_description,
                                                                                code = cl.EconomicActivity.ea_code },
                                                            city = new CityViewModel { 
                                                                                id = cl.Cities.cty_id,
                                                                                name = cl.Cities.cty_name,
                                                                                DANECode = cl.Cities.cty_dane_code}
                                                        })
                                                        .DefaultIfEmpty()
                                                        .ToList();

                    return Ok(lsClient);
                }
            }
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
           
        }
    }
}
