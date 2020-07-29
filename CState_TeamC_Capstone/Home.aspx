<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CState_TeamC_Capstone.Home" Title="Home"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/Home.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <main role="main" class="container-fluid">
        <h2>Near Miss Incident Dashboard</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <div id="lastIncidentDescription" class="lastIncidentDescription">
            <div id="lastIncidentHeading" class="lastIncidentHeading text-center d-inline" runat="server">Last Reported Incident Occurred: </div>
            <div id="lastIncident" class="lastIncident d-inline" runat="server"></div>
            <div id="daysAgo" runat="server" class="d-inline">days ago</div>
        </div>

        <!-- Show/Hide Date Filters -->
        <button id="btnToggleFilters" class="btn btn-primary center" type="button" data-toggle="collapse" data-target="#filtersCollapse" aria-expanded="false" aria-controls="filtersCollapse">
            Show/Hide Date Filters
        </button>
        <div id="filtersCollapse" class="collapse">
            <div class="card card-body center2">
                <form id="frmDateRange" name="frmDateRange"  method="post" action="#" runat="server" onsubmit="return $('#frmDateRange').valid()">
                    <div id="dateRangePickers" class="center2">
                        <div>
                            <input id="dteStart" name="dteStart" class="form-control" type="date" required="required" value="<%= this.dteStartInput %>"/>
                            <div class="errorText"></div>
                        </div>
                        <div id="to" class="d-inline">to</div>
                        <div>
                            <input id="dteEnd" name="dteEnd" class="form-control" type="date" required="required" value="<%= this.dteEndInput %>"/>
                            <div class="errorText"></div>
                        </div>
                    </div>
                    <div class="center2">
                        <button type="button" id="btnClear" class="btn btn-secondary btn-sm d-inline btnClear" onserverclick="btnClear_Click" runat="server">Clear</button>
                        <button type="submit" id="btnFilterDates" class="btn btn-primary btn-sm d-inline btnFilterDates" onserverclick="btnFilterDates_Click" runat="server">Filter by Dates</button>
                    </div>
                </form>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="container-fluid chartContainer col-lg-auto">
                    <div id="riskSeverityChart"></div>
                    <div id="srByDepartmentFilter" class="filter"></div>
                </div>
                <div class="w-100"></div>
                <div class="container-fluid chartContainer col-lg-auto">
                    <div id="departmentNearMissTypesChart"></div>
                    <div id="typeByDepartmentFilter" class="filter"></div>
                    <div id="nearMissTypeFilter" class="filter"></div>
                </div>
                <div class="container-fluid chartContainer col-lg-auto">
                    <span class="chartHeading">Frequency of Near Miss Types</span>
                    <div id="nearMissTypesChart"></div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" Runat="Server">
   <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script src="Scripts/homeValidation.js"> </script>
    <!-- Google Charts -->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="Scripts/Home.js"></script>
</asp:Content>