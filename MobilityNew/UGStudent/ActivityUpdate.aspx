<%@ Page Title="" Language="C#" MasterPageFile="~/UGStudent/UGMasterPage.master" AutoEventWireup="true" CodeFile="ActivityUpdate.aspx.cs" Inherits="UGStudent_ActivityUpdate" %>

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
    <table style="width: 100%;">
        <tr>
            <td class="style158">
                <br />
                Update Information<br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td colspan="3"><span style="color: rgb(51, 51, 51); font-family: Roboto-Regular, Arial; font-size: 13.3333px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 0px; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: nowrap; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">Please update your information when you are abroad</span></td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 37px; width: 93px;">Phone Number:</td>
                        <td style="height: 37px; width: 326px">
                            <asp:TextBox ID="txtboxPhoneNo" runat="server"></asp:TextBox>
                        </td>
                        <td style="height: 37px; width: 128px;">Emergency Contact:<asp:TextBox ID="txtboxEmergencyContact" runat="server"></asp:TextBox>
                        </td>
                        <td style="height: 37px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 93px">Address:</td>
                        <td style="width: 326px">
                            <asp:TextBox ID="txtboxAddress" runat="server" Height="125px" Width="247px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td style="width: 128px">Emergency Contact Phone No :
                            <asp:TextBox ID="txtboxEContactPhoneNo" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            Emergency Contact Relation :
                            <asp:TextBox ID="txtboxEContactRelation" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 37px; width: 93px;"></td>
                        <td style="height: 37px; width: 326px">&nbsp;</td>
                        <td style="height: 37px; width: 128px;"></td>
                    </tr>
                </table>
&nbsp;<br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 350px">
                            
                            
                            
                        </td>
                        <td style="width: 115px">
                            
                            <asp:Button ID="Button3" runat="server" Text="Cancel" PostBackUrl="~/UGStudent/Activity.aspx" />
                            
                        </td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;
                <br />
                <span style="color: #990000">__________________________________________________________________________________________________________________________________________________________________________</span></td>
        </tr>
    </table>
</asp:Content>

