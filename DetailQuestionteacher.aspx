<%@ Page Language="C#" enableEventValidation="false" AutoEventWireup="true" CodeFile="DetailQuestionteacher.aspx.cs" Inherits="DetailQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
    <style>
        #Keyanswer{
            margin-top:10px;

        }
        body
        {
             background:none;
                background-image:url(images/lift_bg_3.jpg);
                background-repeat:repeat-y;

        }
        #content
        {
            width:700px;
            margin:auto;
          color:white;
        }

        #top_header a{
	       font-size:19px;
        }
        .choosekey
        {
             border: none;
    background:none;
    background: url('images/choosekey.png');
    width:138px;
    height:37px;
        }

        .submit_img {
    border: none;
    background:none;
    background: url('images/submit_img.png');
    width:138px;
    height:37px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
         <div id="top_header"><a href="cancel.aspx">注销</a></div>
         <div id="content">
    <div id="main1">
        <asp:TextBox ID="Question" runat="server" TextMode="MultiLine" style="width:203px;height:60px;"></asp:TextBox>
        <br />
        <div><asp:TextBox ID="Keyanswer"  style="float:left" runat="server" placeholder="您可以输入答案并选择为参考答案" Height="188px" TextMode="MultiLine" Width="273px"></asp:TextBox><asp:Image ID="updateimg" runat="server" style="float:left;width:273px;" /></div>
          
          <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fileupload" BorderStyle="None"/>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" CssClass="submit_img"  />
        <br />
        <asp:Button ID="choosekeyanswer"  runat="server" CssClass="choosekey" OnClick="choosekeyanswer_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True">
            <Columns>
                <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="Id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="adetial" SortExpression="adetial">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("adetial") %>' Height="100px" TextMode="MultiLine" Width="273px"></asp:TextBox>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("imgsrc") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="imgsrc" HeaderText="imgsrc" SortExpression="imgsrc" />
                <asp:BoundField DataField="agree" HeaderText="agree" SortExpression="agree" />
                <asp:BoundField DataField="disagree" HeaderText="disagree" SortExpression="disagree" />
                <asp:BoundField DataField="datatime" HeaderText="datatime" SortExpression="datatime" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" CssClass="choosekey" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [adetial], [agree], [disagree], [imgsrc], [datatime] FROM [TAnswer]"></asp:SqlDataSource>
    </div>
            </div>
    </form>
</body>
</html>
