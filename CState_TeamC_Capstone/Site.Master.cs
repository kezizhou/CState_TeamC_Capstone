using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
	public partial class SiteMaster : MasterPage {
		protected void Page_Load(object sender, EventArgs e) {
            try
            {
                if (Session["User_ID"] == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                // User session expired
                Response.Redirect("signIn.aspx");
            }

            // Check if user is authorized
            if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "NearMissEHS"))
            {
                ReviewIncident.Style["display"] = "block";
                UpdateIncident.Style["display"] = "block";
                SearchTool.Style["display"] = "block";
            }
            if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "NearMissAssignee"))
            {
                ReviewIncident.Style["display"] = "block";
                UpdateIncident.Style["display"] = "block";
            }
            if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "NearMissAdmin"))
            {
                AdminSettings.Style["display"] = "block";
            }

            // Change signout to user initials
            userinitials.InnerText = GetInitials();

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
	}
}