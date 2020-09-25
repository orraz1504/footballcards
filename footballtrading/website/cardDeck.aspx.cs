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

public partial class cardDeck : System.Web.UI.Page
{
    public string carddeck;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void printAllPlayersFromClub(string club)
    {
        //creating all players from club
        List<string[]> players = CardFunctions.getByClub(club);
        foreach (string[] player in players)
        {
            createCard(player);
        }
    }
    public void createCard(string[] player)
    {
        //create card
        string card = "<div class='card'>";

        //create top layer
        card += "<div class='top' style='background-image:url(\"testWhtml/images/" + player[6] + "-top.png\");'></div>";

        //add nation
        card+= "<div class='nation' style='background-image:url(\"testWhtml/flags/" + player[2] + ".png\");'></div>";

        //add stat and badge
        card += "<div class='pstat'><p>"+player[5]+ "</p><p>" + player[4] + "</p>";
        card += "<img src='testWhtml/images/badges/" + player[3]+".png'></div>";

        //add player name
        string[] namesplit = player[0].Split(' ');
        card += "<div class='pname'><p>" + namesplit[namesplit.Length - 1] + "</p></div>";

        //add player img
        card += "<div class='player' style='background-image:url(\""+player[1]+"\");'></div>";

        //end
        card += "</div>";
        carddeck += card;

    }

    protected void openPack_Click(object sender, EventArgs e)
    {
        Random rnd = new Random();
        //printAllPlayersFromClub("Manchester City");
        
        for (int i = 0; i < 5; i++)
        {
            int num = rnd.Next(100);
            if (num <= 30)
            {
                createCard(CardFunctions.getByCardId(1));
            }
            else if (num > 30 && num <= 50)
            {
                createCard(CardFunctions.getByCardId(2));
            }
            else if(num > 50 && num <=100)
            {
                createCard(CardFunctions.getByCardId(3));
            }
            System.Diagnostics.Debug.WriteLine("num- "+num);
        }
        
    }
}