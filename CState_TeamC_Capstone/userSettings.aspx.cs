using CState_TeamC_Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
	public partial class userSettings : System.Web.UI.Page {
		protected List<string> lstCurrentRoles { get; set; }
		protected List<Role> lstRoles { get; set; }

		protected List<RoleRequest> lstAllRoleRequests { get; set; }

		protected void Page_Load(object sender, EventArgs e) {
			try {
				lstCurrentRoles = LoadCurrentRoles();
				lstRoles = LoadRequestRoles();
				lstAllRoleRequests = LoadAllRoleRequests();
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}

		private List<string> LoadCurrentRoles() {
			lstCurrentRoles = new List<string>();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT RR.Name FROM Reference.Role AS RR JOIN Config.EmployeeRole AS CER ON RR.ID = CER.Role_ID WHERE Person_ID = @uid";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				var uidParam = new SqlParameter("@uid", System.Data.SqlDbType.Int);
				uidParam.Value = Session["User_ID"];
				cmd.Parameters.Add(uidParam);

				SqlDataReader sdr = cmd.ExecuteReader();

				while (sdr.Read()) {
					lstCurrentRoles.Add(sdr["Name"].ToString());
				}
			}

			return lstCurrentRoles;
		}

		private List<Role> LoadRequestRoles() {
			lstRoles = new List<Role>();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT ID, Name FROM Reference.Role ";

			// Fill in with user's existing roles
			if (lstCurrentRoles.Count != 0) {
				qry += "WHERE Name NOT IN('";
				for (int i = 0; i < lstCurrentRoles.Count; i++) {
					qry += lstCurrentRoles[i];
					if (i != lstCurrentRoles.Count - 1) {
						qry += "', '";
					} else {
						qry += "')";
					}
				}
			}

			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				string strID = "";
				string strRole = "";

				SqlDataReader sdr = cmd.ExecuteReader();

				while (sdr.Read()) {
					strID = sdr["ID"].ToString();
					strRole = sdr["Name"].ToString();
					lstRoles.Add(new Role(strID, strRole));
				}
			}

			return lstRoles;
		}

		protected void btnRequest_Click(object sender, EventArgs e) {
			try {
				int intRoleID = int.Parse(Request.Form["sltRole"].ToString());

				if ( lstAllRoleRequests.Any(n=>n.strStatus == "Pending") && lstAllRoleRequests.Any(n=>n.strRole == stringOfIDRole(intRoleID)) ) {
					// Role already requested
					Page.ClientScript.RegisterStartupScript(this.GetType(), "ResetForm", "invalidInput.style.display = 'block'", true);
				} else {
					SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
					conn.Open();
					string qry = "INSERT INTO Config.RoleRequests VALUES (@uid, @roleID, 2)";
					using (SqlCommand cmd = new SqlCommand(qry, conn)) {

						var uidParam = new SqlParameter("@uid", System.Data.SqlDbType.Int);
						uidParam.Value = Session["User_ID"];
						cmd.Parameters.Add(uidParam);

						var roleIDParam = new SqlParameter("@roleID", System.Data.SqlDbType.Int);
						roleIDParam.Value = intRoleID;
						cmd.Parameters.Add(roleIDParam);

						cmd.ExecuteNonQuery();

						cmd.Dispose();
						conn.Close();
					}
					Response.Redirect(Request.RawUrl);
				}
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}

		private string stringOfIDRole(int intRoleID) {
			string strRole = "";

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT Name FROM Reference.Role WHERE ID = @id";

			using (SqlCommand cmd = new SqlCommand(qry, conn)) {

				var idParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
				idParam.Value = intRoleID;
				cmd.Parameters.Add(idParam);

				SqlDataReader sdr = cmd.ExecuteReader();

				sdr.Read();
				strRole = sdr["Name"].ToString();

				cmd.Dispose();
				conn.Close();

				return strRole;
			}
		}

		private List<RoleRequest> LoadAllRoleRequests() {
			lstAllRoleRequests = new List<RoleRequest>();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT CRR.ID, Name, Status FROM Config.RoleRequests AS CRR JOIN Reference.Role AS RR ON CRR.Role_ID = RR.ID JOIN Reference.RequestStatus AS RSS ON CRR.Status_ID = RSS.ID WHERE CRR.Person_ID = @uid";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				string strID = "";
				string strRole = "";
				string strStatus = "";

				var uidParam = new SqlParameter("@uid", System.Data.SqlDbType.Int);
				uidParam.Value = Session["User_ID"];
				cmd.Parameters.Add(uidParam);

				SqlDataReader sdr = cmd.ExecuteReader();

				while (sdr.Read()) {
					strID = sdr["ID"].ToString();
					strRole = sdr["Name"].ToString();
					strStatus = sdr["Status"].ToString();

					// Add user to list
					lstAllRoleRequests.Add(new RoleRequest(strID, strRole, strStatus));
				}

				cmd.Dispose();
				conn.Close();
			}

			return lstAllRoleRequests;
		}
	}
}