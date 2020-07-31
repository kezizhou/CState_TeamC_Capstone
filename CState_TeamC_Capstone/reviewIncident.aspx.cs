using System;
using System.Collections.Generic;
using CState_TeamC_Capstone.DomainObjects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace CState_TeamC_Capstone {
    public partial class reviewIncident : System.Web.UI.Page {
        public List<Filters> assignTo;
        public List<Filters> severity;
        public List<Filters> risk;
        protected void Page_Load(object sender, EventArgs e) {
            assignTo = Shared.GetAssignedToNameFilter();
            severity = Shared.GetSeverityFilter();
            risk = Shared.GetRiskFilter();
            userFullName.InnerText = GetUserName();
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

                strUserName = "Welcome: " + sdr["First_Name"].ToString() + " " + sdr["Last_Name"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strUserName;
        }
    }
}