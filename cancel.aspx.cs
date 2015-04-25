using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cancel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string quanxian=StaticVariable.cookie.qucookie("quanxian");
        StaticVariable.cookie.zhuxiao();
        if (quanxian=="2")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
      
    }
}