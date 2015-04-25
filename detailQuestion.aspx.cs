using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;

public partial class detailQuestion : System.Web.UI.Page
{
    MySql sql = new MySql();
    String user = StaticVariable.cookie.cookieisequal();
    String id;
    String url = HttpContext.Current.Request.Url.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (user != "")
        {
            login.Style["display"] = "none";
            logined.Style["display"] = "block";
            loguser.InnerText = user;
        }
        if ( url.IndexOf("?") == -1 )
        {
            //Response.Redirect("detailQuestion.aspx?5");
            return;
        }

        id = Regex.Replace(url, "[\\d\\D]*\\?", "");

        if (Regex.Match(id, "^\\d+$").Length == 0)
        {
            return;
        }


        String sq = "select * from TQuestion where id = " + id;
        DataSet dq = sql.sqlsearch(sq);
        if (StaticVariable.istablehad(dq))
        {
            Image1.ImageUrl = getuserhead(dq.Tables["t"].Rows[0]["userid"].ToString());
            Label1.Text = getusername(dq.Tables["t"].Rows[0]["userid"].ToString());
            question.Text = dq.Tables["t"].Rows[0]["qtitle"].ToString();
            //dtquestion.Text = dq.Tables["t"].Rows[0]["qdetial"].ToString();
            date.Text = Convert.ToDateTime(dq.Tables["t"].Rows[0]["datatime"]).ToString("yyyy-MM-dd");

        }

        // keyanswer
        String keyid = dq.Tables["t"].Rows[0]["keyanswerid"].ToString();

        if (keyid != "")
        {
            String kanswer = "select * from TAnswer where id = " + keyid;
            DataSet keyds = sql.sqlsearch(kanswer);
            if (StaticVariable.istablehad(keyds))
            {
                Label4.Text = getusername(keyds.Tables["t"].Rows[0]["userid"].ToString());
                keyanswerimg.ImageUrl = getuserhead(keyds.Tables["t"].Rows[0]["userid"].ToString());
                keyanswertext.Text = keyds.Tables["t"].Rows[0]["adetial"].ToString();
                Label5.Text = Convert.ToDateTime(keyds.Tables["t"].Rows[0]["datatime"]).ToString("yyyy-MM-dd");
                //暂 反 数目
                Label2.Text = keyds.Tables["t"].Rows[0]["agree"].ToString();
                Label3.Text = keyds.Tables["t"].Rows[0]["disagree"].ToString();

                // 添加 data 属性 确定 ajax
                argeeimg.Attributes["data-id"] = keyid;
                disagreeimg.Attributes["data-id"] = keyid;
                argeeimg.Attributes["data-which"] = "agree";
                disagreeimg.Attributes["data-which"] = "disagree";

                String imgurl = keyds.Tables["t"].Rows[0]["imgsrc"].ToString();
                if (imgurl != "")
                {
                    imganswer.ImageUrl = imgurl;
                }
            }
            else
            {
                keyanswer.Style["display"] = "none";
            }
        }
        else
        {
            keyanswer.Style["display"] = "none";
        }

        //除了 keyanswerid 以外的 答案
        String selectsql = "";
        if (keyid != "")
        {
            selectsql = "select * from TAnswer  where qid = " + id + " and id <>" + keyid + "ORDER BY score desc";
        }
        else
        {
            selectsql = "select * from TAnswer where qid = " + id + " ORDER BY score desc";
        }

        DataSet ds = sql.sqlsearch(selectsql);

        GridView1.DataSource = ds.Tables["t"];
        GridView1.DataBind();

