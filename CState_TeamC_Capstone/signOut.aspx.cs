using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CState_TeamC_Capstone {
	public partial class signOut : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		[WebMethod]
		public static void signout_Click() {
			try {
				FormsAuthentication.SignOut();
			} catch (Exception ex) {
				HttpContext.Current.Response.Write(ex.Message);
			}
		}
	}
}