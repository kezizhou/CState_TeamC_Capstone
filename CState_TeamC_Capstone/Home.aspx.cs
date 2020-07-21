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
		public static List<object> GetInjuryRisksChartData() {
			List<object> lstChartDate = new List<object>();
			DataTable dt = new DataTable();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT T.NearMissType, DATEPART(Month, NMR.NearMissDate) AS 'Months' FROM Data.NearMissRecord AS NMR JOIN Reference.Department AS D ON NMR.Department_ID = D.ID JOIN Reference.RiskLevel AS RL ON NMR.Risk_ID = RL.ID GROUP BY Months";
			using (SqlDataAdapter sda = new SqlDataAdapter(qry, conn)) {
				sda.Fill(dt);

				sda.Dispose();
				conn.Close();
			}

			// Departments
			List<string> lstDepartments = (from p in dt.AsEnumerable()
										  select p.Field<string>("Department")).Distinct().ToList();

			// Label for 

			return lstChartDate;
		}


		public static int DaysSinceLastIncident() {
			int intDays = 0;

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT MIN( DATEDIFF(day,NearMissDate, GETDATE()) ) AS 'LastIncident' FROM Data.NearMissRecord";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				SqlDataReader sdr = cmd.ExecuteReader();
				if (sdr.Read()) {
					intDays = int.Parse(sdr["LastIncident"].ToString());
				}
				cmd.Dispose();
				conn.Close();
			}

			return intDays;
		}
	}
}