using ASP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DAL;
using DAL.apiClases;
using gf = DAL.GlobalFunctions;
using System.Diagnostics;

public partial class cardDeck : System.Web.UI.Page
{
    public string carddeck;
    private List<Card> cards;
    private Dictionary<string, clubColour> clbclr;
    protected void Page_Load(object sender, EventArgs e)
    {
        createpacksforuser();
        saveB.Visible = false;
        clbclr = CardFunctions.getcolours();
    }
    // function creates all the pack for logged in user
    public void createpacksforuser()
    {
        List<int> packsFU = PackFunctions.packsByUsername(Session["username"].ToString());
        foreach (int PackId in packsFU)
        {
            Button b = new Button();
            b.Text = PackId.ToString();
            b.Click += new EventHandler(openPack_Click);
            b.CssClass = "btn btn-primary";
            PackPlaceHolder.Controls.Add(b);
        }
        if (PackPlaceHolder.Controls.Count == 0)
            carddeck = "<p>no packs available</p>";
    }

    // the function gets the rating and the card list and handesls the return if contains
    private Card cardByRating(List<Card> cards, int ratinglow, int ratinghigh)
    {
        Card player = CardFunctions.getByRating(ratinglow,ratinghigh);
        while (doesContain(cards, player.name))
        {
            player = CardFunctions.getByRating(ratinglow,ratinghigh);
        }
        return player;
    }

    //the function gets the current list of cards and a name of the next card and returns 
    //true if duplicaate and false if not.
    private bool doesContain(List<Card> cards, string name)
    {
        foreach (Card player in cards)
        {
            if (player.name == name)
                return true;
        }
        return false;
    }
    //function thats called when open packs is pressed
    protected void openPack_Click(object sender, EventArgs e)
    {
        int packID;
        try
        {
            packID = Convert.ToInt32(((Button)sender).Text);
            Debug.WriteLine(packID.ToString());
        }
        catch
        {
            packID = -1;
            Debug.WriteLine("Failed to find PACKID");
        }
        if (packID != -1)
        {
            #region chances
            int total = 0;
            string[] odds = PackFunctions.getByPackId(packID);
            int under80 = total + Convert.ToInt32(odds[1]);
            total += Convert.ToInt32(odds[1]);
            int under85 = total + Convert.ToInt32(odds[2]);
            total += Convert.ToInt32(odds[2]);
            int under90 = total + Convert.ToInt32(odds[3]);
            total += Convert.ToInt32(odds[3]);
            int under99 = total + Convert.ToInt32(odds[5]);
            total += Convert.ToInt32(odds[4]);
            int special = total + Convert.ToInt32(odds[4]);
            total += Convert.ToInt32(odds[5]);

            Debug.WriteLine(under80);
            Debug.WriteLine(under85);
            Debug.WriteLine(under90);
            Debug.WriteLine(under99);
            Debug.WriteLine(special);
            #endregion

            Random rnd = new Random();
            cards = new List<Card>();
            List<string> cid = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                int num = rnd.Next(100);
                if (num <= under80)
                {
                    Card card = cardByRating(cards, 0, 80);
                    cards.Add(card);
                    cid.Add(card.id.ToString());
                }
                else if (num > under80 && num <= under85)
                {
                    Card card = cardByRating(cards, 80, 85);
                    cards.Add(card);
                    cid.Add(card.id.ToString());
                }
                else if (num > under85 && num <= under90)
                {
                    Card card = cardByRating(cards, 85, 90);
                    cards.Add(card);
                    cid.Add(card.id.ToString());
                }
                else if (num > under90 && num <= under99)
                {
                    Card card = cardByRating(cards, 90, 99);
                    cards.Add(card);
                    cid.Add(card.id.ToString());
                }
                else
                {

                }
                Debug.WriteLine("num- " + num);
            }
            Debug.WriteLine("started with API");
            Dictionary<string, Element> dic = APICall.getListOfStats(cid);
            Debug.WriteLine("Done with API");
            foreach (Card player in cards.OrderByDescending(x => x.rating).ToList())
            {
                try
                {
                    carddeck += gf.createCard(player, clbclr[player.club], dic[player.id.ToString()]);
                }
                catch
                {
                    carddeck += gf.createCard(player, clbclr[player.club], new Element());
                }

                if (!cardInv.checkDuplicate(Session["username"].ToString(), player.id.ToString()))
                {
                    //cardInv.Addplayer(Session["username"].ToString(), player.id.ToString());//remooooove
                }
                Debug.WriteLine(player.id);
            }
            //PackFunctions.deletePack(Session["username"].ToString(), packID);//remooooove
            //PackPlaceHolder.Controls.Remove((Button)sender);//remooooove
            PackPlaceHolder.Visible = false;
            saveB.Visible = true;
        }
    }
    //function that runs when you want to save pack, saves to database. 
    protected void saveB_Click(object sender, EventArgs e)
    {
        PackPlaceHolder.Visible = true;
        saveB.Visible = false;
        carddeck = "";
        Debug.WriteLine("saved");
        if (PackPlaceHolder.Controls.Count == 0)
            carddeck = "<p>no packs available</p>";
    }
}