<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="initiatePage.aspx.cs" Inherits="CState_TeamC_Capstone.initiatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
    
    <!-- Custom CSS -->
    <link rel="stylesheet" type="text/css" href="Content/Site.css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="Content/initiatePage.css" media="screen"/>

    <title>Near Miss Reporting - New Incident</title>
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
                    <a class="nav-item nav-link" href="~/Home.aspx" runat="server">Home</a>
                    <a class="nav-item nav-link active" href="~/initiatePage.aspx" runat="server">Initiate Incident<span class="sr-only">(current)</span></a>
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
        <h2>Report a New Incident</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <!-- Validation for incomplete form -->
        <div id="incompleteInput" class="incompleteInput center">
            Please correct the following:
            <ul>
                <li>Enter operator name.</li>
                <li>Select department.</li>
                <li>Select near miss type.</li>
                <li>Provide near miss detail.</li>
                <li>Provide description for action taken.</li>
            </ul>
        </div>

        <!-- Form -->
        <form name="frmNewIncident" method="get" action="#" runat="server">
            <div class="row justify-content-center">
                <table class="formTable">
                    <tr>
                        <td>
                            <label for="dteIncident">Date of Near Miss:</label>
                        </td>
                        <td>
                            <input id="dteIncident" name="dteIncident" type="date" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="txtOperator">Operator Name:</label>
                        </td>
                        <td>
                            <input id="txtOperator" type="text" name="txtOperator"/>
                        </td>
                    </tr>
                    <tr>
                        <td> <label for="sltDepartment">Department:</label> </td>
                        <td>
                            <select id="sltDepartment" name="sltDepartment">
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select Production Area</option>
                                <option value="value">These will be populated from database</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td> <label for="sltType">Type of Near Miss:</label> </td>
                        <td>
                            <select id="sltType" name="sltType">
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select Near Miss</option>
                                <option value="value">These will be populated from database</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td> <label for="txaDescription"> Near Miss/Proposed Solution: </label> </td>
                        <td>
                            <textarea name="txaDescription" id="txaDescription"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td> <label for="txaActionTaken"> Action Taken: </label> </td>
                        <td>
                            <textarea name="txaActionTaken" id="txaActionTaken"></textarea>
                        </td>
                    </tr>
                </table>
            </div>

            <div>
                <button type="button" id="btnSubmit"  class="btn btn-primary btn-sm center" onclick="incompleteInput()">Submit Near Miss</button>
            </div>
        </form>

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

</body>

</html>


<script>
    function incompleteInput() {
        var x = document.getElementById("incompleteInput");
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
        }

        window.scrollTo(0, 0);
    }
</script>