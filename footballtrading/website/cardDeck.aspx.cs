using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using DAL;
using DAL.apiClases;
using gf = DAL.GlobalFunctions;
using System.Web.UI.HtmlControls;

public partial class cardDeck : System.Web.UI.Page
{
    public string carddeck;
    private List<Card> allCards;
    private Dictionary<string, clubColour> clbclr;
    private Dictionary<string, Element> els;
    protected void Page_Load(object sender, EventArgs e) 
    {
        //only people logged in can use this page
        if (Session["username"] == null)
        {
            Response.Redirect("~/initPage.aspx");
        }
        start();
        showAll();
    }
    public void start()
    {

        allCards = new List<Card>();

        Debug.WriteLine("starting DB");
        string ids =cardInv.getAllcardId(Session["username"].ToString());
        Debug.WriteLine("done DB");
        Debug.WriteLine("starting DB2");
        allCards=CardFunctions.getALLByCardId("(" + ids + ")");
        allCards = allCards.OrderByDescending(o => Convert.ToInt32(o.rating)).ToList();


        List<string> ls = ids.Split(',').ToList();

        els = APICall.getListOfStats(ls);

        clbclr = CardFunctions.getcolours();
        Debug.WriteLine("done with start");

        bfix.Visible = true;
        afix.Visible = false;
    }
    public void showAll()
    {
        List<string[]> li = CardFunctions.getClubsTotal();
        foreach (string[] Club in li)
        {
            HtmlGenericControl all = new HtmlGenericControl("DIV");
            all.Attributes.Add("class", "bard");
            all.Style.Add("background-color", clbclr[Club[0]].scolour);
            bfix.Controls.Add(all);

            int howmany = count(Club[0]);

            HtmlGenericControl bbox = new HtmlGenericControl("DIV");
            bbox.Attributes.Add("class", "box");
            bbox.InnerHtml += gf.createClubPrec(Club, howmany, clbclr[Club[0]]);
            all.Controls.Add(bbox);

            Button b = new Button();
            b.Text= (100 * howmany) / Convert.ToInt32(Club[1]) + "%";
            b.Attributes["club"]= Club[0];
            b.Attributes.Add("class", "btn btn-primary");
            b.Attributes.Add("runat", "server");
            b.Click += clickedonclub;
            bbox.Controls.Add(b);
            
        }
    }
    public void clickedonclub(object sender, EventArgs e)
    {
        string clubname = ((Button)sender).Attributes["club"];
        carddeck = "";
        foreach (Card c in allCards)
        {
            if (c.club == clubname)
            {
                try
                {
                    carddeck += gf.createCard(c, clbclr[c.club], els[c.id.ToString()]);
                }
                catch
                {
                    carddeck += gf.createCard(c, clbclr[c.club], new Element());
                }
            }
        }
        bfix.Visible = false;
        afix.Visible = true;
    }
    public int count(string name)
    {
        int counter = 0;
        foreach (Card crd in allCards)
        {
            if (crd.club == name)
                counter++;
        }
        return counter;
    }

    protected void back_Click(object sender, EventArgs e)
    {
        carddeck += "";
        bfix.Visible = true;
        afix.Visible = false;
    }

}