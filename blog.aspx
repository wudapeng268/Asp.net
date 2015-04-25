<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blog.aspx.cs" Inherits="about" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
<script type="text/javascript" src="js/custom.js"></script>
<script type="text/javascript" src="js/input.js" language="javascript"></script>
<style type="text/css">
ul.bjqs h1, ol.bjqs-markers li a {
	behavior: url("js/PIE.htc") !important;
}
</style>


</head>

<body>
    <form id="form1" runat="server">
<!--Header Start Here-->
<div id="header">
  <div id="top_header">
    <div class="center_frame" runat="Server" >
      <div class="top">
          <div class="search">
            <input type="text" placeholder="Search" />
            <a id="sss" href="default.htm"></a> </div>
        
        <div class="login" runat="server" id="login"> <a href="login.aspx" class="login_img">&nbsp;</a> <a href="register.aspx" class="register">&nbsp;</a> </div>
          <ul>
          <div runat="Server" id="logined" style="display:none;">
              <a id="loguser" href="cancel.aspx" class="loged" runat="Server">hhh</a>
              <li>
              <div id="info">
                  <a href="blog.aspx">个人主页</a>
                  <br />
                  <a href="cancel.aspx">注销</a>
              </div>
                  </li>
              <%--<span id="loguser" class="loged">jjjjj</span>--%>

          </div>
              </ul>
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
        <!--About Top Start Here -->
        <div id="about_us">
          <h1>个人主页</h1>
          <ul class="meet_the_team">
            
            <li> <a href="blog.aspx?question" class="kangaroo">&nbsp;</a> <strong>已提问过的问题</strong>
              <p></p>
            </li>
            <li> <a href="blog.aspx?answer" class="koala">&nbsp;</a> <strong>贡献的答案</strong>
              <p></p>
            </li>
            <li> <a href="blog.aspx?information" class="squirrel">&nbsp;</a> <div style="margin-left:-60px;"><strong>个人信息</strong></div>
              <p></p>
            </li>
          </ul>
        </div>
        <!--About Top Start Here --> 
        <!--CHANGE ONLY UPERE PART IN INNER PAGES--> 
      </div>
    </div>
  </div>
</div>
<!--Header End Here--> 
<!--Wrapper Start Here-->
<div id="wrapper"> 
  <!-- About Wrapper Top Start Here-->
  <div id="wrapper_top_about">
    <div class="center_frame" id="tree" runat="Server">
      <h2>
      </h2>
        
      <!--About Left Start-->
      <div id="about_left" runat="Server">
        
       
       
      </div>
      <!--About Left End--> 
      <!--About Middle Start-->
      <div id="about_middle">  <span class="drop_title" id="drop_title" runat="Server"></span></div>
      <!--About Middle End--> 
      <!--About Right Start-->
      <div id="about_right" runat="Server" style="margin-top:100px;">
         
        
      </div>
      <!--About Right End--> 
    </div>
      <div class="clear"></div>
      <div id="personalmsg" runat="Server">
          
    <br />
    <div style="width:50%;margin:auto;">
    <div class="taber" id="myBang">
        <h3></h3>
    </div>
    <div class="ckin cle bang" style="margin-left:20px;font-size:20px">
        <p>
            用户名：<asp:label ID="txtNickName" runat="server"></asp:label></p>
        <p>
            头像：<asp:image runat="server" id="show_img" width="40" /><asp:FileUpload ID="user_img" runat="server" /> &nbsp;<asp:Button ID="update" runat="server"  OnClick="update_Click" CssClass="submit_img" /></p>
        <p>
            邮箱：<asp:label ID="txtEmail" runat="server"></asp:label></p>
        <p>
            提问数：<asp:Label ID="lblAskNumber" runat="server"></asp:Label></p>
        <p>
            回答数：<asp:Label ID="lblReviewNumber" runat="server"></asp:Label></p>       
    </div>
    <div class="c" style="margin-top:20px; margin-left:20px;">
        <asp:Button ID="btnOk" CssClass="savebtn" Text="更改密码" runat="server" OnClick="btnOk_Click"/>
        <span class="info" id="setInfo"></span>
        <div id="provepwd" style="display:none;" runat="Server">
            <asp:TextBox ID="pwd" runat="server" placeholder="我们需要验证您的密码" TextMode="Password"></asp:TextBox>
            <asp:Button ID="provebt" runat="server" Text="" CssClass="queding" OnClick="provebt_Click" />

        </div>
    </div>
        </div>
 


      </div>
  </div>
  <!-- About Wrapper Top End Here--> 
  <!--About Affiliates Start Here-->
  <!--About Affiliates End Here--> 
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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TUser]"></asp:SqlDataSource>
    </form>

</body>
</html>
