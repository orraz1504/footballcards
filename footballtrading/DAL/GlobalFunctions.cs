using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.apiClases;
using DAL;
using System.Web.UI.WebControls;

namespace DAL
{
    public static class GlobalFunctions
    {
        public static string createCard(Card player, clubColour clr)
        {
            //create card
            string card = "<div class='card' style='background-color:" + clr.mcolour + "'>";

            //create Rating text
            card += "<div class='rating'><p>" + player.rating + "</p></div>";

            //add gradient
            card += "<div class='gradient' style='background: linear-gradient(0deg, "+ clr.mcolour +" 0%, " + clr.mcolour + "CC 60%," + clr.mcolour +"00 100%);'></div>";

            //add player img
            card += "<img class='player' src='"+ player.img +"'>";

            //add badge
            card += "<div class='badgecont'>";
            card += "<img class='Cbadge' src='testWhtml/images/badges/" + player.club + ".png'>";
            card += "</div>";

            //add name
            card += "<div class='namecont'>";
            string[] namesplit = player.name.Split(' ');
            try{card += "<p class='fname'>" + namesplit[namesplit.Length - 2] + "</p>";}catch {card+= "<p class='fname' style='visibility: hidden;'>aa</p>"; }
            card += "<p class='lname' style='color:"+clr.scolour+"'>" + namesplit[namesplit.Length - 1] + "</p>";
            card += "</div>";

            //end
            card += "</div>";
            return card;
        }
        public static string CreateGame(Root game, Dictionary<int,string> clubs)
        {
            //creating vairables
            string homeT = clubs[game.team_h];
            string awayT = clubs[game.team_a];

            DateTime time = game.kickoff_time ?? DateTime.Now.AddYears(-19999999);

            int? homeS = 0;
            if (game.team_h_score != null)
                homeS = game.team_h_score;
            int? awayS = 0;
            if (game.team_a_score != null)
                awayS = game.team_a_score;



            //create fixture
            string fixture = "<div class='row'>";

            fixture += "<div class='col - sm'>";
            fixture += "<img src='testWhtml/images/badges/" + homeT + ".png'>";
            fixture += "</div>";
            
            fixture += "<div class='col - sm'>";
            fixture += "<div class='row'>";
            fixture += "<div class='col - sm'>";
            fixture += "<p>"+ homeT + "</p>";
            fixture += "</div>";
            fixture += "<div class='col - sm'>";
            if (game.started == true)
            {
                fixture += "<p> (" + homeS + " - " + awayS + ") </p>";
            }
            else
            {
                fixture += "<p> "+ time.ToString("dddd, dd MMMM h:mm tt") +" </p>";
                fixture+= "<asp:Button runat='server' class='btn btn-primary' id='" + game.id + "' Text='bet' OnClick='bet_click' />";
            }
            fixture += "</div>";
            fixture += "<div class='col - sm'>";
            fixture += "<p>" + awayT + "</p>";
            fixture += "</div>";
            fixture += "</div>";
            fixture += "</div>";

            fixture += "<div class='col - sm'>";
            fixture += "<img src='testWhtml/images/badges/" + awayT + ".png'>";
            fixture += "</div>";

            fixture += "</div>";
            return fixture;
        }
    }
}
