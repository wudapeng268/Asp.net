using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;

public partial class ajax : System.Web.UI.Page
{
    MySql sql = new MySql();
    protected void Page_Load(object sender, EventArgs e)
    {
        String user = StaticVariable.cookie.cookieisequal();
        if (user == "")
        {
            Response.Write("没有登录 ,请登录后再操作");
            return;
        }


        String url = HttpContext.Current.Request.Url.ToString();
        if (url.IndexOf("?key") == -1)
        {
            Response.Write("ajax出现错误! 请返回给管理员");
            return;
        }

        //?key=dianzan&agree&1;

        String keystr = Regex.Replace(url, "[\\d\\D]*\\?key=", "");
        String []all = Regex.Split(keystr, "&");
        String key = all[0];
        if (key == "dianzan")
        {
            try
            {
                String which = all[1];
                String id = all[2];
                String hadsql = "select * from TAnswer where id =" + id;
                DataSet hadset = sql.sqlsearch(hadsql);
                String nu = hadset.Tables["t"].Rows[0][which].ToString();
                String insertsql = "update TAnswer set " + which + " = " + (int.Parse(nu) + 1) + " where id = " + id;
                sql.sqlinsert(insertsql);

                String nu2;
                int score = 0;
                if (which == "agree")
                {
                    nu2 = hadset.Tables["t"].Rows[0]["disagree"].ToString();
                    score = (int.Parse(nu) + 1) * 5 - int.Parse(nu2) * 3;
                }
                else
                {
                    nu2 = hadset.Tables["t"].Rows[0]["agree"].ToString();
                    score = int.Parse(nu2) * 5 - (int.Parse(nu) + 1) * 3;
                }

                if (score == 0)
                {
                    return;
                }

                String updateScore = "update TAnswer set score = " + score + "where id = " + id;
                sql.sqlinsert(updateScore);
            }
            catch
            {
                Response.Write("ajax出现错误! 请返回给管理员");
            }

        }






    }
}