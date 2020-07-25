
namespace CState_TeamC_Capstone
{
    public class Shared
    {
        public const string sqlConn = "Data Source=itd2.cincinnatistate.edu;Initial Catalog=CPDM-MccomasV; User ID=CPDM-vlMcComas;Password=0477095; ";
        //  public const string sqlConn = "Data Source=itd2.cincinnatistate.edu;Initial Catalog=CPDM-MccomasV; User ID=CPDM-Adam;Password=; ";
        //  public const string sqlConn = "Data Source=itd2.cincinnatistate.edu;Initial Catalog=CPDM-MccomasV; User ID=CPDM-Keziah;Password=; ";

        public static string GetTopNearMissRecord()
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "SELECT MAX(ID) FROM [Data].[NearMissRecord]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.Text;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); 
                        // "SELECT MAX(ID) FROM [Data].[NearMissRecord]"
                if (_dataTable.Rows.Count > 0)
                    _returnString = _dataTable.Rows[0][0].ToString();
            }

            return _returnString;
        }

        public static void InsertNearMissRecord(string dtNearMissDate, string strOperatorName, string strDepartment, string strNearMissType, string strNearMissSolution, string strNearMiss_ActionTaken)
        {
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[InsertNearMissRecord]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMissDate", System.Data.SqlDbType.DateTime)).Value = dtNearMissDate;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OperatorName", System.Data.SqlDbType.VarChar)).Value = strOperatorName;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Department", System.Data.SqlDbType.VarChar)).Value = strDepartment;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMissType", System.Data.SqlDbType.VarChar)).Value = strNearMissType;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMiss_Solution", System.Data.SqlDbType.VarChar)).Value = strNearMissSolution;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMiss_ActionTaken", System.Data.SqlDbType.VarChar)).Value = strNearMiss_ActionTaken;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateEntered", System.Data.SqlDbType.DateTime2)).Value = System.DateTime.Now;
                _sqlConnection.Open();

                _sqlCommand.ExecuteNonQuery();
            }
        }
        public static string GetEHSEmailNearMiss()
        {
                string _returnString = string.Empty;
                var _dataTable = new System.Data.DataTable();
                using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
                {
                    string _sqlCommandText;

                    // ---------------------------------------------------------------------------------------------------------------------------------------------------
                    _sqlCommandText = "SELECT Username FROM [VW].[EmployeeApplicationRights] WHERE [Role_ID] LIKE '%1%' ";
                    // ---------------------------------------------------------------------------------------------------------------------------------------------------
                    var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                    _sqlCommand.CommandType = System.Data.CommandType.Text;
                    var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                    _sqlDataAdapter.Fill(_dataTable);

                    // If _dataTable.Rows.Count > 0 Then _returnString = _dataTable.Rows(0).Item(0).ToString
                    foreach (System.Data.DataRow _row in _dataTable.Rows)
                        _returnString += _row["Username"];
                }
                return _returnString;
            }
        public static string GetAssigneeEmailNearMiss(string Username)
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[GetNearMissEmailAddresses]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.VarChar)).Value = Username;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // "[SP].[GetNearMissEmailAddresses]"

                // If _dataTable.Rows.Count > 0 Then _returnString = _dataTable.Rows(0).Item(0).ToString
                foreach (System.Data.DataRow _row in _dataTable.Rows)
                    _returnString += _row["EmailAddress"];
            }

            return _returnString;
        }
        public static string GetReviewAssigneeEmailNearMiss(string strAssigneeUsername)
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[GetReviewNearMissEmailAddresses]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.VarChar)).Value = strAssigneeUsername;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // "[SP].[GetNearMissEmailAddresses]"

                // If _dataTable.Rows.Count > 0 Then _returnString = _dataTable.Rows(0).Item(0).ToString
                foreach (System.Data.DataRow _row in _dataTable.Rows)
                    _returnString += _row["EmailAddress"];
            }

            return _returnString;
        }

        public static string GetNameEmailNearMiss()
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "SELECT Username FROM [VW].[EmployeeApplicationRights]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.Text;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // [VW].[EmployeeApplicationRights]

                // If _dataTable.Rows.Count > 0 Then _returnString = _dataTable.Rows(0).Item(0).ToString
                foreach (System.Data.DataRow _row in _dataTable.Rows)
                    _returnString += _row["Username"];
            }

            return _returnString;
        }
        public static string GetNearMissAssigneeList()
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[GetNearMissAssigneeList]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // [SP].[GetNearMissAssigneeList]
                if (_dataTable.Rows.Count > 0)
                    _returnString = _dataTable.Rows[0][0].ToString();

            }

            return _returnString;
        }

        public static string GetDepartments()
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[GetDepartments]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // [SP].[GetDepartments]
                if (_dataTable.Rows.Count > 0)
                    _returnString = _dataTable.Rows[0][0].ToString();

            }

            return _returnString;
        }

        public static string GetNearMissType()
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[GetNearMissType]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // [SP].[GetNearMissType]
                if (_dataTable.Rows.Count > 0)
                    _returnString = _dataTable.Rows[0][0].ToString();

            }

            return _returnString;
        }

        public static string GetRiskLevel()
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[GetRiskLevel]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // [SP].[GetRiskLevel]
                if (_dataTable.Rows.Count > 0)
                    _returnString = _dataTable.Rows[0][0].ToString();

            }

            return _returnString;
        }

        public static string GetSeverityofInjury()
        {
            string _returnString = string.Empty;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[GetSeverityofInjury]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // [SP].[GetSeverityofInjury]
                if (_dataTable.Rows.Count > 0)
                    _returnString = _dataTable.Rows[0][0].ToString();

            }

            return _returnString;
        }
        public static void InsertNearMissReviewRecord(string strID, string strAssignee, string strSeverity, string strRisk, string strReviewComments, string strReviewedBy)
        {
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[InsertNearMissReviewRecord]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMiss_ID", System.Data.SqlDbType.VarChar)).Value = strID;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Assignee", System.Data.SqlDbType.VarChar)).Value = strAssignee;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Severity", System.Data.SqlDbType.VarChar)).Value = strSeverity;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Risk", System.Data.SqlDbType.VarChar)).Value = strRisk;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewComments", System.Data.SqlDbType.VarChar)).Value = strReviewComments;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewedBy", System.Data.SqlDbType.VarChar)).Value = strReviewedBy;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewDate", System.Data.SqlDbType.DateTime)).Value = System.DateTime.Now;
                _sqlConnection.Open();
                _sqlCommand.ExecuteNonQuery();
            }
        }
        public static void UpdateNearMissReviewRecord(string strID, string strAssigneeUsername, string strSeverity, string strRisk, string strReviewComments, string strReviewedBy)
        {
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[UpdateNearMissReviewRecord]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMiss_ID", System.Data.SqlDbType.VarChar)).Value = strID;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Assignee", System.Data.SqlDbType.VarChar)).Value = strAssigneeUsername;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Severity", System.Data.SqlDbType.VarChar)).Value = strSeverity;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Risk", System.Data.SqlDbType.VarChar)).Value = strRisk;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewComments", System.Data.SqlDbType.VarChar)).Value = strReviewComments;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewedBy", System.Data.SqlDbType.VarChar)).Value = strReviewedBy;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewDate", System.Data.SqlDbType.DateTime)).Value = System.DateTime.Now;
                _sqlConnection.Open();
                _sqlCommand.ExecuteNonQuery();
            }
        }
        public static bool CheckNearMissReviewRecordExists(string strNearMiss_ID)
        {
            bool _returnBoolean = false;
            var _dataTable = new System.Data.DataTable();
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[CheckNearMissReviewRecordExists]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMiss_ID", System.Data.SqlDbType.VarChar)).Value = strNearMiss_ID;
                var _sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(_sqlCommand);
                _sqlDataAdapter.Fill(_dataTable); // [SP].[CheckNearMissReviewRecordExists]
                if (_dataTable.Rows.Count > 0)
                    _returnBoolean = true;
            }

            return _returnBoolean;
        }
        public static void InsertNearMissActionTakenUpdate(string strID, string strNearMiss_ActionTaken, string strUpdatedBy)
        {
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;

                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[InsertNearMissActionTakenUpdate]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMiss_ID", System.Data.SqlDbType.VarChar)).Value = strID;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMiss_ActionTaken", System.Data.SqlDbType.VarChar)).Value = strNearMiss_ActionTaken;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UpdatedBy", System.Data.SqlDbType.VarChar)).Value = strUpdatedBy;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateUpdated", System.Data.SqlDbType.VarChar)).Value = System.DateTime.Now;
                _sqlConnection.Open();         
                _sqlCommand.ExecuteNonQuery(); 
            }                                  
        }

        public static void InsertNewEmployee(string strFirstName, string strMiddleName, string strLastName, string strUsername, string hashParam, string saltParam, bool blnActive, int intEmployeeID, string strEmail, string strDepartment)
        {
            using (var _sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString: sqlConn))
            {
                string _sqlCommandText;
                
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                _sqlCommandText = "[SP].[InsertNewEmployee]";
                // ---------------------------------------------------------------------------------------------------------------------------------------------------
                var _sqlCommand = new System.Data.SqlClient.SqlCommand(_sqlCommandText, _sqlConnection);
                _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@First_Name", System.Data.SqlDbType.VarChar)).Value = strFirstName;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Middle_Name", System.Data.SqlDbType.VarChar)).Value = strMiddleName;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Last_Name", System.Data.SqlDbType.VarChar)).Value = strLastName;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Username", System.Data.SqlDbType.VarChar)).Value = strUsername;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.Char)).Value = hashParam;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Salt", System.Data.SqlDbType.Char)).Value = saltParam;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Active", System.Data.SqlDbType.Bit)).Value = blnActive;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Employee_ID", System.Data.SqlDbType.Int)).Value = intEmployeeID;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = strEmail;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Department", System.Data.SqlDbType.VarChar)).Value = strDepartment;
                
                _sqlConnection.Open();

                _sqlCommand.ExecuteNonQuery();
            }
        }
    }
}