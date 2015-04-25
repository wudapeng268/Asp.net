<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgetPwd.aspx.cs" Inherits="forgetPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
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
<!--Header Start Here-->
<div id="header">
  <div id="top_header">
    <div class="center_frame">
      <div class="top">
        <form name="search" method="post" action="">
          <div class="search">
            <input type="text" placeholder="Search" />
            <a id="sss" href="default.htm"></a> </div>
            
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
        <div id="forgetpwd">
          <form action="" runat="Server">
            <h6>忘记密码</h6>
              <asp:TextBox ID="email" runat="server" type="text"  placeholder="邮箱" class="input_2"></asp:TextBox>
              <asp:Button ID="submit" runat="server" type="submit" name="submit" value="" OnClick="submit_Click"/>
            
           
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
</body>
</html>
