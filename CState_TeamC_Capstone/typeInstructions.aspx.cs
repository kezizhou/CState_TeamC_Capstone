using System;
using System.Collections.Generic;
using CState_TeamC_Capstone.Classes;
using System.Configuration;
using System.Data.SqlClient;


namespace CState_TeamC_Capstone {
	public partial class typeInstructions : System.Web.UI.Page {
        protected List<NearMissTypeInstructions> lstNMTypeInstructions { get; set; }
        protected void Page_Load(object sender, EventArgs e) {

          string strNearMissType_ID = Request.QueryString["NearMissType_ID"];
        }

        private List<NearMissTypeInstructions> LoadNearMissTypeInstructions()
        {
            //string strNearMissType_ID = Request.QueryString["NearMissType_ID"];
            lstNMTypeInstructions = new List<NearMissTypeInstructions>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();

            string qry = "SELECT NearMissType_ID, NMT_Type, I_Ins FROM [VW].[Config_TypeInstructions] WHERE NearMissType_ID = @NearMissType_ID ";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                string strNearMissType_ID = "";
                string strNMT_Type = "";
                string strI_Ins = "";

                var nmTypeIDParam = new SqlParameter("@NearMissType_ID", System.Data.SqlDbType.Int);
                nmTypeIDParam.Value = Request.QueryString["NearMissType_ID"];
                cmd.Parameters.Add(nmTypeIDParam);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    strNearMissType_ID = sdr["NearMissType_ID"].ToString();
                    strNMT_Type = sdr["NMT_Type"].ToString();
                    strI_Ins = sdr["I_Ins"].ToString();

                    // Add user to list
                    lstNMTypeInstructions.Add(new NearMissTypeInstructions(strNearMissType_ID, strNMT_Type, strI_Ins));
                }

                cmd.Dispose();
                conn.Close();
            }

            return lstNMTypeInstructions;
        }
    }
}