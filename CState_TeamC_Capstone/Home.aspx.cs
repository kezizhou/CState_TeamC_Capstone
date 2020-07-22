using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Linq;

namespace CState_TeamC_Capstone {
	public partial class Home : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			// Days since last incident
			lastIncident.InnerText = DaysSinceLastIncident().ToString();

			if (int.Parse(lastIncident.InnerText) == 1) {
				lastIncidentDescription.InnerText = "day ago";
			}
		}

		[WebMethod]
		public static List<object> GetNearMissTypesChartData() {
			List<object> lstChartData = new List<object>();
			lstChartData.Add(new object[] {
				"NearMissType",
				"TotalIncidents"
			});

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT T.NearMissType, COUNT(T.ID) TotalIncidents FROM Data.NearMissRecord AS R JOIN Reference.NearMissType AS T ON R.NearMissType_ID = T.ID GROUP BY T.NearMissType";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read()) {
					lstChartData.Add(new object[] {
						sdr["NearMissType"], sdr["TotalIncidents"]
					});
				}
				cmd.Dispose();
				conn.Close();
			}

			return lstChartData;
		}

		[WebMethod]
		public static List<object> GetInjurySeverityChartData() {
			List<object> lstChartData = new List<object>();
			DataTable dt = new DataTable();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT D.Department, SL.SeverityType, ISNULL(COUNT(NMRL.ID),0) AS 'TotalIncidents' " +
						 "FROM Data.NearMiss_ReviewLog AS NMRL JOIN Reference.SeverityofInjury AS SL ON NMRL.Severity_ID = SL.ID " +
						 "JOIN Data.NearMissRecord AS NMR ON NMRL.NearMiss_ID = NMR.ID " +
						 "JOIN Reference.Department AS D ON NMR.Department_ID = D.ID " +
						 "GROUP BY D.Department, SL.SeverityType";
			using (SqlDataAdapter sda = new SqlDataAdapter(qry, conn)) {
				sda.Fill(dt);

				sda.Dispose();
				conn.Close();
			}

			// Severity Types
			List<string> lstSeverityTypes = (from p in dt.AsEnumerable()
										  select p.Field<string>("SeverityType")).Distinct().ToList();

			// Label for severity type first position
			lstSeverityTypes.Insert(0, "SeverityType");

			// Add departments array to chart array
			lstChartData.Add(lstSeverityTypes.ToArray());

			// Get distinct departments
			List<string> lstDepartments = (from p in dt.AsEnumerable()
								   select p.Field<string>("Department")).Distinct().ToList();

			// Loop through departments
			foreach (string department in lstDepartments) {
				// Get the total incidents for each department for the month
				List<object> lstTotals = (from p in dt.AsEnumerable()
										  where p.Field<string>("Department") == department
										  select p.Field<int>("TotalIncidents")).Cast<object>().ToList();

				// Insert departments value as label in first position
				lstTotals.Insert(0, department.ToString());

				// Add departments array to chart array
				lstChartData.Add(lstTotals.ToArray());
			}

			return lstChartData;
		}


		public static int DaysSinceLastIncident() {
			int intDays = 0;

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT MIN( DATEDIFF(day, NearMissDate, GETDATE()) ) AS 'LastIncident' FROM Data.NearMissRecord";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				SqlDataReader sdr = cmd.ExecuteReader();
				if (sdr.Read()) {
					try {
						intDays = int.Parse(sdr["LastIncident"].ToString());
					} catch (Exception ex) {
						intDays = 0;
					}
				}
				cmd.Dispose();
				conn.Close();
			}

			return intDays;
		}
	}
}