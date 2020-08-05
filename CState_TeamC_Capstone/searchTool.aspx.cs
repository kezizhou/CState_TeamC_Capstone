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
            SetPage(1);
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

        private void SetPage(int pageNumber,
                             string departmentFilter = null,
                             string nearMissTypeFilter = null,
                             string severityTypeFilter = null,
                             string riskTypeFilter = null,
                             string operatorFilter = null,
                             string assigneeFilter = null)
        {
            results = Shared.GetSearchToolQuery(pageNumber, departmentFilter, nearMissTypeFilter, severityTypeFilter, riskTypeFilter, operatorFilter, assigneeFilter);
            SetPageCountFromResults();
            CreateControl();
        }


        private void CreateControl()
        {
            PlaceHolder1.Controls.Clear();
            for (var i = 1; i < pageCount + 1; i++)
            {
                LinkButton lb = new LinkButton();
                lb = new LinkButton();
                lb.Text = Convert.ToString(i) + " ";
                lb.ID = Convert.ToString(i);
                lb.CommandArgument = Convert.ToString(i);
                lb.CommandName = Convert.ToString(i);
                lb.Command += lb_Command;
                PlaceHolder1.Controls.Add(lb);
            }
        }

        void lb_Command(object sender, CommandEventArgs e)
        {
            SetPage(int.Parse(e.CommandArgument.ToString()));
        }

        protected void Filter(object sender, EventArgs e)
        {
            var departmentSelection = Request["sltDepartment"];
            var nearMissTypeSElection = Request["sltNearMissType"];
            var severitySelection = Request["sltSeverityLevel"];
            var riskSelection = Request["sltRiskLevel"];
            var operatorSelection = Request["sltOperatorName"];
            var assignedToSelection = Request["sltAssignedTo"];

            SetPage(1, departmentSelection, nearMissTypeSElection, severitySelection, riskSelection, operatorSelection, assignedToSelection);
        }

        protected void Clear(object sender, EventArgs e)
        {
            SetPage(1);
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