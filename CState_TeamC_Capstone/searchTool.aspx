<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchTool.aspx.cs" Inherits="CState_TeamC_Capstone.searchTool" Title="Search Tool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/searchTool.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <main role="main" class="container-fluid">
        <form name="frmFilters" id="frmFilters" method="get" action="#" runat="Server">
            <!-- Search filters -->
            <!-- Future feature: Allow select boxes to be searched for a string -->
            <div class="container-fluid center2">
                <select id="sltDepartment" name="sltDepartment">
                    <option value="" selected="selected" disabled="disabled">Department</option>


                    <% foreach (var x in departments)
                        {%><option value="<%= x.ID%>">

                        <%= x.Description%>
                            
                    </option>
                    <%};%>
                </select>
                <select id="sltNearMissType" name="sltNearMissType">
                    <option value="none" selected="selected" disabled="disabled">Near Miss Type</option>
                    <% foreach (var x in nearMissType)
                        {%><option value="<%= x.ID%>">

                        <%= x.Description%>
                            
                    </option>
                    <%};%>
                </select>
                <select id="sltSeverityLevel" name="sltSeverityLevel">
                    <option value="none" selected="selected" disabled="disabled">Severity Level</option>
                    <% foreach (var x in severity)
                        {%><option value="<%= x.ID%>">

                        <%= x.Description%>
                            
                    </option>
                    <%};%>
                </select>
                <select id="sltRiskLevel" name="sltRiskLevel">
                    <option value="none" selected="selected" disabled="disabled">Risk Level</option>
                    <% foreach (var x in risk)
                        {%><option value="<%= x.ID%>">

                        <%= x.Description%>
                            
                    </option>
                    <%};%>
                </select>
                <button id="btnToggleFilters" class="btn btn-primary" type="button" data-toggle="collapse" data-target="#filtersCollapse" aria-expanded="false" aria-controls="filtersCollapse">
                    Advanced Filters
                </button>
            </div>

            <!-- Advanced Filters -->
            <div id="filtersCollapse" class="collapse">
                <div class="card card-body center2">
                    <div name="frmFilters" id="Form1" method="get" action="#" runat="server">

                        <div class="container-fluid">
                            <i class="fas fa-filter"></i>

                            <select id="sltOperatorName" name="sltOperatorName">
                                <option value="none" selected="selected" disabled="disabled">Operator Name</option>
                                <% foreach (var x in operatorName)
                                    {%><option value="<%= x.Description%>">

                                    <%= x.Description%>
                            
                                </option>
                                <%};%>
                            </select>

                            <select id="sltAssignedTo" name="sltAssignedTo">
                                <option value="none" selected="selected" disabled="disabled">Assigned To</option>
                                <% foreach (var x in assignedToName)
                                    {%><option value="<%= x.Description%>">

                                    <%= x.Description%>
                            
                                </option>
                                <%};%>
                            </select>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid center2">
                <asp:Button runat="server" ID="btnFilter" class="btn btn-secondary btn-sm" Text="Filter" OnClick="Filter" />
                <asp:Button runat="server" ID="btnClear" class="btn btn-secondary btn-sm" Text="Clear" OnClick="Clear" />
                <button type="button" id="btnExport" class="btn btn-secondary btn-sm" onclick="">Export to Excel</button>
            </div>

            <!-- Results table -->
            <div class="container-fluid .table-responsive row justify-content-center">
                <table class="resultTable">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col">Near Miss ID</th>
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
                        <% foreach (var x in results)
                            {%><tr>

                            <td><%= x.ID%></td>
                            <td><%= x.OperatorName%></td>
                            <td><%= x.Department%></td>
                            <td><%= x.NearMissType%></td>
                            <td><%= x.AssignedTo%></td>
                            <td><%= x.SeverityType%></td>
                            <td><%= x.RiskType%></td>
                            <td><%= x.Comments%></td>
                        </tr>
                        <%};%>
                    </tbody>
                </table>
            </div>
            <div>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
        </form>
    </main>

</asp:Content>
