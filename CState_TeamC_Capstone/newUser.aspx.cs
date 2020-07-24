using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace CState_TeamC_Capstone
{
    public partial class newUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(conn);

            string sqlquery = "SELECT [ID], [Department] FROM [Reference].[Department] ORDER BY [Department] ASC";
            SqlDataAdapter sda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlconn.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sltDepartment.DataSource = dt;
            sltDepartment.DataTextField = "Department";
            sltDepartment.DataValueField = "ID";
            sltDepartment.DataBind();
            
            sqlconn.Close();

            sltDepartment.Items.Insert(0, "Select Department");
               
        }

        protected void btnSubmitNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                string strFirstName = Request.Form["txtFirstName"];
                string strMiddleName = Request.Form["txtMiddleName"];
                string strLastName = Request.Form["txtLastName"];
                int intEmployeeID = Convert.ToInt32(Request.Form["txtemployeeID"]);
                string strUsername = Request.Form["txtUsername"];
                string strPassword = Request.Form["txtPassword"];
                string strActive = Request.Form["cbEmployeeStatus"];
                string strEmail = Request.Form["txtEmail"];
                string strDepartment = Request.Form["sltDepartment"];

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                conn.Open();
                               
                    // Add hash password
                    HashSalt hashSalt = HashSalt.GenerateSaltedHash(32, strPassword);
                    string hashParam = hashSalt.Hash;
                   
                    // Add salt
                    string saltParam = hashSalt.Salt;
                
                Shared.InsertNewEmployee(strFirstName, strMiddleName, strLastName, strUsername, hashParam, saltParam, strActive, intEmployeeID, strEmail, strDepartment);

                conn.Close();
                              
            }
            
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
      
         }
    }
}

