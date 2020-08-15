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
            height: '90%',
        },
        legend: {
            textStyle: {
                color: '#757575',
                fontName: 'Roboto',
                fontSize: '15'
            }
        },
        sliceVisibilityThreshold: 0
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
                $("#riskSeverityChart").append("No data available");
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

        var options = {
            // Use https://learnui.design/tools/data-color-picker.html for more color schemes
            colors: colors,
            isStacked: 'true',
            height: '400',
            width: data.getNumberOfRows() * 105 + 400,
            bar: {
                groupWidth: '75%'
            },
            hAxis: {
                title: ''
            },
            //vAxis: {
            //    viewWindow: {
            //        // Change this number to a multiple of 6 to have whole number y-axis labels
            //        min: '0',
            //        max: '6'
            //    }
            //},
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
            },
            chart: {
                title: 'Incidents Severity and Risk by Department'
            }
        };

        // Chart Wrapper
        var chart = new google.visualization.ChartWrapper({
            chartType: 'Bar',
            containerId: 'riskSeverityChart',
            options: google.charts.Bar.convertOptions(options)
        });

        var initState = { selectedValues: [] };

        // Control Wrapper
        var columnFilter = new google.visualization.ControlWrapper({
            controlType: 'CategoryFilter',
            containerId: 'srByDepartmentFilter',
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

        google.visualization.events.addListener(dashboard, 'ready', function () {
            // Dashboard redraw, look at how many rows are displayed
            var numRows = chart.getDataTable().getNumberOfRows();
            var expectedWidth = numRows * 105 + 365;
            if (parseInt(chart.getOption("width"), 10) != expectedWidth) {
                // Update chart options and redraw
                chart.setOption("width", expectedWidth);
                chart.draw();
            }
        })

        dashboard.bind(columnFilter, chart);
        dashboard.draw(data);
    }

}

// Near Miss Types Column Chart
function drawDepartmentNearMissTypesChart() {
    var colors = ['#c55d86', '#75b74b', '#c15abc', '#009999', '#7768ca', '#c69442', '#6c93d0', '#cb5842', '#6f823b'];

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

        // For near miss type filter
        var nearMissInitState = { selectedValues: [] };
        for (var i = 1; i < data.getNumberOfColumns(); i++) {
            columnsTable.addRow([i, data.getColumnLabel(i)]);
        }

        var options = {
            isStacked: 'true',
            height: '385',
            width: data.getNumberOfRows() * 130 + 335,
            bar: {
                groupWidth: '75%'
            },
            hAxis: {
                title: ''
            },
            //vAxis: {
            //    viewWindow: {
            //        // Change this number to a multiple of 6 to have whole number y-axis labels
            //        max: '6',
            //        min: '0'
            //    }
            //},
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
            },
            chart: {
                title: 'Incident Types by Department'
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

        // Near Miss Type Control Wrapper
        var nearMissColumnFilter = new google.visualization.ControlWrapper({
            controlType: 'CategoryFilter',
            containerId: 'nearMissTypeFilter',
            dataTable: columnsTable,
            options: {
                filterColumnLabel: 'colLabel',
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

        function setChartView() {
            var state = nearMissColumnFilter.getState();
            var row;
            var view = {
                columns: [0]
            }

            if (state.selectedValues.length == 0) {
                for (var i = 0; i < columnsTable.getNumberOfRows(); i++) {
                    value = columnsTable.getValue(i, 0);
                    view.columns.push(value);
                }
            } else {
                for (var i = 0; i < state.selectedValues.length; i++) {
                    row = columnsTable.getFilteredRows([{ column: 1, value: state.selectedValues[i] }])[0];
                    view.columns.push(columnsTable.getValue(row, 0));
                }

                // Sort the indices into their original order
                view.columns.sort(function (a, b) {
                    return (a - b);
                });
            }

            // Keep original colors
            chart.getOptions().series = [];
            for (var i = 1; i < view.columns.length; i++) {
                chart.getOptions().series.push({ color: colors[view.columns[i] - 1] });
            }

            chart.setView(view);

            // Dashboard
            var dashboard = new google.visualization.Dashboard();

            google.visualization.events.addListener(dashboard, 'ready', function () {
                // Dashboard redraw, look at how many rows are displayed
                var numRows = chart.getDataTable().getNumberOfRows();
                var expectedWidth = numRows * 130 + 330;
                if (parseInt(chart.getOption("width"), 10) != expectedWidth) {
                    // Update chart options and redraw
                    chart.setOption("width", expectedWidth);
                    chart.draw();
                }
                if (numRows == 1) {
                    chart.setOption("height", "90%");
                    chart.setOption("width", "510");
                }
            })

            dashboard.bind(columnFilter, chart);
            dashboard.draw(data);
        }

        google.visualization.events.addListener(nearMissColumnFilter, 'statechange', setChartView);
        setChartView();
        nearMissColumnFilter.draw();
    }
}


function resetForm() {
    document.getElementById("frmDateRange").reset();
}