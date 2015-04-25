using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// sqlsearch 返回dataset
/// sqlinsert 执行操作
/// </summary>
public class MySql
{
    String constr = StaticVariable.connstr;
    public MySql()
    {
    }

    /// <summary>
    /// 返回 表名为 t
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    public DataSet sqlsearch(string search)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(search, con);
        DataSet ds = new DataSet();
        con.Close();
        da.Fill(ds, "t");
        return ds;
    }

    public void sqlinsert(string insert)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand(insert, con);					//创建执行
        cmd.ExecuteNonQuery();										//执行SQL
        con.Close();
    }

    //UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";
}