using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
	public partial class adminSettings : System.Web.UI.Page {

		protected List<UserRequest> lstUsersWithRequests;

		protected void Page_Load(object sender, EventArgs e) {
			try {
				lstUsersWithRequests = LoadRequests();
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}

		private List<UserRequest> LoadRequests() {
			List<UserRequest> lstUsersWithRequests = new List<UserRequest>();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT CRR.ID, RR.Name, DE.First_Name, DE.Middle_Name, DE.Last_Name, DE.Email, DE.Employee_ID, DE.Department FROM Data.Employee AS DE " + 
						 "JOIN Config.RoleRequests AS CRR ON DE.Person_ID = CRR.Person_ID JOIN Reference.Role AS RR ON CRR.Role_ID = RR.ID " +
						 "WHERE NOT DE.Person_ID = @uid AND NOT CRR.Status_ID IN(1, 3) ";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				string strID = "";
				string strRole = "";
				string strFirstName = "";
				string strMiddleName = "";
				string strLastName = "";
				string strEmail = "";
				string strEmployeeID = "";
				string strDepartment = "";

				var uidParam = new SqlParameter("@uid", System.Data.SqlDbType.Int);
				uidParam.Value = Session["User_ID"];
				cmd.Parameters.Add(uidParam);

				SqlDataReader sdr = cmd.ExecuteReader();

				while (sdr.Read()) {
					strID = sdr["ID"].ToString();
					strRole = sdr["Name"].ToString();
					strFirstName = sdr["First_Name"].ToString();
					strMiddleName = sdr["Middle_Name"].ToString();
					strLastName = sdr["Last_Name"].ToString();
					strEmail = sdr["Email"].ToString();
					strEmployeeID = sdr["Employee_ID"].ToString();
					strDepartment = sdr["Department"].ToString();

					// Add user to list
					lstUsersWithRequests.Add(new UserRequest(strID, strRole, strFirstName, strMiddleName, strLastName, strEmail, strEmployeeID, strDepartment));
				}

				cmd.Dispose();
				conn.Close();
			}

			return lstUsersWithRequests;
		}

		[WebMethod]
		public static void btnAccept_Click(string strRequestID) {
			try {
				AddRoleForUser(strRequestID);

				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
				conn.Open();
				string qry = "UPDATE Config.RoleRequests SET Status_ID = 1 WHERE ID = @requestID";
				using (SqlCommand cmd = new SqlCommand(qry, conn)) {

					var requestIDParam = new SqlParameter("@requestID", System.Data.SqlDbType.Int);
					requestIDParam.Value = strRequestID;
					cmd.Parameters.Add(requestIDParam);

					cmd.ExecuteNonQuery();

					cmd.Dispose();
					conn.Close();
				}
			} catch (Exception ex) {
				HttpContext.Current.Response.Write(ex.Message);
			}
		}

		protected static void AddRoleForUser(string strRequestID) {
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "INSERT INTO Config.EmployeeRole SELECT DE.Person_ID, CRR.Role_ID FROM Data.Employee AS DE JOIN Config.RoleRequests AS CRR ON DE.Person_ID = CRR.Person_ID WHERE CRR.ID = @requestID";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {

				var requestIDParam = new SqlParameter("@requestID", System.Data.SqlDbType.Int);
				requestIDParam.Value = strRequestID;
				cmd.Parameters.Add(requestIDParam);

				cmd.ExecuteNonQuery();

				cmd.Dispose();
				conn.Close();
			}
		}

		[WebMethod]
		public static void btnReject_Click(string strRequestID) {
			try {
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
				conn.Open();
				string qry = "UPDATE Config.RoleRequests SET Status_ID = 3 WHERE ID = @requestID";
				using (SqlCommand cmd = new SqlCommand(qry, conn)) {

					var requestIDParam = new SqlParameter("@requestID", System.Data.SqlDbType.Int);
					requestIDParam.Value = strRequestID;
					cmd.Parameters.Add(requestIDParam);

					cmd.ExecuteNonQuery();

					cmd.Dispose();
					conn.Close();
				}
			} catch (Exception ex) {
				HttpContext.Current.Response.Write(ex.Message);
			}
		}
	}
}