﻿using CState_TeamC_Capstone.DomainObjects;
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
        public List<ExcellTableExport> excelExport;
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
            excelExport = Shared.GetExcellTableExport(departmentFilter, nearMissTypeFilter, severityTypeFilter, riskTypeFilter, operatorFilter, assigneeFilter);
        }

        protected void Filter(object sender, EventArgs e)
        {
            var departmentSelection = Request["sltDepartment"];
            ViewState["sltDepartment"] = departmentSelection;

            var nearMissTypeSelection = Request["sltNearMissType"];
            ViewState["sltNearMissType"] = nearMissTypeSelection;

            var severitySelection = Request["sltSeverityLevel"];
            ViewState["sltSeverityLevel"] = severitySelection;

            var riskSelection = Request["sltRiskLevel"];
            ViewState["sltRiskLevel"] = riskSelection;

            var operatorSelection = Request["sltOperatorName"];
            var assignedToSelection = Request["sltAssignedTo"];

            GetResults(departmentSelection, nearMissTypeSelection, severitySelection, riskSelection, operatorSelection, assignedToSelection);
        }

        protected void Clear(object sender, EventArgs e)
        {
            GetResults();
            ViewState.Clear();
        }
        protected void Export(object sender, EventArgs e)
        {
            Filter(sender, e);
            var excellBytes = Services.ExcellGeneration.CreateExcelDocument(excelExport);

            string myName = Server.UrlEncode("NearMissReports" + DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'_'mm'_'ss") + ".xlsx");

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + myName);
            Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(excellBytes);
            Response.End();
        }
    }
}