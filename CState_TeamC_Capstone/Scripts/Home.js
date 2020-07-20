// Load the Visualization API and the piechart package
google.charts.load('current', { 'packages': ['corechart'] });

// Set a callback to run when the Google Visualization API is loaded
google.charts.setOnLoadCallback(drawChart);

// Draw the chart and set the chart values
function drawChart() {
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

    $.ajax({
        type: "POST",
        // Call the method using ajax
        url: "Home.aspx/GetNearMissTypesChartData",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            // Draw the chart in the specified id div
            var data = google.visualization.arrayToDataTable(r.d);
            var chart = new google.visualization.PieChart($("#nearMissTypesChart")[0]);
            chart.draw(data, options);
        },
        failure: function (r) {
            alert(r.d);
        },
        error: function (r) {
            alert(r.d);
        }
    })
}