using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Linq;
using System.Web;

namespace CState_TeamC_Capstone {
	public partial class Home : System.Web.UI.Page {

		static string strStartDate;
		static string strEndDate;

		protected string dteStartInput { get; set; }
		protected string dteEndInput { get; set; }

		protected void Page_Load(object sender, EventArgs e) {
    
			try {
				// Welcome name
				firstnamelastname.InnerText = GetFirstNameLastName();
				
				// Days since last incident
				int intDays = DaysSinceLastIncident();

				if (intDays == -1) {
					lastIncident.InnerText = "";
					daysAgo.InnerText = "";
					lastIncidentHeading.InnerText = "No incidents reported";
				} else {
					lastIncident.InnerText = intDays.ToString();

					if (intDays == 1) {
						daysAgo.InnerText = "day ago";
					}
				}

				// Reset start end date
				strStartDate = DateTime.Now.ToString();
				strEndDate = DateTime.Now.ToString();
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}

		[WebMethod]
		public static List<object> GetNearMissTypesChartData() {
			List<object> lstChartData = new List<object>();

			try {
				lstChartData.Add(new object[] {
					"NearMissType",
					"TotalIncidents"
				});

				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
				conn.Open();
				string qry = "SELECT T.NearMissType, COUNT(R.ID) TotalIncidents FROM Data.NearMissRecord AS R RIGHT JOIN Reference.NearMissType AS T ON R.NearMissType_ID = T.ID GROUP BY T.NearMissType";
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
			} catch (Exception ex) {
				HttpContext.Current.Response.Write(ex.Message);
			}

			return lstChartData;
		}

		[WebMethod]
		public static List<object> GetInjurySeverityChartData() {
			List<object> lstChartData = new List<object>();
			DataTable dt = new DataTable();
			string qry = "";

			try {
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
				conn.Open();

				if (DateTime.Parse(strStartDate).Date == DateTime.Now.Date && DateTime.Parse(strEndDate).Date == DateTime.Now.Date) {
					// Date filter not changed, show all data
					qry = "SELECT Department, SeverityType_Low, SeverityType_Medium, SeverityType_High, RiskLevel_Low, RiskLevel_Medium, RiskLevel_High, TotalIncidents FROM VW.GetDepartmentChartData ORDER BY TotalIncidents DESC, SeverityType_High DESC, RiskLevel_High DESC, SeverityType_Medium DESC, RiskLevel_Medium DESC, SeverityType_Low DESC, RiskLevel_Low DESC";
					using (SqlDataAdapter sda = new SqlDataAdapter(qry, conn)) {
						sda.Fill(dt);

						sda.Dispose();
						conn.Close();
					}
				} else {
					// Date changed with filters
					qry = "EXEC SP.GetIncidentsBetweenDates @StartDate = @dteStart, @EndDate = @dteEnd";
					using (SqlDataAdapter sda = new SqlDataAdapter(qry, conn)) {
						var startDateParam = new SqlParameter("@dteStart", System.Data.SqlDbType.DateTime);
						startDateParam.Value = strStartDate;
						sda.SelectCommand.Parameters.Add(startDateParam);

						var endDateParam = new SqlParameter("@dteEnd", System.Data.SqlDbType.DateTime);
						endDateParam.Value = strEndDate;
						sda.SelectCommand.Parameters.Add(endDateParam);

						sda.Fill(dt);

						sda.Dispose();
						conn.Close();
					}
				}

				// Severity and Risk Types
				List<string> lstSeverityRiskTypes = new List<string>();

				foreach (string strSeverity in GetSeverityTypes()) {
					lstSeverityRiskTypes.Add(strSeverity);
				}
				foreach (string strRisk in GetRiskLevels()) {
					lstSeverityRiskTypes.Add(strRisk);
				}

				// Label for departments first position
				lstSeverityRiskTypes.Insert(0, "Departments");

				// Add severity risk types array to chart array
				lstChartData.Add(lstSeverityRiskTypes.ToArray());

				// Get distinct departments
				List<string> lstDepartments = (from p in dt.AsEnumerable()
									   select p.Field<string>("Department")).Distinct().ToList();

				// Loop through departments
				foreach (string department in lstDepartments) {
					// Get the total incidents for each severity for this department
					// Severity Low
					List<object> lstTotals = (from p in dt.AsEnumerable()
											  where p.Field<string>("Department") == department
											  select p.Field<int>("SeverityType_Low")).Cast<object>().ToList();

					// Insert departments value as label in first position
					lstTotals.Insert(0, department.ToString());

					// Severity Medium
					lstTotals.Add((from p in dt.AsEnumerable()
								   where p.Field<string>("Department") == department
								   select p.Field<int>("SeverityType_Medium")).Cast<int>().ToList()[0]);

					// Severity High
					lstTotals.Add((from p in dt.AsEnumerable()
								   where p.Field<string>("Department") == department
								   select p.Field<int>("SeverityType_High")).Cast<int>().ToList()[0]);

					// Risk Low
					lstTotals.Add((from p in dt.AsEnumerable()
								   where p.Field<string>("Department") == department
								   select p.Field<int>("RiskLevel_Low")).Cast<int>().ToList()[0]);

					// Risk Medium
					lstTotals.Add( (from p in dt.AsEnumerable()
									where p.Field<string>("Department") == department
									select p.Field<int>("RiskLevel_Medium")).Cast<int>().ToList()[0] );

					// Risk High
					lstTotals.Add((from p in dt.AsEnumerable()
								   where p.Field<string>("Department") == department
								   select p.Field<int>("RiskLevel_High")).Cast<int>().ToList()[0]);

					// Add totals to chart data array if the department has data
					if ((int)lstTotals[1] != 0 || (int)lstTotals[2] != 0 || (int)lstTotals[3] != 0 || (int)lstTotals[4] != 0 || (int)lstTotals[5] != 0 || (int)lstTotals[6] != 0) {
						lstChartData.Add(lstTotals.ToArray());
					}
				}
			} catch (Exception ex) {
				HttpContext.Current.Response.Write(ex.Message);
			}

			return lstChartData;
		}

		public static List<string> GetSeverityTypes() {
			List<string> lstSeverityTypes = new List<string>();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT * FROM Reference.SeverityofInjury";
			using (SqlCommand cmd = new SqlCommand(qry, conn))
			{
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					lstSeverityTypes.Add("Severity " + sdr["SeverityType"].ToString());
				}
				cmd.Dispose();
				conn.Close();
			}

			return lstSeverityTypes;
		}

