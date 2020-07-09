<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="initiateIncident.aspx.cs" Inherits="CState_TeamC_Capstone.initiateIncident" Title="New Incident"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/initiateIncident.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <main role="main" class="container-fluid">
        <h2>Report a New Incident</h2>
        <h5>Welcome: LastName, FirstName</h5>

            <div class="incompleteInput" id="incompleteWrapper">
                <span>Please correct the following:</span>
                <ul id="incompleteInput">
                    <!-- Validation message from Jquery goes here -->
                </ul>
            </div>

        <!-- Form -->
        <form name="frmNewIncident" id="frmNewIncident" method="post" action="#" runat="server">
    
            <div class="row justify-content-center">
                <table class="formTable">
                    <tr>
                        <td>
                            <label for="dteIncident">Date of Near Miss:</label>
                        </td>
                        <td>
                            <input id="dteIncident" name="dteIncident" type="date" required="required"/>
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
                            <input id="txtBadgeNumber" type="text" name="txtBadgeNumber" required="required"/>
                        </td>
                    </tr>
                    <tr>
                        <td> <label for="sltDepartment">Department:</label> </td>
                        <td>
                            <select id="sltDepartment" name="sltDepartment" class="required">
                                <option value="" selected="selected" disabled="disabled" hidden="hidden">Select Production Area</option>
                                <option value="value">These will be populated from database</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td> <label for="sltType">Type of Near Miss:</label> </td>
                        <td>
                            <select id="sltType" name="sltType" class="required">
                                <option value="" selected="selected" disabled="disabled" hidden="hidden">Select Near Miss</option>
                                <option value="value">These will be populated from database</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td> <label for="txaSolution"> Near Miss Proposed Solution: </label> </td>
                        <td>
                            <textarea name="txaSolution" id="txaSolution" required="required"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td> <label for="txaActionTaken"> Action Taken: </label> </td>
                        <td>
                            <textarea name="txaActionTaken" id="txaActionTaken" required="required"></textarea>
                        </td>
                    </tr>
                  
                </table>
            </div>

            <div>
                <button type="submit" id="btnSubmit" class="btn btn-primary btn-sm center" >Submit Near Miss</button>
           </div>
        </form>

    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" Runat="Server">
    <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script src="Scripts/initiateIncident.js"></script>
</asp:Content>