using CState_TeamC_Capstone.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
	public partial class searchTool : System.Web.UI.Page {
        public List<SearchToolQueryResult> results;
		protected void Page_Load(object sender, EventArgs e) {
            results = Shared.GetSearchToolQuery();
        }
	}
}