using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using AspxOn.Search.FenLei;
using System.IO;
using SharpICTCLAS;
using System.Data;

public partial class search : System.Web.UI.Page
{
    String url = HttpContext.Current.Request.Url.ToString();
    MySql sql = new MySql();
    DataSet allds;

    double yuzhi = 0.2;
    protected void Page_Load(object sender, EventArgs e)
    {
        String user = StaticVariable.cookie.cookieisequal();
        if (user != "")
        {
            login.Style["display"] = "none";
            logined.Style["display"] = "block";
            loguser.InnerText = user;
        }

        if (url.IndexOf( "?" ) == -1)
        {
            return;
        }

        String key = Regex.Replace(url, "^[\\d\\D]*?\\?", "");

        int[] colarray;
        if (key != "")
        {
            colarray = getdata(key);
        }
        else
        {
            colarray = null;
        }
        if (colarray[0] == -1 || colarray == null)
        {
            tishi.InnerHtml = "抱歉:没有找到有关" + key + "的问题,请修改后继续查找,或者您也可以选择</br><a href='askquestion.aspx?" + key + "'>我要提问</a>";
        }

        //for (int i = 0; i < colarray.Length; i++)
        //{
        //    Response.Write(colarray[i] + "<br>");
        //}

        DataTable table = new DataTable(); //Create a new Table
        createquestiontable(table, allds, colarray);
        GridView1.DataSource = table;
        GridView1.DataBind();

        String searchanswer = "";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            String qid = table.Rows[i]["id"].ToString();
            ((LinkButton)GridView1.Rows[i].FindControl("question")).PostBackUrl = "detailquestion.aspx?" + qid;

            searchanswer = "";
            if (table.Rows[i]["keyanswerid"].ToString() == "")
            {
                searchanswer = "select adetial from TAnswer where qid = " + qid + "order by score desc";
            }
            else
            {
                searchanswer = "select adetial from TAnswer where id = " + table.Rows[i]["keyanswerid"].ToString();
            }

            if (searchanswer == "")
            {
                return;
            }
            else
            {
                DataSet temp = sql.sqlsearch(searchanswer);
                if (temp.Tables["t"].Rows.Count > 0)
                {
                    ((Label)GridView1.Rows[i].FindControl("answer1")).Text = temp.Tables["t"].Rows[0]["adetial"].ToString();
                }
            }

        }
        if (searchtb.Text == "")
        {
            searchtb.Text = key;
        }

    }

    private int[] getdata(string key)
    {
        SVMModle svm = new SVMModle();
        string DictPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "Data") + Path.DirectorySeparatorChar;
        // Console.WriteLine("正在初始化字典库，请稍候");
        WordSegment wordSegment = new WordSegment();
        ICTCLASAnalyzer a = new ICTCLASAnalyzer();
        wordSegment.InitWordSegment(DictPath);

        string terms = ChineseSpliter.Split(key, "|", a, wordSegment); //中文分词处理（分词结果可能包含停用词）
        if (terms == "")
        {
            terms = key;
        }
        List<ClassifyResult> crs = new List<ClassifyResult>(); //分类结果

        String selectall = "select * from TQuestion where id >= 0";
        allds = sql.sqlsearch(selectall);
        int len = allds.Tables["t"].Rows.Count;
        ClassifyResult[] cr = new ClassifyResult[len];

        for (int i = 0; i < len; i++)
        {
            cr[i] = new ClassifyResult();
            cr[i].id = allds.Tables["t"].Rows[i]["id"].ToString();
            cr[i].keyanswerid = allds.Tables["t"].Rows[i]["keyanswerid"].ToString();
            cr[i].keytext = allds.Tables["t"].Rows[i]["keytext"].ToString();
            cr[i].rownu = i;
            cr[i].probability = svm.Similarity(terms, cr[i].keytext);
            if (cr[i].keyanswerid == "")
            {
                cr[i].probability *= 0.7;
            }
        }
        int[] rownu = new int[len];
        sort(cr);
        for (int i = 0; i < len; i++)
        {
            rownu[i] = -1;
        }

        // string[] text2 = tdm.getText(Ci);
        for (int i = 0; i < len; i++)
        {
            if (cr[i].probability < yuzhi)
            {
                if (i < 10)
                {
                    yuzhi -= 0.01;
                }
                else
                {
                    break;
                }


            }
            rownu[i] = cr[i].rownu;
            //Response.Write(cr[i].probability+"\n");



        }
        return rownu;
    }

    private void sort(ClassifyResult[] cr)
    {

        QuickSortRelax(cr, 0, cr.Length - 1 );
    }

    static void QuickSortRelax(ClassifyResult[] data, int low, int high)
    {
        if (low >= high)
        {
            return;
        }
        double temp = data[(low + high) / 2].probability;
        int i = low - 1, j = high + 1;
        while (true)
        {
            while (data[++i].probability > temp) ;
            while (data[--j].probability < temp) ;
            if (i >= j)
            {
                break;
            }
            swap(data, i, j);
        }
        QuickSortRelax(data, j + 1, high);
        QuickSortRelax(data, low, i - 1);
    }
    static void swap(ClassifyResult[] data, int i, int j)
    {
        ClassifyResult temp = data[i];
        data[i] = data[j];
        data[j] = temp;
    }
    protected void searchbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("search.aspx?" + searchtb.Text);
    }

    protected void updateq_Click(object sender, EventArgs e)
    {
        Response.Redirect("askquestion.aspx?" + searchtb.Text);
    }

    private void createquestiontable(DataTable table, DataSet ds, int[] colarray)
    {
        DataColumn colId = new DataColumn("Id", System.Type.GetType("System.Int32"));//ID
        DataColumn colqtitle = new DataColumn("qtitle", System.Type.GetType("System.String"));//名称
        DataColumn coluserid = new DataColumn("userid", System.Type.GetType("System.Int32"));//qid
        DataColumn coldatatime = new DataColumn("datatime", System.Type.GetType("System.String"));
        DataColumn colkeyanswerid = new DataColumn("keyanswerid", System.Type.GetType("System.Int32"));//agree
        DataColumn colreportnum = new DataColumn("reportnum", System.Type.GetType("System.String"));
        DataColumn colkeytext = new DataColumn("otherkeytext", System.Type.GetType("System.String"));

        table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };
        table.Columns.AddRange(new DataColumn[] { colId, colqtitle, coluserid, coldatatime, colkeyanswerid, colreportnum, colkeytext });


        //Add a line of data
        for (int i = 0; i < colarray.Length&&i<5; i++)
        {
            if (colarray[i] < 0)
            {
                break;
            }
            DataRow row = table.NewRow();
            row[colId] = int.Parse(ds.Tables["t"].Rows[colarray[i]]["id"].ToString());
            row[colqtitle] = ds.Tables["t"].Rows[colarray[i]]["qtitle"].ToString();
            row[coluserid] = int.Parse(ds.Tables["t"].Rows[colarray[i]]["userid"].ToString());
            row[coldatatime] = Convert.ToDateTime(ds.Tables["t"].Rows[colarray[i]]["datatime"]).ToString("yyyy-MM-dd");
            row[colkeyanswerid] = int.Parse(ds.Tables["t"].Rows[colarray[i]]["keyanswerid"].ToString());
            row[colreportnum] = ds.Tables["t"].Rows[colarray[i]]["reportnum"].ToString();
            row[colkeytext] = ds.Tables["t"].Rows[colarray[i]]["keytext"].ToString();
            table.Rows.Add(row);
        }
    }

}