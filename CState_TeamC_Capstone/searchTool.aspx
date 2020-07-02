<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchTool.aspx.cs" Inherits="CState_TeamC_Capstone.searchTool" Title="Search Tool"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/searchTool.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <main role="main" class="container-fluid">
        <!-- Search filters -->
        <!-- Future feature: Allow select boxes to be searched for a string -->
        <div class="container-fluid">
            <select id="sltDepartment" name="sltDepartment">
                <option value="none" selected="selected"></option>
                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Department</option>
                <option value="value">Populated from database</option>
            </select>
            <select id="sltNearMissType" name="sltNearMissType">
                <option value="none" selected="selected"></option>
                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Near Miss Type</option>
                <option value="value">Populated from database</option>
            </select>
            <select id="sltSeverityLevel" name="sltSeverityLevel">
                <option value="none" selected="selected"></option>
                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Severity Level</option>
                <option value="value">Populated from database</option>
            </select>
            <select id="sltRiskLevel" name="sltRiskLevel">
                <option value="none" selected="selected"></option>
                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Risk Level</option>
                <option value="value">Populated from database</option>
            </select>
            <button id="btnToggleFilters" class="btn btn-primary" type="button" data-toggle="collapse" data-target="#filtersCollapse" aria-expanded="false" aria-controls="filtersCollapse">
                Advanced Filters
            </button>
        </div>

        <!-- Advanced Filters -->
        <div id="filtersCollapse" class="collapse">
            <div class="card card-body">
                <form name="frmFilters" id="frmFilters" method="get" action="#" runat="server">
                    <div class="container-fluid">
                        <i class="fas fa-filter"></i>
                        <select id="sltOperatorName" name="sltOperatorName">
                            <option value="none" selected="selected"></option>
                            <option value="none" selected="selected" disabled="disabled" hidden="hidden">Operator Name</option>
                            <option value="value">Populated from database</option>
                        </select>
                        <select id="sltAssignedTo" name="sltAssignedTo">
                            <option value="none" selected="selected"></option>
                            <option value="none" selected="selected" disabled="disabled" hidden="hidden">Assigned To</option>
                            <option value="value">Populated from database</option>
                        </select>
                        <input id="txtCustomFilter" type="text" name="txtCustomFilter" placeholder="Text to search"/>    
                        <button type="button" id="btnFilter" class="btn btn-secondary btn-sm" onclick="">Filter</button>     
                        <button type="button" id="btnClear" class="btn btn-secondary btn-sm" onclick="">Clear Filters</button>    
                    </div>
                </form>
            </div>
        </div>

        <div class="container-fluid">
            <button type="button" id="btnExport" class="btn btn-secondary btn-sm" onclick="">Export to Excel</button>
        </div>
          
        <!-- Results table -->
        <div class="container-fluid .table-responsive">
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
                        <td>FirstName LastName</td>
                        <td>Medium</td>
                        <td>Low</td>
                        <td>This is a paragraph of brief detail describing the incident.</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </main>

    <!-- Page numbers -->
    <!-- To be programmed with scripting -->
    <div class="pagination center">
        <a href="#">&laquo;</a>
        <a href="#" class="active">1</a>
        <a href="#">2</a>
        <a href="#">3</a>
        <a href="#">4</a>
        <a href="#">5</a>
        <a href="#">6</a>
        <a href="#">&raquo;</a>
    </div>
</asp:Content>