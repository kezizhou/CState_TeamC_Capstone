using CState_TeamC_Capstone.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace CState_TeamC_Capstone {
	public partial class searchTool : System.Web.UI.Page {
        public List<SearchToolQueryResult> results;
        public List<Filters> departments;
        public List<Filters> nearMissType;
        public List<Filters> severity;
        public List<Filters> risk;
        public List<SearchToolQueryResult> originalResult;
        protected void Page_Load(object sender, EventArgs e) {
            results = Shared.GetSearchToolQuery();
            originalResult = results;
            departments = Shared.GetDepartmentFilter();
            nearMissType = Shared.GetNearMissTypeFilter();
            severity = Shared.GetSeverityFilter();
            risk = Shared.GetRiskFilter();
        }
        protected void Filter(object sender, EventArgs e)
        {

            var departmentSelection = Request["sltDepartment"];
            var nearMissTypeSElection = Request["sltNearMissType"];
            var severitySelection = Request["sltSeverityLevel"];
            var riskSelection = Request["sltRiskLevel"];

            if (!String.IsNullOrEmpty(departmentSelection)) {
                results = originalResult.Where(x => x.Department == departmentSelection).ToList();
            }
            if (!String.IsNullOrEmpty(nearMissTypeSElection))
            {
                results = originalResult.Where(x => x.NearMissType == nearMissTypeSElection).ToList();
            }
            if (!String.IsNullOrEmpty(severitySelection))
            {
                results = originalResult.Where(x => x.SeverityLevel == severitySelection).ToList();
            }
            if (!String.IsNullOrEmpty(riskSelection)) {
                results = originalResult.Where(x => x.RiskLevel == riskSelection).ToList();
            }

        }
        protected void Clear(object sender, EventArgs e)
        {
            results = originalResult;

        }
    }
}