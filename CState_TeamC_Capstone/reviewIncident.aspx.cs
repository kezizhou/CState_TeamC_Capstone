using System;
using System.Collections.Generic;
using CState_TeamC_Capstone.DomainObjects;
using CState_TeamC_Capstone.Classes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace CState_TeamC_Capstone
{
    public partial class reviewIncident : System.Web.UI.Page
    {
        public List<ReviewIncidentPageTable> results;
        public List<Filters> nearMissReportID;
        public List<Filters> assignTo;
        public List<Filters> severity;
        public List<Filters> risk;
        protected void Page_Load(object sender, EventArgs e)
        {
            results = Shared.GetReviewIncidentPageQuery();
            assignTo = Shared.GetAssignIncidentReviewPage();
            severity = Shared.GetSeverityFilter();
            risk = Shared.GetRiskFilter();
            nearMissReportID = Shared.GetNearMissRecordIDReviewPage();
            GetUserName();
            if (!IsPostBack)
            {
                CreateDropDown();
            }
            userFullName.InnerText = ExtensionMethods.GetLastNameFirstName();
        }
        public void Filter(object sender, EventArgs e)
        {
            var selectedID = sltNearMissReportID.SelectedItem;
            if (int.Parse(selectedID.Value) == -1)
            {
                return;
            }
            results = Shared.GetReviewIncidentPageQuery(selectedID.ToString());
        }
        public void InsertReviewLog(object sender, EventArgs e)
        {
            var assignIncidentSelection = Request["sltAssignIncident"];
            var severitySelection = Request["sltSeverityLevel"];
            var riskSelection = Request["sltRiskLevel"];
            var nearMissReportID = sltNearMissReportID.SelectedValue;
            var user = GetUserName();
            Shared.InsertReviewLogStatement(nearMissReportID, assignIncidentSelection, severitySelection, riskSelection, user, DateTime.Now.Date.ToString());
            Response.Redirect(Request.RawUrl);
        }
        public void CreateDropDown()
        {
            sltNearMissReportID.DataTextField = "Value";
            sltNearMissReportID.DataValueField = "Id";
            sltNearMissReportID.DataBind();

            sltNearMissReportID.Items.Insert(0, new ListItem("Please Select Near Miss Incident Report", "-1"));
            var rownumber = 1;
            foreach (var x in nearMissReportID)
            {
                sltNearMissReportID.Items.Insert(rownumber, new ListItem(x.Description, x.ID.ToString()));
                rownumber++;

            }

        }

        private string GetUserName()
        {
            int intUserID = int.Parse(Session["User_ID"].ToString());
            string strUserName = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT * FROM Data.Employee WHERE Person_ID = @id";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                var idParam = new SqlParameter("@id", System.Data.SqlDbType.VarChar);
                idParam.Value = intUserID;
                cmd.Parameters.Add(idParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strUserName = sdr["First_Name"].ToString() + " " + sdr["Last_Name"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strUserName;
        }

    }
}