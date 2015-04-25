using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AspxOn.Search.FenLei;
using System.IO;
using SharpICTCLAS;


/// <summary>
/// StaticVariable 的摘要说明
/// </summary>
public class StaticVariable
{
    public StaticVariable()
    {
    }

    public static string connstr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\BigData.mdf;Integrated Security=True";	//连接字符串
    public static Cookie cookie = new Cookie();//创建cookie

    public static Boolean istablehad(DataSet ds)
    {
        if (ds.Tables["t"].Rows.Count > 0)
        {
            return true;
        }

        return false;
    }

    public static String qanda(String qid)
    {
        MySql sql = new MySql();
        String qsearch = "select * from TQuestion where id = " + qid;
        DataSet ds = sql.sqlsearch(qsearch);
        if (!istablehad(ds))
        {
            return "";
        }

        String qtitle = ds.Tables["t"].Rows[0]["qtitle"].ToString();
        String keyid = ds.Tables["t"].Rows[0]["keyanswerid"].ToString();
        if (keyid=="-1")
        {
            return qtitle;
        }
        String asearch = "select * from TAnswer where id = " + keyid;
        DataSet da = sql.sqlsearch(asearch);

        if (!istablehad(da))
        {
            return qtitle;
        }

        String keyanswer = da.Tables["t"].Rows[0]["adetial"].ToString();

        return qtitle + keyanswer;
    }

    public static void charu(String qid, String key)
    {
        MySql sql = new MySql();
        String qsearch = "update TQuestion set keytext = N'" + key + "' where id = " + qid;
        sql.sqlinsert(qsearch);
    }

    public static void updatekey(int i)
    {
        string DictPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "Data") + Path.DirectorySeparatorChar;
        // Console.WriteLine("正在初始化字典库，请稍候");
        WordSegment wordSegment = new WordSegment();
        wordSegment.InitWordSegment(DictPath);
        ICTCLASAnalyzer a = new ICTCLASAnalyzer();
        string s = "";
        string t = "";
        //StaticVariable.charu(2 + "", "4564");
       
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