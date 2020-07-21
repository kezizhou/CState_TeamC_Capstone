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

namespace CState_TeamC_Capstone {
	public partial class resetCredentials : System.Web.UI.Page {
		

		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void btnResetCredentials_Click(object sender, EventArgs e) {
			try {
				string strFirstName = Request.Form["txtFirstName"];
				string strLastName = Request.Form["txtLastName"];
				string strEmail = Request.Form["txtEmail"];
				string strUsername = "";
				string qry = "";

				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
				conn.Open();
				if (Request.Form["txtUsername"] != "") {
					// Forgot password
					strUsername = Request.Form["txtUsername"];
					qry = "SELECT * FROM Data.Employee WHERE First_Name = @firstname AND Last_Name = @lastname AND Email = @email AND Username = @username";
					using (SqlCommand cmd = new SqlCommand(qry, conn)) {
						var firstNameParam = new SqlParameter("@firstname", System.Data.SqlDbType.VarChar);
						firstNameParam.Value = strFirstName;
						cmd.Parameters.Add(firstNameParam);

						var lastNameParam = new SqlParameter("@lastname", System.Data.SqlDbType.VarChar);
						lastNameParam.Value = strLastName;
						cmd.Parameters.Add(lastNameParam);

						var emailParam = new SqlParameter("@email", System.Data.SqlDbType.VarChar);
						emailParam.Value = strEmail;
						cmd.Parameters.Add(emailParam);

						var usernameParam = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
						usernameParam.Value = strUsername;
						cmd.Parameters.Add(usernameParam);

						SqlDataReader sdr = cmd.ExecuteReader();
						if (sdr.Read()) {
							// Matching user found
							int intID = (int)sdr["Person_ID"];
							strUsername = sdr["Username"].ToString();

							// Send reset password email
							sendResetEmail(intID, strUsername, strEmail);
						}

						cmd.Dispose();
						conn.Close();
					}

				}
				else if (Request.Form["txtPassword"] != "") {
					// Forgot username
					string strEnteredPassword = Request.Form["txtPassword"];
					qry = "SELECT * FROM Data.Employee WHERE First_Name = @firstname AND Last_Name = @lastname AND Email = @email";
					using (SqlCommand cmd = new SqlCommand(qry, conn)) {
						var firstNameParam = new SqlParameter("@firstname", System.Data.SqlDbType.VarChar);
						firstNameParam.Value = strFirstName;
						cmd.Parameters.Add(firstNameParam);

						var lastNameParam = new SqlParameter("@lastname", System.Data.SqlDbType.VarChar);
						lastNameParam.Value = strLastName;
						cmd.Parameters.Add(lastNameParam);

						var emailParam = new SqlParameter("@email", System.Data.SqlDbType.VarChar);
						emailParam.Value = strEmail;
						cmd.Parameters.Add(emailParam);

						SqlDataReader sdr = cmd.ExecuteReader();
						if (sdr.Read()) {
							// Matching user found
							strUsername = sdr["Username"].ToString();
							string strHash = sdr["Password"].ToString();
							string strSalt = sdr["Salt"].ToString();

							// Check if password hashes and salt match
							bool passwordMatches = HashSalt.VerifySaltedHash(strEnteredPassword, strHash, strSalt);

							if (passwordMatches) {
								// Send forgot username email if password is correct
								sendForgotUsernameEmail(strUsername, strEmail);
							}
						}

						cmd.Dispose();
						conn.Close();
					}
				}

				// Redirect to email sent page
				// This displays for invalid credentials as well so malicious users are not able to find valid usernames to attack
				Response.Redirect("resetEmailSent.aspx");
			}
			catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}

		private void sendResetEmail(int intID, string strUsername, string strEmail) {
			string strToken = generateToken();
			string strHashedToken = HashSalt.GenerateHashString(strToken);

			// Mark any existing tokens and used
			markExistingTokens();

			// Store the hashed token in database
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "INSERT into Data.ResetTokens(Person_ID, Token_Hash, Expiration_Date, Token_Used) VALUES(@id, @tokenhash, '" + DateTime.Now.AddHours(3) + "', '0')";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				var idParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
				idParam.Value = intID;
				cmd.Parameters.Add(idParam);

				var tokenHashParam = new SqlParameter("@tokenhash", System.Data.SqlDbType.Char);
				tokenHashParam.Value = strHashedToken;
				cmd.Parameters.Add(tokenHashParam);

				cmd.ExecuteNonQuery();

				cmd.Dispose();
				conn.Close();
			}

			SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
			MailMessage mailMessage = new MailMessage(section.Network.UserName, strEmail);
			string templatePath = HttpRuntime.AppDomainAppPath + "/emailResetTemplate.html";
			StreamReader sr = new StreamReader(templatePath);
			string strEmailBody = sr.ReadToEnd();
			sr.Close();

			// Replace the template placeholder variables
			strEmailBody = strEmailBody.Replace("[strUsername]", strUsername);
			strEmailBody = strEmailBody.Replace("[actionURL]", ConfigurationManager.AppSettings["mainURL"] + "resetPassword?username=" + strUsername + "&token=" + Server.UrlEncode(strToken));
			strEmailBody = strEmailBody.Replace("[mainURL]", ConfigurationManager.AppSettings["mainURL"] + "signIn");

			mailMessage.IsBodyHtml = true;
			mailMessage.Body = strEmailBody;
			mailMessage.Subject = "Reset Your Password";
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Send(mailMessage);
		}

		private void sendForgotUsernameEmail(string strUsername, string strEmail) {
			SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
			MailMessage mailMessage = new MailMessage(section.Network.UserName, strEmail);
			string templatePath = HttpRuntime.AppDomainAppPath + "/emailForgotUsernameTemplate.html";
			StreamReader sr = new StreamReader(templatePath);
			string strEmailBody = sr.ReadToEnd();
			sr.Close();

			// Replace the template placeholder variables
			strEmailBody = strEmailBody.Replace("[strUsername]", strUsername);
			strEmailBody = strEmailBody.Replace("[mainURL]", ConfigurationManager.AppSettings["mainURL"] + "signIn");

			mailMessage.IsBodyHtml = true;
			mailMessage.Body = strEmailBody;
			mailMessage.Subject = "Forgot Username?";
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Send(mailMessage);
		}

		private string generateToken() {
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) {
				Byte[] randomToken = new byte[12];
				rng.GetBytes(randomToken);
				string strToken = Convert.ToBase64String(randomToken);

				return strToken;
			}
		}

		private void markExistingTokens() {
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "UPDATE Data.ResetTokens SET Token_Used = 1 WHERE Token_Used = 0";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				conn.Close();
			}
		}
	}
}