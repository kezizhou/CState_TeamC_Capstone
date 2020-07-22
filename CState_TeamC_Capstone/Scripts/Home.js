// Load the Visualization API and the piechart package
google.charts.load('current', { 'packages': ['corechart'] });

// Set a callback to run when the Google Visualization API is loaded
google.charts.setOnLoadCallback(drawNearMissTypesChart);
google.charts.setOnLoadCallback(drawInjurySeverityChart);

// Draw the chart and set the chart values
function drawNearMissTypesChart() {
    var options = {
        'width': '450',
        'height': '300',
        // Use https://learnui.design/tools/data-color-picker.html for more color schemes
        'colors': ['#009999', '#008bae', '#0083bf', '#4776c7', '#7e62c0', '#ac45a6', '#ca147b', '#d30046', '#c70000'],
        'chartArea': {
            'width': '100%',
            'height': '100%',
            'left': '10',
            'top': '10'
        }
    };

    $.ajax({
        type: "POST",
        // Call the method using ajax
        url: "Home.aspx/GetNearMissTypesChartData",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Draw the chart in the specified id div
            var data = google.visualization.arrayToDataTable(response.d);
            if (data.getNumberOfRows() == 0) {
                $("#nearMissTypesChart").append("No data available");
            } else {
                var chart = new google.visualization.PieChart($("#nearMissTypesChart")[0]);
                chart.draw(data, options);
            }
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    })
}

function drawInjurySeverityChart() {
    var options = {
        'width': '800',
        'height': '300',
        // Use https://learnui.design/tools/data-color-picker.html for more color schemes
        'colors': ['#009999', '#067cd4', '#ca147b'],
        'chartArea': {
            'width': '100%',
            'height': '100%',
            'left': '10',
            'top': '10'
        },
        'isStacked': 'true'
    };

    $.ajax({
        type: "POST",
        url: "Home.aspx/GetInjurySeverityChartData",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Draw the chart in the specified id div
            var data = google.visualization.arrayToDataTable(response.d);
            if (data.getNumberOfRows() == 0) {
                $("#injurySeverityChart").append("No data available");
            } else {
                var chart = new google.visualization.ColumnChart($("#injurySeverityChart")[0]);
                chart.draw(data, options);
            }
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    })
}