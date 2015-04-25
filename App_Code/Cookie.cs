using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

/// <summary>
/// qucookie()
/// zhuxiao()
/// </summary>
public class Cookie
{
    MySql sql = new MySql();
    public Cookie()
    {
    }

    public void xierucookie(String id, String name, String pas, String qx)
    {
        try
        {
            HttpCookie cookie = new HttpCookie("User");
            cookie.Value = id;
            cookie["name"] = name;
            cookie["quanxian"] = qx;//权限
            cookie["mima"] = MD5Password.Encrypt(pas);
            DateTime dtNow = DateTime.Now;
            TimeSpan tsMinute = new TimeSpan(30, 0, 0, 0);
            cookie.Expires = dtNow + tsMinute;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        catch (Exception)
        {
        }

    }

    /// <summary>
    /// 取出cookie的内容
    /// </summary>
    /// <param name="key">
    /// name:返回名字
    /// password:返回密码
    /// quanxian:返回权限
    /// user:id,name,password,quanxian
    /// </param>
    /// <returns></returns>
    public string qucookie(string key)
    {
        try
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
            string s = cookie.Value.ToString();
            String []strall = new String[4];
            string[] sArray = Regex.Split(s, "&", RegexOptions.IgnoreCase);

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    strall[0] = sArray[0];
                }
                else
                {
                    strall[i] = Regex.Split(sArray[i], "=", RegexOptions.IgnoreCase)[1];
                }
            }

            if (key == "id")
            {
                return strall[0];
            }
            else if (key == "name")
            {
                return strall[1];
            }
            else if (key == "password")
            {
                return strall[3];
            }
            else if (key == "quanxian")
            {
                return strall[2];
            }
            else if (key == "user")
            {
                return strall[0] + "," + strall[1] + "," + strall[2] + "," + strall[3];
            }
            else
            {
                return "";
            }
        }
        catch (Exception)
        {
            return "";
        }
    }

    public void zhuxiao()
    {
        try
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["User"];
            DateTime dtNow = DateTime.Now;
            cookie.Expires = dtNow;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        catch (Exception)
        {
        }
    }



    //public bool ishaduser(string user, string password)
    //{
    //    password = MD5Password.Decrypt(password);//解密  密码

    //    string search = "select * from TUser where username='" + user + "'";
    //    DataSet ds = sql.sqlsearch(search, "Table");
    //    if (ds.Tables["Table"].Rows.Count != 0 && ds.Tables["Table"].Rows[0]["password"].ToString() == password)
    //    {
    //        return true;
    //    }

    //    return false;
    //}

    public string cookieisequal()
    {
        string c = qucookie("user");
        string[] sArray = Regex.Split(c, ",", RegexOptions.IgnoreCase);

        if (sArray.Length == 4)
        {
            string id = sArray[0];
            string name = sArray[1];
            string mima = sArray[3];

            string check = "select * from TUser where id = " + id;
            DataSet ds = sql.sqlsearch(check);		//创建数据集
            if (StaticVariable.istablehad(ds))                      //判断同名
            {
                mima = MD5Password.Decrypt(mima);
                if (ds.Tables["t"].Rows[0]["password"].ToString() == mima)
                {
                    return name;
                }
            }
        }
        return "";
    }
}