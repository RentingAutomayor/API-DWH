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
    public class ContactController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetContactsByClient(string pClient_id) {
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities() )
								{

                    var lsContacts = new List<ContactViewModel>();
                    var branch = db.branch.Where(b => b.cli_document == pClient_id).Select(b => new BranchViewModel { id = b.bra_id, name = b.bra_name }).FirstOrDefault();
                    var lsTmp = db.Contact.Where(ct => ct.bra_id == branch.id).Count();

                    if (lsTmp > 0)
                    {

                        lsContacts = db.Contact.Where(ct => ct.bra_id == branch.id)
                                                    .Select(ct =>
                                                       new ContactViewModel
                                                       {
                                                           id = ct.cnt_id,
                                                           name = ct.cnt_name,
                                                           lastName = ct.cnt_lastName,
                                                           phone = ct.cnt_phone,
                                                           cellPhone = ct.cnt_cellPhone,
                                                           email = ct.cnt_email,
                                                           jobTitle = new JobTitleViewModel { id = ct.JobTitlesClient.jtcl_id, description = ct.JobTitlesClient.jtcl_description },
                                                           adress = ct.cnt_adress,
                                                           branch = new BranchViewModel { id = ct.branch.bra_id, name = ct.branch.bra_name }
                                                       }
                                                    ).ToList();
                        

                    }

                    return Ok(lsContacts);

                }
								
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);	
						}
        }
    }
}
