using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using AspxOn.Search.FenLei;
using System.IO;
using SharpICTCLAS;
public partial class _Default : System.Web.UI.Page
{
    Cookie cookie = new Cookie();
    MySql sql = new MySql();

    protected void Page_Load(object sender, EventArgs e)
    {
        String user = cookie.cookieisequal();
        if (user != "")
        {
            login.Style["display"] = "none";
            logined.Style["display"] = "block";
            loguser.InnerText = user;
        }

        int nu = 0;
        for (int i = 0; i < 5; i++)
        {
            DataSet ds = get(nu);
            if (StaticVariable.istablehad(ds))
            {
                String url = Regex.Replace(HttpContext.Current.Request.Url.ToString(), "Default.aspx[\\d\\D]*", "");

                ((LinkButton)GridView1.Rows[i].FindControl("question")).Text = ds.Tables["t"].Rows[0]["qtitle"].ToString();
                ((LinkButton)GridView1.Rows[i].FindControl("question")).PostBackUrl = url + "detailQuestion.aspx?" + nu;

                ((Label)GridView1.Rows[i].FindControl("date")).Text = Convert.ToDateTime(ds.Tables["t"].Rows[0]["datatime"].ToString()).ToShortDateString();

                ((Label)GridView1.Rows[i].FindControl("answer1")).Text = answer(nu);
            }
            else
            {
                i--;
            }

            nu++;
        }
       
        
           
        

     


    }

    private DataSet get(int id)
    {
        MySql sql = new MySql();
        String str = "select * from TQuestion where id = " + id;
        return sql.sqlsearch(str);
    }

    private String answer(int id)
    {
        MySql sql = new MySql();
        String str = "select * from TAnswer where qid = " + id;
        DataSet ds = sql.sqlsearch(str);

        if (StaticVariable.istablehad(ds))
        {
            return ds.Tables["t"].Rows[0]["adetial"].ToString();
        }
        return "等待你来回答哦~~";
    }



    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    private void updatekey()
    {
        string DictPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "Data") + Path.DirectorySeparatorChar;
        // Console.WriteLine("正在初始化字典库，请稍候");
        WordSegment wordSegment = new WordSegment();
        wordSegment.InitWordSegment(DictPath);
        ICTCLASAnalyzer a = new ICTCLASAnalyzer();
        string s = "";
        string t = "";
        //StaticVariable.charu(2 + "", "4564");
        for (int i = 1; i <= 162; i++)
        {
            try
            {
                s = StaticVariable.qanda(i + "");
                // Response.Write(s);
                t = ChineseSpliter.Split(s, "|", a, wordSegment);
                StaticVariable.charu(i + "", t);
            }
            catch (System.Exception ex)
            {


            }

        }
    }
}