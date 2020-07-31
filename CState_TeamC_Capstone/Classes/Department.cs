using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone.Classes {
	public class Department {
		public string strID { get; set; }
		public string strDepartment { get; set; }

		public Department(string strID, string strDepartment) {
			this.strID = strID;
			this.strDepartment = strDepartment;
		}
	}
}