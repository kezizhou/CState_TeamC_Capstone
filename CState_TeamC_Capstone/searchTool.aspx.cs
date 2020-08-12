using CState_TeamC_Capstone.DomainObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone
{
    public partial class searchTool : System.Web.UI.Page
    {
        public List<SearchToolQueryResult> results;
        public int pageCount;

        public List<Filters> departments;
        public List<Filters> nearMissType;
        public List<Filters> severity;
        public List<Filters> risk;
        public List<Filters> operatorName;
        public List<Filters> assignedToName;


        protected void Page_Load(object sender, EventArgs e)
        {
            GetResults();
            SetFilterOptions();
        }

        private void SetPageCountFromResults()
        {
            var recordIntoPages = (results.FirstOrDefault()?.TotalRows / 5.0);
            if (recordIntoPages != null)
            {
                pageCount = (int)Math.Ceiling((double)recordIntoPages);

            }
            else
            {
                pageCount = 1;
            }
        }

        private void SetFilterOptions()
        {
            departments = Shared.GetDepartmentFilter();
            nearMissType = Shared.GetNearMissTypeFilter();
            severity = Shared.GetSeverityFilter();
            risk = Shared.GetRiskFilter();
            operatorName = Shared.GetOperatorNameFilter();
            assignedToName = Shared.GetAssignedToNameFilter();
        }

        private void GetResults(string departmentFilter = null,
                             string nearMissTypeFilter = null,
                             string severityTypeFilter = null,
                             string riskTypeFilter = null,
                             string operatorFilter = null,
                             string assigneeFilter = null)
        {
            results = Shared.GetSearchToolQuery(departmentFilter, nearMissTypeFilter, severityTypeFilter, riskTypeFilter, operatorFilter, assigneeFilter);
            SetPageCountFromResults();
        }

        protected void Filter(object sender, EventArgs e)
        {
            var departmentSelection = Request["sltDepartment"];
            ViewState["sltDepartment"] = departmentSelection;

            var nearMissTypeSElection = Request["sltNearMissType"];
            ViewState["sltNearMissType"] = nearMissTypeSElection;

            var severitySelection = Request["sltSeverityLevel"];
            ViewState["sltSeverityLevel"] = severitySelection;

            var riskSelection = Request["sltRiskLevel"];
            ViewState["sltRiskLevel"] = riskSelection;

            var operatorSelection = Request["sltOperatorName"];
            var assignedToSelection = Request["sltAssignedTo"];

            GetResults(departmentSelection, nearMissTypeSElection, severitySelection, riskSelection, operatorSelection, assignedToSelection);
        }

        protected void Clear(object sender, EventArgs e)
        {
            GetResults();
            ViewState.Clear();
        }
        protected void Export(object sender, EventArgs e)
        {
            var exportExcell = Shared.GetExcellTableExport();
            var excellBytes = Services.ExcellGeneration.CreateExcelDocument(exportExcell);

            string myName = Server.UrlEncode("NearMissReports.xlsx");

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + myName);
            Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(excellBytes);
            Response.End();
        }
    }
}