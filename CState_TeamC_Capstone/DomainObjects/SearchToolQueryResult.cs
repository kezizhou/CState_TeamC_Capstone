namespace CState_TeamC_Capstone.DomainObjects
{
    public class SearchToolQueryResult
    {
        public int ID { get; set; }
        public string OperatorName { get; set; }
        public string Department { get; set; }
        public string NearMissType { get; set; }
        public string AssignedTo { get; set; }
        public string SeverityType { get; set; }
        public string RiskType { get; set; }
        public string Comments { get; set; }
        public int TotalRows { get; set; }
    }
}