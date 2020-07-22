<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CState_TeamC_Capstone.Home" Title="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/Home.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <main role="main" class="container-fluid">
        <h2>Near Miss Incident Dashboard</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <div class="container-fluid">
            <div class="row">
                <div class="container-fluid chartContainer col-sm-auto">
                    <span class="chartHeading">Frequency of Near Miss Types</span>
                    <div id="nearMissTypesChart"></div>
                </div>
                <div class="container-fluid chartContainer col-sm-auto">
                    <span class="chartHeading">Last Reported Incident Occurred</span>
                    <div id="recentIncidentChart">
                        <div class="d-inline align-self-center">
                            <h1 id="lastIncident" class="dataLabel" runat="server">7</h1>
                            <div id="lastIncidentDescription" class="centerDescription" runat="server">days ago</div>
                        </div>
                    </div>
                </div> 
                <div class="container-fluid chartContainer col-sm-auto">
                    <span class="chartHeading">Incident Severity of Injury by Department</span>
                    <div id="injurySeverityChart"></div>
                </div>
                <div class="container-fluid chartContainer col-sm-auto">
                    <span class="chartHeading">Chart 4</span>
                    <div id="chart4"></div>
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