<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="initiatePage.aspx.cs" Inherits="CState_TeamC_Capstone.initiatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8"/>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.6/html5shiv.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/Site.css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="Content/InitiatePage.css" media="screen"/>

    <title>Near Miss Reporting - New Incident</title>
</head>

<body>
    <div class="container">

        <div class="header">
            <img class="logo" src="Media/logo.png"/>
        </div>

        <div class="topnav">
            <a href="">Home</a>
            <a class="active" href="">Initiate Incident</a>
            <a href="">Sign Out</a>
        </div>

        <form name="frmNewIncident" method="get" action="" runat="server">
            <h2>Norwood Safety Near Miss Reporting</h2>
            <h5>Welcome: LastName, FirstName</h5>

            <!--Moved to the top for easy viewing-->
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

            <table class="formTable">
                <tr>
                    <td>
                        <label for="dteIncident">Date of Near Miss:</label>
                    </td>
                    <td>
                        <img src="calendarplaceholder.png">
                        <h6>The near miss occurred on:</h6>
                        <h6>[mm/dd/yyyy]</h6>
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

            <!--Moved to the bottom for easy submission-->
            <div>
                <button type="button" id="btnSubmit" class="center" onclick="incompleteInput()">Submit Near Miss</button>
            </div>

        </form>

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