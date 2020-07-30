<%@ Page Title="Admin Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminSettings.aspx.cs" Inherits="CState_TeamC_Capstone.adminSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/adminSettings.css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.css"/>
    <link rel="stylesheet" type="text/css" href="Content/table.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <div class="container-fluid">
            <label class="form-label">Pending requests: </label>
            <div class="table-responsive">
                <table id="pendingRequests" class="table table-hover">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Request</th>
                            <th scope="col">First</th>
                            <th scope="col">Middle</th>
                            <th scope="col">Last</th>
                            <th scope="col">Email</th>
                            <th scope="col">Employee ID</th>
                            <th scope="col">Department</th>
                            <th scope="col">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (var userRequest in lstUsersWithRequests) { %>
                            <tr>
                                <th scope="row" id="row" class="align-middle"><%= userRequest.strID %></th>
                                <td class="align-middle"><%= userRequest.strRole %></td>
                                <td class="align-middle"><%= userRequest.strFirstName %></td>
                                <td class="align-middle"><%= userRequest.strMiddleName %></td>
                                <td class="align-middle"><%= userRequest.strLastName %></td>
                                <td class="align-middle"><%= userRequest.strEmail %></td>
                                <td class="align-middle"><%= userRequest.strEmployeeID %></td>
                                <td class="align-middle"><%= userRequest.strDepartment %></td>
                                <td>
                                    <button type="button" class="btnAccept d-inline btn btn-primary btn-sm" onclick="CallBtnAcceptClick.call(this)" value="<%= userRequest.strID %>">
                                        Accept
                                    </button>
                                    <button type="button" class="btnReject d-inline btn btn-secondary btn-sm" onclick="CallBtnRejectClick.call(this)" value="<%= userRequest.strID %>">
                                        Reject
                                    </button>
                                </td>
                            </tr> 
                        <% } %>
                    </tbody>
                </table>
            </div>
        </div>
    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.js"></script>
    <script src="Scripts/adminSettings.js"></script>
</asp:Content>
