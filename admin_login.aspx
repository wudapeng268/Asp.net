<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>问吧系统 教师管理员登陆</title>
    <style type="text/css">
        .auto-style1 {            
            font-size: x-large;
            color: #FFFFFF;
        }
        .auto-style4 {
            width: 100%;
            height:100%;
        }
        .auto-style5 {
            width: 25%;
            text-align: right;
        }
        .auto-style7 {
            width: 15%;
        }
        .auto-style10 {
            width: 350px;
            height: 150px;
            font-size: 40pt;
            font-family:'Microsoft JhengHei UI';
            
        }
        .auto-style11 {
            width: 350px;
            height:40px;
            text-align: left;
        }
        .auto-style12 {
            height: 120px;
            text-align: right;
        }
        .auto-style13 {
            height: 30%;
        }
        .auto-style14 {
            height: 30%;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="position: fixed; width: 100%; height: 100%; background-image: url('images/loginbg.png'); background-repeat :repeat-x">
        <tr>
            <td>
                <br />
                <table class="auto-style4">
                    <tr>
                        <td class="auto-style7" rowspan="7">
                            &nbsp;</td>
                        <td class="auto-style12" colspan="2">
                        </td>
                        <td class="auto-style7" rowspan="7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Image ID="Image1" runat="server" Height="74px" ImageUrl="~/images/logo2.png" Width="88px" />
                        </td>
                        <td class="auto-style10" style="font-family: &quot;Microsoft JhengHei UI Light&quot;; color: #FFFFFF">管理员登陆</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5" rowspan="3">&nbsp;</td>
                        <td class="auto-style11">
                            <div style="width:90px;float:left;">用户名:</div><asp:TextBox ID="UserName" runat="server" Width="200px" Height="100%"></asp:TextBox>
                            
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11"><div style="width:90px;float:left;">密码:</div><asp:TextBox class="colorblur" onfocus="this.className='colorfocus';" onblur="this.className='colorblur';"
                        ID="Password" TextMode="Password" runat="server" Width="200px" Height="100%" />
                            </td>
                    </tr>
                    <tr>
                        
                        <td class="auto-style11">
                             <div style="clear:left;width:90px;float:left; height: 32px;">
                             </div><asp:Button class="button" ID="Button1" Text="登 录" OnClick="Submit_OnClick" runat="server" BackColor="#66CCFF" BorderStyle="None" Height="100%" Width="200px" CssClass="auto-style1" Font-Names="Microsoft YaHei UI Light" Font-Size="18px"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style13">
                             &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<%--    
<asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="UserName" Display="Dynamic" ErrorMessage="*" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="UserName" Display="Dynamic" ErrorMessage="*" ValidationExpression="[^']+" />


<asp:RequiredFieldValidator ControlToValidate="Password" ID="RequiredFieldValidator1" ErrorMessage="*" Display="Dynamic" runat="server" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Password" ValidationExpression="[^']+" ErrorMessage="*" Display="Dynamic" />
                        
--%>