using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_login : System.Web.UI.Page
{
    MySql sql = new MySql();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_OnClick(object sender, EventArgs e)
    {
        String user = UserName.Text;
        String pwd = Password.Text;

        String sqlsearch = "select * from TUser where username = '" + user + "'";

        DataSet ds = sql.sqlsearch(sqlsearch);

        if (StaticVariable.istablehad(ds))
        {
            String pass = ds.Tables["t"].Rows[0]["password"].ToString();
            if (pass == pwd)
            {
                StaticVariable.cookie.xierucookie(ds.Tables["t"].Rows[0]["id"].ToString(), ds.Tables["t"].Rows[0]["username"].ToString(), ds.Tables["t"].Rows[0]["password"].ToString(), ds.Tables["t"].Rows[0]["quanxian"].ToString());

                if (ds.Tables["t"].Rows[0]["quanxian"].ToString() == "1")
                {
                    Response.Redirect("question.aspx");
                }
                else if (ds.Tables["t"].Rows[0]["quanxian"].ToString() == "0")
                {
                    Response.Redirect("main_admin.aspx");
                }
            }
            else
            {
                Response.Write(" <script type='text/javascript'>alert('密码错误!!!')</script>");
            }
        }
        else
        {
            Response.Write(" <script type='text/javascript'>alert('用户名不存在!!!')</script>");
        }
    }
}