<%@ Page Title="Review Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reviewIncident.aspx.cs" Inherits="CState_TeamC_Capstone.reviewIncident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Content/reviewIncident.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Review Incident</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <!-- Form -->
        <form name="frmReviewIncident" method="get" action="#" runat="server">

            <div style="display: flex; justify-content: center;">
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
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>This is a paragraph of brief detail describing the incident.</td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div class="row justify-content-center">

                <table class="formTable">
                    
                    <tr>
                    <td>
                        <label for="sltAssignIncident">Assign Near Miss Incident:</label>
                    </td>
                    <td>
                        <select id="sltAssignIncident" name="sltAssignIncident">
                            <option value="none" selected="selected" disabled="disabled" hidden="hidden">Assign Near Miss to..</option>
                            <option value="value">These will be populated from database</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="sltInjurySeverity">Severity of Injury:</label>
                    </td>
                    <td>
                        <select id="sltInjurySeverity" name="sltInjurySeverity">
                            <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select Severity of Injury</option>
                            <option value="value">These will be populated from database</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="sltRiskLevel">Risk Level:</label>
                    </td>
                    <td>
                        <select id="sltRiskLevel" name="sltRiskLevel">
                            <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select Risk Level</option>
                            <option value="value">These will be populated from database</option>
                        </select>
                    </td>
                </tr>

                </table>
            </div>

            <div>
                <button type="button" id="btnSubmit" class="btn btn-primary btn-sm center" onclick="incompleteInput()">Submit</button>
            </div>
        </form>

    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
