using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;


public partial class about : System.Web.UI.Page
{
    MySql sql = new MySql();
    int length = 0;
    String user = StaticVariable.cookie.cookieisequal();

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

        // TUser
        String search = "select * from TUser where username = '" + user + "'";
        DataSet ds = sql.sqlsearch(search);
        String id = ds.Tables["t"].Rows[0]["id"].ToString();

        //TQuestion
        String qs = "select * from TQuestion where userid = " + id;
        DataSet qds = sql.sqlsearch(qs);
        //TAnswer
        String asearch = "select * from TAnswer where userid = " + id;
        DataSet ads = sql.sqlsearch(asearch);
        // 数目
        int qnu = qds.Tables["t"].Rows.Count;
        int anu = ads.Tables["t"].Rows.Count;

        String key = Regex.Replace(HttpContext.Current.Request.Url.ToString(), "^[\\d\\D]*?\\?", "");

        if (key == "question")
        {
            anu = 0;
        }
        else if (key == "answer")
        {
            qnu = 0;
        }
        else
        {
            tree.Style["display"] = "none";
            personalmsg.Style["display"] = "block";
            txtNickName.Text = user;
            //show_img.src = ds.Tables["t"].Rows[0]["head"].ToString();
            txtEmail.Text = ds.Tables["t"].Rows[0]["email"].ToString();
            lblAskNumber.Text = qnu + "";
            lblReviewNumber.Text = anu + "";
            show_img.ImageUrl = ds.Tables["t"].Rows[0]["head"].ToString();
            return;
        }





        String[,] str = new String[qnu + anu, 4];
        for (int i = 0; i < qnu; i++)
        {
            str[i, 0] = "detailQuestion.aspx?" + qds.Tables["t"].Rows[i]["id"].ToString();
            str[i, 1] = "提问: " + qds.Tables["t"].Rows[i]["qtitle"].ToString();
            str[i, 2] = "";//qds.Tables["t"].Rows[i]["qdetial"].ToString();
            str[i, 3] = Convert.ToDateTime(qds.Tables["t"].Rows[i]["datatime"]).ToString("yyyyMMdd");
        }

        for (int i = 0; i < anu; i++)
        {
            String qid = ads.Tables["t"].Rows[i]["qid"].ToString();
            str[i + qnu, 0] = "detailQuestion.aspx?" + qid;
            str[i + qnu, 1] = "回答: " + getquestiontitle(qid);
            str[i + qnu, 2] = ads.Tables["t"].Rows[i]["adetial"].ToString();
            str[i + qnu, 3] = Convert.ToDateTime(ads.Tables["t"].Rows[i]["datatime"]).ToString("yyyyMMdd");
        }



        int[,] array = new int[qnu + anu, 2];
        for (int i = 0; i < qnu + anu; i++)
        {
            array[i, 0] = i;
            array[i, 1] = int.Parse(str[i, 3]);
        }

        //sort
        sort(array);

        String strleft = "";
        String strright = "";
        for (int i = 0; i < qnu + anu; i++)
        {
            int j = array[i, 0];
           
            str[j, 3] = str[j, 3].Substring(0, 4) + "/" + str[j, 3].Substring(4, 2) + "/" + str[j, 3].Substring(6, 2);
            if (i % 2 == 0)
            {
                strleft += block(str[j, 0], str[j, 1], str[j, 2], str[j, 3], true);
            }
            else
            {
                strright += block(str[j, 0], str[j, 1], str[j, 2], str[j, 3], false);
            }
        }



        about_left.InnerHtml = strleft;
        about_right.InnerHtml = strright;

        personalmsg.Style["display"] = "none";

    }

    private String block(String qhref, String qtext, String antext, String qdate, bool isleft)
    {
        String left = "<div class=\"future_projects\"> <img src=\"images/toltip_left.png\" alt=\"\" class=\"toltip_left\" /><h3><a href=\"$arr[0]\">$arr[1]</a></h3><p>$arr[2]</p><em>$arr[3]</em> </div>";
        String right = "<div class=\"implantation_first\"> <img src=\"images/toltip_right.png\" alt=\"\" class=\"toltip_right\" /><h3><a href=\"$arr[0]\">$arr[1]</a></h3><p>$arr[2]</p><em>$arr[3]</em> </div>";
        StringBuilder sb;
        if (isleft)
        {
            sb = new StringBuilder(left);
        }
        else
        {
            sb = new StringBuilder(right);
        }

        String[] format = { qhref, qtext, antext, qdate };
        for (int i = 0; i < format.Length; i++)
        {
            sb.Replace("$arr[" + i + "]", format[i]);
        }
        length += 132;
        drop_title.Style["height"] = length + "px";
        return sb.ToString();
    }

    private String getquestiontitle(String qid)
    {
        String qs = "select * from TQuestion where id = " + qid;
        DataSet qds = sql.sqlsearch(qs);

        if (qds.Tables["t"].Rows.Count > 0)
        {
            return qds.Tables["t"].Rows[0]["qtitle"].ToString();
        }
        return "";
    }

    protected void provebt_Click(object sender, EventArgs e)
    {
        String pas = pwd.Text;
        String sqlse = "select * from TUser where username = '" + user + "'";
        DataSet ds = sql.sqlsearch(sqlse);

        if (ds.Tables["t"].Rows.Count > 0)
        {
            if (ds.Tables["t"].Rows[0]["password"].ToString() == pas)
            {
                String u = MD5Password.Encrypt(ds.Tables["t"].Rows[0]["email"].ToString());
                Response.Redirect("change.aspx?" + u);
            }
            else
            {
                Response.Write(" <script type='text/javascript'>alert('密码错误!!!')</script>");
                return;
            }
        }
        else
        {
            Response.Write("<scrpit>alert('您的身份存在问题!!')</scrpit>");
            Response.Redirect("cancel.aspx");
        }

    }


    static void sort(int[,] arr)
    {
        QuickSortRelax(arr, 0, arr.Length / 2 - 1 , 2);
    }


    static void QuickSortRelax(int[,] data, int low, int high, int colum)
    {
        if (low >= high)
        {
            return;
        }
        int temp = data[((low + high) / 2), (colum - 1)];
        int i = low - 1, j = high + 1;
        while (true)
        {
            while (data[++i, (colum - 1)] > temp) ;
            while (data[--j, (colum - 1)] < temp) ;
            if (i >= j)
            {
                break;
            }
            swap(data, i, j, colum);
        }
        QuickSortRelax(data, j + 1, high, colum);
        QuickSortRelax(data, low, i - 1, colum);
    }
    static void swap(int[,] data, int i, int j, int colum)
    {
        for (int k = 0; k < colum; k++)
        {
            int temp = data[j, k];
            data[j, k] = data[i, k];
            data[i, k] = temp;
        }

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        provepwd.Style["display"] = "block";
    }
    protected void update_Click(object sender, EventArgs e)
    {
        string str = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        string fileName = str;
        string fullFileName = user_img.PostedFile.FileName;
        string fileType = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
        if (fileType == "jpg" || fileType == "png" || fileType == "bmp" || fileType == "gif")
        {
            this.user_img.PostedFile.SaveAs(Server.MapPath("images") + "\\" + fileName + "." + fileType);
            this.show_img.ImageUrl = "images/" + fileName + "." + fileType;

            String updatestr = "update TUser set head = '" + this.show_img.ImageUrl + "' where username = '" + user + "'";

            sql.sqlinsert(updatestr);

        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('图片格式不正确，请重新选择');</script>");
        }
    }
}