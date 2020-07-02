<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="initiateIncident.aspx.cs" Inherits="CState_TeamC_Capstone.initiateIncident" Title="New Incident"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/initiateIncident.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <main role="main" class="container-fluid">
        <h2>Report a New Incident</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <!-- Validation for incomplete form -->
        <div id="incompleteInput" class="incompleteInput center">
            Please correct the following:
            <ul>
                <li>Enter badge number.</li>
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
                            <!-- Populated from account info in database -->
                            <input id="txtOperator" type="text" name="txtOperator" value="FirstName LastName" readonly="readonly" class="populated"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="txtBadgeNumber">Badge Number:</label>
                        </td>
                        <td>
                            <input id="txtBadgeNumber" type="text" name="txtBadgeNumber"/>
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" Runat="Server">
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
</asp:Content>