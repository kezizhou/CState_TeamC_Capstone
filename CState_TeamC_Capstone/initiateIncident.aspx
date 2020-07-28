<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="initiateIncident.aspx.cs" Inherits="CState_TeamC_Capstone.initiateIncident" Title="New Incident"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/initiateIncident.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <main role="main" class="container-fluid">
        <h2>Report a New Incident</h2>
        <h5>Welcome:  <span id="firstnamelastname" class="control-label" runat="server">
             <!-- User initials here -->
             XX
            </span>
        </h5>
        <!-- Form -->
        <div class="container">
            <form name="frmNewIncident" id="frmNewIncident" method="post" action="#" runat="server">
                <div class="form-group">
                    <label for="dteIncident" class="control-label">Date of Near Miss:</label>
                    <input id="dteIncident" name="dteIncident" class="form-control" type="date" required="required"/>
                </div>
                <div class="form-group">
                    <label for="txtOperator" class="control-label">Operator Name:</label>
                    <!-- Populated from account info in database -->              
                  <input id="txtOperator" type="text" name="txtOperator" class="form-control populated" value="FirstName LastName" readonly="readonly"/>
                </div>
                <div class="form-group">
                    <label for="txtBadgeNumber" class="control-label">Badge Number:</label>
                    <input id="txtBadgeNumber" type="text" name="txtBadgeNumber" class="form-control" required="required"/>
                </div>
                <div class="form-group" id="departmentDiv">
                    <label for="sltDepartment" class="control-label">Department:</label>
                    <select id="sltDepartment" name="sltDepartment" runat="server" class="required form-control" >
                        <option value=""  selected="selected" disabled="disabled" hidden="hidden">Select Production Area</option>               
                    </select>
                       </div>

                <div class="form-group">
                    <label for="sltType" class="control-label">Type of Near Miss:</label>
                    <select id="sltType" name="sltType" class="required form-control" runat="server" >
                        <option value="" selected="selected" disabled="disabled" hidden="hidden">Select Near Miss</option>
                    </select>
                 </div>

                <div class="form-group">
                    <label for="txaSolution" class="control-label"> Near Miss Proposed Solution: </label>
                    <textarea name="txaSolution" id="txaSolution" class="form-control" rows="8" required="required"></textarea>
                </div>

                <div class="form-group">
                    <label for="txaActionTaken" class="control-label"> Action Taken: </label>
                    <textarea name="txaActionTaken" id="txaActionTaken" class="form-control" rows="8" required="required"></textarea>
                </div>
                
                <div class="container">
                    <button type="submit" id="btnSubmit" class="btn btn-primary btn-sm center" runat="server" onserverclick="btnSubmit_Click">Submit New User</button>
                </div>
            </form>
        </div>
    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" Runat="Server">
    <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script src="Scripts/initiateIncident.js"></script>
</asp:Content>