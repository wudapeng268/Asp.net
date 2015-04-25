<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

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
<script type="text/javascript" src="js/validation.js" language="javascript"></script>
<style type="text/css">
ul.bjqs h1, ol.bjqs-markers li a {
behavior: url("js/PIE.htc") !important;
}
</style>
<script type="text/javascript">
    function validateForm() {

        var flag = 0;
        if (document.form2.firstName.value == "") {
            alert("Please enter your name");
            document.form2.firstName.focus();
            flag = 1;
            return false;
        }

        if (document.form2.useremail.value == "") {
            alert("Please enter your email address");
            document.form2.useremail.focus();
            flag = 1;
            return false;
        }

        else {
            var reg = /^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$/;
            var emailVali = document.form2.useremail.value;
            if (reg.test(emailVali) == false) {
                alert('Invalid Email Address');
                document.form2.useremail.focus();
                flag = 1;
                return false;
            }
        }

        if (document.form2.message.value == "") {
            alert("Please enter Message");
            document.form2.message.focus();
            flag = 1;
            return false;
        }





    }
				</script>

</head>

<body>
    
   
    
<!--Header Start Here-->
<div id="header">
<div id="top_header">
<div class="center_frame">
<div class="top">
<div class="search">
<input type="text" placeholder="Search" />
<a id="sss" href=""><img src="images/search_icon.png" alt="" /></a> </div>
    
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
<div class="bg_11">
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

<!--Contact Top Start Here -->
<div id="contact">
<div id="contact_form_left">
<h1>联系我们</h1>
    <form  runat="Server">

    <asp:TextBox ID="firstName" runat="server" class="contact_name" value=" First name"></asp:TextBox>
    <asp:TextBox ID="usermail" runat="server" class="contact_email" value=" Email"></asp:TextBox>
   <textarea name="message" id="message" class="contact_textarea" rows="" cols="" >Message</textarea>
    <asp:Button ID="submit" runat="server"  name="submit" type="submit"/>
        </form>
</div>
<div class="contact_form_line"> <img src="images/contact_form_line.png" alt=""  /> </div>
<div id="contact_form_right">
<h1>Call us</h1>
<h6>1-888-238-3292</h6>
<p>我们提供7*24小时服务,如果你对于我们的产品有任何疑问,欢迎来电咨询</p>
</div>
</div>
<!--Contact Top End Here -->
<!--CHANGE ONLY UPERE PART IN INNER PAGES-->
</div>
</div>
</div>
</div>
<!--Header End Here-->

<!--Wrapper Start Here-->
<div id="wrapper">
<!--Main Contant Start Here-->
<div id="main_contant">
<div class="center_frame">
<!--Contact Page Address Start Here-->
<div id="contact_address">
<h1>地址</h1>
<div class="address_powerhouse"style="color:black;"> <img src="images/contact_page_map.png" alt="" class="address_powerhouse_img" />

<span>江苏省镇江市江苏科技大学</span> <a href="#"></a> </div>
</div>
<!--Contact Page Address End Here-->
    
</div>
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
