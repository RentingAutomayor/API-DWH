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
    public class RequestController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllRequest() {
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities())
								{
										var lsRequest = db.Request.Where(r => r.rqt_state == true)
																				.Select(r => new RequestViewModel
																				{
																						id = r.rqt_id,
																						client = new ClientViewModel
																						{
																								document = r.Client.cli_document,
																								kindOfDocument = new KindOfDocumentViewModel
																								{
																										id = r.Client.kindOfDocument.kod_id,
																										description = r.Client.kindOfDocument.kod_description
																								},
																								name = r.Client.cli_name,
																								lastName = r.Client.cli_lastName,
																								cellPhone = r.Client.cli_cellPhone,
																								email = r.Client.cli_email,
																								city = new CityViewModel
																								{
																										id = r.Client.Cities.cty_id,
																										name = r.Client.Cities.cty_name,
																										departmentId = r.Client.Cities.dpt_id
																								},
																								economicActivity = new EconomicActivityViewModel
																								{
																										id = r.Client.EconomicActivity.ea_id,
																										description = r.Client.EconomicActivity.ea_description
																								},
																								canal = new CanalViewModel
																								{
																										id = r.Client.Canal.cnl_id,
																										description = r.Client.Canal.cnl_description
																								}
																						},
																						probability = new ProbabilityViewModel { id = r.probability.prb_id, description = r.probability.prb_description },
																						parentState = new StateViewModel { id = r.states.sta_id, description = r.states.sta_description },
																						childState = new StateViewModel { id = r.states1.sta_id, description = r.states1.sta_description },
																						user = new UserViewModel { document = r.users.usu_document, name = r.users.usu_name, lastName = r.users.usu_lastName },
																						contact = new ContactViewModel { id = r.Contact.cnt_id, name = r.Contact.cnt_name, lastName = r.Contact.cnt_lastName },
																						initialDate = r.rqt_firstVisitDate,
																						lastDate = r.rqt_lastVisitDate,
																						registrationDate = r.rqt_registrationDate
																				}).OrderByDescending(r => r.registrationDate)
																				.ToList();

										foreach (var rqt in lsRequest)
										{
												var riskInformation = db.riskInformationByRequest.Where(ri => ri.rqt_id == rqt.id && ri.ribr_state == true).FirstOrDefault();

												if (riskInformation.states != null)
												{
														var oState = new StateViewModel();
														oState.id = riskInformation.states.sta_id;
														oState.description = riskInformation.states.sta_description;

														rqt.riskInformation = new RiskInformationViewModel()
														{
																id = riskInformation.ribr_id,
																riskState = oState,
																ammountApproved = long.Parse(riskInformation.ribr_ammountApproved.ToString()),
																datefiling = riskInformation.ribr_dateFiling
														};
												}



												var operationalInformation = db.operationalInformationByRequest.Where(oi => oi.rqt_id == rqt.id && oi.oibr_state == true).FirstOrDefault();


												rqt.operationalInformation = new OperationalInformationViewModel()
												{
														id = operationalInformation.oibr_id,
														deliveredAmmount = Decimal.Parse(operationalInformation.oibr_deliveredAmmount.ToString()),
														deliveredVehicles = int.Parse(operationalInformation.oibr_deliveredVehicles.ToString()),
														deliveredDate = operationalInformation.oibr_deliveredDate,
														legalizationDate = operationalInformation.oibr_legalizationDate
												};



												var branch = db.branch.Where(br => br.cli_document == rqt.client.document).FirstOrDefault();

												var lsContactsByClient = db.Contact.Where(cnt => cnt.bra_id == branch.bra_id)
																														.Select(cnt => new ContactViewModel
																														{
																																id = cnt.cnt_id,
																																name = cnt.cnt_name,
																																lastName = cnt.cnt_lastName,
																																phone = cnt.cnt_phone,
																																cellPhone = cnt.cnt_cellPhone,
																																email = cnt.cnt_email,
																																jobTitle = new JobTitleViewModel { id = cnt.JobTitlesClient.jtcl_id, description = cnt.JobTitlesClient.jtcl_description },
																																adress = cnt.cnt_adress,
																																branch = new BranchViewModel { id = cnt.branch.bra_id, name = cnt.branch.bra_name }
																														}).ToList();


												rqt.client.lsContacts = lsContactsByClient;
										}

										return Ok(lsRequest);
								}
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
        }
    }
}
