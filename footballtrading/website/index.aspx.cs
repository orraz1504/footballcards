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
        if (Session["username"] == null)
        {
            Response.Redirect("~/initPage.aspx");
        }
        username = Session["username"].ToString();
    }

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("~/Login.aspx");
    }
}