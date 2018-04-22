<%@ Page Title="" Language="C#" MasterPageFile="~/UGStudent/UGMasterPage.master" AutoEventWireup="true" CodeFile="ActivityGallery.aspx.cs" Inherits="UGStudent_ActivityGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" Runat="Server">
      <div id="cssmenu2">
        <ul style="font-size: small">
            <li class="inactive" style="text-align: center"><a href="Homeafter.aspx">&nbsp;Home</a></li>
            <li></li>
            <li class="inactive" style="text-align: center"><a href="inbox.aspx">&nbsp;Inbox</a></li>
            <li></li>
            <li class="active" style="text-align: center"><a href="Activity.aspx">&nbsp;Activity Logs</a></li>
        </ul>
    </div>
    <table style="width: 100%;">
        <tr>
            <td class="style158">
                <br />
                Gallery<br />
                <br />
                <asp:Repeater ID="rptGallery" runat="server">
                    <ItemTemplate>
                        <%--<asp:Label runat="server" ID="lblpath"><%#Eval("FILEPATH") %></asp:Label><br />--%>
                        <%--<asp:Image ID="Image1" runat="server" ImageUrl="<%#Eval("FILENAME")%>" />--%>
                        <%--<asp:Image id="Image2" runat="server" ImageUrl='<%# string.Format("~Upload/Documents/Sponsor/",Eval("FILENAME"))%>' height="150" width="150" />--%>

                        <%--<asp:Image ID="Image2" runat="server" ImageUrl="~/Upload/Documents/Sponsor/<%# Eval("FILENAME")%>" height="150" width="150"/>--%>

                        <asp:Image id="abc" runat="server" ImageUrl =<%# string.Format("~/Upload/Documents/Sponsor/{0}",Eval("FILENAME"))%> height="150" width="150"/>

                    <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Upload/Documents/Acceptance Letter/aaa2.jpg" />--%>
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <span style="color: #990000">__________________________________________________________________________________________________________________________________________________________________________</span></td>
        </tr>
    </table>
</asp:Content>

