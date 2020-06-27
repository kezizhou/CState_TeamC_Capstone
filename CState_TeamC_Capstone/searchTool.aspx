<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchTool.aspx.cs" Inherits="CState_TeamC_Capstone.searchTool" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8"/>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.6/html5shiv.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/Site.css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="Content/searchTool.css" media="screen"/>

    <title>Near Miss Reporting - Search Tool</title>
</head>

<body>
    <div class="container">

        <div class="header">
            <img class="logo" src="Media/logo.png"/>
        </div>

        <div class="topnav">
            <a href="">Home</a>
            <a href="">Initiate Incident</a>
            <a class="active" href="">Search Tool</a>
            <a href="">Sign Out</a>
        </div>

        <form name="frmFilters" method="get" action="" runat="server">
            <h2>Norwood Safety Near Miss Search Tool</h2>
            <h5>Welcome: LastName, FirstName</h5>

            <div class="wrapper">
                <table id="filters">
                    <tr>
                        <td>
                            <select id="sltOperatorName" name="sltOperatorName">
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Operator Name</option>
                                <option value="value">Populated from database</option>
                            </select>
                        </td>
                        <td>
                            <select id="sltDepartment" name="sltDepartment">
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Department</option>
                                <option value="value">Populated from database</option>
                            </select>
                        </td>
                        <td>
                            <select id="sltNearMissType" name="sltNearMissType">
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Near Miss Type</option>
                                <option value="value">Populated from database</option>
                            </select>
                        </td>
                        <td>
                            <select id="sltAssignedTo" name="sltAssignedTo">
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Assigned To</option>
                                <option value="value">Populated from database</option>
                            </select>
                        </td>
                        <td>
                            <select id="sltSeverityLevel" name="sltSeverityLevel">
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Severity Level</option>
                                <option value="value">Populated from database</option>
                            </select>
                        </td>
                        <td>
                            <select id="sltRiskLevel" name="sltRiskLevel">
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Risk Level</option>
                                <option value="value">Populated from database</option>
                            </select>
                        </td>
                        <td>
                            <input id="txtCustomFilter" type="text" name="txtCustomFilter" placeholder="Text to search"/>
                        </td>
                        <td>
                            <button type="button" id="btnFilter" class="center" onclick="">Filter</button>
                        </td>
                        <td>
                            <button type="button" id="btnClear" class="center" onclick="">Clear Filters</button>
                        </td>
                        <td>
                            <button type="button" id="btnExport" class="center" onclick="">Export to Excel</button>
                        </td>
                    </tr>
                </table>
            </div>
        </form>

        <div class="wrapper">
            <table class="resultTable">
                <tr>
                    <th>Operator Name</th>
                    <th>Department</th>
                    <th>Near Miss Type</th>
                    <th>Assigned To</th>
                    <th>Severity Level</th>
                    <th>Risk Level</th>
                    <th>Brief Detail</th>
                </tr>
            </table>
        </div>

        <div class="push"></div>
    </div>


    <footer class="footer">
        <table>
            <tr>
                <td colspan="2">Copyright ©</td>
            </tr>
            <tr>
                <td>
                    <a href="">TERMS OF USE</a>
                </td>
                <td class="separateBorder">
                    <a href="">PRIVACY POLICY</a>
                </td>
            </tr>
        </table>
    </footer>

</body>

</html>
