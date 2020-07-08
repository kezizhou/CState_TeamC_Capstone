<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="initiateIncident_asp.aspx.cs" Inherits="CState_TeamC_Capstone.initiateIncident_asp" Title="New Incident"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Content/initiateIncident.css" media="screen"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <main role="main" class="container-fluid">
        <h2>Report a New Incident</h2>
        <h5>Welcome: LastName, FirstName</h5>

        <!-- Validation for incomplete form -->
        <!-- Form -->
        <form name="frmNewIncident" method="get" action="#" runat="server">
           <div id="incompleteInput" class="incompleteInput center">
                   
               </div>
            
            <div class="row justify-content-center">
                <table class="formTable">
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary_EHSSafetyNearMiss"
                                runat="server"
                                DisplayMode="BulletList"
                                ValidationGroup="ValidationSummary_EHSSafetyNearMiss"
                                class="incompleteInput center"
                                HeaderText="<span class='ValidationHeader'>Please correct the following: <br/></span>"/>
                            </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIncidentDate" 
                                runat="server" 
                                CssClass="label"
                                Text="Near Miss Incident Date:">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:Calendar ID="calIncidentDate" 
                                runat="server">
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblOperator" 
                                runat="server" 
                                Text="Operator Number:" 
                                CssClass="label">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbOperatorNumber" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTextbox" 
                                runat="server" 
                                ControlToValidate="tbOperatorNumber" 
                                CssClass="validationerrormessage"
                                Text="*" 
                                ErrorMessage="Operator Number required. Please enter valid number."
                                ValidationGroup="ValidationSummary_EHSSafetyNearMiss">
                            </asp:RequiredFieldValidator>

                            <asp:RangeValidator ID="rvTextbox" 
                                runat="server" 
                                MinimumValue="1" 
                                MaximumValue="999999" 
                                ControlToValidate="tbOperatorNumber"
                                Text="*" 
                                ErrorMessage="Enter a valid number."
                                ValidationGroup ="ValidationSummary_EHSSafetyNearMiss">                              
                            </asp:RangeValidator>
                      </td>
                    </tr>
                    <tr>
                        <td>
                           <asp:Label ID="lblOperatorName" 
                               runat="server" 
                               CssClass="label" 
                               Text ="Operator Name:">
                           </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblOperatorNameReturnedValue" 
                                runat="server" 
                                Text="Name will populate from database"
                                CssClass="label">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDepartment" 
                                runat="server" 
                                Text="Department:" 
                                CssClass="label">
                            </asp:Label>
                       </td>
                        <td>
                            <asp:DropDownList ID="ddlDepartment" 
                                runat="server" 
                                CssClass="dropdown dropdown-menu-left">
                                <asp:ListItem>Select Department</asp:ListItem>
                                <asp:ListItem>Will populate from database</asp:ListItem>                               
                            </asp:DropDownList>

                        <%--Dropdown list will populate from database.  
                            </asp:DropDownList>
                                  
                                     <asp:DropDownList ID="ddlDepartment" 
                             runat="server" 
                             AppendDataBoundItems="True"  
                             AutoPostBack="True" 
                             DataTextField="Dept" 
                             DataValueField="Dept" 
                             Font-Names="Siemens Sans" 
                             Font-Size="Small" 
                             Height="32px"
                             Width="245px" 
                             DataSourceID="SqlDataSource1"
                             CssClass="auto-style5" 
                             TabIndex="3">
                         <asp:ListItem Selected="True" Enabled="True">Select Production Area</asp:ListItem>
                         </asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSource1" 
                             runat="server" 
                             ConnectionString="<%$ ConnectionStrings:EnterConnectionStringHere %>" 
                             SelectCommand="SELECT FROM WHERE ">
                             <SelectParameters>
                                 <asp:Parameter DefaultValue="1" Name="Active" Type="Int32" />
                             </SelectParameters>
                         </asp:SqlDataSource>--%>
                         <asp:RequiredFieldValidator ID="rfvDepartment"
                           runat="server"
                           ControltoValidate="ddlDepartment"
                           InitialValue="Select Department"
                           ErrorMessage="Select department."
                           CssClass="validationerrormessage"
                           Text="*"
                           ValidationGroup="ValidationSummary_EHSSafetyNearMiss">
                        </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td> 
                             <asp:Label ID="lblType" 
                                 runat="server" 
                                 Text="Near Miss Type:" 
                                 CssClass="label">
                             </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlNearMissType" 
                                runat="server" 
                                CssClass="dropdown dropdown-menu-left">
                                <asp:ListItem>Select Near Miss Type</asp:ListItem>
                                <asp:ListItem>Will populate from database</asp:ListItem>                               
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rfvNearMissType"
                                 runat="server"
                                 ControltoValidate="ddlNearMissType"
                                 InitialValue="Select Near Miss Type"
                                 ErrorMessage="Select near miss type"
                                 CssClass="validationerrormessage"
                                 Text="*"
                                ValidationGroup="ValidationSummary_EHSSafetyNearMiss">
                            </asp:RequiredFieldValidator>
                        <%--Dropdown list will populate from database.  
                            </asp:DropDownList>
                                  
                                     <asp:DropDownList ID="ddlNearMissType" 
                             runat="server" 
                             AppendDataBoundItems="True"  
                             AutoPostBack="True" 
                             DataTextField="Type" 
                             DataValueField="Type" 
                             Font-Names="Siemens Sans" 
                             Font-Size="Small" 
                             Height="32px"
                             Width="245px" 
                             DataSourceID="SqlDataSource1"
                             CssClass="auto-style5" 
                             TabIndex="3">
                         <asp:ListItem Selected="True" Enabled="True">Select Near Miss Type</asp:ListItem>
                         </asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSource1" 
                             runat="server" 
                             ConnectionString="<%$ ConnectionStrings:EnterConnectionStringHere %>" 
                             SelectCommand="SELECT FROM WHERE ">
                             <SelectParameters>
                                 <asp:Parameter DefaultValue="1" Name="Active" Type="Int32" />
                             </SelectParameters>
                         </asp:SqlDataSource>--%>
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            <asp:Label ID="lblDescription" 
                                runat="server" 
                                Text="Near Miss Proposed Solution:" 
                                CssClass="label">
                            </asp:Label> 
                        </td>
                        <td>
                           <asp:TextBox ID="tbDescription" 
                               runat="server" 
                               TextMode="MultiLine" 
                               CssClass="textarea">
                           </asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvDescription" 
                                runat="server" 
                                ControlToValidate="tbDescription" 
                                CssClass="validationerrormessage"
                                Text="*" 
                                ErrorMessage="Description of near miss incident is required."
                                ValidationGroup="ValidationSummary_EHSSafetyNearMiss">
                           </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            <asp:Label ID="lblActionTaken" 
                                runat="server" 
                                Text="Action Taken:" 
                                CssClass="label">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbActionTaken" 
                                runat="server" 
                                TextMode="MultiLine" 
                                CssClass="textarea">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td colspan="2" class="table-row center" >
                            <asp:Button ID="btnSubmit"
                                CssClass="buttonsubmit"
                                runat="server" 
                                Text="Submit Near Miss"
                                ValidationGroup="ValidationSummary_EHSSafetyNearMiss" />                           
                        </td>
                    </tr>
                </table>
            </div>

        </form>

    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" Runat="Server">

</asp:Content>