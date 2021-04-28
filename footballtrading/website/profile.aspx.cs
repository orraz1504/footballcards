using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class profile : System.Web.UI.Page
{
    public string username;
    public string allUsers;
    protected void Page_Load(object sender, EventArgs e)
    {
        //only people logged in can use this page
        if (Session["username"] == null)
        {
            Response.Redirect("~/initPage.aspx");
        }
        username = Session["username"].ToString();

        if (userFunction.isAdmin(Session["username"].ToString()))
        {
            admin.Visible = true;
            allUsers = userFunction.GetUsers();
        }

        if (IsPostBack)
        {
            string postReason = Request.Form["submitter"];
            string postId = Request.Form["key"];
            if (postReason != null && postId != null && postId != "orez")
            {
                if (postReason.Equals("delete"))
                {
                    if (!userFunction.isAdmin(postId))
                    {
                        userFunction.Deleteuser(postId);
                        Response.Redirect(Request.RawUrl);
                    }
                }
                else if (postReason.Equals("admin"))
                {
                    System.Diagnostics.Debug.WriteLine("in admin");
                    userFunction.toggleAdmin(postId);
                    System.Threading.Thread.Sleep(500);
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }

    protected void pswdsub_Click(object sender, EventArgs e)
    {
        if (pswdtxt.Text.ToString() != "")
        {
            userFunction.UpdatePassword(Session["username"].ToString(), AesCryp.encrypt(pswdtxt.Text.ToString()));
            Response.Redirect(Request.RawUrl);
        }

    }

    protected void delbtn_Click(object sender, EventArgs e)
    {
        if (!userFunction.isAdmin(Session["username"].ToString()))
        {
            userFunction.Deleteuser(Session["username"].ToString());
            Session["username"] = null;
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Register.aspx");
        }
    }
}