using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

public partial class register : System.Web.UI.Page
{
    // 全局变量
    MySql sql = new MySql();        //数据库操作类
    Cookie zccookie = StaticVariable.cookie;//cookie操作类

    protected void Page_Load(object sender, EventArgs e)
    {
        String user = zccookie.cookieisequal();
        if (user != "")
        {
            login.Style["display"] = "none";
            logined.Style["display"] = "block";
            loguser.InnerHtml = user;
        }
    }
    protected void username_TextChanged(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        //注册
        if (Check(username.Text) || Check(password.Text))			//检查字串
        {
            err.Text = "用户信息中不能够包含特殊字符如<,>,',//,\\等,请审核";	//输出信息
        }
        else
        {
            try
            {
                string checksql = "select * from TUser where username='" + username.Text + "'";

                DataSet ds = sql.sqlsearch(checksql);				//创建数据集
                if (StaticVariable.istablehad(ds))                              //判断同名
                {
                    err.Text = "用户名存在";
                    return;
                }

                string emailsql = "select * from TUser where email='" + Email.Text + "'";
                DataSet dsemail = sql.sqlsearch(emailsql);				//创建数据集
                if (StaticVariable.istablehad(dsemail))                              //判断同名
                {
                    err.Text = "一个邮箱只能注册一次~~~";
                    return;
                }

                string strsql = "insert into [TUser] ([username], [password],[quanxian],[email]) values ('" + username.Text + "', '" + password.Text + "','" + 2 + "','"   + Email.Text + "')";             //插入表
                sql.sqlinsert(strsql);

                DataSet ds2 = sql.sqlsearch(checksql);

                zccookie.xierucookie(ds2.Tables["t"].Rows[0]["id"].ToString(), username.Text, password.Text, "2");
                this.Response.Write(" <script language = javascript>alert('注册成功');window.window.location.href = 'Default.aspx';</script>");
            }
            catch
            {
                err.Text = "出现错误信息, 请返回给管理员";
            }
        }
    }

    protected bool Check(string text)												//判断实现
    {
        if (text.Contains("<") || text.Contains(">") || text.Contains("'") ||
                text.Contains("//") || text.Contains("\\") || text.Contains(","))					//检查字串
        {
            return true;														//返回真
        }
        else
        {
            return false;														//返回假
        }
    }
}