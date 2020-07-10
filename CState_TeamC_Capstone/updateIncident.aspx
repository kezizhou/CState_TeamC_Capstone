<%@ Page Title="Update Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateIncident.aspx.cs" Inherits="CState_TeamC_Capstone.updateIncident" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/reviewIncident.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Update Incident Action</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <div class="center2">
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

        <div class="container">
            <!-- Update Incident Action Form -->
            <form id="frmUpdateIncident" name="frmUpdateIncident" method="post" action="#" runat="server">
                <div class="form-group">
                    <label for="txaActionUpdate" class="control-label"> Action Update: </label>
                    <textarea name="txaActionUpdate" id="txaActionUpdate" class="form-control" rows="9"></textarea>
                </div>
                <div class="container">
                    <button type="submit" id="btnSubmit" class="btn btn-primary btn-sm center">Submit</button>
                </div>
            </form>
        </div>

    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script src="Scripts/updateIncident.js"></script>
</asp:Content>
