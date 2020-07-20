using System;

namespace CState_TeamC_Capstone
{
    public partial class initiateIncident : System.Web.UI.Page {
        public object dteIncident;
        public object txtOperator;
        public object sltDepartment;
        public object sltType;
        public object txaSolution;
        public object txaActionTaken;
        public object strID;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            {
               
            }

         }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string dtNearMissDate = dteIncident.ToString();
            string strOperatorName = txtOperator.ToString();
            string strDepartment = sltDepartment.ToString();
            string strNearMissType = sltType.ToString();
            string strNearMissSolution = txaSolution.ToString();
            string strNearMiss_ActionTaken = txaActionTaken.ToString();

            Shared.InsertNearMissRecord(dtNearMissDate, strOperatorName, strDepartment, strNearMissType, strNearMissSolution, strNearMiss_ActionTaken);
            

            //Shared.InsertNearMissReviewRecord(strID, "Under Review", "Under Review", "Under Review", "", "Under Review", dtDateEntered);

        }      

    }

}