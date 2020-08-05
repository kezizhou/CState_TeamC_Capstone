using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone.DomainObjects
{
    public class ExcellTableExport
    {
        public int ID { get; set; }
        public DateTime DateEntered { get; set; }
        public string OperatorName { get; set; }
        public string Department { get; set; }
        public string NearMiss_Solution { get; set; }
        public string NearMiss_ActionTaken { get; set; }
        public string Additional_Actions_Taken { get; set; }
        public string NearMissType { get; set; }
        public string AssignedTo { get; set; }
        public string SeverityType { get; set; }
        public string RiskType { get; set; }
        public string Comments { get; set; }
        public string ReviewedBy { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
