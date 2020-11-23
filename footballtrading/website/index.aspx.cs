using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    public string username;
    protected void Page_Load(object sender, EventArgs e)
    {
        username = Session["username"].ToString();
    }

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Redirect("~/Login.aspx");
    }
}