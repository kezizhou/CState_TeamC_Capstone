using System.Configuration;
using System.Data.SqlClient;

namespace CState_TeamC_Capstone.Classes {
	public class ExtensionMethods {
        public static string GetLastNameFirstName() {
            int intUserID = int.Parse(System.Web.HttpContext.Current.Session["User_ID"].ToString());
            string strName = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT * FROM Data.Employee WHERE Person_ID = @id";
            using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                var idParam = new SqlParameter("@id", System.Data.SqlDbType.VarChar);
                idParam.Value = intUserID;
                cmd.Parameters.Add(idParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strName = sdr["Last_Name"].ToString() + ", " + sdr["First_Name"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strName;
        }
    }
}