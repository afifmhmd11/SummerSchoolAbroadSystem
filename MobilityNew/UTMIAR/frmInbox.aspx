<%@ Page Title="" Language="C#" MasterPageFile="~/UTMIAR/UTMIRMasterPage.master" AutoEventWireup="true" CodeFile="frmInbox.aspx.cs" Inherits="UTMIAR_frmInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" Runat="Server">
    <div id="cssmenu2">
        <ul style="font-size: small">
            <li class="active"><a href="Dashboard.aspx"><span class="fa fa-inbox fa-lg"></span>&nbsp;Inbox</a></li>
            <li><a href="frmInProcess.aspx"><span class="fa fa-play fa-lg"></span>&nbsp;In Process</a></li>
            <li><a href="frmAccepted.aspx"><span class="fa fa-check fa-lg"></span>&nbsp;Accepted</a></li>
            <li><a href="frmRejected.aspx"><span class="fa fa-times fa-lg"></span>&nbsp;Rejected</a></li>
        </ul>
    </div>
    <table style="float: right">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="" Font-Bold="True">Application <span class="fa fa-arrow-right"></span>&nbsp;Outbound <span class="fa fa-arrow-right"></span>&nbsp;Inbox</asp:Label>
            </td>
        </tr>
    </table>
    <br>
    <br>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT *, PROGRAMME.TYPE AS Expr2, PROGRAMME.UNIVERSITY AS Expr3, PROGRAMME.STARTDATE AS Expr4, PROGRAMME.ENDDATE AS Expr5, PROGRAMME.PROGNAME AS Expr6, STUDENT.NAME AS Expr1 FROM PROGRAMME INNER JOIN STUDENT ON PROGRAMME.MATRIC = STUDENT.MATRIC">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" Style="width: 100%" EmptyDataText="No record found">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:BoundField DataField="APP_APPID" HeaderText="APP_APPID" SortExpression="APP_APPID" />--%>
            <%--<asp:BoundField DataField="APP_MATRIC" HeaderText="APP_MATRIC" SortExpression="APP_MATRIC" />--%>
            <%--<asp:BoundField DataField="APP_STATUS" HeaderText="APP_STATUS" SortExpression="APP_STATUS" />--%>
            <%--<asp:BoundField DataField="STUD_MATRIC" HeaderText="STUD_MATRIC" SortExpression="STUD_MATRIC" />--%>
            <asp:BoundField DataField="UNIVERSITY" HeaderText="UNIVERSITY" SortExpression="UNIVERSITY" />
            <%--<asp:BoundField DataField="PROG_PROGID" HeaderText="PROG_PROGID" SortExpression="PROG_PROGID" />--%>
            <%--<asp:BoundField DataField="PROG_APPID" HeaderText="PROG_APPID" SortExpression="PROG_APPID" />--%>
            <asp:BoundField DataField="COUNTRY" HeaderText="COUNTRY" SortExpression="COUNTRY" />
            <asp:BoundField DataField="STARTDATE" HeaderText="STARTDATE" SortExpression="STARTDATE" />
            <asp:BoundField DataField="ENDDATE" HeaderText="ENDDATE" SortExpression="ENDDATE" />
            <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
            <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
           
            <asp:BoundField DataField="MATRIC" HeaderText="MATRIC" SortExpression="MATRIC" />
            
            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
            <asp:TemplateField HeaderText="Action">

                <ItemTemplate>
                    <asp:LinkButton ID ="btnView" runat="server"  CommandArgument='<%# Eval("MATRIC") %>' OnClick="ViewStudent" OnClientClick="return confirm('VIEW STUDENT?');">
                        <span class="fa fa-search fa-lg"></span>&nbsp;View Application
                    
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
    <br />
    <table style="border: 1px dotted #64001C; border-radius: 15px; width: 100%">
        <tr>
            <td colspan="4">
                <strong>Legends:</strong>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server">
                <span class="fa fa-search fa-lg"></span>&nbsp;View Application</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

