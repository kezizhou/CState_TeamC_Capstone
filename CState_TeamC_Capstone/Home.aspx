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
                        <h1 class="dataLabel">7</h1>
                        <div class="centerDescription">days ago</div>
                    </div>
                </div> 
                <div class="container-fluid chartContainer col-sm-auto">
                    <span class="chartHeading">Chart 3</span>
                    <div id="chart3"></div>
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
    <!-- Placeholder charts, coding method can be changed later -->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        // Load google charts
        google.charts.load('current', {'packages':['corechart']});
        google.charts.setOnLoadCallback(drawChart);

        // Draw the chart and set the chart values
        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['Near Miss Type', 'Number of Incidents'],
                ['Spill', 8],
                ['Hazardous Waste', 2],
                ['Damaged Machinery', 4],
                ['Near Miss Type 1', 2],
                ['Other', 8]
            ]);

            var options = {
                'width': '450',
                'height': '300',
                // Use https://learnui.design/tools/data-color-picker.html for more color schemes
                'colors': ['#009999', '#008bae', '#0077b9', '#575cad', '#883886', '#99004d'],
                'chartArea': {
                    'width': '100%',
                    'height': '100%',
                    'left': '10',
                    'top': '10'
                }
            };

            // Display the chart inside the <div> element with id="piechart"
            var chart = new google.visualization.PieChart(document.getElementById('nearMissTypesChart'));
            chart.draw(data, options);
        }
    </script>
</asp:Content>