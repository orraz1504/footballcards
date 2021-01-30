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

public partial class cardDeck : System.Web.UI.Page
{
    public string carddeck;
    private List<Card> allCards;
    private Dictionary<string, clubColour> clbclr;
    private Dictionary<string, Element> els;
    protected void Page_Load(object sender, EventArgs e) 
    {
        start();
        sortByRating();
    }
    public void start()
    {
        Debug.WriteLine("entered");
        frns.Attributes.Add("style", "display:none");
        nationS.Attributes.Add("style", "display:none");
        nationSub.Attributes.Add("style", "display:none");
        frcs.Attributes.Add("style", "display:none");
        clubS.Attributes.Add("style", "display:none");
        clubsub.Attributes.Add("style", "display:none");

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
    }
    //on change for select
    protected void sortselec_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sortselec.SelectedValue == "nation")
        {
            frns.Attributes["style"] = "display:inline-block;";
            nationS.Attributes["style"] = "display:inline-block;";
            nationSub.Attributes["style"] = "display:inline-block;";
        }
        else if (sortselec.SelectedValue == "club")
        {
            frcs.Attributes["style"] = "display:inline-block;";
            clubS.Attributes["style"] = "display:inline-block;";
            clubsub.Attributes["style"] = "display:inline-block;";
        }
        else if(sortselec.SelectedValue == "rating")
        {
            sortByRating();
        }
    }
    public void sortByRating()
    {
        carddeck = "";
        foreach (Card crd in allCards)
        {
            try
            {

                carddeck += gf.createCard(crd, clbclr[crd.club], els[crd.id.ToString()]);
            }
            catch
            {
                carddeck += gf.createCard(crd, clbclr[crd.club], new Element());
            }
        }
    }

    protected void nationSub_Click(object sender, EventArgs e)
    {
        carddeck = "";
        foreach (Card c in allCards)
        {
            if (c.country.ToUpper() == nationS.Text.ToUpper())
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
        nationS.Text = "";
        sortselec.ClearSelection();

    }

    protected void clubsub_Click(object sender, EventArgs e)
    {
        carddeck = "";
        foreach (Card c in allCards)
        {
            if (c.club.ToUpper() == clubS.Text.ToUpper())
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
        clubS.Text = "";
        sortselec.ClearSelection();
    }
}