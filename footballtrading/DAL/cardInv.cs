using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class cardInv
    {
        public static void Addplayer(string username, int cardId)
        {
            string com = "insert into [cardinventory] ([username],[cardID]) VALUES ('" + username + "' ," + cardId + ")";
            oledbhelper.Execute(com);
        }
        public static bool checkDuplicate(string username, int cardId)
        {
            string com = "SELECT [cardID] FROM [cardinventory] where [username] = '" + username+ "' AND [cardID] = "+cardId+"";
            DataTable dt = oledbhelper.GetTable(com);
            if (dt.Rows.Count <= 0)
                return false;
            return true;
        }
        public static string getAllcardId(string username)
        {
            string mrow = "";
            string com = "SELECT [cardID] FROM [cardinventory] where [username] = '" + username + "'";
            DataTable dt = oledbhelper.GetTable(com);
            int itmLength = dt.Rows.Count;
            for (int i = 0; i < itmLength; i++)
            {
                mrow += dt.Rows[i].ItemArray[0].ToString();
                if (i != itmLength - 1)
                    mrow += ",";
            }
            return mrow;
        }
    }
}
