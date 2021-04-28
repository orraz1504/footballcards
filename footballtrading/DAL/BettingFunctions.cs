using DAL.apiClases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class BettingFunctions
    {
        public static void AddBet(string username, int GameID, string winner, string score, string scorer)
        {
            string com = "insert into [bets] ([username],[GameID],[winner],[score],[scorer],[didClaim]) VALUES ('" + username + "' ," + GameID + " ,'" + winner + "' ,'" + score + "' ,'" + scorer + "', 0)";
            oledbhelper.Execute(com);
        }
        public static bool didBet(string username, int GameID)
        {
            string com = "SELECT [GameID] FROM [bets] where [username] = '" + username + "' AND [GameID] = " + GameID + "";
            DataTable dt = oledbhelper.GetTable(com);
            if (dt.Rows.Count <= 0)
                return false;
            return true;
        }
        public static void claimed(string username, int GameID)
        {
            string com = "UPDATE [bets] Set [didClaim] = 1 WHERE [username] = '" + username+ "' AND [GameID]= "+ GameID +"";
            oledbhelper.Execute(com);
        }
        public static List<Bet> getAllBets(string username)
        {
            string com = "SELECT * FROM [bets] where [username] = '" + username + "'";
            DataTable dt = oledbhelper.GetTable(com);
            int itmLength = dt.Rows.Count;
            List<Bet> lb = new List<Bet>();
            for (int i = 0; i < itmLength; i++)
            {
                Bet b = new Bet(dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dt.Rows[i].ItemArray[5].ToString(), Convert.ToInt32(dt.Rows[i].ItemArray[6]));
                lb.Add(b);
            }
            return lb;
        }
        public static List<Root> getAllGamestoPage(string gw)
        {
            string com = "SELECT * FROM [game] where [gw] = '" + gw + "'";
            DataTable dt = oledbhelper.GetTable(com);
            int itmLength = dt.Rows.Count;
            List<Root> lb = new List<Root>();
            for (int i = 0; i < itmLength; i++)
            {
                //CultureInfo provider = new CultureInfo("en_US");
                DateTime date = DateTime.ParseExact((dt.Rows[i].ItemArray[3]).ToString(), "EEEE, dd MMMM h:mm a", null); //provider);
                Root r = new Root();
                r.id = Convert.ToInt32((dt.Rows[i].ItemArray[0]).ToString());
                r.team_h = Convert.ToInt32((dt.Rows[i].ItemArray[1]).ToString());
                r.team_a = Convert.ToInt32((dt.Rows[i].ItemArray[2]).ToString());
                lb.Add(r);
            }
            return lb;
        }
    }
}
