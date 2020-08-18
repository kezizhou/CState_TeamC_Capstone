using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web;
using DocumentFormat.OpenXml.Office2010.Excel;
using CState_TeamC_Capstone.Classes;
using System.Collections.Generic;
using System.Security.Permissions;

namespace CState_TeamC_Capstone
{
    public partial class newUser : System.Web.UI.Page
    {
        public List<Department> departments = new List<Department>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try {

                string conn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(conn);

                string sqlquery = "SELECT [ID], [Department] FROM [Reference].[Department] ORDER BY [Department] ASC";
                SqlCommand command = new SqlCommand(sqlquery, sqlconn);
                sqlconn.Open();
                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        departments.Add(new Department(reader[0].ToString(), reader[1].ToString()));
					}
				}
            
                sqlconn.Close();

            } catch (Exception ex) {
                Response.Write(ex.Message);
            }
        }

        protected void btnSubmitNewUser_Click(object sender, EventArgs e)
        {
            try {
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
            } catch (Exception ex) {
                Response.Write(ex.Message);
            }
        }

        [WebMethod]
        public static bool CheckDuplicateUsername(string strUsername) {
            bool blnDuplicate = true;

            try {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                conn.Open();
                string qry = "SELECT * FROM Data.Employee WHERE Username = @username";
                using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                    var usernameParam = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
                    usernameParam.Value = strUsername;
                    cmd.Parameters.Add(usernameParam);

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
                string qry = "SELECT * FROM Data.Employee WHERE Email = @email";
                using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                    var emailParam = new SqlParameter("@email", System.Data.SqlDbType.VarChar);
                    emailParam.Value = strEmail;
                    cmd.Parameters.Add(emailParam);

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

