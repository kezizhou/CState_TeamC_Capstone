using System;
using System.Collections.Generic;
using CState_TeamC_Capstone.DomainObjects;
using CState_TeamC_Capstone.Classes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.IO;

namespace CState_TeamC_Capstone
{
    public partial class reviewIncident : System.Web.UI.Page {
        public List<ReviewIncidentPageTable> results;
        public List<Filters> nearMissReportID;
        public List<Filters> assignTo;
        public List<Filters> severity;
        public List<Filters> risk;
        protected void Page_Load(object sender, EventArgs e) {
            messageDiv.Style["display"] = "none";
            results = Shared.GetReviewIncidentPageQuery();
            assignTo = Shared.GetAssignIncidentReviewPage();
            severity = Shared.GetSeverityFilter();
            risk = Shared.GetRiskFilter();
            nearMissReportID = Shared.GetNearMissRecordIDReviewPage();
            GetUserName();
            userFullName.InnerText = ExtensionMethods.GetLastNameFirstName();

            if (!Page.IsPostBack) {
                CreateDropDown();

                if (Request.QueryString["NearMissID"] != null) {
                    sltNearMissReportID.SelectedValue = Request.QueryString["NearMissID"].ToString();
                    if (sltNearMissReportID.SelectedValue == "-1") {
                        // ID no longer found
                        messageDiv.Style["display"] = "block";
                    } else {
                        Filter(sender, e);
                    }
                } else {
                    Filter(sender, e);
                }
			}
        }
        public void Filter(object sender, EventArgs e) {
            var selectedID = sltNearMissReportID.SelectedItem;
            if (int.Parse(selectedID.Value) == -1) {
                results = new List<ReviewIncidentPageTable>();
                return;
            }
            results = Shared.GetReviewIncidentPageQuery(selectedID.ToString());
        }
        public void InsertReviewLog(object sender, EventArgs e) {
            var assignIncidentSelection = Request["sltAssignIncident"];
            var severitySelection = Request["sltSeverityLevel"];
            var riskSelection = Request["sltRiskLevel"];
            var nearMissReportID = sltNearMissReportID.SelectedValue;
            var user = GetUserName();
            var comments = Request["txaComments"];
            Shared.InsertReviewLogStatement(nearMissReportID, assignIncidentSelection, severitySelection, riskSelection, user, comments, DateTime.Now.Date.ToString());

            string strSeverity = GetSeverityFromID(severitySelection);
            string strRisk = GetRiskFromID(riskSelection);
            SendAssigneeEmail(nearMissReportID, assignIncidentSelection, strSeverity, strRisk, comments);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", "ShowPopup();", true);
        }
        public void CreateDropDown() {
            sltNearMissReportID.DataTextField = "Value";
            sltNearMissReportID.DataValueField = "Id";
            sltNearMissReportID.DataBind();

            sltNearMissReportID.Items.Insert(0, new ListItem("Select Near Miss Incident Report", "-1"));
            var rownumber = 1;
            foreach (var x in nearMissReportID) {
                sltNearMissReportID.Items.Insert(rownumber, new ListItem(x.Description, x.ID.ToString()));
                rownumber++;
            }
        }

