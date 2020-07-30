<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchTool.aspx.cs" Inherits="CState_TeamC_Capstone.searchTool" Title="Search Tool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/searchTool.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.css"/>
    <link rel="stylesheet" type="text/css" href="Content/table.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <main role="main" class="container-fluid">
        <form name="frmFilters" id="frmFilters" method="get" action="#" runat="Server">
            <!-- Search filters -->
            <!-- Future feature: Allow select boxes to be searched for a string -->
            <div class="container-fluid center2 form-inline">
                <select id="sltDepartment" name="sltDepartment" class="form-control">
                    <option value="" selected="selected" disabled="disabled">Department</option>
                    <% foreach (var x in departments)
                        {%><option value="<%= x.ID%>">

                        <%= x.Description%>
   
                    </option>
                    <%};%>
                </select>
                <select id="sltNearMissType" name="sltNearMissType" class="form-control">
                    <option value="none" selected="selected" disabled="disabled">Near Miss Type</option>
                    <% foreach (var x in nearMissType)
                        {%><option value="<%= x.ID%>">

                        <%= x.Description%>
                            
                    </option>
                    <%};%>
                </select>
                <select id="sltSeverityLevel" name="sltSeverityLevel" class="form-control">
                    <option value="none" selected="selected" disabled="disabled">Severity Level</option>
                    <% foreach (var x in severity)
                        {%><option value="<%= x.ID%>">

                        <%= x.Description%>
                            
                    </option>
                    <%};%>
                </select>
                <select id="sltRiskLevel" name="sltRiskLevel" class="form-control">
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
                <div class="card card-body center">
                    <div name="frmFilters" id="Form1" method="get" action="#" runat="server">

                        <div class="container-fluid">
                            <i class="fas fa-filter"></i>

                            <select id="sltOperatorName" name="sltOperatorName" class="form-control">
                                <option value="none" selected="selected" disabled="disabled">Operator Name</option>
                                <% foreach (var x in operatorName)
                                    {%><option value="<%= x.Description%>">

                                    <%= x.Description%>
                            
                                </option>
                                <%};%>
                            </select>

                            <select id="sltAssignedTo" name="sltAssignedTo" class="form-control">
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
                                <th scope="col">Brief Detail</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var x in results)
                                {%><tr>

                                <th scope="row"><%= x.ID%></th>
                                <td class="align-middle"><%= x.OperatorName%></td>
                                <td class="align-middle"><%= x.Department%></td>
                                <td class="align-middle"><%= x.NearMissType%></td>
                                <td class="align-middle"><%= x.AssignedTo%></td>
                                <td class="align-middle"><%= x.SeverityType%></td>
                                <td class="align-middle"><%= x.RiskType%></td>
                                <td class="align-middle"><%= x.Comments%></td>
                            </tr>
                            <%};%>
                        </tbody>
                    </table>
                </div>
            </div>
        </form>
    </main>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.js"></script>
    <script src="Scripts/searchTool.js"></script>
</asp:Content>
