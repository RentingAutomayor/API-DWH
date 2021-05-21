using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DWH.ViewModels
{
		public class VehicleViewModel
		{
				public string licensePlate;
				public string brand;
				public string model;
				public string year;
				public string chasisCode;
				public string engineCode;
				public string loadingCapacity;
				public string cylinder;
				public string clasification;
				public string color;
				public string passangerCapacity;
				public string serviceType;
				public string mileage;
				public string status;
				public Nullable<DateTime> purchaseDate;
				public Nullable<double> purchasePrice;
				public Nullable<double> accesoriesPrice;
				public Nullable<DateTime> deliveredDate;
				public Nullable<DateTime> lastInspectionDate;
				public AllyViewModel provider;
				public string contract;
				public string contratedMileage;

		}
}