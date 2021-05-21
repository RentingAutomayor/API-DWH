using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class ClientViewModel
		{
				public string document;
				public KindOfDocumentViewModel kindOfDocument;
				public string name;
				public string lastName;
				public string cellPhone;
				public string email;
				public EconomicActivityViewModel economicActivity;
				public CityViewModel city;
				public string state;
				public CanalViewModel canal;
				public DateTime registrationDate;
				public List<ContactViewModel> lsContacts;
		}
}