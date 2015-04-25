using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;

public partial class DetailQuestion : System.Web.UI.Page {

    MySql sql = new MySql();
    String url = HttpContext.Current.Request.Url.ToString();
    String user = StaticVariable.cookie.cookieisequal();
    String updateid = "-1";

    string id = "";
    protected void Page_Load(object sender, EventArgs e) {
        String user = StaticVariable.cookie.cookieisequal();

        if (user == "") {
            Response.Redirect("admin_login.aspx");
        }

        String quanxian = StaticVariable.cookie.qucookie("quanxian");
        if (quanxian != "1") {
            Response.Redirect("admin_login.aspx");
        }


        if(url.IndexOf("?") == -1) {
            return;
        }

        id = Regex.Replace(url, "[\\d\\D]*\\?", "");

        if ( Regex.Match(id, "\\d+").Length == 0 ) {
            return;
        }

        String qstr = "select * from TQuestion where id = " + id;
        DataSet dsq = sql.sqlsearch(qstr);

        String keyid = dsq.Tables["t"].Rows[0]["keyanswerid"].ToString();
        if (keyid != "-1" ) {
            if (!IsPostBack) {
                String answer = "select * from TAnswer where id = " + keyid;
                DataSet ads = sql.sqlsearch(answer);
                Keyanswer.Text = ads.Tables["t"].Rows[0]["adetial"].ToString();
            }
            updateid = keyid;
        }

        if (!IsPostBack) {
            Question.Text = dsq.Tables["t"].Rows[0]["qtitle"].ToString();
        }


        String searchsql = "select * from TAnswer where qid = " + id + " and id <> " + keyid + " order by score desc";
        DataSet ds = sql.sqlsearch(searchsql);

        GridView1.DataSource = ds.Tables["t"];
        GridView1.DataBind();

    }
    protected void TextBox5_TextChanged(object sender, EventArgs e) {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {

    }

    protected void Button1_Click1(object sender, EventArgs e) {
        GridViewRow gvr = (sender as Button).NamingContainer as GridViewRow;
        int nu = gvr.RowIndex;
        Label Label1 = (Label)GridView1.Rows[nu].FindControl("Label1");
        String keyid = Label1.Text;
        String updatestr = "update TQuestion set keyanswerid = " + keyid + ", qtitle = N'" + Question.Text + "' where id = " + id;
        sql.sqlinsert(updatestr);
        //String deletestr = "delete from TAnswer where id = " + keyid;
        //sql.sqlinsert(deletestr);
        Response.Write("<script type='text/javascript'>alert('选定成功')</script>");
        StaticVariable.updatekey(int.Parse(id));
        Response.Redirect("question.aspx");

    }
    protected void choosekeyanswer_Click(object sender, EventArgs e) {
        String time = DateTime.Now.ToString("yyyy/MM/dd");
        String userid = getuserid(user);
        String maxid = "select id from TAnswer where id = (select MAX(id) from TAnswer)";
        DataSet maxds = sql.sqlsearch(maxid);
        String md = maxds.Tables["t"].Rows[0]["id"].ToString();

        if (updateid == "-1") {
            String answerstr = "insert into [TAnswer]([adetial],[qid],[agree],[disagree],[score],[userid],[datatime],[imgsrc])values(N'" + Keyanswer.Text + "', " + id + ", 1000, 0, 1000, " + userid + ", '" + time + "', '" + updateimg.ImageUrl + "')";
            sql.sqlinsert(answerstr);
            String searchid = "select id from TAnswer where id > " + md + " and userid = " + userid;
            DataSet ds = sql.sqlsearch(searchid);
            String linktoid = ds.Tables["t"].Rows[0]["id"].ToString();

            String updatestr = "update TQuestion set keyanswerid = " + linktoid + ", qtitle = '" + Keyanswer.Text + "' where id = " + id;
            sql.sqlinsert(updatestr);

        }
        else {
            String answerstr = "update TAnswer set adetial = N'" + Keyanswer.Text + "',  disagree = 1, imgsrc = '" + updateimg.ImageUrl + "' where id = " + updateid;
            sql.sqlinsert(answerstr);
            UpdateQuestion();
        }
        StaticVariable.updatekey(int.Parse(id));
        Response.Redirect("question.aspx");
    }

    private String getuserid(String username) {
        String searchsql = "select id from TUser where username = '" + username + "'";
        DataSet ds = sql.sqlsearch(searchsql);
        return ds.Tables["t"].Rows[0]["id"].ToString();
    }
    protected void Button2_Click(object sender, EventArgs e) {
        string str = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string fileName = str;
        string fullFileName = this.FileUpload1.PostedFile.FileName;
        string fileType = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
        if (fileType == "jpg" || fileType == "png" || fileType == "bmp" || fileType == "gif" || fileType == "JPG" || fileType == "PNG" || fileType == "BMP" || fileType == "GIF") {
            this.FileUpload1.PostedFile.SaveAs(Server.MapPath("images") + "\\" + fileName + "." + fileType);
            this.updateimg.ImageUrl = "images/" + fileName + "." + fileType;
        }
        else {
            Response.Write("<script type='text/javascript'>alert('图片格式不正确，请重新选择');</script>");
        }
    }

    private void UpdateQuestion() {
        String upq = "update TQuestion set qtitle = N'" + Question.Text + "' where id = " + id;
        sql.sqlinsert(upq);
    }
}