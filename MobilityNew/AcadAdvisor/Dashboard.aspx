<%@ Page Title="" Language="C#" MasterPageFile="~/AcadAdvisor/AAMasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="AcadAdvisor_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="BodyContent" Runat="Server">
    <div id="cssmenu2">
        <ul style="font-size: small">
            <li class="active"><a>
                <img alt="" class="tab-icon" src="../Styles/images/NavBtn/Non Active/ic_mail_white_24dp.png">&nbsp;Inbox</a></li>
            <li><a href="ActiveStudent.aspx">
                <img alt="" class="tab-icon" src="../Styles/images/NavBtn/Active/people.png">&nbsp;Active</a></li>
            <li><a href="GradStudent.aspx">
                <img alt="" class="tab-icon" src="../Styles/images/NavBtn/Active/tool.png">&nbsp;Graduated</a></li>
            <li><a href="Subject.aspx">
                <img alt="" class="tab-icon" src="../Styles/images/NavBtn/Active/ic_library_books_black_24dp.png">&nbsp;Subject</a></li>
            <li><a href="Advisor.aspx">
                <img alt="" class="tab-icon" src="../Styles/images/NavBtn/Active/ic_account_circle_black_24dp.png">&nbsp;Academic
                Advisor</a></li>
            <li><a href="frmStudMobility.aspx"><span class="fa fa-plane fa-lg"></span>&nbsp;Student Mobility</a></li>
        </ul>
    </div>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [AAView]">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" Style="width: 100%" EmptyDataText="No record found">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:BoundField DataField="APP_APPID" HeaderText="APP_APPID" SortExpression="APP_APPID" />--%>
            <%--<asp:BoundField DataField="APP_MATRIC" HeaderText="APP_MATRIC" SortExpression="APP_MATRIC" />--%>
            <%--<asp:BoundField DataField="APP_STATUS" HeaderText="APP_STATUS" SortExpression="APP_STATUS" />--%>
            <%--<asp:BoundField DataField="STUD_MATRIC" HeaderText="STUD_MATRIC" SortExpression="STUD_MATRIC" />--%>
            <asp:BoundField DataField="MATRIC" HeaderText="MATRIC" SortExpression="MATRIC" />
            <%--<asp:BoundField DataField="PROG_PROGID" HeaderText="PROG_PROGID" SortExpression="PROG_PROGID" />--%>
            <%--<asp:BoundField DataField="PROG_APPID" HeaderText="PROG_APPID" SortExpression="PROG_APPID" />--%>
            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
            <asp:BoundField DataField="PROGNAME" HeaderText="PROGNAME" SortExpression="PROGNAME" />
            <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
            <asp:BoundField DataField="STARTDATE" HeaderText="STARTDATE" SortExpression="STARTDATE" />
            <asp:BoundField DataField="ENDDATE" HeaderText="ENDDATE" SortExpression="ENDDATE" />

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
                <%--<asp:LinkButton ID="ViewStudApp" runat="server" OnClick="ViewStudApp">
                <span class="fa fa-search fa-lg"></span>&nbsp;View Application</asp:LinkButton>--%>
                <br />
                <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2">
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>


