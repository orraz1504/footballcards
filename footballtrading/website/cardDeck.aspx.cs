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
using System.Diagnostics;

public partial class cardDeck : System.Web.UI.Page
{
    public string carddeck;
    public string packs;
    private List<Card> cards;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    // function creates all the pack for logged in user
    public void createpacksforuser()
    {
        List<int> packs = PackFunctions.packsByUsername(Session["username"].ToString());
        foreach (int PackId in packs)
        {
            string btn = $"<asp:Button ID='openPack' Text='basicPack' Runat='Server' OnClick='openPack_Click' />";
            carddeck += btn;
        }
    }
    public void printAllPlayersFromClub(string club)
    {
        //creating all players from club
        List<Card> playerss = CardFunctions.getByClub(club);
        foreach (Card player in playerss)
        {
            createCard(player);
        }
    }
    public void createCard(Card player)
    {
        //create card
        string card = "<div class='card'>";

        //create top layer
        card += "<div class='top' style='background-image:url(\"testWhtml/images/" + player.type + "-top.png\");'></div>";

        //add nation
        card+= "<div class='nation' style='background-image:url(\"testWhtml/flags/" + player.country + ".png\");'></div>";

        //add stat and badge
        card += "<div class='pstat'><p>"+player.rating+ "</p><p>" + player.pos + "</p>";
        card += "<img src='testWhtml/images/badges/" + player.club+".png'></div>";

        //add player name
        string[] namesplit = player.name.Split(' ');
        card += "<div class='pname'><p>" + namesplit[namesplit.Length - 1] + "</p></div>";

        //add player img
        card += "<div class='player' style='background-image:url(\""+player.img+"\");'></div>";

        //end
        card += "</div>";
        carddeck += card;

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
            packID = 1;
            Debug.WriteLine("Failed to find PACKID");
        }
        string[] odds = PackFunctions.getByPackId(packID);
        int under80 = 100 - Convert.ToInt32(odds[1]);
        int under85 = 100 - Convert.ToInt32(odds[2]);
        int under90 = 100 - Convert.ToInt32(odds[3]);
        int under99 = 100 - Convert.ToInt32(odds[5]);
        int special = 100 - Convert.ToInt32(odds[4]);

        Debug.WriteLine(under80);
        Debug.WriteLine(under85);
        Debug.WriteLine(under90);
        Debug.WriteLine(under99);
        Debug.WriteLine(special);

        Random rnd = new Random();
        cards = new List<Card>();
        for (int i = 0; i < 5; i++)
        {
            int num = rnd.Next(100);
            if (num <= under80)
            {
                Card card = cardByRating(cards, 0 , 80);
                cards.Add(card);
            }
            else if (num > under80 && num <= under85)
            {
                Card card = cardByRating(cards, 80 , 85);
                cards.Add(card);
            }
            else if (num > under85 && num <= under90)
            {
                Card card = cardByRating(cards, 85 , 90);
                cards.Add(card);
            }
            else if (num > under90 && num <= under99)
            {
                Card card = cardByRating(cards, 90, 99);
                cards.Add(card);
            }
            else
            {
                
            }
            Debug.WriteLine("num- " + num);
        }
        foreach (Card player in cards.OrderByDescending(x => x.rating).ToList())
        {
            createCard(player);
            if (cardInv.checkDuplicate(Session["username"].ToString(), player.id.ToString()))
                Debug.WriteLine("Duplicate");
            else
                Debug.WriteLine("not Duplicate");
            Debug.WriteLine(player.id);
        }
    }
}