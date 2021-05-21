﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class RiskInformationViewModel
		{
        public Nullable<int> id;
        public DateTime? dateSubmissionAnalysis;
        public DateTime? dateResponseAnalysis;
        public long ammountApproved;
        public StateViewModel riskState;
        public DateTime? datefiling;
        public UserViewModel user;
        public bool state;
    }
}