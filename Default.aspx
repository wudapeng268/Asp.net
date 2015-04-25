 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
<script src="js/basic-jquery-slider.js"  type="text/javascript" language="javascript"></script>
<script type="text/javascript" src="js/custom.js" language="javascript"></script>
<script type="text/javascript" src="js/input.js" language="javascript"></script>

<!--  Attach the plug-in to the slider parent element and adjust the settings as required -->
<script  type="text/javascript" language="javascript">
    $(document).ready(function () {

        $('#banner').bjqs({
            'animation': 'slide',
            'width': 960,
            'height': 450
        });

    });
    </script>
<script type="text/javascript" src="js/pie.js" language="javascript"></script>
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
    <div class="center_frame">
      <div class="top">
          <div class="search">
            <input type="text" placeholder="Search" />
            <a id="sss" href="search.aspx"></a> </div>
       
        
        <div class="login" runat="server" id="login"> <a href="login.aspx" class="login_img">&nbsp;</a> <a href="register.aspx" class="register">&nbsp;</a> 
          
          </div>
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
    <div class="bg1">
        
      <div class="center_frame"> 
        <!--Logo And Navigation Start Here-->
        <div class="logo"> <a href="Default.aspx"><img src="images/logo.png" alt=""  /></a> </div>
        <ul id="navigation">
          <li><a href="Default.aspx"><span>主页</span></a></li>
         
          <li><a href="contact.aspx"><span>联系我们</span></a></li>
          <li><a href="blog.aspx"><span>个人主页</span></a></li>
        </ul>
        <!--Logo And Navigation End Here--> 
        <!--slider here--><div class="copyrights">Collect from <a href="http://www.ytvip.cn/">网站模板</a></div>
        
        <!--  Outer wrapper for presentation only, this can be anything you like -->
        <div id="banner"> 
          <!-- start Basic Jquery Slider -->
          <ul class="bjqs">
            <li>
              <h1>问吧</h1>
              <p>在这里关于数字逻辑,问你想问的,找你所需的.</p>
              <label><a href="#" class="pap"></a></label>
            </li>
          </ul>
          <!-- end Basic jQuery Slider --> 
        </div>
        <!-- End outer wrapper --> 
        
        <!--slider end here--> 
        
      </div>
    </div>
  </div>
</div>
<!--Header End Here--> 
<!--slider start here--> 

<!--Wrapper Start Here-->

  <!--Top Wrapper End Here--> 
  <!--Main Contant Start Here-->
  <div id="main_contant" runat="server">
    <!--这里放一些推荐问题-->
        

  <!-- Main Contant End Here --> 
      <asp:GridView ID="GridView1" runat="server" class="gridview" GridLines="None" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Id" >
          
         <Columns>
              <asp:TemplateField>
                  <ItemTemplate>
                      
                      <div class="qandan" >
                      <asp:linkbutton ID="question" runat="server" CssClass="searchquestion" PostBackUrl="~/detailQuestion.aspx" ></asp:linkbutton>
                          <br />
                          <asp:label ID="date" runat="server" Text="2014-3-2" style="float:right" CssClass="date"></asp:label>
                      <br />
                      <asp:label ID="answer1" runat="server" CssClass="answer"   PostBackUrl="~/detailQuestion.aspx"></asp:label>
                      <br />
                     
                          </div>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          
          <PagerTemplate>
              <br />
          </PagerTemplate>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Templete]"></asp:SqlDataSource>
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
</div>

        

    </form>

</body>
</html>
