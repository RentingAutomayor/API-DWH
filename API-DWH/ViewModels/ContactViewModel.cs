﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class ContactViewModel
		{
        public Nullable<int> id;
        public string name;
        public string lastName;
        public string phone;
        public string cellPhone;
        public string adress;
        public string email;
        public JobTitleViewModel jobTitle;
        public BranchViewModel branch;
    }
}