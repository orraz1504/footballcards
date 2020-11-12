﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    public string error;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            Response.Redirect("~/index.aspx");
        }
        if (IsPostBack)
        {
            string username = Request.Form["username"];
            string password = Request.Form["pass"];
            if (userFunction.isUsername(username) && userFunction.checkPassword(username) == password)
            {
                Session["username"] = username;
                Response.Redirect("~/index.aspx");
            }
            else
            {
                error = "invaild username or password";
            }
        }
    }
}