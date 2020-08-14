<%@ Page Title="Review Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reviewIncident.aspx.cs" Inherits="CState_TeamC_Capstone.reviewIncident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/reviewIncident.css" media="screen" />

    <!-- These must be placed before modal -->
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>

    <script src="Scripts/reviewIncidentPopup.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Review Incident</h2>
        <h5>Welcome: <span id="userFullName" runat="server"></span></h5>

        <div class="container">
            <div id="messageDiv" class="message center2" runat="server"><h5 id="confirmMessage" runat="server">This incident has already been reviewed.</h5></div>
        </div>

        <div class="container">
            <!-- Review Incident Form -->
            <form id="frmReviewIncident" name="frmReviewIncident" method="post" action="#" runat="server">
                <div class="form-group container">
                    <label for="sltNearMissReportID" class="control-label">Select Near Miss Incident ID:</label>
                    <asp:DropDownList runat="server" ID="sltNearMissReportID" name="sltNearMissReportID" class="required form-control" OnSelectedIndexChanged="Filter" AutoPostBack="True">
                    </asp:DropDownList>
                </div>

                <!-- Results table -->
                <div class="container">
                    <div class="table-responsive">
                        <table id="resultTable" class="table">
                            <thead class="thead-light">
                                <tr>
                                    <th scope="col">Near Miss ID</th>
                                    <th scope="col">Operator Name</th>
                                    <th scope="col">Department</th>
                                    <th scope="col">Near Miss Type</th>
                                    <th scope="col">Near Miss Detail</th>
                                    <th scope="col">Action Taken</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var x in results)
                                    {%><tr>

                                        <th scope="row"><%= x?.ID%></th>
                                        <td class="align-middle"><%= x?.OperatorName%></td>
                                        <td class="align-middle"><%= x?.Department%></td>
                                        <td class="align-middle"><%= x?.NearMissType%></td>
                                        <td class="align-middle"><%= x?.NearMiss_Solution%></td>
                                        <td class="align-middle"><%= x?.NearMiss_ActionTaken%></td>
                                    </tr>
                                <%};%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="container">
                    <div class="form-group">
                        <label for="sltAssignIncident" class="control-label">Assign Near Miss Incident:</label>
                        <select id="sltAssignIncident" name="sltAssignIncident" class="required form-control">
                            <option value="none" selected="selected" disabled="disabled">Assign Near Miss to..</option>
                            <% foreach (var x in assignTo)
                                {%><option value="<%= x.Description%>">

                                    <%= x.Description%>
                            
                                </option>
                            <%};%>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="sltSeverityLevel" class="control-label">Severity of Injury:</label>
                        <select id="sltSeverityLevel" name="sltSeverityLevel" class="required form-control">
                            <option value="none" selected="selected" disabled="disabled">Severity Level</option>
                            <% foreach (var x in severity)
                                {%><option value="<%= x.ID%>">

                                    <%= x.Description%>
                            
                                </option>
                            <%};%>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="sltRiskLevel" class="control-label">Risk Level:</label>
                        <select id="sltRiskLevel" name="sltRiskLevel" class="required form-control">
                            <option value="none" selected="selected" disabled="disabled">Risk Level</option>
                            <% foreach (var x in risk)
                                {%><option value="<%= x.ID%>">

                                    <%= x.Description%>
                            
                                </option>
                            <%};%>
                        </select>
                    </div>
                    <div class="container">
                        <asp:Button runat="server" ID="btnSubmit" class="btn btn-primary btn-sm center" Text="Submit" OnClick="InsertReviewLog" />
                    </div>
                </div>
                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Update Record</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                Success! Near Miss Record Updated.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script type ="text/javascript">
        $(function () {
            $.validator.addMethod("dropDownValidator", function (value, element, param) {
                if (value == '-1')
                    return false;
                else
                    return true; 
            }, "This field is required.");

            $("#frmReviewIncident").validate({
                rules: {
                    <%=sltNearMissReportID.UniqueID %>: {
                        dropDownValidator: true,
                    },
                    sltAssignIncident: {
                        required: true,
                    },
                    sltSeverityLevel: {
                        required: true,
                    },
                    sltRiskLevel: {
                        required: true,
                    },
                },
                messages: {
                    <%=sltNearMissReportID.UniqueID %>: {
                        dropDownValidator: "Select a report to modify"
                    },
                    sltAssignIncident: "Select person to assign to",
                    sltSeverityLevel: "Select severity of injury",
                    sltRiskLevel: "Select risk level"
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
        });
    </script>
</asp:Content>
