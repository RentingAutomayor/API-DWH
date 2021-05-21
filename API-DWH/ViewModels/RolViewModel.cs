using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class RolViewModel
		{
				public Nullable<int> id;
				public string name;
				public string description;
				public List<PermissionByModuleViewModel> permissionByModule;
		}
}