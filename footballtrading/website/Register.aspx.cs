using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    public string error;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string username = Request.Form["username"];
            string password = Request.Form["pass"];
            if (!userFunction.isUsername(username))
            {
                userFunction.AddUser(username, password);
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                error = "Username already taken";
            }
        }
    }
}