using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone {
	public class UserRequest {
		public string strID { get; set; }
		public string strRole { get; set; }
		public string strFirstName { get; set; }
		public string strMiddleName { get; set; }
		public string strLastName { get; set; }
		public string strEmail { get; set; }
		public string strEmployeeID { get; set; }
		public string strDepartment { get; set; }

		public UserRequest(string strID, string strRole, string strFirstName, string strMiddleName, string strLastName, string strEmail, string strEmployeeID, string strDepartment) {
			this.strID = strID;
			this.strRole = strRole;
			this.strFirstName = strFirstName;
			this.strMiddleName = strMiddleName;
			this.strLastName = strLastName;
			this.strEmail = strEmail;
			this.strEmployeeID = strEmployeeID;
			this.strDepartment = strDepartment;
		}
	}
}