using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone {
	public class RoleRequest {

		public string strID { get; set; }
		public string strRole { get; set; }
		public string strStatus { get; set; }

		public RoleRequest(string strID, string strRole, string strStatus) {
			this.strID = strID;
			this.strRole = strRole;
			this.strStatus = strStatus;
		}
	}
}