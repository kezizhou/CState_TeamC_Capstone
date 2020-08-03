using System;
using System.Collections.Generic;
using CState_TeamC_Capstone.Classes;
using System.Configuration;
using System.Data.SqlClient;


namespace CState_TeamC_Capstone {
	public partial class typeInstructions : System.Web.UI.Page {
        protected List<NearMissTypeInstructions> LSTNMTypeInstructions { get; set; }
        protected void Page_Load(object sender, EventArgs e) {

          string strNearMissType_ID = Request.QueryString["intNearMissType_ID"];
           // string strNearMissType_ID = (Request.Form["intNearMissType_ID"].ToString());
        }

        private List<NearMissTypeInstructions> LoadNearMissTypeInstructions()
        {
            LSTNMTypeInstructions = new List<NearMissTypeInstructions>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT NMT_Type, I_Ins FROM [VW].[Config_TypeInstructions]";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                string strNearMissType_ID = "";
                string strNMT_Type = "";
                //string strInstruction_ID = "";
                string strI_Ins = "";

                var nmTypeInstParam = new SqlParameter("@NearMissType_ID", System.Data.SqlDbType.Int);
                nmTypeInstParam.Value = Session["NearMissType_ID"];
                cmd.Parameters.Add(nmTypeInstParam);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    strNearMissType_ID = sdr["NearMissType_ID"].ToString();
                    strNMT_Type = sdr["NMT_Type"].ToString();
                    //strInstruction_ID = sdr["Instruction_ID"].ToString();
                    strI_Ins = sdr["I_Ins"].ToString();

                    // Add user to list
                    LSTNMTypeInstructions.Add(new NearMissTypeInstructions(strNMT_Type, strI_Ins));
                }

                cmd.Dispose();
                conn.Close();
            }

            return LSTNMTypeInstructions;
        }
    }
}