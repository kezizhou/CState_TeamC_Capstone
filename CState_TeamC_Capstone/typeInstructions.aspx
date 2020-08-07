<%@ Page Title="Update Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="typeInstructions.aspx.cs" Inherits="CState_TeamC_Capstone.typeInstructions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Site.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Near Miss Action Instructions</h2>
        <h2> <span id="nearmisstype" class="align-center" runat="server">
            </span>
        </h2>

        <!-- Form -->
        <form name="frmTypeInstructions" method="get" action="#" runat="server">
            <div class="form-group">
                <label for="txtNearMissType_ID" class="control-label" hidden="hidden">Operator Name:</label>
            </div>

            <div class="table-responsive">
                <table id="nearmissInitialInstructions" class="table">
                    <thead class="thead-light">
                        <tr>
                            <%--<th scope="col">Near Miss Type ID</th>
                            <th scope="col">Near Miss Type</th>
                            <th scope="col">Instructions</th>--%>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th class="align-middle" scope="row" rowspan="<%= lstNMTypeInstructions.Count + 1%>">Instructions</th>
                        </tr>
                        <% foreach (var request in lstNMTypeInstructions) { %>
                            <tr>

                                <td class="align-left"><%= request.strI_Ins %></td>
                            </tr> 
                        <% } %>
                    </tbody>
                </table>
            </div>
        </form>
    </main>
 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">

</asp:Content>
