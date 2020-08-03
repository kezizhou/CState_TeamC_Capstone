using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone.Classes {
	public class NearMissTypeInstructions {
		public string strNMType_ID { get; set; }
        public string strNMT_Type { get; set; }
        public string strI_Ins { get; set; }
       // public string strInstruction_ID { get; set; }

		//public NearMissTypeInstructions(string strNMType_ID, string strInstruction_ID, string strI_Ins) {
        public NearMissTypeInstructions(string strNMT_Type, string strI_Ins)
            {
                this.strNMType_ID = strNMType_ID;
                this.strNMT_Type = strNMT_Type;
               // this.strInstruction_ID = strInstruction_ID;
			    this.strI_Ins = strI_Ins;

		}
	}
}