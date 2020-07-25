<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CState_TeamC_Capstone.Home" Title="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/Home.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <main role="main" class="container-fluid">
        <h2>Near Miss Incident Dashboard</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <div id="lastIncidentDescription" class="lastIncidentDescription" runat="server">
            <span class="chartHeading text-center">Last Reported Incident Occurred: </span>
            <span id="lastIncident" class="lastIncident" runat="server"></span>
            days ago
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
                <div class="container-fluid chartContainer col-md-auto">
                    <span class="chartHeading">Frequency of Near Miss Types</span>
                    <div id="nearMissTypesChart"></div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" Runat="Server">
    <!-- Google Charts -->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="Scripts/Home.js"></script>
</asp:Content>