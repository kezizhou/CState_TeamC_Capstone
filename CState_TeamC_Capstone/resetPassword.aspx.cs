using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
	public partial class resetPassword : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			try {
				if (Request.QueryString["username"] != null && Request.QueryString["username"] != string.Empty && Request.QueryString["token"] != null && Request.QueryString["token"] != string.Empty) {
					txtUsername.Value = Request.QueryString["username"];
					string strUsername = Request.QueryString["username"];
					string strToken = Request.QueryString["token"];

					string strHashedTokenDb = "";
					bool blnHashesEqual = false;

					// Get the hashed token in the database
					SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
					conn.Open();
					string qry = "SELECT R.Token_Hash FROM Data.ResetTokens AS R JOIN Data.Employee AS E ON R.Person_ID = E.Person_ID WHERE E.Username = @username AND R.Token_Used = 0 AND DATEDIFF(millisecond, R.Expiration_Date, GETDATE()) < 0";
					using (SqlCommand cmd = new SqlCommand(qry, conn)) {
						var usernameParam = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
						usernameParam.Value = strUsername;
						cmd.Parameters.Add(usernameParam);

						SqlDataReader sdr = cmd.ExecuteReader();

						if (sdr.Read()) {
							strHashedTokenDb = sdr["Token_Hash"].ToString().Trim();

							// Compare to query string token hash
							string strHashedToken = HashSalt.GenerateHashString(strToken);
							if (strHashedToken.Equals(strHashedTokenDb)) {
								blnHashesEqual = true;
							}
						} else {
							// Token is already used or expired
							// Or user does not have an tokens
							Response.Redirect("reset.aspx?type=invalidToken");
						}

						cmd.Dispose();
						conn.Close();
					}

					if (blnHashesEqual == false) {
						// Invalid token
						Response.Redirect("reset.aspx?type=invalidToken");
					}
				} else {
					// No username or token provided
					Response.Redirect("reset.aspx?type=invalidToken");
				}
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}

		protected void btnResetPassword_Click(object sender, EventArgs e) {
			try {
				string strPassword = Request.Form["txtPassword"];
				string strUsername = Request.Form["txtUsername"];

				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
				conn.Open();
				string qry = "UPDATE Data.Employee SET Password = @hash, Salt = @salt WHERE Username = @username";
				using (SqlCommand cmd = new SqlCommand(qry, conn)) {
					var usernameParam = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
					usernameParam.Value = strUsername;
					cmd.Parameters.Add(usernameParam);

					// Add hash password
					HashSalt hashSalt = HashSalt.GenerateSaltedHash(32, strPassword);
					var hashParam = new SqlParameter("@hash", System.Data.SqlDbType.Char);
					hashParam.Value = hashSalt.Hash;
					cmd.Parameters.Add(hashParam);

					// Add salt
					var saltParam = new SqlParameter("@salt", System.Data.SqlDbType.Char);
					saltParam.Value = hashSalt.Salt;
					cmd.Parameters.Add(saltParam);

					SqlDataReader sdr = cmd.ExecuteReader();
					conn.Close();
				}


				// Mark token as used
				conn.Open();
				qry = "UPDATE Data.ResetTokens SET Data.ResetTokens.Token_Used = 1 FROM Data.ResetTokens AS R JOIN Data.Employee AS E ON R.Person_ID = E.Person_ID WHERE E.Username = @username";
				using (SqlCommand cmd = new SqlCommand(qry, conn)) {
					var usernameParam = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
					usernameParam.Value = strUsername;
					cmd.Parameters.Add(usernameParam);
					SqlDataReader sdr = cmd.ExecuteReader();
				}

				conn.Close();

				// Redirect to succesful reset page
				Response.Redirect("reset.aspx?type=resetPasswordSuccess");
			}
			catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}
	}
}