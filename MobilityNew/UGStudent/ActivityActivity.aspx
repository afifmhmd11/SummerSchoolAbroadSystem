﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UGStudent/UGMasterPage.master" AutoEventWireup="true" CodeFile="ActivityActivity.aspx.cs" Inherits="UGStudent_ActivityActivity" %>

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
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <span style="font-size: small">
                <br />
&nbsp;New Activity</span><br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 11px">Title:</td>
                        <td>
                            <asp:TextBox ID="txtboxTitle" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 11px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 11px">Blog:</td>
                        <td>
                            <asp:TextBox ID="txtboxBlog" runat="server" Height="141px" Width="548px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 11px">&nbsp;</td>
                        <td>
                            <asp:FileUpload id="FileUploadControl" runat="server" />
                            <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
                            <br /><br />
                            <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 11px">&nbsp;</td>
                        <td>Upload image: Max 5<br />
                            <br />
                <asp:Button ID="Button1" runat="server" Text="Back" PostBackUrl="~/UGStudent/Activity.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <%--<ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />--%>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

