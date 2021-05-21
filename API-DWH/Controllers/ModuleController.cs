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
		public class ModuleController : ApiController
		{
				[HttpGet]
				public IHttpActionResult GetPermissionByModule()
				{
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities())
								{
										var lsModules = db.modules.Select(mdl => new ModuleViewModel { id = mdl.mdl_id, name = mdl.mdl_name })
																							.ToList();

										var lsPermissionByModule = new List<PermissionByModuleViewModel>();

										foreach (ModuleViewModel module in lsModules)
										{
												PermissionByModuleViewModel permByMod = new PermissionByModuleViewModel();

												var lsPermission = new List<PermissionViewModel>();
												lsPermission = db.permissionByModule.Where(perm => perm.mdl_id == module.id)
																																 .Select(perm => new PermissionViewModel
																																 {
																																		 id = perm.perm_id,
																																		 name = perm.permission.perm_name,
																																		 description = perm.permission.perm_description
																																 }).ToList();


												permByMod.module = module;
												permByMod.lsPermission = lsPermission;

												lsPermissionByModule.Add(permByMod);
										}

										return Ok(lsPermissionByModule);
								}
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
				}

				[HttpGet]
				public IHttpActionResult GetPermissionByRol(int rol_id)
				{
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities())
								{
										var lsPermissionByModule = new List<PermissionByModuleViewModel>();

										var lsPermissionByRol = db.permissionByRole.Where(perm => perm.rol_id == rol_id)
																															 .Select(
																																	perm => new PermissionByModuleViewModel
																																	{
																																			id = perm.permByMdl_id
																																	}
																																).ToList();

										Dictionary<ModuleViewModel, PermissionViewModel> dicPermission = new Dictionary<ModuleViewModel, PermissionViewModel>();

										foreach (var perByMod in lsPermissionByRol)
										{
												var module = db.permissionByModule.Where(p => p.permByMdl_id == perByMod.id)
																													.Select(p => new ModuleViewModel { id = p.mdl_id, name = p.modules.mdl_name })
																													.FirstOrDefault();

												var permission = db.permissionByModule.Where(p => p.permByMdl_id == perByMod.id)
																															.Select(p => new PermissionViewModel
																															{
																																	id = p.perm_id,
																																	name = p.permission.perm_name,
																																	description = p.permission.perm_description
																															})
																															.FirstOrDefault();

												dicPermission.Add(module, permission);
										}




										var lsModules = db.modules.Select(mdl => new ModuleViewModel { id = mdl.mdl_id, name = mdl.mdl_name })
																						.ToList();



										foreach (ModuleViewModel module in lsModules)
										{
												var lsPermission = from p in dicPermission
																					 where p.Key.id == module.id
																					 select new PermissionViewModel { id = p.Value.id, name = p.Value.name, description = p.Value.description };


												PermissionByModuleViewModel prm = new PermissionByModuleViewModel();
												prm.module = module;
												prm.lsPermission = new List<PermissionViewModel>();
												foreach (var perm in lsPermission)
												{
														prm.lsPermission.Add(perm);
												}

												lsPermissionByModule.Add(prm);

										}

										return Ok(lsPermissionByModule);
								}
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
				}


				[HttpPost]
				public IHttpActionResult SavePermissionByRol(PermissionByRoleViewModel permByRol) {
						try
						{
								var message = "Hola";
								//TODO: Delete current permission by rol
								using (BD_DWHEntities db = new BD_DWHEntities())
								{
										//Primero debemos eliminar los permisos actuales y luego si agregar los nuevos permisos
										var lsActualPermission = db.permissionByRole.Where(p => p.rol_id == permByRol.rol.id).ToList();

										foreach (var permToDelete in lsActualPermission) {
												db.permissionByRole.Remove(permToDelete);
												db.SaveChanges();
										}

										foreach (var perByMod in permByRol.permissionByModule) {
												var pbr = new permissionByRole();
												pbr.rol_id = (int) permByRol.rol.id;

												foreach (var permission in perByMod.lsPermission) {
														var permByMdl = db.permissionByModule.Where(pbm => pbm.mdl_id == perByMod.module.id && pbm.perm_id == permission.id)
																																 .FirstOrDefault();

														pbr.permByMdl_id = permByMdl.permByMdl_id;
														db.permissionByRole.Add(pbr);
														db.SaveChanges();
												}
										}
										ResponseViewModel rta = new ResponseViewModel();
										rta.response = true;
										rta.message = "Se actualizan los permisos del rol: " + permByRol.rol.name;
										return Ok(rta);
								}
								
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
				}

		}
}
