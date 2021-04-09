using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class GameFunctions
    {
        public static List<prediction> byGameweek(int gameweek)
        {
            string com = "SELECT * FROM [game] where [gw] = '" + (gameweek) + "'";
            DataTable dt = oledbhelper.GetTable(com);
            List<prediction> ls = new List<prediction>();
            Console.WriteLine(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                ls.Add(new prediction(Convert.ToInt32(row.ItemArray[0].ToString()), Convert.ToInt32(row.ItemArray[1].ToString()), Convert.ToInt32(row.ItemArray[2].ToString())));
            }
            return ls;
        }
        public static void addPrecent(double hteam, double draw, double ateam, int gameID)
        {
            string com = "UPDATE game SET [hteamW] = " + Convert.ToInt32(hteam) + ", [draw] = " + Convert.ToInt32(draw) + ", [ateamW] =" + Convert.ToInt32(ateam) + " Where gameID = " + gameID;
            oledbhelper.Execute(com);
        }
        public static int getPrecentbyMatchID(int gameID, int isH)
        {
            string com = "SELECT * FROM [game] where [gameID] = " + gameID;
            DataTable dt = oledbhelper.GetTable(com);
            int[] ret = new int[3];
            ret[0] = Convert.ToInt32(dt.Rows[0].ItemArray[7]);
            ret[1] = Convert.ToInt32(dt.Rows[0].ItemArray[8]);
            ret[2] = Convert.ToInt32(dt.Rows[0].ItemArray[9]);
            return ret[isH];
        }

    }
}
