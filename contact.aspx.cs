using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
    Cookie cookie = new Cookie();
    protected void Page_Load(object sender, EventArgs e)
    {
        String user = cookie.cookieisequal();
        if (user != "")
        {
            login.Style["display"] = "none";
            logined.Style["display"] = "block";
            loguser.InnerText = user;
        }
    }
   
}