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
        public static string createCard(Card player, clubColour clr, Element els)
        {
            //create card
            string card = "<div class='card' >";
            card += "<div class='card__inner'>";



            //front
            card += "<div class='card__face card__face--front' style='background-color:" + clr.mcolour + "'>";

            //create Rating text
            card += "<div class='rating'><p>" + player.rating + "</p></div>";

            //add gradient
            card += "<div class='gradient' style='background: linear-gradient(0deg, " + clr.mcolour + " 0%, " + clr.mcolour + "CC 60%," + clr.mcolour + "00 100%);'></div>";

            //add player img
            card += "<img class='player' src='" + player.img + "'>";

            //add badge
            card += "<div class='badgecont'>";
            card += "<img class='Cbadge' src='images/badges/" + player.club + ".png'>";
            card += "</div>";

            //add name
            card += "<div class='namecont'>";
            string[] namesplit = player.name.Split(' ');
            try { card += "<p class='fname'>" + namesplit[namesplit.Length - 2] + "</p>"; } catch { card += "<p class='fname' style='visibility: hidden;'>aa</p>"; }
            card += "<p class='lname' style='color:" + clr.scolour + "'>" + namesplit[namesplit.Length - 1] + "</p>";
            card += "</div>";


            card += "</div>";


            //back of card
            card += "<div class='card__face card__face--back' style='background-color:" + clr.mcolour + "'>";
            card += "<div class='mins'><p style='color:" + clr.scolour + "'>Minutes: " + els.minutes + "</p></div>";
            if (player.pos != "Goalkeeper")
            {
                card += "<div class='goals'><p style='color:" + clr.scolour + "'>Goals scored: " + els.goals_scored + "</p></div>";
                card += "<div class='assits'><p style='color:" + clr.scolour + "'>Assits: " + els.assists + "</p></div>";
                
            }
            else
            {
                card += "<div class='saves'><p style='color:" + clr.scolour + "'>saves: " + els.saves + "</p></div>";
                card += "<div class='cleansheet'><p style='color:" + clr.scolour + "'>clean sheet: " + els.clean_sheets + "</p></div>";
                card += "<div class='yellow'><p style='color:" + clr.scolour + "'>yellow cards: " + els.yellow_cards + "</p></div>";
                card += "<div class='red'><p style='color:" + clr.scolour + "'>red cards: " + els.red_cards + "</p></div>";
            }
            card += "</div>";


            //end
            card += "</div>";
            card += "</div>";
            
           

            return card;
        }
        public static string createClubPrec(string[] a, int curnum, clubColour clr)
        {

            string stylecalc = "stroke-dashoffset:calc(440 - (440 * "+ (100 * curnum)/ Convert.ToInt32(a[1]) + ") / 100); stroke:"+clr.mcolour;


            string club = "<div class='precent'>";
            club += "<svg>";
            club += "<circle style='"+stylecalc+"' cx='70' cy='70' r='70'></circle>";
            club += "<circle style='" + stylecalc + "' cx='70' cy='70' r='70'></circle>";
            club += "</svg>";
            club += "<div class='clubbdg'>";
            club+= "<img src='images/badges/" + a[0] + ".png'>";
            club += "</div>";
            club += "</div>";
            club += "<h2>"+ (100 * curnum) / Convert.ToInt32(a[1]) + "%</h2>";


            return club;
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
            fixture += "<img src='images/badges/" + homeT + ".png'>";
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
            fixture += "<img src='images/badges/" + awayT + ".png'>";
            fixture += "</div>";

            fixture += "</div>";
            return fixture;
        }
    }
}
