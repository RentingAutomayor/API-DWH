using API_DWH.Models;
using API_DWH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_DWH.Controllers
{
    public class ContractController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get() {
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities())
								{
										var lsContract = db.Contract
																		.Select(
																				ctr => new ContractViewModel { 
																						id = ctr.contract_id,
																						description = ctr.contract_description,
																						client = new ClientViewModel { document = ctr.cli_document, name = ctr.Client.cli_name},
																						actCode = ctr.contract_actCode,
																						startDate = ctr.contract_startDate,
																						endingDate = ctr.contract_endingDate,
																						renovationDate = ctr.contract_renovationDate,
																						signatureDate = ctr.contract_signatureDate,
																						state = ctr.contract_state
																				}		
																		)
																		.ToList();
										return Ok(lsContract);
								}								
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
        }
    }
}
