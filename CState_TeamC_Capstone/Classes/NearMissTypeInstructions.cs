using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone.Classes {
	public class NearMissTypeInstructions {
		public string strNearMissType_ID { get; set; }
        public string strNMT_Type { get; set; }
        public string strI_Ins { get; set; }
      
        public NearMissTypeInstructions(string strNearMissType_ID, string strNMT_Type, string strI_Ins)
            {
                this.strNearMissType_ID = strNearMissType_ID;
                this.strNMT_Type = strNMT_Type;
                this.strI_Ins = strI_Ins;

		}
	}
}