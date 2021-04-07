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
            string com = "SELECT * FROM [game] where [gw] = '" + (gameweek - 1) + "'";
            DataTable dt = oledbhelper.GetTable(com);
            List<prediction> ls = new List<prediction>();
            Console.WriteLine(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                ls.Add(new prediction(Convert.ToInt32(row.ItemArray[0].ToString()), Convert.ToInt32(row.ItemArray[1].ToString()), Convert.ToInt32(row.ItemArray[2].ToString())));
            }
            return ls;
        }

    }
}
