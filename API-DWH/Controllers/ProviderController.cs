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
    public class ProviderController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get() {
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities()) {
										var lsProvider = db.ally.Where(prv => prv.kindOfAlly.koa_id == 1 && prv.ally_state == true)
																						.Select(prv => new AllyViewModel
																						{
																								document = prv.ally_document,
																								kindOfDociment = new KindOfDocumentViewModel
																								{
																										id = (int)prv.kod_id,
																										description = prv.kindOfDocument.kod_description
																								},
																								name = prv.ally_name,
																								lastName = prv.ally_lastName
																						}).ToList();
										return Ok(lsProvider);
								}
								
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);								
						}
        }
    }
}
