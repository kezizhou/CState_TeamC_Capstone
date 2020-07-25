using System;
using System.Collections.Generic;
using CState_TeamC_Capstone.DomainObjects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
    public partial class reviewIncident : System.Web.UI.Page {
        public List<Filters> severity;
        public List<Filters> risk;
        protected void Page_Load(object sender, EventArgs e) {
            severity = Shared.GetSeverityFilter();
            risk = Shared.GetRiskFilter();
        }
        protected void Filter(object sender, EventArgs e)
        {

            var departmentSelection = Request["sltDepartment"];
            var nearMissTypeSElection = Request["sltNearMissType"];
            var severitySelection = Request["sltSeverityLevel"];
            var riskSelection = Request["sltRiskLevel"];

            //if (!String.IsNullOrEmpty(departmentSelection))
            //{
            //    results = originalResult.Where(x => x.Department == departmentSelection).ToList();
            //}
            //if (!String.IsNullOrEmpty(nearMissTypeSElection))
            //{
            //    results = originalResult.Where(x => x.NearMissType == nearMissTypeSElection).ToList();
            //}
            //if (!String.IsNullOrEmpty(severitySelection))
            //{
            //    results = originalResult.Where(x => x.SeverityLevel == severitySelection).ToList();
            //}
            //if (!String.IsNullOrEmpty(riskSelection))
            //{
            //    results = originalResult.Where(x => x.RiskLevel == riskSelection).ToList();
            //}

        }
    }
}