using CState_TeamC_Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Net.Configuration;
using System.Net.Mail;
using System.IO;
using System.Web.Services;

namespace CState_TeamC_Capstone
{
    public partial class initiateIncident : System.Web.UI.Page
    {
        protected List<Department> lstDepartments { get; set; }
        protected List<NearMissType> lstNMType { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lstDepartments = LoadDepartments();
            lstNMType = LoadNearMissType();
            firstLastName.InnerText = ExtensionMethods.GetLastNameFirstName();
        }

        private List<Department> LoadDepartments()
        {
            lstDepartments = new List<Department>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT ID, Department FROM Reference.Department ";

            // Fill in with Departments
             using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                string strID = "";
                string strDepartment = "";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    strID = sdr["ID"].ToString();
                    strDepartment = sdr["Department"].ToString();
                    lstDepartments.Add(new Department(strID, strDepartment));
                }
            }

            return lstDepartments;
        }

        private List<NearMissType> LoadNearMissType()
        {
            lstNMType = new List<NearMissType>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT ID, NearMissType FROM Reference.NearMissType ";

            // Fill in with Near Miss Types
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                string strID = "";
                string strNearMissType = "";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    strID = sdr["ID"].ToString();
                    strNearMissType = sdr["NearMissType"].ToString();
                    lstNMType.Add(new NearMissType(strID, strNearMissType));
                }
            }

            return lstNMType;
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try 
            {
                int intDepartment_ID = Convert.ToInt32(Request.Form["sltDepartment"].ToString());
                int intNearMissType_ID = Convert.ToInt32(Request.Form["sltNMType"].ToString());
                string dteNearMissDate = Convert.ToString(Request.Form["dteIncident"]);
                int intBadgeNumber = Convert.ToInt32(Request.Form["txtBadgeNumber"]);
                string strNearMissSolution = Request.Form["txaSolution"];
                string strNearMiss_ActionTaken = Request.Form["txaActionTaken"];

                string strDepartment = lstDepartments.Find(item => item.strID == Request.Form["sltDepartment"]).strDepartment;
                string strType = lstNMType.Find(item => item.strID == Request.Form["sltNMType"]).strNearMissType;

                string strOperatorName = GetOperatorName(intBadgeNumber);
                
                int intNearMissID = Shared.InsertNearMissRecord(dteNearMissDate, strOperatorName, intDepartment_ID, intNearMissType_ID, strNearMissSolution, strNearMiss_ActionTaken);

                // Get list of EHS members
                List<string> lsttEHSMembers = EHSList();

                // Send EHS Review Email
                SendEHSReviewEmail(intNearMissID, lsttEHSMembers, strDepartment, strType);
                    
			}

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            int NearMissType_ID = Convert.ToInt32(Request.Form["sltNMType"].ToString());
            Response.Redirect("~/typeInstructions.aspx?NearMissType_ID=" + NearMissType_ID.ToString());

        }

        private List<string> EHSList()
        {
            List<string> lsttEHSMembers = new List<string>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT DE.Email FROM Data.Employee AS DE JOIN Config.EmployeeRole AS CER ON DE.Person_ID = CER.Person_ID WHERE CER.Role_ID = 2";
            using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read()) {
                    lsttEHSMembers.Add(sdr["Email"].ToString());
				}

                cmd.Dispose();
                conn.Close();
            }

            return lsttEHSMembers;
        }

        private string GetFirstNameLastName()
        {
            int intUserID = int.Parse(Session["User_ID"].ToString());
            string strfirstnamelastname = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT * FROM Data.Employee WHERE Person_ID = @id";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                var idParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
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
        private string GetOperatorName(int intBadgeNumber)
        {
            string strOperatorName = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT First_Name, Last_Name FROM Data.Employee WHERE Employee_ID =@id";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                var idParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
                idParam.Value = intBadgeNumber;
                cmd.Parameters.Add(idParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read()) {
                    strOperatorName = sdr["Last_Name"].ToString() + ", " + sdr["First_Name"].ToString();
                }

                cmd.Dispose();
                conn.Close();
            }

            return strOperatorName;
        }

        private string GetUserEmailAddress()
        {
            int intUserID = int.Parse(Session["User_ID"].ToString());
            string strUserEmail = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT * FROM Data.Employee WHERE Person_ID = @id";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                var idParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
                idParam.Value = intUserID;
                cmd.Parameters.Add(idParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strUserEmail = sdr["Email"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strUserEmail;
        }
        
       private void SendEHSReviewEmail(int intNearMissID, List<string> lsttEHSMembers, string strDepartment, string strType)
        {
            int intBadgeNumber = Convert.ToInt32(Request.Form["txtBadgeNumber"]);
            string strNearMissSolution = Request.Form["txaSolution"];
            string strNearMiss_ActionTaken = Request.Form["txaActionTaken"];
            
            SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(section.Network.UserName);
       
            foreach (string strEmail in lsttEHSMembers) {
                mailMessage.To.Add(new MailAddress(strEmail));
			}

            string templatePath = HttpRuntime.AppDomainAppPath + "/emailEHSNotificationTemplate.html";
            StreamReader sr = new StreamReader(templatePath);
            string strEmailBody = sr.ReadToEnd();
            sr.Close();

            // Replace the template placeholder variables
            strEmailBody = strEmailBody.Replace("[actionURL]", ConfigurationManager.AppSettings["mainURL"] + "reviewIncident?NearMissID=" + intNearMissID.ToString());
            strEmailBody = strEmailBody.Replace("[mainURL]", ConfigurationManager.AppSettings["mainURL"]);

            strEmailBody = strEmailBody.Replace("[NearMissID]", intNearMissID.ToString());
            strEmailBody = strEmailBody.Replace("[OperatorName]", (GetOperatorName(intBadgeNumber)));
            strEmailBody = strEmailBody.Replace("[Department]", strDepartment);
            strEmailBody = strEmailBody.Replace("[NearMissType]", strType);
            strEmailBody = strEmailBody.Replace("[NearMissDetails]", strNearMissSolution);
            strEmailBody = strEmailBody.Replace("[NearMissActionTaken]", strNearMiss_ActionTaken);
 
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = strEmailBody;
            mailMessage.Subject = "Near Miss Incident Requiring Review";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);

        }

        [WebMethod]
        public static bool CheckValidID(string strBadgeNumber) {
            bool blnValid = false;

            try {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                conn.Open();
                string qry = "SELECT * FROM Data.Employee WHERE Employee_ID = @id";
                using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                    var idParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
                    idParam.Value = strBadgeNumber;
                    cmd.Parameters.Add(idParam);

                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read()) {
                        blnValid = true;
                    }
                    cmd.Dispose();
                    conn.Close();
                }
            } catch (Exception ex) {
                HttpContext.Current.Response.Write(ex.Message);
            }

            return blnValid;
        }
    }
}

