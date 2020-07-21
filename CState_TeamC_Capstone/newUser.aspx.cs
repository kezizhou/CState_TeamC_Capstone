using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net.Configuration;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace CState_TeamC_Capstone
{
    public partial class newUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmitNewUser_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string strFirstName = Request.Form["txtFirstName"];
            //    string strMiddleName = Request.Form["txtMiddleName"];
            //    string strLastName = Request.Form["txtLastName"];
            //    string strEmployeeID = Request.Form["txtemployeeID"];
            //    string strEmail = Request.Form["txtEmail"];
            //    string strDepartment = Request.Form["sltDepartment"];
            //    string strUsername = Request.Form["txtUsername"];
            //    string strPassword = Request.Form["txtPassword"];
            //    string qry = "";

            //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            //    conn.Open();
            //}

         }
    }
}

