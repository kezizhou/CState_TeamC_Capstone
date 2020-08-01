using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone.Classes {
	public class NearMissType {
		public string strID { get; set; }
		public string strNearMissType { get; set; }

		public NearMissType(string strID, string strNearMissType) {
			this.strID = strID;
			this.strNearMissType = strNearMissType;
		}
	}
}