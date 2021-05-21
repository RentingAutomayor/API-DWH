using API_DWH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class UserViewModel
		{
				public KindOfDocumentViewModel kindOfDocument;
				public string document;
				public string name;
				public string lastName;
				public string cellPhone;
				public string email;
				public string adress;
				public LoginViewModel login;
				public RolViewModel rol;
				public CityViewModel city;
				public JobTitleViewModel jobTitle;
		}
}