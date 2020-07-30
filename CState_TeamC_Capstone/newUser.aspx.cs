using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web;

namespace CState_TeamC_Capstone
{
    public partial class newUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try {

                string conn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(conn);

                string sqlquery = "SELECT [ID], [Department] FROM [Reference].[Department] ORDER BY [Department] ASC";
                SqlDataAdapter sda = new SqlDataAdapter(sqlquery, sqlconn);
                sqlconn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sltDepartment.DataSource = dt;
                sltDepartment.DataTextField = "Department";
                sltDepartment.DataValueField = "Department";
                sltDepartment.DataBind();
            
                sqlconn.Close();

                sltDepartment.Items.Insert(0, "Select Department");

            } catch (Exception ex) {
                Response.Write(ex.Message);
            }
        }

        protected void btnSubmitNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                string strFirstName = Request.Form["txtFirstName"];
                string strMiddleName = Request.Form["txtMiddleName"];
                string strLastName = Request.Form["txtLastName"];
                int intEmployeeID = Convert.ToInt32(Request.Form["txtEmployeeID"]);
                string strUsername = Request.Form["txtUsername"];
                bool blnActive;
                string strPassword = Request.Form["txtPassword"];
                string strEmail = Request.Form["txtEmail"];
                string strDepartment = Request.Form["sltDepartment"];
                
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                conn.Open();

                // Add hash password
                HashSalt hashSalt = HashSalt.GenerateSaltedHash(32, strPassword);
                string hashParam = hashSalt.Hash;
                   
                // Add salt
                string saltParam = hashSalt.Salt;

                blnActive = cbEmployeeStatus.Checked;

                Shared.InsertNewEmployee(strFirstName, strMiddleName, strLastName, strUsername, hashParam, saltParam, blnActive, intEmployeeID, strEmail, strDepartment);

                conn.Close();

                Response.Redirect("signIn.aspx?type=newUser");
            }
                 
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
      
         }

        [WebMethod]
        public static bool CheckDuplicateUsername(string strUsername) {
            bool blnDuplicate = true;

            try {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                conn.Open();
                string qry = "SELECT * FROM Data.Employee WHERE Username = '" + strUsername + "'";
                using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read()) {
                        blnDuplicate = false;
                    }
                    cmd.Dispose();
                    conn.Close();
                }
            } catch (Exception ex) {
                HttpContext.Current.Response.Write(ex.Message);
            }

            return blnDuplicate;
		}

        [WebMethod]
        public static bool CheckDuplicateEmail(string strEmail) {
            bool blnDuplicate = true;

            try {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                conn.Open();
                string qry = "SELECT * FROM Data.Employee WHERE Email = '" + strEmail + "'";
                using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read()) {
                        blnDuplicate = false;
                    }
                    cmd.Dispose();
                    conn.Close();
                }
            } catch (Exception ex) {
                HttpContext.Current.Response.Write(ex.Message);
            }

            return blnDuplicate;
        }
    }
}

