<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CState_TeamC_Capstone.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/65ffd49b86.js" crossorigin="anonymous"></script>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
    
    <!-- Custom CSS -->
    <link rel="stylesheet" type="text/css" href="Content/Site.css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="Content/Home.css" media="screen"/>

    <title>Near Miss Reporting - Home</title>
</head>

<body>

    <header>
        <!-- Title -->
        <div class="header">
            <h1>Near Miss Incident Dashboard</h1>
        </div>

        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark">
            <span class="navbar-brand mb-0 h1">
                <img src="Media/logo.png" class="logo"/>
            </span>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarText">
                <div class="navbar-nav">
                    <a class="nav-item nav-link active" href="#">Home<span class="sr-only">(current)</span></a>
                    <a class="nav-item nav-link" href="~/initiatePage.aspx" runat="server">Initiate Incident</a>
                    <a class="nav-item nav-link" href="~/searchTool.aspx" runat="server">Search Tool</a>
                </div>
                <div class="navbar-nav ml-auto">
                    <a class="nav-item nav-link" id="signout" href="~/signIn.aspx" runat="server">
                        <span id="userinitials" class="navbar-text userInitials rounded-circle">
                            <!-- User initials here -->
                            XX
                        </span>
                        Sign Out
                    </a>
                </div>
            </div>
        </nav>
    </header>


    <main role="main" class="container-fluid">
        <h2>Near Miss Incident Search Tool</h2>
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

    <footer class="footer">
        <div class="container-fluid">
            Copyright © 2020 Cincinnati State Capstone Team C
        </div>
    </footer>


    <!-- JavaScript for Bootstrap -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>

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

</body>

</html>