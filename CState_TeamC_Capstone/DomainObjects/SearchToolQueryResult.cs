namespace CState_TeamC_Capstone.DomainObjects
{
    public class SearchToolQueryResult
    {
        public int NearMissRecordID { get; set; }
        public string Operator { get; set; }
        public string Department { get; set; }
        public string NearMissType { get; set; }
        public string Assignee { get; set; }
        public string SeverityLevel { get; set; }
        public string RiskLevel { get; set; }
        public string BriefDetail { get; set; }
    }
}