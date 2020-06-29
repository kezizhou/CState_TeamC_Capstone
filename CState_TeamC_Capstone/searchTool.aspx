<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchTool.aspx.cs" Inherits="CState_TeamC_Capstone.searchTool" %>

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
    <link rel="stylesheet" type="text/css" href="Content/searchTool.css" media="screen"/>

    <title>Near Miss Reporting - Search Tool</title>
</head>

<body>

    <header>
        <!-- Title -->
        <div class="header">
            <h1>Near Miss Incident Reporting Tool</h1>
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
                    <a class="nav-item nav-link" href="#">Home</a>
                    <a class="nav-item nav-link" href="~/initiatePage.aspx" runat="server">Initiate Incident</a>
                    <a class="nav-item nav-link active" href="#">Search Tool<span class="sr-only">(current)</span></a>
                </div>
                <div class="navbar-nav ml-auto">
                    <a class="nav-item nav-link" id="signout" href="~/signIn.aspx" runat="server">Sign Out</a>
                </div>
            </div>
        </nav>
    </header>


    <main role="main" class="container-fluid">
        <h2>Norwood Safety Near Miss Search Tool</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <!-- Search filters -->
        <form name="frmFilters" id="frmFilters" method="get" action="#" runat="server">
            <div class="container-fluid">
                <i class="fas fa-filter"></i>
                <select id="sltOperatorName" name="sltOperatorName">
                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Operator Name</option>
                    <option value="value">Populated from database</option>
                </select>
                <select id="sltDepartment" name="sltDepartment">
                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Department</option>
                    <option value="value">Populated from database</option>
                </select>
                <select id="sltNearMissType" name="sltNearMissType">
                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Near Miss Type</option>
                    <option value="value">Populated from database</option>
                </select>
                <select id="sltAssignedTo" name="sltAssignedTo">
                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Assigned To</option>
                    <option value="value">Populated from database</option>
                </select>
                <select id="sltSeverityLevel" name="sltSeverityLevel">
                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Severity Level</option>
                    <option value="value">Populated from database</option>
                </select>
                <select id="sltRiskLevel" name="sltRiskLevel">
                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Risk Level</option>
                    <option value="value">Populated from database</option>
                </select>
                <input id="txtCustomFilter" type="text" name="txtCustomFilter" placeholder="Text to search"/>    
                <button type="button" id="btnFilter" class="btn btn-secondary btn-sm" onclick="">Filter</button>     
                <button type="button" id="btnClear" class="btn btn-secondary btn-sm" onclick="">Clear Filters</button>    
                <button type="button" id="btnExport" class="btn btn-secondary btn-sm" onclick="">Export to Excel</button>
            </div>
        </form>

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

</body>

</html>