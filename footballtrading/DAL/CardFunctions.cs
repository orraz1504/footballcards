using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CardFunctions
    {
        public static List<string[]> getByClub(string club)
        {
            List<string[]> ret = new List<string[]>();
            string com = "SELECT * FROM [card] where [club] = '" + club + "'";
            DataTable dt = oledbhelper.GetTable(com);
            foreach (DataRow row in dt.Rows)
            {
                int itmLength = row.ItemArray.Length;
                string[] mrow = new string[itmLength - 1];
                for (int i = 1; i < itmLength; i++)
                {
                    mrow[i - 1] = row.ItemArray[i].ToString();
                }
                ret.Add(mrow);
            }
            return ret;
        }
        public static string[] getByCardId(int Id)
        {
            string com = "SELECT * FROM [card] where [cardID] = " + Id;
            DataTable dt = oledbhelper.GetTable(com);
            int itmLength = dt.Rows[0].ItemArray.Length;
            string[] mrow = new string[itmLength - 1];
            for (int i = 1; i < itmLength; i++)
            {
                mrow[i - 1] = dt.Rows[0].ItemArray[i].ToString();
            }
            return mrow;
        }
    }
}
