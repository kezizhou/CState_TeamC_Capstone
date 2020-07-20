using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
	public partial class Home : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		public static List<object> GetNearMissTypesChartData() {
			List<object> lstChartData = new List<object>() {
				"NearMissType",
				"TotalIncidents"
			};

			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
			conn.Open();
			string qry = "SELECT T.NearMissType, COUNT(T.ID) TotalIncidents FROM Data.NearMissRecord AS R JOIN Reference.NearMissType AS T ON R.NearMiss_ID = T.ID GROUP BY T.NearMissType";
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
	}
}