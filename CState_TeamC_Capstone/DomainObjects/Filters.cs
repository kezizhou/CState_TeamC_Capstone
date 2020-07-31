using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone.DomainObjects
{
    public class Filters
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }

    public class OperatorFilters
    {
        public int ID { get; set; }
        public string OperatorName { get; set; }
    }
}