
using CState_TeamC_Capstone.DomainObjects;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

using System.Configuration;

namespace CState_TeamC_Capstone
{
    public class Shared
    {
        public static string sqlConn = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;

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

        public static void InsertNearMissRecord(string dtNearMissDate, string strOperatorName, int intDepartment_ID, int intNearMissType_ID, string strNearMissSolution, string strNearMiss_ActionTaken)
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
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Department_ID", System.Data.SqlDbType.Int)).Value = intDepartment_ID;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NearMissType_ID", System.Data.SqlDbType.Int)).Value = intNearMissType_ID;
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
        public static void InsertNearMissReviewRecord(string strID, string strAssignee, int strSeverity_ID, int strRisk_ID, string strReviewComments, string strReviewedBy)
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
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Severity_ID", System.Data.SqlDbType.Int)).Value = strSeverity_ID;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Risk_ID", System.Data.SqlDbType.Int)).Value = strRisk_ID;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewComments", System.Data.SqlDbType.VarChar)).Value = strReviewComments;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewedBy", System.Data.SqlDbType.VarChar)).Value = strReviewedBy;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewDate", System.Data.SqlDbType.DateTime)).Value = System.DateTime.Now;
                _sqlConnection.Open();
                _sqlCommand.ExecuteNonQuery();
            }
        }
        public static void UpdateNearMissReviewRecord(string strID, string strAssigneeUsername, int intSeverity_ID, int intRisk_ID, string strReviewComments, string strReviewedBy)
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
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Severity_ID", System.Data.SqlDbType.Int)).Value = intSeverity_ID;
                _sqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Risk_ID", System.Data.SqlDbType.Int)).Value = intRisk_ID;
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

        public static List<SearchToolQueryResult> GetSearchToolQuery(int pageNumber,
                                                                     string departmentFilter = null,
                                                                     string nearMissTypeFilter = null,
                                                                     string severityTypeFilter = null,
                                                                     string riskTypeFilter = null,
                                                                     string operatorFilter = null,
                                                                     string assigneeFilter = null)
        {
            var sqlOffset = 0;
            if (pageNumber != 1)
            {
                sqlOffset = (pageNumber - 1) * 5;
            }

            List<SearchToolQueryResult> resultList = new List<SearchToolQueryResult>();

            string sql = $@"SELECT Data.NearMissRecord.ID, data.NearMissRecord.OperatorName, Reference.Department.Department, Reference.NearMissType.NearMissType, data.NearMiss_ReviewLog.AssignedTo,
                                   Reference.SeverityofInjury.SeverityType, Reference.RiskLevel.RiskType, data.NearMiss_ReviewLog.Comments, TotalRows = COUNT(*) OVER()
                                    FROM data.NearMissRecord
                                    INNER JOIN data.NearMiss_ReviewLog ON data.NearMissRecord.ID = data.NearMiss_ReviewLog.NearMiss_ID
                                    INNER JOIN Reference.Department ON Reference.Department.ID = data.NearMissRecord.Department_ID
                                    INNER JOIN Reference.NearMissType ON Reference.NearMissType.ID = data.NearMissRecord.NearMissType_ID
                                    INNER JOIN Reference.SeverityofInjury ON Reference.SeverityofInjury.ID = data.NearMiss_ReviewLog.Severity_ID
                                    INNER JOIN Reference.RiskLevel ON Reference.RiskLevel.ID = data.NearMiss_ReviewLog.Risk_ID
                                      where Reference.Department.ID = COALESCE({departmentFilter ?? "null"}, Reference.Department.ID)
                                        AND Reference.NearMissType.ID = COALESCE({nearMissTypeFilter ?? "null"}, Reference.NearMissType.ID)
                                        AND Reference.SeverityofInjury.ID = COALESCE({severityTypeFilter ?? "null"}, SeverityofInjury.ID)
                                        AND Reference.RiskLevel.ID = COALESCE({riskTypeFilter ?? "null"}, Reference.RiskLevel.ID)
                                        AND data.NearMissRecord.OperatorName = COALESCE({GetNameFormattedForSQL(operatorFilter)}, data.NearMissRecord.OperatorName)
                                        AND data.NearMiss_ReviewLog.AssignedTo = COALESCE({GetNameFormattedForSQL(assigneeFilter)}, data.NearMiss_ReviewLog.AssignedTo)
                                    ORDER BY DATA.NearMissRecord.ID
                                    OFFSET {sqlOffset} ROWS
                                    FETCH NEXT 5 ROWS ONLY";

            using (IDbConnection connection = new SqlConnection(sqlConn))
            {
                resultList.AddRange(connection.Query<SearchToolQueryResult>(sql, commandType: CommandType.Text).ToList());
            }

            return resultList;
        }

        private static string GetNameFormattedForSQL(string name)
        {
            if (name == null)
            {
                return "null";
            }
            else
            {
                return $@"'{name}'";
            }
        }

        public static List<Filters> GetDepartmentFilter()
        {
            var searchQueryResults = new List<Filters>();
            string queryString = @"SELECT ID,Department FROM Reference.Department WHERE GETDATE() BETWEEN ValidFromDate and ValidToDate ORDER BY Department ASC";
            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
        }
        public static List<Filters> GetNearMissTypeFilter()
        {
            var searchQueryResults = new List<Filters>();
            string queryString = @"SELECT ID,NearMissType FROM Reference.NearMissType WHERE GETDATE() BETWEEN ValidFromDate and ValidToDate ORDER BY NearMissType ASC";
            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
        }
        public static List<Filters> GetSeverityFilter()
        {
            var searchQueryResults = new List<Filters>();
            string queryString = @"SELECT ID,SeverityType FROM Reference.SeverityofInjury WHERE GETDATE() BETWEEN ValidFromDate and ValidToDate";
            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
        }
        public static List<Filters> GetRiskFilter()
        {
            var searchQueryResults = new List<Filters>();
            string queryString = @"SELECT ID, RiskType FROM Reference.RiskLevel WHERE GETDATE() BETWEEN ValidFromDate and ValidToDate";
            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
        }
        public static List<Filters> GetOperatorNameFilter()
        {
            var searchQueryResults = new List<Filters>();
            //string queryString = @"SELECT ID, OperatorName FROM data.NearMissRecord ORDER BY OperatorName ASC";
            string queryString = @"SELECT MIN(Data.NearMissRecord.ID) as ID, data.NearMissRecord.OperatorName From data.NearMissRecord group by OperatorName ORDER BY OperatorName ASC";
            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
        }
        public static List<Filters> GetAssignedToNameFilter()
        {
            var searchQueryResults = new List<Filters>();
            //string queryString = @"SELECT Data.NearMiss_ReviewLog.NearMiss_ID, data.NearMiss_ReviewLog.AssignedTo FROM data.NearMiss_ReviewLog";
            string queryString = @"SELECT MIN(Data.NearMiss_ReviewLog.NearMiss_ID) as id, data.NearMiss_ReviewLog.AssignedTo From data.NearMiss_ReviewLog group by AssignedTo ORDER BY AssignedTo ASC";

            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
        }
        public static List<Filters> GetAssignIncidentReviewPage()
        {
            var searchQueryResults = new List<Filters>();
            //string queryString = @"SELECT Data.NearMiss_ReviewLog.NearMiss_ID, data.NearMiss_ReviewLog.AssignedTo FROM data.NearMiss_ReviewLog";
            string queryString = @"SELECT DISTINCT [D_EMP].[Person_ID],	[D_EMP].[Last_Name] + ', ' + [D_EMP].[First_Name] AS [DisplayName]
	                               FROM [Data].[Employee] AS [D_EMP]	
                                   LEFT JOIN [Config].[EmployeeRole]    AS [CON_ER] ON [D_EMP].[Person_ID] = [CON_ER].[Person_ID]
                                   INNER JOIN [Reference].[Role]        AS [REF_R]  ON [CON_ER].[Role_ID] = [REF_R].[ID]
                                   CROSS APPLY [UTVF].[GetPersonRolesCommaDelimited] ([CON_ER].[Person_ID]) AS [GPRCD]";

            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
        }
        public static List<Filters> GetNearMissRecordIDReviewPage()
        {
            var searchQueryResults = new List<Filters>();
            string queryString = @"SELECT ID, ID FROM[Data].[NearMissRecord]
                                    WHERE Data.NearMissRecord.ID NOT IN (SELECT data.NearMiss_ReviewLog.NearMiss_ID FROM data.NearMiss_ReviewLog)";

            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
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
        public static List<ReviewIncidentPageTable> GetReviewIncidentPageQuery(string nearMissRecordID = null)
        {
            List<ReviewIncidentPageTable> resultList = new List<ReviewIncidentPageTable>();

            string sql = $@"SELECT Data.NearMissRecord.ID, data.NearMissRecord.OperatorName, Reference.Department.Department, Reference.NearMissType.NearMissType, data.NearMissRecord.NearMiss_Solution
                                    FROM data.NearMissRecord
                                    LEFT JOIN Reference.Department ON Reference.Department.ID = data.NearMissRecord.Department_ID
                                    LEFT JOIN Reference.NearMissType ON Reference.NearMissType.ID = data.NearMissRecord.NearMissType_ID
                                      where Data.NearMissRecord.ID = COALESCE({nearMissRecordID ?? "null"}, Reference.Department.ID)
                                      AND Data.NearMissRecord.ID NOT IN (SELECT data.NearMiss_ReviewLog.NearMiss_ID FROM data.NearMiss_ReviewLog)";

            using (IDbConnection connection = new SqlConnection(sqlConn))
            {
                resultList.AddRange(connection.Query<ReviewIncidentPageTable>(sql, commandType: CommandType.Text).ToList());
            }

            return resultList;
        }
        public static void InsertReviewLogStatement(string sltNearMissReportID, string sltAssignIncident = null, string sltSeverityLevel = null, string sltRiskLevel = null, string strUserName = null, string reviewDate = null)
        {
            string sql = $@"INSERT INTO Data.NearMiss_ReviewLog(NearMiss_ID, AssignedTo, Severity_ID, Risk_ID, Comments, ReviewedBy, ReviewDate)
                            VALUES(@sltNearMissReportID, @sltAssignIncident, @sltSeverityLevel, @sltRiskLevel, '', @strUserName, @reviewDate )";

            using (IDbConnection connection = new SqlConnection(sqlConn))
            {
                connection.Execute(sql, new {
                    sltNearMissReportID,
                    sltAssignIncident,
                    sltSeverityLevel,
                    sltRiskLevel,
                    strUserName,
                    reviewDate
                });
            }

        }
        public static List<UpdateActionPageTable> GetUpdateActionIncidentPageQuery(string nearMissRecordID = null)
        {
            List<UpdateActionPageTable> resultList = new List<UpdateActionPageTable>();

            string sql = $@"SELECT Data.NearMissRecord.ID, data.NearMissRecord.OperatorName, Reference.Department.Department, Reference.NearMissType.NearMissType, data.NearMiss_ReviewLog.AssignedTo,
                                   Reference.SeverityofInjury.SeverityType, Reference.RiskLevel.RiskType, data.NearMissRecord.NearMiss_Solution, data.NearMissRecord.NearMiss_ActionTaken
                                    FROM data.NearMissRecord
                                    INNER JOIN data.NearMiss_ReviewLog ON data.NearMissRecord.ID = data.NearMiss_ReviewLog.NearMiss_ID
                                    INNER JOIN Reference.Department ON Reference.Department.ID = data.NearMissRecord.Department_ID
                                    INNER JOIN Reference.NearMissType ON Reference.NearMissType.ID = data.NearMissRecord.NearMissType_ID
                                    INNER JOIN Reference.SeverityofInjury ON Reference.SeverityofInjury.ID = data.NearMiss_ReviewLog.Severity_ID
                                    INNER JOIN Reference.RiskLevel ON Reference.RiskLevel.ID = data.NearMiss_ReviewLog.Risk_ID
                                      where Data.NearMissRecord.ID = COALESCE({nearMissRecordID ?? "null"}, Reference.Department.ID)";

            using (IDbConnection connection = new SqlConnection(sqlConn))
            {
                resultList.AddRange(connection.Query<UpdateActionPageTable>(sql, commandType: CommandType.Text).ToList());
            }

            return resultList;
        }
        public static List<Filters> GetNearMissRecordIDUpdateActionPage()
        {
            var searchQueryResults = new List<Filters>();
            string queryString = @"SELECT data.NearMissRecord.ID, data.NearMissRecord.ID FROM[Data].[NearMissRecord]
  INNER JOIN data.NearMiss_ReviewLog ON data.NearMissRecord.ID = data.NearMiss_ReviewLog.NearMiss_ID
INNER JOIN Reference.NearMissType ON Reference.NearMissType.ID = data.NearMissRecord.NearMissType_ID
INNER JOIN Reference.SeverityofInjury ON Reference.SeverityofInjury.ID = data.NearMiss_ReviewLog.Severity_ID
INNER JOIN Reference.RiskLevel ON Reference.RiskLevel.ID = data.NearMiss_ReviewLog.Risk_ID
  WHERE data.NearMiss_ReviewLog.AssignedTo IS NOT NULL
  AND data.NearMiss_ReviewLog.Severity_ID IS NOT NULL
  AND data.NearMiss_ReviewLog.Severity_ID IS NOT NULL";

            using (SqlConnection connection = new SqlConnection(sqlConn))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        searchQueryResults.Add(new Filters
                        {
                            ID = (int)reader[0],
                            Description = reader[1].ToString(),
                        });
                    }
                }
            }

            return searchQueryResults;
        }
        public static void InsertUpdateActionStatement(string sltNearMissReportID, string txaActionUpdate = null, string strUserName = null, string reviewDate = null)
        {
            string sql = $@"INSERT INTO Data.NearMiss_ActionTakenUpdate(NearMiss_ID, NearMiss_ActionTaken, UpdatedBy, DateUpdate)
                            VALUES(@sltNearMissReportID, @txaActionUpdate, @strUserName, @reviewDate )";

            using (IDbConnection connection = new SqlConnection(sqlConn))
            {
                connection.Execute(sql, new
                {
                    sltNearMissReportID,
                    txaActionUpdate,
                    strUserName,
                    reviewDate
                });
            }

        }
    }
}