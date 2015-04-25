using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;

public partial class change : System.Web.UI.Page
{
    MySql sql = new MySql();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (HttpContext.Current.Request.Url.ToString().IndexOf("?") == -1)
        {
            Response.Write("<script type='text/javascript'>alert('非法进入!!'); window.window.location.href = 'cancel.aspx'</script>");
            //Response.Redirect("cancel.aspx");
            return;
        }

        String email = Regex.Replace(HttpContext.Current.Request.Url.ToString(), "^[\\d\\D]*?\\?", "");

        try
        {
            email = MD5Password.Decrypt(email);
        }
        catch
        {
            email = "";
            Response.Write("<script type='text/javascript'>alert('非法进入!!');</script>");
            Response.Redirect("cancel.aspx");
        }


        String searchsql = "select * from TUser where email = '" + email + "'";
        DataSet ds = sql.sqlsearch(searchsql);
        if (!StaticVariable.istablehad(ds))
        {
            Response.Write("<script type='text/javascript'>alert('非法进入!!'); window.window.location.href = 'Default.aspx'</script>");
            Response.Redirect("cancel.aspx");
        }
        Email.Text = email;
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        String pwd = password.Text;
        String updatesql = "update TUser set password = '" + pwd + "' where email = '" + Email.Text + "'";
        sql.sqlinsert(updatesql);
        Response.Redirect("Default.aspx");
    }

}