<%@ Page Title="Update Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateIncident.aspx.cs" Inherits="CState_TeamC_Capstone.updateIncident" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/reviewIncident.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Update Incident Action</h2>
        <h5>Welcome: <span id="userFullName" runat="server"></span></h5>

        <div class="container">
            <div id="messageDiv" class="message center2" runat="server"><h5 id="confirmMessage" runat="server">You are unauthorized to update actions for this incident. Please try an incident in the dropdown below.</h5></div>
        </div>

        <div class="container">
            <!-- Update Incident Action Form -->
            <form id="frmUpdateIncident" name="frmUpdateIncident" method="post" action="#" runat="server">
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
                                    <th scope="col">Assigned To</th>
                                    <th scope="col">Severity Level</th>
                                    <th scope="col">Risk Level</th>
                                    <th scope="col">Near Miss Detail</th>
                                    <th scope="col">Action Taken</th>
                                    <th scope="col">Additional Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var x in results)
                                    {%><tr>

                                    <th scope="row"><%= x?.ID%></th>
                                    <td class="align-middle"><%= x?.OperatorName%></td>
                                    <td class="align-middle"><%= x?.Department%></td>
                                    <td class="align-middle"><%= x?.NearMissType%></td>
                                    <td class="align-middle"><%= x?.AssignedTo%></td>
                                    <td class="align-middle"><%= x?.SeverityType%></td>
                                    <td class="align-middle"><%= x?.RiskType%></td>
                                    <td class="align-middle"><%= x?.NearMiss_Solution%></td>
                                    <td class="align-middle"><%= x?.NearMiss_ActionTaken%></td>
                                    <td class="align-middle"><%= x?.Additional_Actions_Taken%></td>
                                </tr>
                                <%};%>
                            </tbody>
                        </table>
                    </div>
                </div>
            
                <div class="container">
                    <div class="form-group">
                        <label for="txaActionUpdate" class="control-label">Action Update: </label>
                        <textarea name="txaActionUpdate" id="txaActionUpdate" class="form-control" rows="9"></textarea>
                    </div>
                    <div class="container">
                        <asp:Button runat="server" ID="btnSubmit" class="btn btn-primary btn-sm center" Text="Update" OnClick="InsertUpdateAction" />
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

            $("#frmUpdateIncident").validate({
                rules: {
                    <%=sltNearMissReportID.UniqueID %>: {
                        dropDownValidator: true,
                    },
                    txaActionUpdate: {
                        required: true,
                        minlength: 5
                    }
                },
                messages: {
                    <%=sltNearMissReportID.UniqueID %>: {
                        dropDownValidator: "Select a report to modify"
                    },
                    txaActionUpdate: {
                        required: "Enter updated actions",
                        minlength: "Update must be at least 5 characters"
                    }
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });
        });
    </script>
</asp:Content>
