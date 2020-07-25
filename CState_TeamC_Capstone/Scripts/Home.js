// Load the Visualization API and the piechart package
google.charts.load('current', {
    packages: ['corechart', 'controls', 'bar']
});

// Set a callback to run when the Google Visualization API is loaded
google.charts.setOnLoadCallback(drawNearMissTypesChart);
google.charts.setOnLoadCallback(drawInjurySeverityChart);
google.charts.setOnLoadCallback(drawDepartmentNearMissTypesChart);

// Pie Chart
function drawNearMissTypesChart() {
    var options = {
        // For more color schemes: 
        // https://learnui.design/tools/data-color-picker.html
        // https://color.adobe.com/create/color-wheel
        // https://medialab.github.io/iwanthue/
        //colors: ['#73265E', '#BFB165', '#BF52A2', '#009999', '#437575', '#993900', '#620F99', '#084D99', '#089947'],
        colors: ['#c55d86', '#75b74b', '#c15abc', '#009999', '#7768ca', '#c69442', '#6c93d0', '#cb5842', '#6f823b'],
        chartArea: {
            width: '100%',
            height: '425',
            left: '10',
            top: '10'
        },
        sliceVisibilityThreshold: .05,
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

// Severity Risk Column Chart
function drawInjurySeverityChart() {
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
                ajaxSuccess(data);
            }
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    })

    function ajaxSuccess(data) {
        var colors = ['#009999', '#c15abc']

        // Columns table
        var columnsTable = new google.visualization.DataTable();
        columnsTable.addColumn('number', 'colIndex');
        columnsTable.addColumn('string', 'colLabel');

        for (var i = 0; i < data.getNumberOfRows(); i++) {
            columnsTable.addRow([i, data.getValue(i, 0)]);
        }

        var options = {
            // Use https://learnui.design/tools/data-color-picker.html for more color schemes
            colors: colors,
            isStacked: 'true',
            height: '425',
            width: data.getNumberOfRows() * 200,
            bar: {
                groupWidth: '75%'
            },
            vAxis: {
                viewWindow: {
                    // Change this number to a multiple of 6 to have whole number y-axis labels
                    min: '0',
                    max: '6'
                }
            },
            vAxes: {
                0: {},
                1: {
                    gridlines: {
                        color: 'transparent'
                    },
                    textStyle: {
                        color: 'transparent'
                    }
                },
            },
            series: {
                3: {
                    targetAxisIndex: 1
                },
                4: {
                    targetAxisIndex: 1
                },
                5: {
                    targetAxisIndex: 1
                }
            }
        };

        // Chart Wrapper
        var chart = new google.visualization.ChartWrapper({
            chartType: 'Bar',
            containerId: 'riskSeverityChart',
            //dataTable: data,
            options: google.charts.Bar.convertOptions(options)
        });

        var initState = { selectedValues: [] };

        // Control Wrapper
        var columnFilter = new google.visualization.ControlWrapper({
            controlType: 'CategoryFilter',
            containerId: 'srByDepartmentFilter',
            //dataTable: columnsTable,
            options: {
                filterColumnLabel: 'Departments',
                //useFormattedValue: true,
                ui: {
                    label: 'Department: ',
                    allowTyping: false,
                    allowMultiple: true,
                    caption: 'All Departments',
                    allowNone: true,
                    selectedValuesLayout: 'below'
                },
            },
            state: initState
        })

        // Dashboard
        var dashboard = new google.visualization.Dashboard();
        dashboard.bind(columnFilter, chart);
        dashboard.draw(data);
    }

}

// Near Miss Types Column Chart
function drawDepartmentNearMissTypesChart() {
    $.ajax({
        type: "POST",
        url: "Home.aspx/GetDepartmentNearMissTypesChartData",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Draw the chart in the specified id div
            var data = google.visualization.arrayToDataTable(response.d);
            if (data.getNumberOfRows() == 0) {
                $("#departmentNearMissTypesChart").append("No data available");
            } else {
                ajaxSuccess(data);
            }
        },
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    })


    function ajaxSuccess(data) {
        // Columns table
        var columnsTable = new google.visualization.DataTable();
        columnsTable.addColumn('number', 'colIndex');
        columnsTable.addColumn('string', 'colLabel');

        for (var i = 0; i < data.getNumberOfRows(); i++) {
            columnsTable.addRow([i, data.getValue(i, 0)]);
        }

        var options = {
            legend: {
                position: 'top',
                maxLines: '2'
            },
            isStacked: 'true',
            height: '100%',
            width: data.getNumberOfRows() * 145,
            bar: {
                groupWidth: '75%'
            },
            vAxis: {
                viewWindow: {
                    // Change this number to a multiple of 6 to have whole number y-axis labels
                    max: '6',
                    min: '0'
                }
            },
            vAxes: {
                0: {},
                1: {
                    gridlines: {
                        color: 'transparent'
                    },
                    textStyle: {
                        color: 'transparent'
                    }
                },
            },
            series: {
                0: {
                    color: '#c55d86'
                },
                1: {
                    color: '#75b74b'
                },
                2: {
                    color: '#c15abc'
                },
                3: {
                    color: '#009999'
                },
                4: {
                    color: '#7768ca'
                },
                5: {
                    color: '#c69442'
                },
                6: {
                    color: '#6c93d0'
                },
                7: {
                    color: '#cb5842'
                },
                8: {
                    color: '#6f823b'
                }
            }
        };

        // Chart Wrapper
        var chart = new google.visualization.ChartWrapper({
            chartType: 'Bar',
            containerId: 'departmentNearMissTypesChart',
            options: google.charts.Bar.convertOptions(options)
        });

        // Department Control Wrapper
        var initState = { selectedValues: [] };
        var columnFilter = new google.visualization.ControlWrapper({
            controlType: 'CategoryFilter',
            containerId: 'typeByDepartmentFilter',
            options: {
                filterColumnLabel: 'Departments',
                //useFormattedValue: true,
                ui: {
                    label: 'Department: ',
                    allowTyping: false,
                    allowMultiple: true,
                    caption: 'All Departments',
                    allowNone: true,
                    selectedValuesLayout: 'belowStacked'
                },
            },
            state: initState
        })

        // Near Miss Tpe Control Wrapper
        var nearMissInitState = { selectedValues: [] };
        var nearMissColumnFilter = new google.visualization.ControlWrapper({
            controlType: 'CategoryFilter',
            containerId: 'Filter',
            //dataTable: columnsTable,
            options: {
                filterColumnLabel: 'NearMissTypes',
                //useFormattedValue: true,
                ui: {
                    label: 'Near Miss Types: ',
                    allowTyping: false,
                    allowMultiple: true,
                    caption: 'All Near Miss Types',
                    allowNone: true,
                    selectedValuesLayout: 'below'
                },
            },
            state: nearMissInitState
        })

        // Dashboard
        var dashboard = new google.visualization.Dashboard();
        dashboard.bind(columnFilter, chart);
        dashboard.draw(data);
    }

}