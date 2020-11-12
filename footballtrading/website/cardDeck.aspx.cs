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
    private List<string[]> cards;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void printAllPlayersFromClub(string club)
    {
        //creating all players from club
        List<string[]> playerss = CardFunctions.getByClub(club);
        foreach (string[] player in playerss)
        {
            createCard(player);
        }
    }
    public void createCard(string[] player)
    {
        //create card
        string card = "<div class='card'>";

        //create top layer
        card += "<div class='top' style='background-image:url(\"testWhtml/images/" + player[7] + "-top.png\");'></div>";

        //add nation
        card+= "<div class='nation' style='background-image:url(\"testWhtml/flags/" + player[3] + ".png\");'></div>";

        //add stat and badge
        card += "<div class='pstat'><p>"+player[6]+ "</p><p>" + player[5] + "</p>";
        card += "<img src='testWhtml/images/badges/" + player[4]+".png'></div>";

        //add player name
        string[] namesplit = player[1].Split(' ');
        card += "<div class='pname'><p>" + namesplit[namesplit.Length - 1] + "</p></div>";

        //add player img
        card += "<div class='player' style='background-image:url(\""+player[2]+"\");'></div>";

        //end
        card += "</div>";
        carddeck += card;

    }

    // the function gets the rating and the card list and handesls the return if contains
    private string[] cardByRating(List<string[]> cards, int ratinglow, int ratinghigh)
    {
        string[] players = CardFunctions.getByRating(ratinglow,ratinghigh);
        while (doesContain(cards, players[0]))
        {
            players = CardFunctions.getByRating(ratinglow,ratinghigh);
        }
        return players;
    }

    //the function gets the current list of cards and a name of the next card and returns 
    //true if duplicaate and false if not.
    private bool doesContain(List<string[]> cards, string name)
    {
        foreach (string[] player in cards)
        {
            if (player.Contains(name))
                return true;
        }
        return false;
    }
    //function thats called when open packs is pressed
    protected void openPack_Click(object sender, EventArgs e)
    {
        string[] odds = PackFunctions.getByPackId(1);
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
        cards = new List<string[]>();
        for (int i = 0; i < 5; i++)
        {
            int num = rnd.Next(100);
            if (num <= under80)
            {
                string[] card = cardByRating(cards, 0 , 80);
                cards.Add(card);
            }
            else if (num > under80 && num <= under85)
            {
                string[] card = cardByRating(cards, 80 , 85);
                cards.Add(card);
            }
            else if (num > under85 && num <= under90)
            {
                string[] card = cardByRating(cards, 85 , 90);
                cards.Add(card);
            }
            else if (num > under90 && num <= under99)
            {
                string[] card = cardByRating(cards, 90, 99);
                cards.Add(card);
            }
            else
            {
                
            }
            Debug.WriteLine("num- " + num);
        }
        foreach (string[] player in cards.OrderByDescending(x => x[5]).ToList())
        {
            createCard(player);
            if (cardInv.checkDuplicate(Session["username"].ToString(), player[0]))
                Debug.WriteLine("Duplicate");
            else
                Debug.WriteLine("not Duplicate");
            Debug.WriteLine(player[0]);
        }
    }
}