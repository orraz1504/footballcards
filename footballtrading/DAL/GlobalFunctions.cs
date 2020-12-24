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
        public static string createCard(Card player)
        {
            //create card
            string card = "<div class='card'>";

            //create top layer
            card += "<div class='top' style='background-image:url(\"testWhtml/images/" + player.type + "-top.png\");'></div>";

            //add nation
            card += "<div class='nation' style='background-image:url(\"testWhtml/flags/" + player.country + ".png\");'></div>";

            //add stat and badge
            card += "<div class='pstat'><p>" + player.rating + "</p><p>" + player.pos + "</p>";
            card += "<img src='testWhtml/images/badges/" + player.club + ".png'></div>";

            //add player name
            string[] namesplit = player.name.Split(' ');
            card += "<div class='pname'><p>" + namesplit[namesplit.Length - 1] + "</p></div>";

            //add player img
            card += "<div class='player' style='background-image:url(\"" + player.img + "\");'></div>";

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
