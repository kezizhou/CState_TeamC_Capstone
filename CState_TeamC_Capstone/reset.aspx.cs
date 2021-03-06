﻿using System;
using System.Web.UI;

namespace CState_TeamC_Capstone {
	public partial class reset : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			try {
				string strType = Request.QueryString["type"];

				switch (strType) {
					case "resetPasswordSuccess":
						Page.Title = "Near Miss Reporting - Successful Password Reset";
						confirmMessage.InnerText = "Thank you! Your password has been reset.";
						break;
					case "resetEmailSent":
						Page.Title = "Near Miss Reporting - Forgot Credentials Email Sent";
						confirmMessage.InnerText = "Thank you! An email has been sent to you with further instructions.";
						break;
					case "invalidToken":
						Page.Title = "Near Miss Reporting -Invalid Token";
						confirmMessage.InnerText = "This token is invalid or expired.";
						messageDiv.Attributes.Add("class", messageDiv.Attributes["class"].ToString().Replace("message", "invalid"));
						break;
					case "unauthorizedUser":
						Page.Title = "Near Miss Reporting - Unauthorized";
						confirmMessage.InnerText = "Error: This page cannot be viewed because you are not signed in or not authorized to view this page.";
						messageDiv.Attributes.Add("class", messageDiv.Attributes["class"].ToString().Replace("message", "invalid"));
						break;
					case "error":
						Page.Title = "Near Miss Reporting - Error";
						confirmMessage.InnerText = "Error: There was an error processing your request. Please try again.";
						messageDiv.Attributes.Add("class", messageDiv.Attributes["class"].ToString().Replace("message", "invalid"));
						break;
					case "typeInstructionsError":
						Page.Title = "Near Miss Reporting - Error";
						confirmMessage.InnerText = "Error: The page you are trying to access can only be accessed after initiating an incident.";
						break;
					default:
						break;
				}
			} catch (Exception ex) {
				Response.Write(ex.Message);
			}
		}
	}
}