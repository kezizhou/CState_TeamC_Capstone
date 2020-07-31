using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace CState_TeamC_Capstone {
	public partial class signIn : System.Web.UI.Page {
		string strType = "";
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());

		protected void Page_Load(object sender, EventArgs e) {
			try {
				if (this.Context.User.Identity.IsAuthenticated && Session["User_ID"] != null) {
					Response.Redirect("Home.aspx");
				}

				if (Request.QueryString["type"] != null) {
					strType = Request.QueryString["type"];
					switch (strType) {
						case "newUser":
							message.InnerText = "New user successfully created.";
							message.Attributes.Add("class", message.Attributes["class"].ToString().Replace("invalidInput", "message"));
							message.Style["display"] = "block";
							break;
						default:
							break;
					}
				}
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e) {
			try {
				// Hide new user message if showing
				if (strType != "") {
					message.InnerText = "Incorrect username or password entered.";
					message.Attributes.Add("class", message.Attributes["class"].ToString().Replace("message", "invalidInput"));
					message.Style["display"] = "none";
				}

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
						bool passwordMatches = HashSalt.VerifySaltedHash(strEnteredPassword, strHash.Trim(), strSalt.Trim());

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
							message.Style["display"] = "block";
						}
					} else {
						// Username not found
						cmd.Dispose();
						conn.Close();
						message.Style["display"] = "block";
					}
					
				}
			}
			catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}
	}
}