using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String user = StaticVariable.cookie.cookieisequal();

        if (user == "")
        {
            Response.Redirect("admin_login.aspx");
        }

        String quanxian = StaticVariable.cookie.qucookie("quanxian");
        if (quanxian != "0")
        {
            Response.Redirect("admin_login.aspx");
        }

    }

    protected void Button4_Click1(object sender, EventArgs e)
    {
        GridViewRow gvr = (sender as Button).NamingContainer as GridViewRow;

        int nu = gvr.RowIndex;
        Label Label1 = (Label)data_user.Rows[nu].FindControl("Label1");

        String keyid = Label1.Text;
        MySql sql = new MySql();
        String updatestr = "update TUser set quanxian = " + 1 + " where id = " + keyid;
        sql.sqlinsert(updatestr);

        Response.Write("<script type='text/javascript'>alert('更改成功');window.window.location.href = 'main_admin.aspx';</script>");

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("cancel.aspx");
    }
}