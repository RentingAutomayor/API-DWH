using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class StateViewModel
		{
				public int id;
				public string description;
				public int? parentState;
				public bool state;
		}
}