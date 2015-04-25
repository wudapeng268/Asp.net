<%@ Page Language="C#" AutoEventWireup="true" CodeFile="question.aspx.cs" Inherits="question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
    <style>
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

        .col1
	{
		width: 130px;
		height: 40px;
		clear: left;
		float:left;
		overflow: hidden;  
    	white-space: nowrap;
    	-o-text-overflow: ellipsis;
    	text-overflow: ellipsis;
	}
	.col2
	{
		width: 400px;
		height: 40px;
		float: left;
		overflow: hidden;  
    	white-space: nowrap;
    	-o-text-overflow: ellipsis;
    	text-overflow: ellipsis;
	}

        #TextArea1 {
            height: 71px;
            width: 394px;
        }
        #TextArea2 {
            height: 58px;
            width: 397px;
        }

    </style>
</head>
<body>
    <div id="top_header"><a href="cancel.aspx">注销</a><br />
    </div>
    
    <form id="form1" runat="server">
       
        <div id="content">

             <div id="add">
                 <br />
                 <asp:Label ID="Label2" runat="server" Text="添加一个新的问题:"></asp:Label>
                 <br />
                 <asp:TextBox ID="TextBox2" runat="server" Height="69px" Width="395px"></asp:TextBox>
                 <br />
                 <asp:Label ID="Label3" runat="server" Text="添加此问题的标准答案:"></asp:Label>
                 <br />
                 <asp:TextBox ID="TextBox3" runat="server" Height="50px" Width="391px"></asp:TextBox>
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
    </div>
    <div style="margin:auto;width:50%;margin-top:10px;font-size:18px;color:red;" runat="Server" id="tishi"></div>
            <br />
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select * from TQuestion where reportnum &gt;= 10 order by reportnum desc" DeleteCommand="DELETE FROM [TQuestion] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TQuestion] ([qtitle], [datatime], [reportnum]) VALUES (@qtitle, @datatime, @reportnum)" UpdateCommand="UPDATE [TQuestion] SET [qtitle] = @qtitle, [datatime] = @datatime, [reportnum] = @reportnum WHERE [Id] = @Id">
             <DeleteParameters>
                 <asp:Parameter Name="Id" Type="Int32" />
             </DeleteParameters>
             <InsertParameters>
                 <asp:Parameter Name="qtitle" Type="String" />
                 <asp:Parameter Name="datatime" Type="DateTime" />
                 <asp:Parameter Name="reportnum" Type="Int32" />
             </InsertParameters>
             <UpdateParameters>
                 <asp:Parameter Name="qtitle" Type="String" />
                 <asp:Parameter Name="datatime" Type="DateTime" />
                 <asp:Parameter Name="reportnum" Type="Int32" />
                 <asp:Parameter Name="Id" Type="Int32" />
             </UpdateParameters>
        </asp:SqlDataSource>
         <br />
        <div id="keyanswer" runat="Server">请选择一个参考答案</div>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
             <Columns>
                 <asp:TemplateField HeaderText="编号" InsertVisible="False" SortExpression="Id">
                     <EditItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="题目" SortExpression="qtitle">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("qtitle") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Eval("qtitle") %>'></asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="datatime" HeaderText="日期" SortExpression="datatime" />
             </Columns>
         </asp:GridView>
    
        <br />
        <div id="jubao" runat="Server">这些问题的举报人数过多,请查看</div>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="编号" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="qtitle" HeaderText="题目" SortExpression="qtitle" />
                <asp:BoundField DataField="datatime" DataFormatString="{0:d}" HeaderText="日期" SortExpression="datatime" />
                <asp:BoundField DataField="reportnum" HeaderText="举报数" SortExpression="reportnum" />
            </Columns>
        </asp:GridView>
   
        <div id="notkey" runat="Server">这些问题的参考答案反对人数较多,请审核</div>
        
            </div>
    </form>
</body>
</html>
