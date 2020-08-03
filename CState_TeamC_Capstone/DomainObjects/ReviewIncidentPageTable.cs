using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone.DomainObjects
{
    public class ReviewIncidentPageTable
    {
            public int ID { get; set; }
            public string OperatorName { get; set; }
            public string Department { get; set; }
            public string NearMissType { get; set; }
            public string NearMiss_Solution { get; set; }
    }
}