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
                cardfornew(username);
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                error = "Username already taken";
            }
        }
    }
    // the function creats card for new user
    private void cardfornew(string username)
    {
        Card player;
        Random rnd = new Random();
        int num = rnd.Next(1,100);
        if (num <= 90)
            player = CardFunctions.getByRating(0, 80);
        else
            player = CardFunctions.getByRating(80, 85);
        cardInv.Addplayer(username, player.id);
    }
}