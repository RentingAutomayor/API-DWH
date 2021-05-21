using API_DWH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class ContractViewModel
		{
				public string id;
				public string description;
				public ClientViewModel client;
				public string actCode;
				public Nullable<DateTime> startDate;
				public Nullable<DateTime> endingDate;
				public Nullable<DateTime> renovationDate;
				public Nullable<DateTime> signatureDate;
				public string state;

		}
}