		public static List<string> GetRiskLevels() {
			List<string> lstRiskyLevels = new List<string>();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT * FROM Reference.RiskLevel";
			using (SqlCommand cmd = new SqlCommand(qry, conn)) {
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read()) {
					lstRiskyLevels.Add("Risk " + sdr["RiskType"].ToString());
				}
				cmd.Dispose();
				conn.Close();
			}

			return lstRiskyLevels;
		}

		[WebMethod]
		public static List<object> GetDepartmentNearMissTypesChartData() {
			List<object> lstChartData = new List<object>();
			DataTable dt = new DataTable();
			string qry = "";

			try {
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
				conn.Open();
				if (DateTime.Parse(strStartDate).Date == DateTime.Now.Date && DateTime.Parse(strEndDate).Date == DateTime.Now.Date) {
					// Date filter not changed, show all data
					qry = "SELECT Department, Slip_Trip_Fall, ElectricalSafety, ChemicalSafety, SafetyMachine_Guarding, SafetyMaterial_Handling, SafetyPPE, SafetyCrane, SafetyHousekeeping, SafetyWeather, TotalIncidents FROM VW.GetDepartmentChartData ORDER BY TotalIncidents DESC";

					using (SqlDataAdapter sda = new SqlDataAdapter(qry, conn)) {
						sda.Fill(dt);

						sda.Dispose();
						conn.Close();
					}

				} else {
					// Date changed with filters
					qry = "EXEC SP.GetIncidentsBetweenDates @StartDate = @StartDate, @EndDate = @EndDate";
					using (SqlDataAdapter sda = new SqlDataAdapter(qry, conn)) {
						var startDateParam = new SqlParameter("@StartDate", System.Data.SqlDbType.DateTime);
						startDateParam.Value = strStartDate;
						sda.SelectCommand.Parameters.Add(startDateParam);

						var endDateParam = new SqlParameter("@EndDate", System.Data.SqlDbType.DateTime);
						endDateParam.Value = strEndDate;
						sda.SelectCommand.Parameters.Add(endDateParam);

						sda.Fill(dt);

						sda.Dispose();
						conn.Close();
					}
				}


				// Near Miss Types
				List<string> lstNearMissTypes = GetNearMissTypes();

				// Label for departments first position
				lstNearMissTypes.Insert(0, "Departments");

				// Add near miss types array to chart array
				lstChartData.Add(lstNearMissTypes.ToArray());

				// Get distinct departments
				List<string> lstDepartments = (from p in dt.AsEnumerable()
											   select p.Field<string>("Department")).Distinct().ToList();

				// Loop through departments
				foreach (string department in lstDepartments)
				{
					// Get the total incidents for each near miss type for this department
					// Slip, trip, fall
					List<object> lstTotals = (from p in dt.AsEnumerable()
											  where p.Field<string>("Department") == department
											  select p.Field<int>("Slip_Trip_Fall")).Cast<object>().ToList();

					// Insert departments value as label in first position
					lstTotals.Insert(0, department.ToString());

					// Electrical Safety
					List<int> lstElectricalSafety = (from p in dt.AsEnumerable()
												where p.Field<string>("Department") == department
												select p.Field<int>("ElectricalSafety")).Cast<int>().ToList();
					lstTotals.Add(lstElectricalSafety[0]);

					// Chemical Safety
					List<int> lstChemicalSafety = (from p in dt.AsEnumerable()
											  where p.Field<string>("Department") == department
											  select p.Field<int>("ChemicalSafety")).Cast<int>().ToList();
					lstTotals.Add(lstChemicalSafety[0]);

					// Safety Machine Guarding
					List<int> lstMachineGuarding = (from p in dt.AsEnumerable()
											  where p.Field<string>("Department") == department
											  select p.Field<int>("SafetyMachine_Guarding")).Cast<int>().ToList();
					lstTotals.Add(lstMachineGuarding[0]);

					// Safety Material Handling
					List<int> lstMaterialHandling = (from p in dt.AsEnumerable()
											  where p.Field<string>("Department") == department
											  select p.Field<int>("SafetyMaterial_Handling")).Cast<int>().ToList();
					lstTotals.Add(lstMaterialHandling[0]);

					// Safety PPE
					List<int> lstPPE = (from p in dt.AsEnumerable()
											  where p.Field<string>("Department") == department
											  select p.Field<int>("SafetyPPE")).Cast<int>().ToList();
					lstTotals.Add(lstPPE[0]);

					// Safety Crane
					List<int> lstCrane = (from p in dt.AsEnumerable()
										where p.Field<string>("Department") == department
										select p.Field<int>("SafetyCrane")).Cast<int>().ToList();
					lstTotals.Add(lstCrane[0]);

					// Safety Housekeeping
					List<int> lstHousekeeping = (from p in dt.AsEnumerable()
										where p.Field<string>("Department") == department
										select p.Field<int>("SafetyHousekeeping")).Cast<int>().ToList();
					lstTotals.Add(lstHousekeeping[0]);

					// Safety Weather
					List<int> lstWeather = (from p in dt.AsEnumerable()
										where p.Field<string>("Department") == department
										select p.Field<int>("SafetyWeather")).Cast<int>().ToList();
					lstTotals.Add(lstWeather[0]);

					// Add totals to chart data array if there is data
					if ((int)lstTotals[1] != 0 || (int)lstTotals[2] != 0 || (int)lstTotals[3] != 0 || (int)lstTotals[4] != 0 || (int)lstTotals[5] != 0 || (int)lstTotals[6] != 0 || (int)lstTotals[7] != 0 || (int)lstTotals[8] != 0 || (int)lstTotals[9] != 0) {
						lstChartData.Add(lstTotals.ToArray());
					}
				}
			} catch (Exception ex) {
				HttpContext.Current.Response.Write(ex.Message);
			}

			return lstChartData;
		}
		public static List<string> GetNearMissTypes() {
			List<string> lstNearMissTypes = new List<string>();

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT * FROM Reference.NearMissType";
			using (SqlCommand cmd = new SqlCommand(qry, conn))
			{
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					lstNearMissTypes.Add(sdr["NearMissType"].ToString());
				}
				cmd.Dispose();
				conn.Close();
			}

