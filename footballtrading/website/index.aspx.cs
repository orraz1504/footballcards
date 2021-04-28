using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.apiClases;

public partial class index : System.Web.UI.Page
{
    public string username;
    public string featured;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("~/initPage.aspx");
        }
        username = Session["username"].ToString();

        getFeatured();
    }
    public void getFeatured()
    {
        List<Card> allCards = new List<Card>();

        Debug.WriteLine("starting DB");
        string ids = cardInv.getAllcardId(Session["username"].ToString());
        Debug.WriteLine("done DB");
        Debug.WriteLine("starting DB2");
        allCards = CardFunctions.getALLByCardId("(" + ids + ")");
        allCards = allCards.OrderByDescending(o => Convert.ToInt32(o.rating)).ToList();


        List<string> ls = ids.Split(',').ToList();

        Dictionary<string, Element> els = APICall.getListOfStats(ls);

        Dictionary<string, clubColour> clbclr = CardFunctions.getcolours();

        featured = GlobalFunctions.createCard(allCards[0], clbclr[allCards[0].club], els[allCards[0].id.ToString()]);
    }

    protected void logOut_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("~/Login.aspx");
    }
}