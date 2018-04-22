<%@ Page Title="" Language="C#" MasterPageFile="~/UGStudent/UGMasterPage.master" AutoEventWireup="true" CodeFile="frmProgramme.aspx.cs" Inherits="UGStudent_frmProgramme" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" Runat="Server">
    <div id="cssmenu2">
        <ul  style="font-size: small; top: 0px; left: 0px;">
            <li class="active" style="text-align: center; top: 2px; left: 1px;"><a href="frmProgramme.aspx">New Application</a></li>
            <li class="active" style="text-align: center; top: 2px; left: 1px;"><a href="ApplicationStatus.aspx">View Application Status</a></li>
            <li class="active" style="text-align: center; top: 2px; left: 1px;"><a href="Activity.aspx">Activity Log</a></li>
            <li></li>
        </ul>
    </div>
    <table style="width: 100%;">
        <tr>
            <td class="style158">
                <table style="width: 100%">
                    <tr>
                        <td style="color: #FFFFFF; background-color: #FFFFFF; font-size: small; height: 18px;">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="frmProgramme.aspx">Programme</a></li>
                            <li><a href="frmPersonal.aspx">Personal</a></li>
                            <li><a href="frmAcademic.aspx">Academic</a></li>
                            <li><a href="frmFinancial.aspx">Financial</a></li>
                            <li><a href="frmAttachment.aspx">Attachment</a></li>
                            <li><a href="frmDeclaration.aspx">Declaration</a></li>
                         </ul>  
                        </td>
                            
                    </tr>
                    <tr>
                        <td style="color: #FFFFFF; background-color: #FFFFFF; font-size: small; height: 19px;">
                                        <table style="width: 100%" __designer:mapid="56a">
                                            <tr __designer:mapid="56b">
                                                <td class="fa-inverse" colspan="5" style="background-color: #990000;" __designer:mapid="56c"><strong __designer:mapid="56d">A. Program Details</strong></td>
                                            </tr>
                                            <tr __designer:mapid="56e">
                                                <td style="color: #000000; width: 158px;" __designer:mapid="56f">Programme Type:</td>
                                                <td style="color: #000000; width: 222px;" __designer:mapid="570">
                                                    <asp:Label runat="server" ID="lblProgramType"></asp:Label>

                                                </td>
                                                <td style="color: #000000" __designer:mapid="572">&nbsp;</td>
                                                <td style="color: #000000; width: 122px;" __designer:mapid="573">&nbsp;</td>
                                                <td style="color: #000000" __designer:mapid="574">&nbsp;</td>
                                            </tr>
                                            <tr __designer:mapid="575">
                                                <td style="color: #000000; width: 158px;" __designer:mapid="576">Start Date:</td>
                                                <td style="color: #000000; width: 222px;" __designer:mapid="577">
                                                    <asp:TextBox runat="server" ID="txtboxStartDate" ></asp:TextBox>

                                                    <ajaxToolkit:CalendarExtender ID="txtboxStartDate_CalendarExtender" runat="server" BehaviorID="txtboxStartDate_CalendarExtender" TargetControlID="txtboxStartDate" Format="dd/MM/yyyy">
                                                    </ajaxToolkit:CalendarExtender>


                                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="txtboxStartDate" ErrorMessage="Start date" ID="RequiredFieldValidator2">*</asp:RequiredFieldValidator>

                                                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                                                    </asp:ScriptManager>

                                                </td>
                                                <td style="color: #000000" __designer:mapid="57b">&nbsp;</td>
                                                <td style="color: #000000; width: 122px;" __designer:mapid="57c">End Date:</td>
                                                <td style="color: #000000" __designer:mapid="57d">


                                                    <asp:TextBox runat="server" ID="txtboxEndDate"  ></asp:TextBox>

                                                    <ajaxToolkit:CalendarExtender ID="txtboxEndDate_CalendarExtender" runat="server" BehaviorID="txtboxEndDate_CalendarExtender" DefaultView="Days" PopupPosition="BottomLeft" TargetControlID="txtboxEndDate">
                                                    </ajaxToolkit:CalendarExtender>

                                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="txtboxEndDate" ErrorMessage="End Date" ID="RequiredFieldValidator3">*</asp:RequiredFieldValidator>

                                                </td>
                                            </tr>
                                            <tr __designer:mapid="581">
                                                <td style="color: #000000; width: 158px; height: 71px;" __designer:mapid="582">Country:</td>
                                                <td style="color: #000000; width: 222px; height: 71px;" __designer:mapid="583">
                                                    <asp:DropDownList runat="server" ID="drpdwnCountry">
                                                    <asp:ListItem>Korea</asp:ListItem>
                                                    <asp:ListItem>Indonesia</asp:ListItem>
                                                    <asp:ListItem>Japan</asp:ListItem>
                                                    <asp:ListItem>Spain</asp:ListItem>
                                                    <asp:ListItem>German</asp:ListItem>
                                                        <asp:ListItem>China</asp:ListItem>
                                                        <asp:ListItem>Singapore</asp:ListItem>
                                                        <asp:ListItem>Brunei</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpdwnCountry" ErrorMessage="Country" ForeColor="Red">*</asp:RequiredFieldValidator>

                                                </td>
                                                <td style="color: #000000; height: 71px;" __designer:mapid="589"></td>
                                                <td style="color: #000000; width: 122px; height: 71px;" __designer:mapid="58a">University Name:</td>
                                                <td style="color: #000000; height: 71px;" __designer:mapid="58b">
                                                    <asp:TextBox runat="server" Width="254px" ID="txtboxUName"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="txtboxUName" ErrorMessage="University Name" ID="RequiredFieldValidator1">*</asp:RequiredFieldValidator>

                                                </td>
                                            </tr>
                                            <tr __designer:mapid="58e">
                                                <td colspan="5" style="color: #000000; height: 18px;" __designer:mapid="58f">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Please fill in these details to continue" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br __designer:mapid="590" />
                                        <table style="width: 100%" __designer:mapid="591">
                                            <tr __designer:mapid="592">
                                                <td __designer:mapid="593" style="width: 217px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                                <td style="width: 129px" __designer:mapid="594">
                                                    <asp:Button ID="btnCancel1" runat="server" ForeColor="Black" Text="Cancel" PostBackUrl="~/UGStudent/Home.aspx" CssClass="btn-sm" />

                                                </td>
                                                <td style="width: 60px" __designer:mapid="596">
                                                    <asp:Button ID="btnSave1" runat="server" ForeColor="Black" Text="Save &amp; Continue" OnClick="btnSave1_Click"  CssClass="btn-sm"  />

                                                </td>
                                                <td __designer:mapid="598"><span style="color: #000000" __designer:mapid="599">&nbsp;Page 1 of 6</span></td>
                                            </tr>
                                        </table>
                                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

