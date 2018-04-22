<%@ Page Title="" Language="C#" MasterPageFile="~/UGStudent/UGMasterPage.master" AutoEventWireup="true" CodeFile="ApplicationStatus.aspx.cs" Inherits="UGStudent_inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" Runat="Server">
      <div id="cssmenu2">
        <ul style="font-size: small">
            <li class="inactive" style="text-align: center"><a href="HomeAfter.aspx">&nbsp;Home</a></li>
            <li></li>
            <li class="active" style="text-align: center"><a href="ApplicationStatus.aspx">&nbsp;ApplicationStatus</a></li>
            <li></li>
            <li class="inactive" style="text-align: center"><a href="Activity.aspx">&nbsp;Activity Logs</a></li>
        </ul>
    </div>
    <table style="width: 100%;">
        <tr>
            <td class="style158">
                <br />
            </td>
        </tr>
    </table>
      <br />
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="1172px">
          <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:BoundField DataField="PROGNAME" HeaderText="PROGRAME NAME" SortExpression="PROGNAME" />
              <asp:BoundField DataField="COUNTRY" HeaderText="COUNTRY" SortExpression="COUNTRY" />
              <asp:BoundField DataField="UNIVERSITY" HeaderText="UNIVERSITY" SortExpression="UNIVERSITY" />
              <asp:BoundField DataField="STARTDATE" HeaderText="START DATE" SortExpression="STARTDATE" />
              <asp:BoundField DataField="SYSTEMDATE" HeaderText="APPROVAL DATE" SortExpression="SYSTEMDATE" />
              <%--<asp:BoundField DataField="SYSTEMSTATUS" HeaderText="STATUS" SortExpression="SYSTEMSTATUS" />--%>

               <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID ="lblStatus" runat="server" Text='<%# checkStatus(Eval("SYSTEMSTATUS").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Action">

                <ItemTemplate>
                    <asp:LinkButton ID ="btnView" runat="server"  CommandArgument='<%# Eval("MATRIC") %>' OnClick="ViewStatus" >
                        <span class="fa fa-search fa-lg"></span>&nbsp;View Status
                    
                    </asp:LinkButton>
                </ItemTemplate>

            </asp:TemplateField>
          </Columns>
          <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
          <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
          <SortedAscendingCellStyle BackColor="#FDF5AC" />
          <SortedAscendingHeaderStyle BackColor="#4D0000" />
          <SortedDescendingCellStyle BackColor="#FCF6C0" />
          <SortedDescendingHeaderStyle BackColor="#820000" />
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT PROGRAMME.PROGNAME, PROGRAMME.COUNTRY, PROGRAMME.UNIVERSITY, PROGRAMME.STARTDATE, PROGRAMME.MATRIC, VERIFICATION.SYSTEMDATE, VERIFICATION.SYSTEMSTATUS, VERIFICATION.SVID FROM APPLICATION INNER JOIN VERIFICATION ON APPLICATION.APPID = VERIFICATION.APPID INNER JOIN PROGRAMME ON APPLICATION.MATRIC = PROGRAMME.MATRIC WHERE  PROGRAMME.MATRIC = @MATRIC">
          <SelectParameters>
              <asp:SessionParameter Name="MATRIC" SessionField="MATRIC"/>
              
          </SelectParameters>
      </asp:SqlDataSource>
      <br />
    
                                                    <asp:Panel ID="Panel1" runat="server" Visible="False" Width="305px">
                                                        <table style="width: 157%">
                                                            <tr>
                                                                <td style="background-color: #990000; height: 24px;" class="fa-inverse" colspan="2"><strong>Status</strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="color: #000000; width: 183px">Academic Advisor </td>
                                                                <td style="width: 275px">
                                                                    Name :
                                                                    <asp:Label runat="server" ID="lblAcadAdvisor" Font-Bold="True" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Date :
                                                                    <asp:Label runat="server" ID="lblAADate" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Status :
                                                                    <asp:Label runat="server" ID="lblStatus" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                </td>
                                                            </tr>                                                                                                                        
                                                        </table>
                                                        <br />
                            </asp:Panel>
                            
                             <asp:Panel ID="Panel2" runat="server" Visible="False" Width="305px">
                                                        <table style="width: 157%">
                                                            <tr>
                                                                <td style="color: #000000; width: 183px">Faculty Dean </td>
                                                                <td style="width: 275px">
                                                                    Name :
                                                                    <asp:Label runat="server" ID="Label1" Font-Bold="True" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Date :
                                                                    <asp:Label runat="server" ID="Label2" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Status :
                                                                    <asp:Label runat="server" ID="Label3" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                            </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" Visible="False" Width="305px">
                                                        <table style="width: 157%">
                                                            <tr>
                                                                <td style="color: #000000; width: 183px">UTM International Assistant Registrar </td>
                                                                <td style="width: 275px">
                                                                    Name :
                                                                    <asp:Label runat="server" ID="Label4" Font-Bold="True" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Date :
                                                                    <asp:Label runat="server" ID="Label5" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Status :
                                                                    <asp:Label runat="server" ID="Label6" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                            </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" Visible="False" Width="305px">
                                                        <table style="width: 157%">
                                                            <tr>
                                                                <td style="color: #000000; width: 183px">UTM International Director </td>
                                                                <td style="width: 275px">
                                                                    Name :
                                                                    <asp:Label runat="server" ID="Label7" Font-Bold="True" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Date :
                                                                    <asp:Label runat="server" ID="Label8" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Status :
                                                                    <asp:Label runat="server" ID="Label9" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                            </asp:Panel>

    <asp:Panel ID="Panel5" runat="server" Visible="False" Width="305px">
                                                        <table style="width: 157%">
                                                            <tr>
                                                                <td style="color: #000000; width: 183px">TNCAA </td>
                                                                <td style="width: 275px">
                                                                    Name :
                                                                    <asp:Label runat="server" ID="Label10" Font-Bold="True" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Date :
                                                                    <asp:Label runat="server" ID="Label11" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                    Status :
                                                                    <asp:Label runat="server" ID="Label12" Font-Bold="False" style="font-size: small" ></asp:Label>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                            </asp:Panel>
</asp:Content>

