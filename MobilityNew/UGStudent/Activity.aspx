<%@ Page Title="" Language="C#" MasterPageFile="~/UGStudent/UGMasterPage.master" AutoEventWireup="true" CodeFile="Activity.aspx.cs" Inherits="UGStudent_Activity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" Runat="Server">
      <div id="cssmenu2">
        <ul style="font-size: small">
            <li class="inactive" style="text-align: center"><a href="Homeafter.aspx">&nbsp;Home</a></li>
            <li></li>
            <li class="inactive" style="text-align: center"><a href="ApplicationStatus.aspx">&nbsp;Application Status</a></li>
            <li></li>
            <li class="active" style="text-align: center"><a href="Activity.aspx">&nbsp;Activity Logs</a></li>
        </ul>
    </div>
    <table style="width: 100%; height: 120px;">
        <tr>
            <td class="text-center" style="width: 175px">
                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Styles/images/New Icon/activity.png" NavigateUrl="~/UGStudent/ActivityActivity.aspx">HyperLink</asp:HyperLink>
                <br />
                <h5>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UGStudent/ActivityActivity.aspx">Post new activity</asp:HyperLink>
                </h5>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <td style="width: 181px" class="text-center">
                <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/Styles/images/New Icon/update.png" NavigateUrl="~/UGStudent/ActivityUpdate.aspx">HyperLink</asp:HyperLink>
                    <br />
                    <h5>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/UGStudent/ActivityUpdate.aspx">Update information</asp:HyperLink>
                    </h5>
                &nbsp;&nbsp;&nbsp;</td>
                <td style="width: 174px" class="text-center">
                <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/Styles/images/New Icon/report.png" NavigateUrl="~/UGStudent/ActivityReport.aspx">HyperLink</asp:HyperLink>
                    <br />
                    <h5>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/UGStudent/ActivityReport.aspx">Create report</asp:HyperLink>
                    </h5>
                &nbsp;&nbsp;</td>
                <td style="width: 148px" class="text-center">
                <asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/Styles/images/New Icon/gallery.png" NavigateUrl="~/UGStudent/ActivityGallery.aspx">HyperLink</asp:HyperLink>
                    <br />
                    <h5>
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/UGStudent/ActivityGallery.aspx">Gallery</asp:HyperLink>
                    </h5>
                <br />
                    </td>
                <span style="color: #990000">
                </span>            
            </td>
            <td class="style158">
                &nbsp;</td>
        </tr>

        

    </table>
</asp:Content>

