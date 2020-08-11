<%@ Page Title="Review Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reviewIncident.aspx.cs" Inherits="CState_TeamC_Capstone.reviewIncident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Content/reviewIncident.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Review Incident</h2>
        <h5>Welcome: <span id="userFullName" runat="server"></span></h5>

        <div class="container">
            <!-- Review Incident Form -->
            <form id="frmReviewIncident" name="frmReviewIncident" method="post" action="#" runat="server">
                <div class="form-group container">
                    <label for="sltNearMissReportID" class="control-label">Select Near Miss Incident ID:</label>
                    <asp:DropDownList runat="server" ID="sltNearMissReportID" name="sltNearMissReportID" class="required form-control" OnSelectedIndexChanged="Filter" AutoPostBack="True">
                    </asp:DropDownList>
                </div>

                <!-- Results table -->
                <div class="container">
                    <div class="table-responsive">
                        <table id="resultTable" class="table">
                            <thead class="thead-light">
                                <tr>
                                    <th scope="col">Near Miss ID</th>
                                    <th scope="col">Operator Name</th>
                                    <th scope="col">Department</th>
                                    <th scope="col">Near Miss Type</th>
                                    <th scope="col">Near Miss Detail</th>
                                    <th scope="col">Action Taken</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var x in results)
                                    {%><tr>

                                    <th scope="row"><%= x?.ID%></th>
                                    <td class="align-middle"><%= x?.OperatorName%></td>
                                    <td class="align-middle"><%= x?.Department%></td>
                                    <td class="align-middle"><%= x?.NearMissType%></td>
                                    <td class="align-middle"><%= x?.NearMiss_Solution%></td>
                                    <td class="align-middle"><%= x?.NearMiss_ActionTaken%></td>
                                </tr>
                                <%};%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="container">
                    <div class="form-group">
                        <label for="sltAssignIncident" class="control-label">Assign Near Miss Incident:</label>
                        <select id="sltAssignIncident" name="sltAssignIncident" class="required form-control">
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
                                {%><option value="<%= x.ID%>">

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
                                {%><option value="<%= x.ID%>">

                                        <%= x.Description%>
                            
                                    </option>
                            <%};%>
                        </select>
                    </div>
                    <div class="container">
                        <asp:Button runat="server" ID="btnSubmit" class="btn btn-primary btn-sm center" Text="Submit" OnClick="InsertReviewLog" />
                    </div>
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
