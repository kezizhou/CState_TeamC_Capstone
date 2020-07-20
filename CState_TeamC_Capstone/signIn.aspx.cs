using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
	public partial class signIn : System.Web.UI.Page {
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());

		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void btnSubmit_Click(object sender, EventArgs e) {
			try {
				string strUsername = Request.Form["txtUsername"];
				string strEnteredPassword = Request.Form["txtPassword"];
				conn.Open();
				string qry = "SELECT * FROM Data.Employee WHERE Username = @username";
				using (SqlCommand cmd = new SqlCommand(qry, conn)) {
					var usernameParam = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
					usernameParam.Value = strUsername;
					cmd.Parameters.Add(usernameParam);

					SqlDataReader sdr = cmd.ExecuteReader();

					if (sdr.Read()) {
						string strHash = sdr["Password"].ToString();
						string strSalt = sdr["Salt"].ToString();

						// Check if password hashes and salt match
						bool passwordMatches = HashSalt.VerifySaltedHash(strEnteredPassword, strHash, strSalt);

						if (passwordMatches) {
							// Sign-in successful
							Session["User_ID"] = sdr["Person_ID"];
							FormsAuthentication.SetAuthCookie(sdr["Username"].ToString(), false);
							cmd.Dispose();
							conn.Close();
							Response.Redirect("~/Home.aspx");
						} else {
							// Incorrect password
							cmd.Dispose();
							conn.Close();
							invalidInput.Style["display"] = "block";
						}
					} else {
						// Username not found
						cmd.Dispose();
						conn.Close();
						invalidInput.Style["display"] = "block";
					}
					
				}
			}
			catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}
	}
}