<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="Server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>江苏科技大学自动问答系统</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<!--[if IE 7]><link rel="stylesheet" media="all" type="text/css" href="css/ie7.css" />
<![endif]-->
<!--[if IE 8]><link rel="stylesheet" media="all" type="text/css" href="css/ie8.css" />
<![endif]-->
<link href="fonts/stylesheet.css" rel="stylesheet" type="text/css" />
<!--slidercss-->
<link rel="stylesheet" href="css/basic-jquery-slider.css" />
<script src="js/jquery-1.6.2.min.js" type="text/javascript" language="javascript"></script>
<script type="text/javascript" src="js/pie.js" language="javascript"></script>
<script type="text/javascript" src="js/custom.js" language="javascript"></script>
<script type="text/javascript" src="js/input.js" language="javascript"></script>
<style type="text/css">
ul.bjqs h1, ol.bjqs-markers li a {
	behavior: url("js/PIE.htc") !important;
}
</style>


</head>

<body>
   <%-- <form runat="Server">--%>
<!--Header Start Here-->
<div id="header">
  <div id="top_header">
    <div class="center_frame">
      <div class="top">
        <form name="search" method="post" action="">
          <div class="search">
            <input type="text" placeholder="Search" />
            <a id="sss" href="search.aspx"></a> </div>
               <div class="login" runat="server" id="login"> <a href="login.aspx" class="login_img">&nbsp;</a> <a href="register.aspx" class="register">&nbsp;</a> </div>
       
          <div runat="Server" id="logined" style="display:none;">
              <a id="loguser" href="cancel.aspx" class="loged" runat="Server">hhh</a>
              <div id="info">
                  <a href="blog.aspx">个人主页</a>
                  <br />
                  <a href="cancel.aspx">注销</a>
              </div>
              <%--<span id="loguser" class="loged">jjjjj</span>--%>

          </div>
        </form>
        
       
      </div>
    </div>
  </div>
  <!--Top Header End Here-->
  <div id="logo_nav">
    <div class="bg">
      <div class="center_frame"> 
        <!--Logo And Navigation Start Here-->
        <div class="logo"> <a href="Default.aspx"><img src="images/logo.png" alt=""  /></a> </div>
        <ul id="navigation">
          <li><a href="Default.aspx"><span>主页</span></a></li>
         
          <li><a href="contact.aspx"><span>联系我们</span></a></li>
          <li><a href="blog.aspx"><span>个人主页</span></a></li>
        </ul>
        <!--Logo And Navigation End Here--> 
        <!--CHANGE ONLY THIS PART HERE--> 
        
        <!--Project Top Start Here -->
        <div id="register_details">
            <form id="form" runat="server">
            <h6>注册</h6>
              
              <asp:TextBox ID="username" runat="server" type="text"  placeholder="用户名" class="input_1" OnTextChanged="username_TextChanged"></asp:TextBox>
              <asp:TextBox ID="password" runat="server" type="text"  placeholder="密码" class="input_2" TextMode="Password"></asp:TextBox>

              <asp:TextBox ID="repeatPwd" runat="server" type="text"  placeholder="重复密码" class="input_3" TextMode="Password"></asp:TextBox>
              
            <asp:TextBox ID="Email" runat="server" type="text"  placeholder="邮箱" class="input_4"></asp:TextBox>
              
              <div>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="username"></asp:RequiredFieldValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空" ControlToValidate="password"></asp:RequiredFieldValidator>
                  <br />
              <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一样" ControlToCompare="password" ControlToValidate="repeatPwd"></asp:CompareValidator>

              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="邮箱不符合格式" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  <br />
                  <asp:Label ID="err" runat="server" ></asp:Label>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="username" ErrorMessage="用户名必须以字母开头,长度在8-20位!!" ValidationExpression="[a-zA-Z]\w{7,19}"></asp:RegularExpressionValidator>
              </div>
              
              <asp:Button ID="submit" runat="server" type="submit" name="submit" value="" class="register_img" Height="46px" OnClick="submit_Click" Width="304px" />
            </form>
        </div>
        <!--Project Top Start Here --> 
        <!--CHANGE ONLY UPERE PART IN INNER PAGES--> 
      </div>
    </div>
  </div>
</div>
<!--Header End Here--> 
<!--slider start here--> 

<!--Wrapper Start Here-->
<div id="wrapper"><!--Top Wrapper End Here--> 
  <!--Main Contant Start Here-->
  <div id="main_contant">
    <div class="center_frame"></div>
  </div>
  <!-- Main Contant End Here --> 
</div>
<!--Wrapper End Here-->
<div id="footer">
  <div id="footer1">
    <div id="fbox1">
      <h2>导航</h2>
      
        <ul><a href="Default.aspx">主页</a></ul>
        <ul><a href="blog.aspx">个人主页</a></ul>
        <ul><a href="contact.aspx">联系我们</a></ul>
    </div>
  </div>      

  <div id="copyrights">
    <div>&copy; Copyright 2012 PowerHouse Corporation, All Rights Reserved</div>
  </div>
</div>
<%--</form>--%>
</body>
</html>
