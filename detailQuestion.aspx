<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detailQuestion.aspx.cs" Inherits="detailQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
#searchtb
{
    padding:10px;border-radius:5px;border:1px solid #D4D4D4;
    box-shadow:inset 0 2px 5px #eee;color:#B8B8B8;
    margin-top:5px;
}

</style>
</head>

<body>

<!--Header Start Here-->
    <form id="Form1" runat="server">
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
              <%--<span id="loguser" class="loged">jjjjj</span>--%>
            </li>
          </div>
          </ul>  
      </div>
         
    </div>
  </div>
  <!--Top Header End Here-->
  <div id="logo_nav2">
    <div >
      <div class="center_frame"> 
        <!--Logo And Navigation Start Here-->
        <div id="logo" class="search"> <a href="Default.aspx"><img src="images/logo.png" alt=""  /></a>  <em><p>江苏科技大学</p>
            <p>自动问答平台</p></em> </div> 
          <div class="search2">
            <asp:TextBox ID="searchtb" runat="server" Height="16px" Width="423px"></asp:TextBox>
            
          </div>
            <asp:Button ID="searchbtn" runat="server"  CssClass="searchanswer" OnClick="searchbtn_Click"   />
          <asp:Button ID="updateq" runat="server" CssClass="post_question" style="" OnClick="updateq_Click"></asp:Button>
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
  <div id="main_contant" runat="server" class="lift_bg_1">
      <div class="xuanfu">

      </div>
      <div class="xuanfu2" >
          <asp:TextBox ID="answertext" runat="server" placeholder="请输入你的答案" Height="269px" TextMode="MultiLine" Width="234px"></asp:TextBox>
          <br />
          <asp:Image ID="updateimg" runat="server" CssClass="updateimg"/>
          <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fileupload" BorderStyle="None"/>
          <div class="clear"></div>
          
          <asp:Button ID="update" runat="server" Text="" OnClick="update_Click" style="float:left;" CssClass="submit_img" />
          <asp:Button ID="submitanswer" runat="server" OnClick="submitanswer_Click" />
          
      </div>
      <div style="margin-left:14%; width:50%; margin-top:20px;">
       <div class="questionimg"><asp:Image ID="Image1" runat="server" CssClass="questionimg"  />
            <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label>
           
       </div>
           <div class="qandan">
           <asp:Label ID="question" runat="server" CssClass="question" Text="1"></asp:Label>
            <br />
               
      <asp:label ID="date" runat="server" Text="2014-3-2" style="float:right" CssClass="date"></asp:label>
               <br />
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="report" OnClick="LinkButton1_Click"></asp:LinkButton>
       </div>
          </div>
      <div class="clear"></div>
      <div style="margin-left:14%; width:50%; margin-top:10px; color:white;" id="keyanswer" runat="server">
          <asp:Label ID="keyanswerlabel" runat="server" Text="参考答案" style="font-size:18px;float:left;" ForeColor="Red"></asp:Label>
          <br />
          <br />
       <div class="questionimg"><asp:Image ID="keyanswerimg" runat="server" CssClass="questionimg"  />
            <asp:Label ID="Label4" runat="server" Text="Label" ></asp:Label>
           
       </div>
           <div class="qandan">
           <asp:Label ID="keyanswertext" runat="server" CssClass="keyanswer" Text="1"></asp:Label>
            <br />
               <asp:Image ID="imganswer" runat="server" style = "width:200px" onclick="lookbigimg(this)"  CssClass="imganswer"  />
               <br />
               
            <div style="float:right">
                            <div style="float:left">
                         <asp:Image ID="argeeimg" runat="server" class="imgclick" ImageUrl="~/images/agree.png" style="margin-right:6px" /><asp:Label ID="Label2" runat="server" Text="123"></asp:Label>
                          <asp:Image ID="disagreeimg" runat="server" class="imgclick" ImageUrl="~/images/disagree.png" /><asp:Label ID="Label3" runat="server" Text="123"></asp:Label>&nbsp&nbsp&nbsp
                                </div>
                      <div style="float:right">
                      <asp:label ID="Label5" runat="server" Text="2014-3-2" style="float:right" CssClass="date"></asp:label>
                      
                        </div>
                      </div>
       </div>
          </div>
      <div class="clear"></div>
      <asp:Label ID="Label6" runat="server" Text="其他答案" style="margin-left:14%; width:50%; margin-top:15px;font-size:16px;float:left;" ForeColor="black"></asp:Label>
          <br />
         
        <asp:GridView ID="GridView1" runat="server" class="gridview" GridLines="None"  AutoGenerateColumns="False" DataKeyNames="Id" CellSpacing="4" >
          
          <Columns>
              <asp:TemplateField>
                  <ItemTemplate>
                      <div class="questionimg"><asp:Image ID="Image1" runat="server" CssClass="questionimg"  />
                          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                      </div>
                      <div class="qandan">
                      <asp:Label ID="dtanswer" runat="server"  ></asp:Label>
                      <br />
                           <asp:Image ID="imganswer" runat="server" style = "width:200px" onclick="lookbigimg(this)" CssClass="imganswer"/>
                          <br />
                        <div style="float:right">
                            <div style="float:left">
                         <asp:Image ID="argeeimg" runat="server" class="imgclick" ImageUrl="~/images/agree.png" style="margin-right:6px" /><asp:Label ID="Label2" runat="server" Text="123"></asp:Label>
                          <asp:Image ID="disagreeimg" runat="server" class="imgclick" ImageUrl="~/images/disagree.png" /><asp:Label ID="Label3" runat="server" Text="123"></asp:Label>&nbsp&nbsp&nbsp
                                </div>
                      <div style="float:right">
                      <asp:label ID="date" runat="server" Text="2014-3-2" style="float:right" CssClass="date"></asp:label>
                      
                        </div>
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