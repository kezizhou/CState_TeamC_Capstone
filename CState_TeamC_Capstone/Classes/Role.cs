using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone.Classes {
	public class Role {
		public string strID { get; set; }
		public string strRole { get; set; }

		public Role(string strID, string strRole) {
			this.strID = strID;
			this.strRole = strRole;
		}
	}
}