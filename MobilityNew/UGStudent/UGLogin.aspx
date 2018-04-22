<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UGLogin.aspx.cs" Inherits="UGStudent_UGLogin" %>



<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <%-- <link href="../Styles/bootsrap/bootstrap-theme.min.css" rel="stylesheet" />
<link href="../Styles/bootsrap/bootstrap-theme.min.css" rel="stylesheet" />--%>
    <%--<link href="../Styles/bootsrap/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/bootsrap/bootstrap.min.css" rel="stylesheet" />
    <%--<link href="../Styles/bootsrap/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/bootsrap/bootstrap-theme.min.css" rel="stylesheet" />
    <%--<link href="../Styles/css/flat.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/css/flat.css" rel="stylesheet" />
    <%--<link href="../Styles/css/tomenu.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/css/tomenu.css" rel="stylesheet" />
    <%--<link href="../Styles/css/ls.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/css/pls.css" rel="stylesheet" />
    <%--<link href="../Styles/css/pls.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Styles/css/pls.css" rel="stylesheet" />
    <%--<link href="../Styles/css/font-awesome.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Style/css/font-awesome.css" rel="stylesheet" />
    <%--<link href="../Styles/css/site.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="../Styles/css/site.css" rel="stylesheet" />--%>
    <%--<script src="../Styles/js/bootsrap/bootstrap.min.js" type="text/javascript"></script>--%>
    <script src="../Styles/js/bootsrap/bootstrap.min.js"></script>
    <%--<script src="../Styles/js/jquery.easing.1.3.js" type="text/javascript"></script>--%>
    <script src="../Styles/js/jquery.easing.1.3.js"></script>
    <%--<script src="../Styles/js/jquery.timeline.min.js" type="text/javascript"></script>--%>
    <script src="../Styles/js/jquery.timeline.min.js"></script>
    <title></title>
    <style type="text/css">
        #username {
            width: 309px;
            height: 25px;
        }
        #password {
            width: 311px;
            height: 23px;
        }
        .auto-style1 {
            width: 362px;
            height: 203px;
        }
        .auto-style2 {
            height: 18px;
        }
        .auto-style3 {
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <div style="width: 400px; margin-left: auto; margin-right:auto;">
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
            <img alt="" class="auto-style1" src="../Styles/images/ssas.PNG" /><br />
            <br />
            <br />
        <asp:ImageButton ID="logoUTM" runat="server" ToolTip="Help & Support" ImageUrl="~/Styles/images/logoUTM.png" OnClientClick="target='blank'" Height="60px" Width="174px" />
            <br />
            <br />
        <br />
        <br />
        <table style="width: 53%; height: 45px;" align="center">
            <div class="w3-bar w3-black">
                <td style="color: #FFFFFF; background-color: #FFFFFF; font-size: small; " class="auto-style2">
                        <ul>
                            <li style="text-align: center; width: 121px" ><a href="../UGStudent/UGLogin.aspx">Student</a>&nbsp;&nbsp; <a href="../AcadAdvisor/AcadAdvisorLogin.aspx" class="auto-style3">Staff</a> </li>
                         </ul>  
                        </td>
                </div>
  
                                    
                            
                    
        </table>
        <div class="form-group" style="text-align: center;">
          
        </div>
        <div style="text-align: center;">
          <label for="pwd">
            Name<asp:TextBox ID="txtboxUGUsername" runat="server" class="form-control"></asp:TextBox>
            <br />
            Password<asp:TextBox ID="txtboxUGPassword" runat="server" class="form-control"></asp:TextBox>
            </label><br />
            <%--<input type="password" class="form-control" id="txtboxUGPassword">--%>
            <br />
            <br />
            <asp:Button ID="btnUGLogin" runat="server" Text="Login"  OnClick="btnUGLogin_Click" class="btn btn-primary" />
        </div>
        </div>
        </div>
        <br />
    </form>
</body>
</html>
