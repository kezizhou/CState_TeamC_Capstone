using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CState_TeamC_Capstone
{
    public partial class initiateIncident : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(conn);
            firstnamelastname.InnerText = GetFirstNameLastName();

            //string strFirstNameLastName = GetFirstNameLastName();
            //var firstnamelastname = strFirstNameLastName.ToString();
            

            string sqlquery_Dep = "SELECT [ID] FROM [Reference].[Department] ORDER BY [ID] ASC";
            SqlDataAdapter sda_Dep = new SqlDataAdapter(sqlquery_Dep, sqlconn);
            sqlconn.Open();
            DataTable dt_Dep = new DataTable();
            sda_Dep.Fill(dt_Dep);
            sltDepartment.DataSource = dt_Dep;
            sltDepartment.DataTextField = "ID";
            sltDepartment.DataValueField = "ID";
            sltDepartment.DataBind();

            sqlconn.Close();

            sltDepartment.Items.Insert(0, "Select Department");

            string sqlquery_NMT = "SELECT [ID] FROM [Reference].[NearMissType] ORDER BY [ID] ASC";
            SqlDataAdapter sda_NMT = new SqlDataAdapter(sqlquery_NMT, sqlconn);
            sqlconn.Open();
            DataTable dt_NMT = new DataTable();
            sda_NMT.Fill(dt_NMT);
            sltType.DataSource = dt_NMT;
            sltType.DataTextField = "ID";
            sltType.DataValueField = "ID";
            sltType.DataBind();

            sqlconn.Close();
            sltType.Items.Insert(0, "Select Near Miss Type");

            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string dteNearMissDate = Convert.ToString(Request.Form["dteIncident"]);
                string strOperatorName = Request.Form["txtOperator"];
                int intBadgeNumber = Convert.ToInt32(Request.Form["txtBadgeNumber"]);
                //str strDepartment = (Request.Form["sltDepartment"]);
                //int intNearMissType_ID = Convert.ToInt32(Request.Form["sltType"]);
                // int intDepartment_ID = Convert.ToInt32(Request.Form["sltDepartmentname"]);
                //string strDepartment = sltDepartment.Items[intDepartment_ID].Text;
                //int intNearMissType_ID = Convert.ToInt32(Request.Form["sltTypename"]);
                //string strNearMissType = sltType.Items[intNearMissType_ID].Text;
                //var selectedDeptText = Convert.ToInt32(hidDeptText.Value);
                //var selectedDeptValue = Convert.ToInt32(hidDeptValue.Value);
                //var selectedNMText = Convert.ToInt32(hidNMText.Value);
                //var selectedNMValue = Convert.ToInt32(hidNMValue.Value);
                string strNearMissSolution = Request.Form["txaSolution"];
                string strNearMiss_ActionTaken = Request.Form["txaActionTaken"];

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                conn.Open();

                Shared.InsertNearMissRecord(dteNearMissDate, strOperatorName, intDepartment_ID, intNearMissType_ID, strNearMissSolution, strNearMiss_ActionTaken);

                conn.Close();

                //Redirect to success new user page
                Response.Redirect("signIn.aspx");
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private string GetFirstNameLastName()
        {
            int intUserID = int.Parse(Session["User_ID"].ToString());
            string strfirstnamelastname = "";

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

                strfirstnamelastname = sdr["Last_Name"].ToString() + ", " + sdr["First_Name"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strfirstnamelastname;
        }

    }
}

