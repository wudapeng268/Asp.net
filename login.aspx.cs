using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    MySql sql = new MySql();        //数据库操作类
    Cookie zccookie = StaticVariable.cookie;//cookie操作类

    protected void Page_Load(object sender, EventArgs e)
    {

        String user = zccookie.cookieisequal();
        if (user != "")
        {
            logining.Style["display"] = "none";
            logined.Style["display"] = "block";
            loguser.InnerHtml = user;
            Response.Redirect("Default.aspx");
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
            string check = "select * from TUser where username='" + username.Text + "'";
            DataSet ds = sql.sqlsearch( check);				//创建数据集
            if (StaticVariable.istablehad(ds))                      //判断
            {
                if(ds.Tables["t"].Rows[0]["password"].ToString() == password.Text)
                {
                    zccookie.xierucookie(ds.Tables["t"].Rows[0]["id"].ToString(), username.Text, password.Text, ds.Tables["t"].Rows[0]["quanxian"].ToString());

                    Response.Write("<script type='text/javascript'>alert('登陆成功');</script> ");
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //"密码错误";
                    Response.Write("<script type='text/javascript'>alert('密码错误');</script> ");
                }
            }
            else
            {
                //"用户名不存在";
                Response.Write("<script type='text/javascript'>alert('用户名不存在');</script> ");
            }
        }
        catch (Exception)
        {
        }
    }

}