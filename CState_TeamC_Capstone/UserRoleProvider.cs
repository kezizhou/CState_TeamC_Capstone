using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Security;

namespace CState_TeamC_Capstone {
	public class UserRoleProvider : RoleProvider {
		public override string ApplicationName {
			get {
				throw new NotImplementedException();
			}

			set {
				throw new NotImplementedException();
			}
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames) {
			throw new NotImplementedException();
		}

		public override void CreateRole(string roleName) {
			throw new NotImplementedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) {
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles() {
			throw new NotImplementedException();
		}

		public override string[] GetRolesForUser(string strUsername) {
			List<string> lstRoles = new List<string>();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT R.Name FROM Config.EmployeeRole AS ER JOIN Data.Employee AS E ON ER.Person_ID = E.Person_ID JOIN Reference.Role AS R ON ER.Role_ID = R.ID WHERE E.Username = @username";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				var usernameParam = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
				usernameParam.Value = strUsername;
				cmd.Parameters.Add(usernameParam);

				SqlDataReader sdr = cmd.ExecuteReader();

				while (sdr.Read()) {
					for (int i = 0; i < sdr.FieldCount; i++) {
						lstRoles.Add(sdr.GetValue(i).ToString());
					}
				}

				cmd.Dispose();
				conn.Close();
			}

			string[] strRoles = new string[lstRoles.Count];
			for (int i = 0; i <  lstRoles.Count; i++) {
				strRoles[i] = lstRoles[i];
			}

			return strRoles;
		}

		public override string[] GetUsersInRole(string roleName) {
			throw new NotImplementedException();
		}

		public override bool IsUserInRole(string strUsername, string strRoleName) {
			string[] astrRoles = GetRolesForUser(strUsername);
			foreach (string strRole in astrRoles) {
				if (strRole.Equals(strRoleName)) {
					return true;
				}
			}
			return false;
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) {
			throw new NotImplementedException();
		}

		public override bool RoleExists(string strRoleName) {
			bool blnRoleExists = false;

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT * FROM Reference.Role WHERE R.Name = @rolename";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				var roleParam = new SqlParameter("@rolename", System.Data.SqlDbType.VarChar);
				roleParam.Value = strRoleName;
				cmd.Parameters.Add(roleParam);

				SqlDataReader sdr = cmd.ExecuteReader();

				if (sdr.Read()) {
					blnRoleExists = true;
				}

				cmd.Dispose();
				conn.Close();

				return blnRoleExists;
			}
		}
	}
}