<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

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
<script src="js/basic-jquery-slider.js"  type="text/javascript" language="javascript"></script>
<script type="text/javascript" src="js/custom.js" language="javascript"></script>


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
#searchtb
{
    padding:10px;border-radius:5px;border:1px solid #D4D4D4;
    box-shadow:inset 0 2px 5px #eee;color:#B8B8B8;
    margin-top:5px;
}
.centerframe
{
   

}
</style>
</head>

<body>

<!--Header Start Here-->
    <form id="Form1" runat="server" target="_blank">
<div id="header">
  <div id="top_header">
    <div class="center_frame">
      <div class="top">
        
          <div class="search">
            <input type="text" placeholder="Search" />
            <a id="sss" href=""></a> </div>
       
        
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
  </div>
  <!--Top Header End Here-->
  <div id="logo_nav2">
    <div >
      <div class="center_frame"> 
        <!--Logo And Navigation Start Here-->
        <div id="logo" class="search" > <a href="Default.aspx"><img src="images/logo.png" alt=""  /></a>  <em><p>江苏科技大学</p>
            <p>自动问答平台</p></em>  <div class="search2" >
            <asp:TextBox ID="searchtb" runat="server" Height="16px" Width="423px"></asp:TextBox>
            </div>
            <asp:Button ID="searchbtn" runat="server"  CssClass="searchanswer"  OnClick="searchbtn_Click" AccessKey="a" /> 

            <asp:Button ID="updateq" runat="server" CssClass="post_question" style="" OnClick="updateq_Click" ></asp:Button>
        </div>
       </div>
        <!--Logo And Navigation End Here--> 
        <!--slider here-->
        
        <!--  Outer wrapper for presentation only, this can be anything you like -->
        
        <!-- End outer wrapper --> 
        
        <!--slider end here--> 
        
      
    </div>
  </div>
</div>
<!--Header End Here--> 
<!--slider start here--> 

<!--Wrapper Start Here-->

  <!--Top Wrapper End Here--> 
  <!--Main Contant Start Here-->
  <div id="main_contant" runat="server">
      <div style="margin:auto;width:50%;margin-top:10px;font-size:18px;color:red;" runat="Server" id="tishi"></div>
    <!--这里放一些推荐问题-->
        <asp:GridView ID="GridView1" runat="server" class="gridview" GridLines="None" AutoGenerateColumns="False" DataKeyNames="Id" CellSpacing="2" >
          
          <Columns>
              <asp:TemplateField>
                  <ItemTemplate>
                      
                        <div class="qandan" >
                      <asp:linkbutton ID="question" runat="server" CssClass="searchquestion" Text='<%# Eval("qtitle") %>' PostBackUrl='~/detailQuestion.aspx' ></asp:linkbutton>
                          <br />
                        <div class="clear"></div>
                      <asp:label ID="answer1" runat="server" CssClass="answer" PostBackUrl="~/detailQuestion.aspx"></asp:label>
                      <br />
                              <asp:label ID="date" runat="server" Text='<%# Eval("datatime") %>' style="float:right" CssClass="date"></asp:label>
                      <br />
                     
                          </div>

                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          
          <PagerTemplate>
              <br />
          </PagerTemplate>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TUser]"></asp:SqlDataSource>

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
</div>
    </form>
</body>
</html>