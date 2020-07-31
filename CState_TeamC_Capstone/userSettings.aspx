<%@ Page Title="User Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userSettings.aspx.cs" Inherits="CState_TeamC_Capstone.userSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/userSettings.css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.css"/>
    <link rel="stylesheet" type="text/css" href="Content/table.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <div id="invalidInput" class="center">
            This role has already been requested.
        </div>

        <div class="container">
            <form name="frmRequestRole" id="frmRequestRole" method="post" action="#" runat="server">
                <div id="currentRoles" class="form-group">
                    <label class="control-label currentRolesDesc">Current roles:</label>
                    <ul class="list-group list-group-horizontal">
                        <% foreach (string strCurrentRole in lstCurrentRoles) { %>
                        <li class="list-group-item">
                           <%= strCurrentRole %>
                        </li>
                        <% } %>
                    </ul>
                </div>

                <div class="form-group">
                    <label for="sltRole" class="control-label">Request Role:</label>
                    <select id="sltRole" name="sltRole" class="required form-control">
                        <option value="" selected="selected" disabled="disabled" hidden="hidden">Select Role</option>
                        <% foreach (var role in lstRoles) { %>
                            <option value="<%= role.strID %>"><%= role.strRole %></option>
                        <% } %>
                    </select>
                </div>
                <div>
                    <button type="submit" id="btnRequest" class="btn btn-primary btn-sm center" onserverclick="btnRequest_Click" runat="server">Request</button>
                </div>
            </form>
        </div>
        <div class="container">
            Total requests: 
            <div class="table-responsive">
                <table id="totalRequests" class="table table-hover">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col">Request ID</th>
                            <th scope="col">Role Name</th>
                            <th scope="col">Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (var request in lstAllRoleRequests) { %>
                            <tr>
                                <th scope="row" class="align-middle"><%= request.strID %></th>
                                <td class="align-middle"><%= request.strRole %></td>
                                <td class="align-middle"><%= request.strStatus %></td>
                            </tr> 
                        <% } %>
                    </tbody>
                </table>
            </div>

        </div>
    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>

    <!-- DataTable JQuery -->
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.js"></script>

    <script src="Scripts/userSettings.js"></script>
</asp:Content>
