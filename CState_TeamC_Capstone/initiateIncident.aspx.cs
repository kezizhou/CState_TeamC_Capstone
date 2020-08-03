using CState_TeamC_Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Net.Configuration;
using System.Net.Mail;
using System.IO;
using System.Data;

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
            firstnamelastname.InnerText = GetFirstNameLastName();
        }


        private List<Department> LoadDepartments()
        {
            lstDepartments = new List<Department>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT ID, Department FROM Reference.Department ";

            // Fill in with user's existing roles
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

            // Fill in with user's existing roles
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
            int intDepartment_ID = int.Parse(Request.Form["sltDepartment"].ToString());
            int intNearMissType_ID = int.Parse(Request.Form["sltNMType"].ToString());
            string strDepartment = (Request.Form["sltDepartment"].ToString());
            string strNearMissType = (Request.Form["sltNMType"].ToString());

            try
            {
                string dteNearMissDate = Convert.ToString(Request.Form["dteIncident"]);
                int intBadgeNumber = Convert.ToInt32(Request.Form["txtBadgeNumber"]);
                string strBadgeNumber = Request.Form["txtBadgeNumber"];
                string strNearMissSolution = Request.Form["txaSolution"];
                string strNearMiss_ActionTaken = Request.Form["txaActionTaken"];
                string strOperatorName = "";
                //string qry = "";
               // string strEmail = "";
                string lblMessage = Request.Form["lblMessage"];
                //string strID;

                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                //conn.Open();
                // Shared.InsertNearMissRecord(dteNearMissDate, strOperatorName, intDepartment_ID, intNearMissType_ID, strNearMissSolution, strNearMiss_ActionTaken);

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertNearMissRecord";

                cmd.Parameters.Add("@NearMissDate", SqlDbType.DateTime).Value = dteNearMissDate;
                cmd.Parameters.Add("@OperatorName", SqlDbType.VarChar).Value = strOperatorName;
                cmd.Parameters.Add("@Department_ID", SqlDbType.Int).Value = intDepartment_ID;
                cmd.Parameters.Add("@NearMissType_ID", SqlDbType.Int).Value = intNearMissType_ID;
                cmd.Parameters.Add("@NearMiss_Solution", SqlDbType.VarChar).Value = strNearMissSolution;
                cmd.Parameters.Add("@NearMiss_ActionTaken", SqlDbType.VarChar).Value = strNearMiss_ActionTaken;
                cmd.Parameters.Add("@DateEntered", SqlDbType.DateTime2).Value = System.DateTime.Now;

                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    lblMessage = obj.ToString();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }

                strOperatorName = GetOpertorName();

               //Redirect to success new user page
                Response.Redirect("signIn.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }




        //qry = "SELECT * FROM Data.NearMissRecord WHERE strID = @ID";
        //strEmail = "vlmccomas@cincinnatistate.edu";

        //if (Request.Form["txtBadgeNumber"] != "")
        //{
        //int intID = cmd.Parameters["@ID"].Value.ToString();
        //using (SqlCommand cmd = new SqlCommand(qry, conn))
        //{

        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.Read())
        //    {
        //        var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int);
        //        idParam.Value = cmd.ExecuteScalar();
        //        cmd.Parameters.Add(idParam);

        //        var nearMissDateParam = new SqlParameter("@NearMissDate", System.Data.SqlDbType.DateTime);
        //        nearMissDateParam.Value = dteNearMissDate;
        //        cmd.Parameters.Add(nearMissDateParam);

        //        var operatorNameParam = new SqlParameter("@OperatorName", System.Data.SqlDbType.VarChar);
        //        operatorNameParam.Value = strOperatorName;
        //        cmd.Parameters.Add(operatorNameParam);

        //        var departmentParam = new SqlParameter("@Department_ID", System.Data.SqlDbType.VarChar);
        //        departmentParam.Value = strDepartment;
        //        cmd.Parameters.Add(departmentParam);

        //        var nearMissParam = new SqlParameter("@NearMiss_ID", System.Data.SqlDbType.VarChar);
        //        nearMissParam.Value = strNearMissType;
        //        cmd.Parameters.Add(nearMissParam);

        //        var nearMissSolutionParam = new SqlParameter("@NearMiss_Solution", System.Data.SqlDbType.VarChar);
        //        nearMissSolutionParam.Value = strNearMissSolution;
        //        cmd.Parameters.Add(nearMissSolutionParam);

        //        var nearMissActionTakenParam = new SqlParameter("@NearMiss_ActionTaken", System.Data.SqlDbType.VarChar);
        //        nearMissActionTakenParam.Value = strNearMiss_ActionTaken;
        //        cmd.Parameters.Add(nearMissActionTakenParam);

        //        // Send EHS Review Email
        //        // sendEHSReviewEmail(strID, strEmail);
        //            }
        //            conn.Close();
        //        }

        //        //Redirect to success new user page
        //        Response.Redirect("signIn.aspx");
        //    }
        //}

        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        private string GetFirstNameLastName()
        {
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
        private string GetOpertorName()
        {
            string strOperatorName;

            string strBadgeNumber = (Request.Form["txtBadgeNumber"].ToString());

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString());
            conn.Open();
            string qry = "SELECT * FROM Data.Employee WHERE Employee_ID ='" + strBadgeNumber + "'";
            using (SqlCommand cmd = new SqlCommand(qry, conn))
            {
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                strOperatorName = sdr["Last_Name"].ToString() + ", " + sdr["First_Name"].ToString();

                cmd.Dispose();
                conn.Close();
            }

            return strOperatorName;
        }

        private void sendEHSReviewEmail(string strUsername, string strEmail)
        {
            SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            MailMessage mailMessage = new MailMessage(section.Network.UserName, strEmail);

            string strID = "";

            //while (sdr.Read())
            //{
            //    if (i != numberOfRecords)
            //    {
            //        strEmail += sdr["Email"] + ", "
            //    }
            //}

            string templatePath = HttpRuntime.AppDomainAppPath + "/emailEHSNotificationTemplate.html";
            StreamReader sr = new StreamReader(templatePath);
            string strEmailBody = sr.ReadToEnd();
            sr.Close();

            // Replace the template placeholder variables
            strEmailBody = strEmailBody.Replace("[strUsername]", strUsername);
            strEmailBody = strEmailBody.Replace("[actionURL]", ConfigurationManager.AppSettings["mainURL"] + "reviewIncident?NearMissID=" + strID);
            strEmailBody = strEmailBody.Replace("[mainURL]", ConfigurationManager.AppSettings["mainURL"] + "signIn");

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = strEmailBody;
            mailMessage.Subject = "Forgot Username?";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }

    }
}

