using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class question : System.Web.UI.Page {
    MySql sql = new MySql();
    String user;
    protected void Page_Load(object sender, EventArgs e) {
        user = StaticVariable.cookie.cookieisequal();
        if (user == "") {
            Response.Redirect("admin_login.aspx");
        }

        String quanxian = StaticVariable.cookie.qucookie("quanxian");
        if (quanxian != "1") {
            Response.Redirect("admin_login.aspx");
        }

        String searchsql = "select * from TQuestion where keyanswerid = -1";
        DataSet ds = sql.sqlsearch(searchsql);
        GridView1.DataSource = ds.Tables["t"];
        GridView1.DataBind();
        if (!StaticVariable.istablehad(ds)) {
            keyanswer.Style["display"] = "none";
            tishi.InnerHtml = "恭喜您,已经没有要处理的问题了!!!<br/>";
        }
        if (GridView2.Rows.Count == 0) {
            jubao.Style["display"] = "none";
            tishi.InnerHtml += "恭喜您,已经没有举报数大于10的问题了!!!";
        }


        String oppstr = "select qid, adetial,disagree,qtitle from TQuestion q,TAnswer a where q.keyanswerid = a.id and a.disagree >= 100";
        DataSet oppds = sql.sqlsearch(oppstr);

        if (StaticVariable.istablehad(oppds)) {
            String str = "";
            for (int i = 0; i < oppds.Tables["t"].Rows.Count; i++) {
                str += "<div class='col1'>问题:</div><a href='DetailQuestionteacher.aspx?" + oppds.Tables["t"].Rows[i]["qid"].ToString() + "'><div class='col2'>" + oppds.Tables["t"].Rows[i]["qtitle"].ToString() + "</div></a><div class='col1'>参考答案:</div><div class='col2'>" + oppds.Tables["t"].Rows[i]["adetial"].ToString() + "</div><div class='col1'>反对数:</div><div class='col2'>" + oppds.Tables["t"].Rows[i]["disagree"].ToString() + "</div>";

                //str += "<tr><td>问题</td><td>" + oppds.Tables["t"].Rows[i]["qtitle"].ToString() + "</td></tr><tr><td>详细答案</td><td>" + oppds.Tables["t"].Rows[i]["adetial"].ToString() + "</td></tr><tr><td>反对数</td><td>" + oppds.Tables["t"].Rows[i]["disagree"].ToString() + "</td></tr>";
            }
          

                notkey.InnerHtml = str;

        }
        else
        {
            
                notkey.Style["display"] = "none";
                tishi.InnerHtml += "恭喜您,已经没有反对数较多的问题";
            
            
        }

    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e) {

    }
    protected void LinkButton1_Click(object sender, EventArgs e) {
        GridViewRow gvr = (sender as LinkButton).NamingContainer as GridViewRow;

        int nu = gvr.RowIndex;
        Label Label1 = (Label)GridView1.Rows[nu].FindControl("Label1");

        String qid = Label1.Text;
        Response.Redirect("DetailQuestionteacher.aspx?" + qid);
    }
    protected void Button1_Click(object sender, EventArgs e) {
        String questionstr = TextBox2.Text;
        String answerstr = TextBox3.Text;

        String maxid = "select id from TQuestion where id = (select MAX(id) from TQuestion)";
        DataSet maxds = sql.sqlsearch(maxid);
        String md = maxds.Tables["t"].Rows[0]["id"].ToString();

        String insertStr = "insert into [TQuestion]([qtitle],[userid],[datatime]) values(N'" + questionstr + "', '" + getuserid(user) + "', '" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
        sql.sqlinsert(insertStr);

        String searchid = "select id from TQuestion where id > " + md + " and userid = " + getuserid(user);
        DataSet ds = sql.sqlsearch(searchid);
        String linktoid = ds.Tables["t"].Rows[0]["id"].ToString();

        String insertanswerstr = "insert [TAnswer]([adetial],[qid],[agree],[disagree],[score],[userid],[datatime]) values(N'" + answerstr + "', " + linktoid + ", 0, 0, 0, " + getuserid(user) + ", '" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
        sql.sqlinsert(insertanswerstr);


        sql.sqlinsert("update TQuestion set keyanswerid = (select id from TAnswer where qid = " + linktoid + ") where id = " + linktoid);



        Response.Write("<script type='text/javascript'>		(function ()		{			var isadd = confirm('添加成功');			if (isadd || !isadd) {				window.window.location.href = 'question.aspx';			}		})()	</script>");
    }

    private String getuserid(String username) {
        String searchsql = "select id from TUser where username = '" + username + "'";
        DataSet ds = sql.sqlsearch(searchsql);
        return ds.Tables["t"].Rows[0]["id"].ToString();
    }
}