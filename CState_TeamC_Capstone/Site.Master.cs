using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace CState_TeamC_Capstone {
	public partial class SiteMaster : MasterPage {
		protected void Page_Load(object sender, EventArgs e) {
			try {
				try {
					if (Session["User_ID"] == null) {
						throw new Exception();
					}
				} catch (Exception) {
					// User session expired
					Response.Redirect("signIn.aspx");
				}

				// Check if user is authorized
				if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "NearMissEHS")) {
					ReviewIncident.Style["display"] = "block";
					UpdateIncident.Style["display"] = "block";
					SearchTool.Style["display"] = "block";
				}
				if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "NearMissAssignee")) {
					ReviewIncident.Style["display"] = "block";
					UpdateIncident.Style["display"] = "block";
				}
				if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "NearMissAdmin")) {
					// Load admin settings requests count
					int intRequests = LoadRequestCount();
					if (intRequests == 0) {
						badge.Attributes.Add("class", badge.Attributes["class"].ToString().Replace("badge-count", "badge-none"));
					}
					badge.InnerText = intRequests.ToString();

					AdminSettings.Style["display"] = "block";
				}

				// Change signout to user initials
				userinitials.InnerText = GetInitials();
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}

		}

		private string GetInitials() {
			int intUserID = int.Parse(Session["User_ID"].ToString());
			string strInitials = "";

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT * FROM Data.Employee WHERE Person_ID = @id";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				var idParam = new SqlParameter("@id", System.Data.SqlDbType.VarChar);
				idParam.Value = intUserID;
				cmd.Parameters.Add(idParam);

				SqlDataReader sdr = cmd.ExecuteReader();
				sdr.Read();

				strInitials = sdr["First_Name"].ToString().Substring(0, 1) + sdr["Last_Name"].ToString().Substring(0, 1);

				cmd.Dispose();
				conn.Close();
			}

			return strInitials;
		}

		private int LoadRequestCount() {
			int intRequestCount = 0;

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT COUNT(ID) AS RequestCount FROM Config.RoleRequests WHERE Status_ID = 2";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				SqlDataReader sdr = cmd.ExecuteReader();
				sdr.Read();

				intRequestCount = int.Parse(sdr["RequestCount"].ToString());

				cmd.Dispose();
				conn.Close();
			}

			return intRequestCount;
		}
	}
}