			return lstNearMissTypes;
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
						// No data
						intDays = -1;
					}
				}
				cmd.Dispose();
				conn.Close();
			}

			return intDays;
		}

		protected void btnFilterDates_Click(object sender, EventArgs e) {
			try {
				this.dteStartInput = Request["dteStart"];
				this.dteEndInput = Request["dteEnd"];

				strStartDate = Request["dteStart"] + " 00:00:00.000";
				strEndDate = Request["dteEnd"] + " 23:59:59.997";
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}
    
    private string GetFirstNameLastName() {
        int intUserID = int.Parse(Session["User_ID"].ToString());
        string strfirstnamelastname = "";

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
        conn.Open();
        string qry = "SELECT * FROM Data.Employee WHERE Person_ID = @id";
        using (SqlCommand cmd = new SqlCommand(qry, conn))
        {
            var idParam = new SqlParameter("@id", System.Data.SqlDbType.VarChar);
            idParam.Value = intUserID;
            cmd.Parameters.Add(idParam);

            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();

            strfirstnamelastname = sdr["Last_Name"].ToString() + ", " + sdr["First_Name"].ToString();

            cmd.Dispose();
            conn.Close();
        }

        return strfirstnamelastname;
    }

		protected void btnClear_Click(object sender, EventArgs e) {
			try {
				Page.ClientScript.RegisterStartupScript(this.GetType(), "ResetForm", "resetForm()", true);
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}
    
  }
}