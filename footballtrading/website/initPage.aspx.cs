using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class initPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null)
            {
                Session["username"] = Request.Cookies["UserName"].Value;
                Response.Redirect("~/index.aspx");
            }
        }
    }

    protected void StartButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Register.aspx");
    }
}