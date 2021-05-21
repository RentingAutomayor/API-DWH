using API_DWH.Models;
using API_DWH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace API_DWH.Controllers
{
    public class UserController : ApiController
    {
				[HttpGet]
				public IHttpActionResult Get() {
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities()) {
										var lsUsers = db.users.Where(usu => usu.usu_state == true)
																				.Select(usu => new UserViewModel { 
																						document = usu.usu_document,
																						kindOfDocument = new KindOfDocumentViewModel {  id = usu.kod_id , description = usu.kindOfDocument.kod_description },
																						name = usu.usu_name,
																						lastName = usu.usu_lastName,
																						email = usu.usu_email,
																						cellPhone = usu.usu_cellphone,
																						adress = usu.usu_adress,
																						city = new CityViewModel { id = usu.cty_id, name = usu.Cities.cty_name } ,
																						jobTitle = new JobTitleViewModel { id = usu.jt_id, description = usu.jobTitle.jt_description },
																						rol = new RolViewModel { id = usu.rol_id, name = usu.roles.rol_name, description = usu.roles.rol_description }		
																				})
																				.ToList();

										return Ok(lsUsers);
								}
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
				}
        [HttpPost]
        public IHttpActionResult authUser(LoginViewModel loginUserRA) {
						try
						{
								ResponseViewModel resp = new ResponseViewModel();

								using (BD_DWHEntities db = new BD_DWHEntities()) {

										var userAuth = db.logins.Where(lg => lg.log_userName == loginUserRA.userName && lg.log_password == loginUserRA.password)
																					.FirstOrDefault();

										if (userAuth != null)
										{
												var user = db.users.Where(u => u.usu_document == userAuth.usu_document)
																						.Select(u => new UserViewModel
																						{
																								document = u.usu_document,
																								kindOfDocument  = new KindOfDocumentViewModel { id = u.kod_id ,description = u.kindOfDocument.kod_description},
																								name = u.usu_name,
																								lastName = u.usu_lastName,
																								cellPhone = u.usu_cellphone,
																								email = u.usu_email
																						})
																						.FirstOrDefault();

												var rolByUser = db.userByRol.Where(rl => rl.usu_document == user.document)
																										.Select(rl => new RolViewModel { id = rl.roles.rol_id, name = rl.roles.rol_name, description = rl.roles.rol_description })
																										.FirstOrDefault();

												user.rol = rolByUser;

												var permissionByRol = db.permissionByRole.Where(perm => perm.rol_id == rolByUser.id)
																																 .Select(perm => new PermissionByRoleViewModel { 
																																		id = perm.permByRol_id,
																																		rol = new RolViewModel {id = perm.rol_id, name = perm.roles.rol_name }								
																																 })
																																 .ToList();

												var permByMod = new List<PermissionByModuleViewModel>();
												Dictionary<ModuleViewModel, PermissionViewModel> dicPermission = new Dictionary<ModuleViewModel, PermissionViewModel>();


												foreach (var pbm in permissionByRol) {
														var permModule = db.permissionByRole.Where(p => p.permByRol_id == pbm.id)
																														.Select(
																																	p => new PermissionByModuleViewModel
																																	{
																																			id = p.permByMdl_id,
																																			module =  new ModuleViewModel { id = p.permissionByModule.mdl_id,name = p.permissionByModule.modules.mdl_name }
																																	}
																															).FirstOrDefault();

														var permission = db.permissionByModule.Where(p => p.permByMdl_id == permModule.id)
																																.Select(p => new PermissionViewModel
																																{
																																		id = p.perm_id,
																																		name = p.permission.perm_name,
																																		description = p.permission.perm_description
																																}).FirstOrDefault();

														dicPermission.Add(permModule.module, permission);
												}


												var lsModules = db.modules.Select(m => new ModuleViewModel { id = m.mdl_id , name = m.mdl_name }).ToList();

												List<PermissionByModuleViewModel> lsPermByMod = new List<PermissionByModuleViewModel>();

												foreach (var module in lsModules) {
														PermissionByModuleViewModel pXm = new PermissionByModuleViewModel();
														pXm.lsPermission = new List<PermissionViewModel>();

													  var lsPermission = from p in dicPermission
																							 where p.Key.id == module.id
																							 select new PermissionViewModel { id = p.Value.id, name = p.Value.name, description = p.Value.description };

														pXm.module = module;

														foreach (var perm in lsPermission)
														{
																pXm.lsPermission.Add(perm);
														}

														lsPermByMod.Add(pXm);
												}

												user.rol.permissionByModule = lsPermByMod;							

												resp.response = true;
												resp.message = "Bienvenido " + user.name + " " + user.lastName;
												resp.user = user;
										}
										else
										{
												resp.response = false;
												resp.message = "Usuario o contraseña inválidos";
										}
								}

										return Ok(resp);
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
        }
    }
}
