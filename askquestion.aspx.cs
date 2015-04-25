using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class askquestion : System.Web.UI.Page
{
    MySql sql = new MySql();
    String user = StaticVariable.cookie.cookieisequal();
    string text = "";
    string url = HttpContext.Current.Request.Url.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (user != "")
        {
            login.Style["display"] = "none";
            logined.Style["display"] = "block";
            loguser.InnerText = user;

        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('请先登录!!');window.window.location.href= 'login.aspx'</script>");
            return;
        }
        if (url.IndexOf("?") > -1)
        {
            text = Regex.Replace(url, "[\\d\\D]*\\?", "");
            if (TextBox1.Text == "")
            {
                searchtb.Text = text;
                TextBox1.Text = text;
            }
        }

        
    }

    protected void askbtn_Click(object sender, EventArgs e)
    {
        String qtitle = TextBox1.Text;
        String time = DateTime.Now.ToString("yyyy/MM/dd");


        String maxid = "select id from TQuestion where id = (select MAX(id) from TQuestion)";
        DataSet maxds = sql.sqlsearch(maxid);
        String md = maxds.Tables["t"].Rows[0]["id"].ToString();

        String insertStr = "insert into [TQuestion]([qtitle],[userid],[datatime]) values(N'" + qtitle + "', '" + getuserid(user) + "', '" + time + "')";
        sql.sqlinsert(insertStr);

        //String searchid = "select id from TQuestion where qtitle = '" + qtitle +"'";// +"' and datatime like '" + time + "'";

        String searchid = "select id from TQuestion where id > " + md + " and userid = " + getuserid(user);
        DataSet ds = sql.sqlsearch(searchid);
        String linktoid = ds.Tables["t"].Rows[0]["id"].ToString();

        Response.Write("<script type='text/javascript'>alert('跳转页面....');window.window.location.href = 'detailQuestion.aspx?'" + linktoid + "</script>");
        StaticVariable.updatekey(int.Parse(linktoid));
        Response.Redirect("detailQuestion.aspx?" + linktoid);
    }


    private String getuserid(String username)
    {
        String searchsql = "select id from TUser where username = '" + username + "'";
        DataSet ds = sql.sqlsearch(searchsql);
        return ds.Tables["t"].Rows[0]["id"].ToString();
    }
    protected void searchbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("search.aspx?" + searchtb.Text);
    }
    protected void updateq_Click(object sender, EventArgs e)
    {
        Response.Redirect("askquestion.aspx");
    }
}