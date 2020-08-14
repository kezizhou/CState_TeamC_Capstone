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
            string strNearMissID = Request.QueryString["NearMissID"];



            if (Request.QueryString["NearMissType_ID"] != null)
            {
                nearmissid.InnerText = Shared.GetTopNearMissRecord();
                nearmisstype.InnerText = GetNearMissType();
                try
                {

                    lstNMTypeInstructions = LoadNearMissTypeInstructions();
                }
            
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else {
                Response.Redirect("reset.aspx?type=typeInstructionsError");
            }
        }

        private List<NearMissTypeInstructions> LoadNearMissTypeInstructions()
        {
            lstNMTypeInstructions = new List<NearMissTypeInstructions>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();

            string qry = "SELECT  NMT_Type, I_Ins FROM [VW].[Config_TypeInstructions] WHERE NearMissType_ID = @NearMissType_ID ";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                //string strNearMissType_ID = "";
                string strNMT_Type = "";
                string strI_Ins = "";

                var nmTypeIDParam = new SqlParameter("@NearMissType_ID", System.Data.SqlDbType.Int);
                nmTypeIDParam.Value = Request.QueryString["NearMissType_ID"];
                cmd.Parameters.Add(nmTypeIDParam);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    strNMT_Type = sdr["NMT_Type"].ToString();
                    strI_Ins = sdr["I_Ins"].ToString();

                    // Add user to list
                   lstNMTypeInstructions.Add(new NearMissTypeInstructions(strNMT_Type, strI_Ins));
                }

                cmd.Dispose();
                conn.Close();
            }

            return lstNMTypeInstructions;
        }

        private string GetNearMissType()
        {
            string strNearMissType_ID = Request.QueryString["NearMissType_ID"];
          
            string strnearmisstype = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT * FROM Reference.NearMissType WHERE ID = @NearMissType_ID";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                var NearMissType_IDParam = new SqlParameter("@NearMissType_ID", System.Data.SqlDbType.Int);
                NearMissType_IDParam.Value = strNearMissType_ID;
                cmd.Parameters.Add(NearMissType_IDParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strnearmisstype = sdr["NearMissType"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strnearmisstype;
        }
    }
}