using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
