<%@ Page Title="Update Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateIncident.aspx.cs" Inherits="CState_TeamC_Capstone.updateIncident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/reviewIncident.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Update Incident Action</h2>
        <h5>Welcome: <span id="userFullName" runat="server"></span></h5>

        <!-- Update Incident Action Form -->
        <form id="frmUpdateIncident" name="frmUpdateIncident" method="post" action="#" runat="server">
            <div class="form-group">
                <label for="sltNearMissReportID" class="control-label">Select Near Miss Incident ID:</label>
                <asp:DropDownList runat="server" ID="sltNearMissReportID" name="sltNearMissReportID" class="required form-control" OnSelectedIndexChanged="Filter" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <!-- Results table -->
                <div class="container-fluid row justify-content-center">
                    <div class="table-responsive">
                        <table id="resultTable" class="table table-hover">
                            <thead class="thead-light">
                                <tr>
                                    <th scope="col">Near Miss ID</th>
                                    <th scope="col">Operator Name</th>
                                    <th scope="col">Department</th>
                                    <th scope="col">Near Miss Type</th>
                                    <th scope="col">Assigned To</th>
                                    <th scope="col">Severity Level</th>
                                    <th scope="col">Risk Level</th>
                                    <th scope="col">Proposed Solution</th>
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
                                    <td class="align-middle"><%= x?.AssignedTo%></td>
                                    <td class="align-middle"><%= x?.SeverityType%></td>
                                    <td class="align-middle"><%= x?.RiskType%></td>
                                    <td class="align-middle"><%= x?.PorposedSolution%></td>
                                    <td class="align-middle"><%= x?.ActionTaken%></td>
                                </tr>
                                <%};%>
                            </tbody>
                        </table>
                    </div>
                </div>
            
            <div class="container">

                <div class="form-group">
                    <label for="txaActionUpdate" class="control-label">Action Update: </label>
                    <textarea name="txaActionUpdate" id="txaActionUpdate" class="form-control" rows="9"></textarea>
                </div>
                <div class="container">
                    <asp:Button runat="server" ID="btnSubmit" class="btn btn-primary btn-sm center" Text="Update" OnClick="InsertUpdateAction" />

                </div>
            </div>
        </form>
    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script src="Scripts/updateIncident.js"></script>
</asp:Content>
