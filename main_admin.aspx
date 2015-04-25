<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main_admin.aspx.cs" Inherits="main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 35px;
        }
        .auto-style3 {
            height: 4px;
        }
        .auto-style4 {
            height: 17px;
        }
        .auto-style5 {
            width: 120px;
        }
        .auto-style6 {
            width: 120px;
            height: 100px;
        }
        .auto-style7 {
            width: 120px;
            height: 15px;
        }
        .auto-style8 {
            width: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">注销</asp:LinkButton>
        
    <div style="width: 100%; height: 100%; background-image: url('images/admin_background.jpg');">
    <table style="width: 100%; height: 765px;">
        <tr>
            <td class="auto-style2" style="background-color: #363636" colspan="3"></td>
        </tr>
        <tr>
            <td class="auto-style3" style="background-color: #0099FF" colspan="3"></td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="3"></td>
        </tr>
        <tr>
            <td class="auto-style8">
                
            </td>
            <td>
                <table border="0" class="auto-style4" style="border-width: 0px; border-style: hidden; width: 100%; height: 100%;">
                    <tr>
                        <td class="auto-style6" style="background-color: #C0C0C0; text-align: center;">
                            <asp:Image ID="Image1" runat="server" Height="81px" ImageUrl="images/logo2.png" style="text-align: center" Width="96px" />
                        </td>
                        <td rowspan="7" style="background-color: #FFFFFF">
                            <asp:GridView ID="data_user" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="100%" Width="100%">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:TemplateField HeaderText="编号" InsertVisible="False" SortExpression="Id">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UserName" HeaderText="用户名" SortExpression="UserName" />
                                    <asp:BoundField DataField="email" HeaderText="电子邮箱" SortExpression="email" />
                                    <asp:TemplateField HeaderText="性别" SortExpression="sex">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("sex") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("sex") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="quanxian" HeaderText="权限" SortExpression="quanxian" />
                                    <asp:TemplateField HeaderText="头像" SortExpression="head">
                                       
                                        <ItemTemplate>
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("head") %>' style="width:40px;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="qid" HeaderText="问过问题的编号" SortExpression="qid" />
                                    <asp:BoundField DataField="aid" HeaderText="贡献答案的编号" SortExpression="aid" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click1" Text="给予教师权限" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [UserName], [Password], [email], [sex], [quanxian], [head], [qid], [aid] FROM [TUser]"></asp:SqlDataSource>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [UserName], [Password], [email], [sex], [quanxian], [head], [qid], [aid] FROM [TUser]" DeleteCommand="DELETE FROM [TUser] WHERE [Id] = @Id" InsertCommand="INSERT INTO [TUser] ([UserName], [Password], [email], [sex], [quanxian], [head], [qid], [aid]) VALUES (@UserName, @Password, @email, @sex, @quanxian, @head, @qid, @aid)" UpdateCommand="UPDATE [TUser] SET [UserName] = @UserName, [Password] = @Password, [email] = @email, [sex] = @sex, [quanxian] = @quanxian, [head] = @head, [qid] = @qid, [aid] = @aid WHERE [Id] = @Id">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="UserName" Type="String" />
                                    <asp:Parameter Name="Password" Type="String" />
                                    <asp:Parameter Name="email" Type="String" />
                                    <asp:Parameter Name="sex" Type="Int32" />
                                    <asp:Parameter Name="quanxian" Type="Int32" />
                                    <asp:Parameter Name="head" Type="String" />
                                    <asp:Parameter Name="qid" Type="String" />
                                    <asp:Parameter Name="aid" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="UserName" Type="String" />
                                    <asp:Parameter Name="Password" Type="String" />
                                    <asp:Parameter Name="email" Type="String" />
                                    <asp:Parameter Name="sex" Type="Int32" />
                                    <asp:Parameter Name="quanxian" Type="Int32" />
                                    <asp:Parameter Name="head" Type="String" />
                                    <asp:Parameter Name="qid" Type="String" />
                                    <asp:Parameter Name="aid" Type="String" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="background-color: #C0C0C0; height: 20px;">
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="background-color: #C0C0C0; height: 20px;">
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="background-color: #C0C0C0; height: 20px;">
                            <asp:Button ID="Button3" runat="server" Text="用户管理" BackColor="Silver" BorderStyle="None" Font-Names="Microsoft JhengHei UI Light" Height="100%" Width="100%" Font-Size="Medium" ForeColor="#666666"  />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="background-color: #C0C0C0; height: 20px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="background-color: #C0C0C0; height: 20px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="background-color: #C0C0C0">&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td class="auto-style8">
                
            </td>
        </tr>
    </table>
    </div>
    
    </form>
    
</body>
</html>
