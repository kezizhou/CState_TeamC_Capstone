using CState_TeamC_Capstone.DomainObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone
{
    public partial class updateIncident : System.Web.UI.Page
    {
        public List<UpdateActionPageTable> results;
        public List<Filters> nearMissReportID;

        protected void Page_Load(object sender, EventArgs e)
        {
            results = Shared.GetUpdateActionIncidentPageQuery();
            nearMissReportID = Shared.GetNearMissRecordIDUpdateActionPage();
            GetUserName();
            if (!IsPostBack)
            {
                CreateDropDown();
            }
            userFullName.InnerText = GetUserName();
        }
        public void Filter(object sender, EventArgs e)
        {
            var selectedID = sltNearMissReportID.SelectedItem;
            if (int.Parse(selectedID.Value) == -1)
            {
                return;
            }
            results = Shared.GetUpdateActionIncidentPageQuery(selectedID.ToString());
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
        public void InsertUpdateAction(object sender, EventArgs e)
        {
            var UpdateAction = Request["txaActionUpdate"];
            var nearMissReportID = sltNearMissReportID.SelectedValue;
            var user = GetUserName();
            Shared.InsertUpdateActionStatement(nearMissReportID, UpdateAction, user, DateTime.Now.Date.ToString());
            Response.Redirect(Request.RawUrl);
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