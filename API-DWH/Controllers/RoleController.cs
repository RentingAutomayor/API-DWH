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
    public class RoleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get() {
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities())
								{
										var lsRoles = db.roles
																		.Select( rl => new RolViewModel { id = rl.rol_id , name = rl.rol_name , description = rl.rol_description})
																		.ToList();

										return Ok(lsRoles);
								}
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);
						}
        }

				[HttpGet]
				public IHttpActionResult GetPermissionByRole(int role_id) {
						try
						{
								using (BD_DWHEntities db = new BD_DWHEntities())
								{
									
										var lsPermissionByRole = db.permissionByRole.Where(pm => pm.rol_id == role_id)
																										 .Select(pm => new PermissionByModuleViewModel
																										 {
																												 id = pm.permByRol_id,
																												 module = new ModuleViewModel { 
																																										id = pm.permissionByModule.modules.mdl_id,
																																										name = pm.permissionByModule.modules.mdl_name,
																																										description = pm.permissionByModule.modules.mdl_description },
																												 //permission = new PermissionViewModel { 
																													//													id = pm.permissionByModule.permission.perm_id,
																													//													name = pm.permissionByModule.permission.perm_name }
																										 }).ToList();


										return Ok(lsPermissionByRole);
								}
						}
						catch (Exception ex)
						{
								return BadRequest(ex.Message);								
						}
				}

		
    }
}
