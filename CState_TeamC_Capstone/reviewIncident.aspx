<%@ Page Title="Review Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reviewIncident.aspx.cs" Inherits="CState_TeamC_Capstone.reviewIncident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Content/reviewIncident.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Review Incident</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <div class="center2">
            <table class="resultTable">
                <thead class="thead-light">
                    <tr>
                        <th scope="col">Operator Name</th>
                        <th scope="col">Department</th>
                        <th scope="col">Near Miss Type</th>
                        <th scope="col">Assigned To</th>
                        <th scope="col">Severity Level</th>
                        <th scope="col">Risk Level</th>
                        <th scope="col">Brief Detail</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>FirstName LastName</td>
                        <td>SampleDepartment</td>
                        <td>Spill</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>This is a paragraph of brief detail describing the incident.</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="container">
            <!-- Review Incident Form -->
            <form id="frmReviewIncident" name="frmReviewIncident" method="post" action="#" runat="server">
                <div class="form-group">
                    <label for="sltAssignIncident" class="control-label">Assign Near Miss Incident:</label>
                    <select id="sltAssignIncident" name="sltAssignIncident"  class="required form-control">
                                <option value="none" selected="selected" disabled="disabled">Assign Near Miss to..</option>
                                <% foreach (var x in assignTo)
                                    {%><option value="<%= x.Description%>">

                                    <%= x.Description%>
                            
                                </option>
                                <%};%>
                            </select>
                </div>
                <div class="form-group">
                    <label for="sltInjurySeverity" class="control-label">Severity of Injury:</label>
                    <select id="sltSeverityLevel" name="sltSeverityLevel" class="required form-control">
                        <option value="none" selected="selected" disabled="disabled">Severity Level</option>
                            <% foreach (var x in severity)
                                {%><option value="<%= x.Description%>">

                                    <%= x.Description%>
                            
                        </option>
                                <%};%>
                    </select>
                </div>
                <div class="form-group">
                    <label for="sltRiskLevel" class="control-label">Risk Level:</label>
                    <select id="sltRiskLevel" name="sltRiskLevel" class="required form-control">
                        <option value="none" selected="selected" disabled="disabled">Risk Level</option>
                            <% foreach (var x in risk)
                                {%><option value="<%= x.Description%>">

                                    <%= x.Description%>
                            
                        </option>
                                <%};%>
            </select>
                </div>
                <div class="container">
                    <button type="submit" id="btnSubmit" class="btn btn-primary btn-sm center">Submit</button>
                </div>
            </form>
        </div>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
     <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script src="Scripts/reviewIncident.js"></script>
</asp:Content>