        private string GetUserName() {
            int intUserID = int.Parse(Session["User_ID"].ToString());
            string strUserName = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT * FROM Data.Employee WHERE Person_ID = @id";
            using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                var idParam = new SqlParameter("@id", System.Data.SqlDbType.VarChar);
                idParam.Value = intUserID;
                cmd.Parameters.Add(idParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strUserName = sdr["Last_Name"].ToString() + ", " + sdr["First_Name"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strUserName;
        }
        private void SendAssigneeEmail(string strNearMissID, string strAssigneeName, string strSeverity, string strRisk, string strComments) {
            string strEmail = GetEmailFromName(strAssigneeName);
            ReviewIncidentPageTable incident = GetIncidentData(strNearMissID);

            SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(section.Network.UserName);
            mailMessage.To.Add(new MailAddress(strEmail));

            string templatePath = HttpRuntime.AppDomainAppPath + "/emailAssigneeNotificationTemplate.html";
            StreamReader sr = new StreamReader(templatePath);
            string strEmailBody = sr.ReadToEnd();
            sr.Close();

            // Replace the template placeholder variables
            strEmailBody = strEmailBody.Replace("[actionURL]", ConfigurationManager.AppSettings["mainURL"] + "updateIncident?NearMissID=" + strNearMissID);
            strEmailBody = strEmailBody.Replace("[mainURL]", ConfigurationManager.AppSettings["mainURL"]);

            string strFirstName = strAssigneeName.Substring(strAssigneeName.LastIndexOf(',') + 2);

            strEmailBody = strEmailBody.Replace("[strUsername]", strFirstName);
            strEmailBody = strEmailBody.Replace("[NearMissID]", strNearMissID);
            strEmailBody = strEmailBody.Replace("[OperatorName]", incident.OperatorName);
            strEmailBody = strEmailBody.Replace("[Department]", incident.Department);
            strEmailBody = strEmailBody.Replace("[NearMissType]", incident.NearMissType);
            strEmailBody = strEmailBody.Replace("[Severity]", strSeverity);
            strEmailBody = strEmailBody.Replace("[Risk]", strRisk);
            strEmailBody = strEmailBody.Replace("[NearMissDetails]", incident.NearMiss_Solution);
            strEmailBody = strEmailBody.Replace("[NearMissActionTaken]", incident.NearMiss_ActionTaken);
            strEmailBody = strEmailBody.Replace("[EHSComments]", strComments);

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = strEmailBody;
            mailMessage.Subject = "Near Miss Incident Requiring Review";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);

        }

        private ReviewIncidentPageTable GetIncidentData(string strNearMissID) {
            ReviewIncidentPageTable incident = new ReviewIncidentPageTable();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT DNMR.ID, DNMR.OperatorName, RD.Department, RNMT.NearMissType, DNMR.NearMiss_Solution, DNMR.NearMiss_ActionTaken FROM Data.NearMissRecord AS DNMR JOIN Reference.Department AS RD ON DNMR.Department_ID = RD.ID JOIN Reference.NearMissType AS RNMT ON DNMR.NearMissType_ID = RNMT.ID WHERE DNMR.ID = @id";
            using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                var fNameParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
                fNameParam.Value = int.Parse(strNearMissID);
                cmd.Parameters.Add(fNameParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                incident.OperatorName = sdr["OperatorName"].ToString();
                incident.Department = sdr["Department"].ToString();
                incident.NearMissType = sdr["NearMissType"].ToString();
                incident.NearMiss_Solution = sdr["NearMiss_Solution"].ToString();
                incident.NearMiss_ActionTaken = sdr["NearMiss_ActionTaken"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return incident;
		}

        private string GetEmailFromName(string strAssigneeName) {
            string strEmail = "";

            string strFirstName = strAssigneeName.Substring(strAssigneeName.LastIndexOf(',') + 2);
            string strLastName = strAssigneeName.Split(',')[0];

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT Email FROM Data.Employee WHERE First_Name = @firstname AND Last_Name = @lastname";
            using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                var fNameParam = new SqlParameter("@firstname", System.Data.SqlDbType.VarChar);
                fNameParam.Value = strFirstName;
                cmd.Parameters.Add(fNameParam);

                var lNameParam = new SqlParameter("@lastname", System.Data.SqlDbType.VarChar);
                lNameParam.Value = strLastName;
                cmd.Parameters.Add(lNameParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strEmail = sdr["Email"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strEmail;
		}

        private string GetSeverityFromID(string strSeverityID) {
            string strSeverity = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT SeverityType FROM Reference.SeverityofInjury WHERE ID = @id";
            using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                var idParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
                idParam.Value = int.Parse(strSeverityID);
                cmd.Parameters.Add(idParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strSeverity = sdr["SeverityType"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strSeverity;
		}

        private string GetRiskFromID(string strRiskID) {
            string strRisk = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT RiskType FROM Reference.RiskLevel WHERE ID = @id";
            using (SqlCommand cmd = new SqlCommand(qry, conn)) {
                var idParam = new SqlParameter("@id", System.Data.SqlDbType.Int);
                idParam.Value = int.Parse(strRiskID);
                cmd.Parameters.Add(idParam);

                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strRisk = sdr["RiskType"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strRisk;
		}
    }
}