        int nu = ds.Tables["t"].Rows.Count;
        if (nu > 0)
        {
            for (int i = 0; i < nu; i++)
            {
                ((Label)GridView1.Rows[i].FindControl("dtanswer")).Text = ds.Tables["t"].Rows[i]["adetial"].ToString();

                String userid = ds.Tables["t"].Rows[i]["userid"].ToString();
                ((Label)GridView1.Rows[i].FindControl("Label1")).Text = getusername(userid);
                //赞同反对
                ((Label)GridView1.Rows[i].FindControl("Label2")).Text = ds.Tables["t"].Rows[i]["agree"].ToString();
                ((Label)GridView1.Rows[i].FindControl("Label3")).Text = ds.Tables["t"].Rows[i]["disagree"].ToString();

                ((Image)GridView1.Rows[i].FindControl("Image1")).ImageUrl = getuserhead(userid);
                ((Label)GridView1.Rows[i].FindControl("date")).Text = Convert.ToDateTime(ds.Tables["t"].Rows[i]["datatime"]).ToString("yyyy-MM-dd");

                //添加 data 属性 ajax专用
                String idajax = ds.Tables["t"].Rows[i]["id"].ToString();
                ((Image)GridView1.Rows[i].FindControl("argeeimg")).Attributes["data-id"] = idajax;
                ((Image)GridView1.Rows[i].FindControl("disagreeimg")).Attributes["data-id"] = idajax;
                ((Image)GridView1.Rows[i].FindControl("argeeimg")).Attributes["data-which"] = "agree";
                ((Image)GridView1.Rows[i].FindControl("disagreeimg")).Attributes["data-which"] = "disagree";

                String imgurl = ds.Tables["t"].Rows[i]["imgsrc"].ToString();
                if (imgurl != "")
                {
                    ((Image)GridView1.Rows[i].FindControl("imganswer")).ImageUrl = imgurl;
                }
            }
        }
    }

    protected String getusername(String id)
    {
        String selectsql = "select username from TUser where id = " + id;
        DataSet ds = sql.sqlsearch(selectsql);

        if (ds.Tables["t"].Rows.Count > 0)
        {
            return ds.Tables["t"].Rows[0]["username"].ToString();
        }

        return "";
    }

    protected String getuserhead(String id)
    {
        String selectsql = "select head from TUser where id = " + id;
        DataSet ds = sql.sqlsearch(selectsql);

        if (ds.Tables["t"].Rows.Count > 0)
        {
            return ds.Tables["t"].Rows[0]["head"].ToString();
        }

        return "";
    }

    protected void submitanswer_Click(object sender, EventArgs e)
    {
        String adetial = answertext.Text;
        if (adetial == "")
        {
            return;
        }
        String userid = getuserid(user);
        String time = DateTime.Now.ToString("yyyy/MM/dd");
        String insertsql;
        if (updateimg.ImageUrl == "")
        {
            insertsql = "insert [TAnswer]([adetial],[qid],[agree],[disagree],[score],[userid],[datatime]) values(N'" + adetial + "', " + id + ", 0, 0, 0, " + userid + ", '" + time + "')";
        }
        else
        {
            insertsql = "insert [TAnswer]([adetial],[qid],[agree],[disagree],[score],[userid],[datatime],[imgsrc]) values(N'" + adetial + "', " + id + ", 0, 0, 0, " + userid + ", '" + time + "', '" + updateimg.ImageUrl + "')";
        }
        sql.sqlinsert(insertsql);
        Response.Write(" <script type='text/javascript'>alert('回答成功!!!')</script>");

        Response.Redirect(url);
    }
    protected void answertext_TextChanged(object sender, EventArgs e)
    {

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
        Response.Redirect("askquestion.aspx?" + searchtb.Text);
    }

    protected void update_Click(object sender, EventArgs e)
    {
        string str = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string fileName = str;
        string fullFileName = this.FileUpload1.PostedFile.FileName;
        string fileType = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
        if (fileType == "jpg" || fileType == "png" || fileType == "bmp" || fileType == "gif" || fileType == "JPG" || fileType == "PNG" || fileType == "BMP" || fileType == "GIF")
        {
            this.FileUpload1.PostedFile.SaveAs(Server.MapPath("images") + "\\" + fileName + "." + fileType);
            this.updateimg.ImageUrl = "images/" + fileName + "." + fileType;
            //imgurl = this.updateimg.ImageUrl;
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('图片格式不正确，请重新选择');</script>");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        String addsqlstr = "update TQuestion set reportnum = reportnum + 1 where id = " + id;
        sql.sqlinsert(addsqlstr);
        Response.Write(" <script type='text/javascript'>alert('举报成功!!!')</script>");
    }
}