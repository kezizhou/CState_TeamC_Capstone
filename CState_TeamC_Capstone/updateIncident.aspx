<%@ Page Title="Update Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateIncident.aspx.cs" Inherits="CState_TeamC_Capstone.updateIncident" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Content/reviewIncident.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Update Incident Action</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <!-- Form -->
        <form name="frmUpdateIncident" method="get" action="#" runat="server">

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
                            <td>FirstName LastName</td>
                            <td>Medium</td>
                            <td>Low</td>
                            <td>This is a paragraph of brief detail describing the incident.</td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <div class="row justify-content-center">
            <table class="formTable">
                <tr>
                    <td> <label for="txaActionUpdate"> Action Update: </label> </td>
                    <td>
                        <textarea name="txaActionUpdate" id="txaActionUpdate"></textarea>
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
