<%@ Page Title="Update Incident" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateIncident.aspx.cs" Inherits="CState_TeamC_Capstone.updateIncident" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Content/Site.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main role="main" class="container-fluid">
        <h2>Near Miss Action Instructions</h2>
      <h2>Slips, Trips, Falls</h2>

        <!-- Form -->
        <form name="frmTypeInstructions" method="get" action="#" runat="server">

            <div style="display: flex; justify-content: center;">
                
                <br/>
                    <asp:Panel ID="pnlSpills" runat="server">
                        <asp:Label ID="lblSpills" runat="server" Text="Spills"></asp:Label>
                       <br/><br/>
                         Slips can be caused by wet surfaces, spills, or weather hazards like ice or snow. Slips are 
                         more likely to occur when you hurry or run, wear the wrong kind of shoes, or don’t pay
                         attention to where you’re walking.<br/>
                         You can help avoid slips by following these safety precautions:<br/>
                         • Practice safe walking skills. Take short steps on slippery surfaces to keep your center of balance under you and<br/>
                         point your feet slightly outward.<br/>
                         • Clean up or report spills right away. Even minor spills can be very dangerous.<br/>
                         • Don’t let grease accumulate at your work place.<br/>
                         • Be extra cautious on smooth surfaces such as newly waxed floors. Also be careful walking on loose carpeting.<br/>
                   <br/> 
                </asp:Panel>
                <asp:Panel ID="pnlTrips" runat="server">
                    <asp:Label ID="lblTripsTitle" runat="server" Text="Trips"></asp:Label>
                  <br/><br/>
                    Trips occur whenever your foot hits an object and you are moving with enough
                    momentum to be thrown off balance.<br/>
                    To prevent trip hazards:<br/>
                    • Make sure you can see where you are walking. Don’t carry loads that you cannot see over.<br/>
                    • Keep walking and working areas well lit, especially at night.<br/>
                    • Keep the work place clean and tidy. Store materials and supplies in the appropriate storage areas.<br />
                    • Arrange furniture and office equipment so that it doesn’t interfere with walkways or pedestrian traffic in your area. <br />
                    • Properly maintain walking areas, and alert appropriate authorities regarding potential maintenance related hazards.<br/>
                  <br/> 
                </asp:Panel>
                   
                <asp:Panel ID="pnlFalls" runat="server">
                    <asp:Label ID="lblFallsTitle" runat="server" Text="Falls"></asp:Label>
                  <br/><br/>
                    To avoid falls consider the following measures:<br/>
                    • Don’t jump off landings or loading docks. Use the stairs<br/>
                    • Repair or replace stairs or handrails that are loose or broken<br/>
                    • Keep passageways and aisles clear of clutter and well lit.<br/>
                    • Wear shoes with appropriate non-slip soles.<br/>
                  <br/> 
                </asp:Panel>
            </div>           
        </form>
    </main>
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
