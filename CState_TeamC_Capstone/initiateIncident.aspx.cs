using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace CState_TeamC_Capstone {
	public partial class initiateIncident : System.Web.UI.Page {

		protected void Page_Load(object sender, EventArgs e) {
            string conn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(conn);

            string sqlquery_Dep = "SELECT [ID], [Department] FROM [Reference].[Department] ORDER BY [Department] ASC";
            SqlDataAdapter sda_Dep = new SqlDataAdapter(sqlquery_Dep, sqlconn);
            sqlconn.Open();
            DataTable dt_Dep = new DataTable();
            sda_Dep.Fill(dt_Dep);
            sltDepartment.DataSource = dt_Dep;
            sltDepartment.DataTextField = "Department";
            sltDepartment.DataValueField = "ID";
            sltDepartment.DataBind();

            sqlconn.Close();

            sltDepartment.Items.Insert(0, "Select Department");

            string sqlquery_NMT = "SELECT [ID], [NearMissType] FROM [Reference].[NearMissType] ORDER BY [NearMissType] ASC";
            SqlDataAdapter sda_NMT = new SqlDataAdapter(sqlquery_NMT, sqlconn);
            sqlconn.Open();
            DataTable dt_NMT = new DataTable();
            sda_NMT.Fill(dt_NMT);
            sltType.DataSource = dt_NMT;
            sltType.DataTextField = "NearMissType";
            sltType.DataValueField = "ID";
            sltType.DataBind();

            sqlconn.Close();
            sltType.Items.Insert(0, "Select Near Miss Type");
            
        }
    }
}
