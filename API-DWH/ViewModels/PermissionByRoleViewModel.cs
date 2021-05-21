using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class PermissionByRoleViewModel
		{
				public Nullable<int> id;
				public RolViewModel rol;
				public List<PermissionByModuleViewModel> permissionByModule;
		}
}